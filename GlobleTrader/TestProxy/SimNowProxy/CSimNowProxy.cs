using HaiFeng;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestProxy
{
    public class MyCTPTrade : CTPTrade
    {
    }

    public class MyCTPQuote : CTPQuote
    {
    }

    public class CSimNowProxy : BaseProxy
    {
        //private Assembly ass = Assembly.LoadFrom("Proxy.dll");

        private MyCTPTrade m_trade = null;
        private MyCTPQuote m_quote = null;

        private string m_investor = string.Empty;
        private string m_password = string.Empty;
        public string m_authCode = string.Empty;
        public string m_appID = string.Empty;
        public string m_productInfo = string.Empty;
        public string m_broker = string.Empty;
        public string m_frontTradeAddr = string.Empty;
        public string m_frontQuoteAddr = string.Empty;

        public CSimNowProxy(PROXYTHROUGH proxyThrough)
        {
            this.m_proxyThroughEnum = proxyThrough;



        }

        /// <summary>
        /// 查询历史重载-可以直接调基类回调返回
        /// </summary>
        public override void QueryHistory(HistoryRequest hisData)
        {
   
        }

        public override void Init(LoginRequest loginData)
        {
            //传入外部参数，保存为全局，供其它部门查询，返回等调用
            //投资者 - 密码 - broker - autoCode - appId - productInfo - fronttradeAddr - frontQuoteAddr

            //Assembly ass1 = Assembly.LoadFrom("Proxy.dll");


            if (loginData == null || loginData.Exdata == string.Empty) return;

            string[] strArray = loginData.Exdata.Split('|');

            m_investor = strArray[0];
            m_password = strArray[1];
            m_broker = strArray[2];
            m_authCode = strArray[3];
            m_appID = strArray[4];
            m_productInfo = strArray[5];
            m_frontTradeAddr = strArray[6];
            m_frontQuoteAddr = strArray[7];

        }

        public override void Connect()
        {
        }

        public override void Login()
        {
            if (m_trade != null && m_trade.IsLogin) return; //已经登陆成功,返回.

            if (m_trade != null)
            {
                m_trade.ReqUserLogout();
                m_trade = null;
            }

            m_trade = new MyCTPTrade();

            m_trade.FrontAddr = m_frontTradeAddr;
            m_trade.Broker = m_broker;
            m_trade.Investor = m_investor;
            m_trade.Password = m_password;
            //SE新增-看穿式监管参数
            m_trade.ProductInfo = m_productInfo;
            m_trade.AppID = m_appID;
            m_trade.AuthCode = m_authCode;

            m_trade.OnFrontConnected += (snd, ea) =>
            {
                m_trade.ReqUserLogin();
            };
            m_trade.OnRspUserLogin += RspLogin;
            m_trade.OnRspUserLogout += RspLogout;
            m_trade.OnRtnOrder += OnOrder;
            m_trade.OnRtnTrade += OnTrade;
            m_trade.OnRtnErrOrder += OnErrOrder;
            m_trade.OnRtnNotice += OnNotice;

            m_trade.ReqConnect(); //Init调用
        }


        private  void RspLogin(object sender, ErrorEventArgs e)
        {

        }

        private  void RspLogout(object sender, IntEventArgs e)
        {

        }
        private void RtnError(object sender, ErrorEventArgs e)
        {

        }
        private void OnNotice(object sender, StringEventArgs e)
        {

        }
        private void RtnExchangeStatus(object sender, StatusEventArgs e)
        {

        }
        private void OnOrder(object sender, OrderArgs e)
        {

        }
        private void OnErrOrder(object sender, ErrOrderArgs e)
        {

        }
        private void OnTrade(object sender, TradeArgs e)
        {

        }

        protected override List<AccountData> QueryAccount()
        {
            //throw new NotImplementedException();
            return null;
        }

        protected override List<PositionData> QueryPosition()
        {
            //throw new NotImplementedException();
            return null;

        }

        protected override List<TradeData> QueryTrade()
        {
            //throw new NotImplementedException();
            return null;

        }

        protected override List<OrderData> QueryOrder()
        {
            //throw new NotImplementedException();
            return null;

        }

        public override bool QueryContract(ContractRequest cQ)
        {
            //对于tosahre来说，他们暂时没有维护一个COntract的列表，所以在这里，我们这样处理
            //收到查询合约的请求之后，主动去查一笔行情，如果能查回来，说明合约存在，加入到缓存和发布；
            return false;
        }

        public override void SendOrder(OrderRequest orderReq)
        {
            //throw new NotImplementedException();
        }

        public override void CancelOrder()
        {
            //throw new NotImplementedException();
        }

        public override void SendOrders()
        {
            //throw new NotImplementedException();
        }

        public override void CancelOrders()
        {
            //throw new NotImplementedException();
        }

        public override void SubScribe(SubscribeRequest sQ)
        {
            //throw new NotImplementedException();
        }

        public override void Close()
        {
            //throw new NotImplementedException();
        }

    }
}
