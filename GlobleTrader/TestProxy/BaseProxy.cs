/********************************************************************
	created:	2021/03/25
	author:		Hanyu	
	purpose:	Abstract Class
*********************************************************************/

//"""
//    Abstract Proxy class for creating gateways connection
//    to different trading systems.

//    # How to implement a gateway:

//    -- -
//## Basics
//    A Proxy should satisfies:
//    *this class should be thread-safe:
//        *all methods should be thread-safe
//        * no mutable shared properties between objects.
//    * all methods should be non-blocked
//    * satisfies all requirements written in Proxy for every method and callbacks.
//    * automatically reconnect if connection lost.

//    ---
//    ## methods must implements:
//    all @abstractmethod

//    ---
//    ## callbacks must response manually:
//    * on_tick
//    * on_trade
//    * on_order
//    * on_position
//    * on_account
//    * on_contract

//    All the XxxData passed to callback should be constant, which means that
//        the object should not be modified after passing to on_xxxx.
//    So if you use a cache to store reference of data, use copy.copy to create a new object
//    before passing that data into on_xxxx
//    抽象层业务适配器Abs
//
//    交易的抽象业务接口：
//    1.初始化 2.连接 3.登陆 4.查询(资金/委托/成交/持仓/基础信息/.) 5.交易(委托/撤单) 6.退出 7.日志打印

//    行情的抽象业务接口:
//    1.初始化 2.连接 3.登陆 4.查询(基础信息/.) 5.订阅行情 6.查历史行情 7.退出 8.日志打印

//    合并交易与行情的抽象层业务表示
//    1.初始化 2.连接 3.登陆 4.查询(资金/委托/成交/持仓/基础信息/.) 5.订阅行情 6.交易(委托/撤单/) 7.查询历史行情 8.退出 9.日志打印
//
//    回调业务上层抽象
//    1.初始化回调 2.连接回调 ............

//    业务调用总纲：
//    为了对于上层不暴露最基础每个接口的对应的的数据格式，统一每个接口在登陆后主动进行依次业务查询，并进行缓存 - 同时广播
//    上次业务需要查询的部分，就直接取每个接口基类的公共数据类型进行调用查询，暴露出公共数据类型，并订阅公共广播，这样的话
//    就摒弃了外部直接调用查询业务造成的数据类型泛化和特例化引起的适配混乱，造成业务无法继续维护。
//    那么剩下的就是一件事，就是定义出所有查询返回业务需要关心的数据结构，并在抽象基类中定义出来，由各个子类自己去实现和赋值
//    当然，对于资金-委托-成交-持仓查询，可以这么做，因为可以登陆时全部查询一边，有公有流推送，增量。但是，对于行情查询，合约
//    查询接口，就没有办法这么做。
//    另外对于登陆接口来说，之前是准备抽象所有接口为统一的一个登陆接口，且作为共同的数据结构，但是显然非常不可取，因为对接的接口
//    种类繁多，不同的登陆接口，有的是只需要链接，有的是需要IP-Port，有的是需要key等等，一种方法是规范所有传参为统一的接口扩充
//    字段的方式，一种是统一所有字段为一种数据格式，接口各自摘取自己感兴趣的字段进行拆解，但是无论两种中的哪种模式，都会造成接口字段
//    大量的冗余，导致膨胀，另外统一成统一的数据类型，也会造成传参释义模糊，所以在登陆上需要另外做处理，与其统一，不如分开，因为登陆
//    仅仅只需要一次操作，且C#所有数据类型共有基类为object，所以，可以传入自己的登陆结构体转为object，然后各自的接口各自转为各自的
//    登陆结构体。
//    操作类的接口也是一样，比如下单，查合约（因为有的市场比如IB，合约太多，所以不可能也按照登陆时一把插回来缓存，所以也得抽象公用接口）
//    和交易接口一样，这个是没有办法的。

//    后面也要思考一下，比如各个子类的配置文件的抽象，因为有的需要落地，然后启动配置，而不是需要每次重新填写，这个也需要抽象出来。
//    包括入库，持久化层.

//注意：对于查询，尤其是交易，还有这个历史数据查询，遇到一个问题，就是唯一定义的区别，多个窗口对象查询同一个历史数据，或者不同的历史数据，通过广播
//回来的数据，对于自己的窗口对象或者其他服务而言，没办法区分是不是自己对象发出去的请求的返回，因为完全有可能是其他对象发出去的请求的返回，所以，需要在
//这里，对于请求和响应做一个一一对应的关系，用于各自对象处理各自的业务。数据是纯数据，但是消息层面上，也需要有一个唯一的指定对应关系。
//这点在K线窗口查询历史数据上出现的问题，开多个窗口的时候，会请求多次数据，对于不同的proxy的返回，因为有窗口参数和bardata的合约对应过滤还好。但是对于
//同一个proxy里的，不同的合约，也还好，因为有symbol过滤，不同的周期也还好，因为有Interval过滤，但是对于开多个窗口，多个窗口是同一个proxy下,同一个合约
//和同一个数据周期，就没有办法过滤了，窗口OnBar就只能重复加载业务，典型的情况就是历史数据又加载了一遍的情况。所以历史数据查询这里，必须加一个，是哪个对象
//过来的查询，就返回给特定的对象进行过滤，独立处理，否则会重复处理.
//但是，为了不给接口不必要的参数，尤其是消息，可以这样处理，就是把所有的接口同步化，然后窗口等开启后，开启一个新的线程去主动查询，然后主动的查询的结果不对外
//发布，只是历史数据存在内存里。按照<hisRequest，Bardata>存放，然后在hisRequest里面增加requestID进行对应即可，目前暂时这个没解决，后面解决。
//【20200418】

//注意：
//对于历史数据查询，这里需要采用同步操作。- 同步操作直接返回，不采用广播全部通知，另外实时行情也需要历史数据推送完毕再增量叠加。

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProxy
{
    public abstract class BaseProxy
    {
        /// <summary>
        /// 行情是否已经登陆属性
        /// </summary>
        protected bool m_mdIsLogin = false;
        public bool IsMdLogin
        {
            get
            {
                return m_mdIsLogin;
            }
        }

        /// <summary>
        /// 交易是否登陆属性
        /// </summary>
        protected bool m_tdIsLogin = false;
        public bool IsTdLogin
        {
            get
            {
                return m_tdIsLogin;
            }
        }

        /// <summary>
        /// 交易是否登陆属性
        /// </summary>
        //protected Logi m_loginConfig = false;
        //public bool IsTdLogin
        //{
        //    get
        //    {
        //        return m_tdIsLogin;
        //    }
        //}

        /// <summary>
        /// 唯一的一笔请求 - 和响应相对应 - 用于前端对特定的对象的查询业务进行广播过滤 - 由外部调用方法进行自增传入
        /// </summary>
        protected int m_requestID = -1;
        public int CreateRequestID()
        {
            m_requestID = m_requestID + 1;
            return m_requestID;
        }

        //开启一个线程，转发API上层的请求，做流控等限制，比如req(Enum,Object),在这个线程里转发到底层API请求里进行请求;
        //开启一个新的线程，该线程主要用于捕获底层抛出的回调信息队列，用于上层转发；
        protected System.Threading.Thread m_OnSpiEventThread;
        protected System.Threading.Thread m_ReqEventThread;

        /// <summary>
        /// 代理名称
        /// </summary>
        protected PROXYTHROUGH m_proxyThroughEnum;
        public PROXYTHROUGH PROXYTHROUGH
        {
            get
            {
                return m_proxyThroughEnum;
            }

            set
            {
                m_proxyThroughEnum = value;
            }

        }

        /// <summary>
        /// 定义持仓缓存数据
        /// </summary>
        protected List<PositionData> m_positions = new List<PositionData>();
        public List<PositionData> Positions
        {
            get
            {
                return m_positions;
            }
        }

        /// <summary>
        /// 定义账户缓存数据
        /// </summary>
        protected List<AccountData> m_accounts = new List<AccountData>();
        public List<AccountData> AccountData
        {
            get
            {
                return m_accounts;
            }
        }

        /// <summary>
        /// 定义缓存合约数据
        /// </summary>
        protected List<ContractData> m_contracts = new List<ContractData>();
        public List<ContractData> ContractData
        {
            get
            {
                return m_contracts;
            }
        }

        /// <summary>
        /// 对外全部以事件形式广播，由于.net子类无法直接调用基类事件，
        /// 因此使用抽象函数指针强制重写，间接调用，供外部订阅
        /// </summary>
        public delegate void OnLoginHandle();
        public event OnLoginHandle OnLoginEvent;

        public delegate void OnTickHandle(List<TickData> tickD);
        public event OnTickHandle OnTickEvent;

        public delegate void OnBarHandle(List<BarData> tickD);
        public event OnBarHandle OnBarEvent;

        public delegate void OnTradeHandle(List<TradeData> tradeD);
        public event OnTradeHandle OnTradeEvent;

        public delegate void OnOrderHandle(List<OrderData> orderD);
        public event OnOrderHandle OnOrderEvent;

        public delegate void OnPositinHandle(List<PositionData> posiD);
        public event OnPositinHandle OnPositinEvent;

        public delegate void OnAccountHandle(List<AccountData> accD);
        public event OnAccountHandle OnAccountEvent;

        public delegate void OnContractHandle(List<ContractData> contD);
        public event OnContractHandle OnContractEvent;

        public delegate void OnLogHandle(LogData logD);
        public event OnLogHandle OnLogEvent;

        #region 抽象接口
        /// <summary>
        /// 行情交易公用
        /// </summary>
        public abstract void Init(LoginRequest loginData);
        public abstract void Connect();
        public abstract void Login();

        /// <summary>
        /// 交易
        /// </summary>
        protected abstract List<AccountData> QueryAccount();
        protected abstract List<PositionData> QueryPosition();
        protected abstract List<TradeData> QueryTrade();
        protected abstract List<OrderData> QueryOrder(); //子类私有实现，不对外暴露了，对外主要是通过推送事件 + 缓存属性暴露，主要是因为统一入参类型使用，防止过度入参适配，以上四个，全部在Init以及登陆之后统一处理
        public abstract bool QueryContract(ContractRequest cQ);
        public abstract void SendOrder(OrderRequest orderReq);
        public abstract void CancelOrder();
        public abstract void SendOrders();
        public abstract void CancelOrders();//交易 - 查询类，则必然面临对外暴露，因为合约太多，不可能每个数据源都登录之后一把查回来对外暴露内存，所以只能暴露。

        /// <summary>
        /// 行情
        /// </summary>
        public abstract void SubScribe(SubscribeRequest sQ); //任何对象一次订阅，所有对象都可以收到tick，对于tick可以自己过滤，因为是统一广播的，且不会重复
        public abstract void QueryHistory(HistoryRequest hisData);

        /// <summary>
        /// 交易与行情公用
        /// </summary>
        public abstract void Close();
        #endregion

        #region 抽象回调
        protected virtual void OnLogin()
        {
            if (this.OnLoginEvent != null) OnLoginEvent();
        }

        protected virtual void OnTick(List<TickData> tickD)
        {
            if (this.OnTickEvent != null) OnTickEvent(tickD);
        }

        protected virtual void OnBar(List<BarData> barD)
        {
            if (this.OnBarEvent != null) OnBarEvent(barD);
        }

        protected virtual void OnTrade(List<TradeData> tradeD)
        {
            if (this.OnTradeEvent != null) OnTradeEvent(tradeD);

        }

        protected virtual void OnOrder(List<OrderData> orderD)
        {
            if (this.OnOrderEvent != null) OnOrderEvent(orderD);

        }

        protected virtual void OnPosition(List<PositionData> posiD)
        {
            if (this.OnPositinEvent != null) OnPositinEvent(posiD);

        }

        protected virtual void OnAccount(List<AccountData> ac)
        {
            if (this.OnAccountEvent != null) OnAccountEvent(ac);

        }

        protected virtual void OnLog(LogData info)
        {
            if (this.OnLogEvent != null) OnLogEvent(info);

        }

        protected virtual void OnContract(List<ContractData> contD)
        {
            if (this.OnContractEvent != null) OnContractEvent(contD);

        }
        #endregion

    }
}
