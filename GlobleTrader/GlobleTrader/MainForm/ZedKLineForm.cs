//关于K线问题一：
//闪烁的问题，可以查看zedgraph原代码进行修改；

//关于K线问题二：
//关于动态K线的解决方案问题，

//关于K线问题三：
//用zedgraph做了一个历史曲线图，需求是取大量数据进行绘制，X轴是时间，Y轴是值。
//当我把X轴的类型设置为：
//pane.XAxis.Type = ZedGraph.AxisType.Date时，在我本地测试的时候没有出现问题，发给用户一段时间后，用户反应曲线没法看了，同一条曲线在界面中分成了多条曲线，也就是本来应该是一条曲线结果成了好多条，导致界面看起来乱七八糟。本来以为是数据出现问题，结果把用户数据拿到本地没发现数据有太大问题，后来考虑可能是zedgraph控件本身的问题，果断换到MSChart试了一下，同样的数据在MSChart下曲线完全正常，但是MSChart的数据实在太坑爹，没办法还要转到zedgraph上，后来试着把X轴的类型改成pane.XAxis.Type = ZedGraph.AxisType.DateAsOrdinal结果曲线也完全正常了。
//在此有几点疑问想请教：
// 1、Date和DateAsOrdinal有什么区别呢？
// 2、为什么我刚开始把X轴类型设置为Date的时候没有问题，一段时间之后数据量变大之后就出现问题了呢？
//（论坛不能发图，不然会更直观..）
//因此，使用 DateAsOrdinal 时，zedgraph帮你做了些自动处理。（Some X values are ignored.）
//比如有2个值
//A(2012-9-2,100) 
//B(2012 - 9 - 2, 99)
//如果是Date,A和B的X值一样，会显示在同一条竖线上。
//而如果是DateAsOrdinal,A和B会按照添加顺序依次显示。 - 如下所示，当换成Date的时候，融合在了一起，曲线没办法看了，换成ordinal后正常了。

//关于K线问题三：
//如何显示动态运行的K线问题：
//这里需要有一个开关，来标识是否有一笔新的合成K线的到来，来封闭tick的暂时加入，让新生成的完成加入之后，再把开关打开；
//1.（if m_isBarComing == false的时候）Ontick()开始的时候加入第一笔【1】;
//2.（if m_isBarComing == false的时候）OnTick()盘中修改各个开高低收，删掉前一笔，加入【2】，循环；
//3.OnBarMaker()最新的一笔14：51：00驱动产生一根新的K线(m_isBarComing == true)，删掉前一笔【2】加入的K线，加入，完成后(m_isBarComing == false)；
//之所以用上面的删增模式实现动态K线的问题，主要是因为，无法动态的去修改添加的K线或者曲线的点，所以只能暂时这么临时解决；

//关于K线问题四：
//重写了zedgraphControl的mousemove和mousedownevent，但是，发现就算设置了可拖拽属性，鼠标也无法拖拽图表了？
//于是去查看了zedgraphcontrol的源代码，在Event事件里发现了如下解释：
//很有意思，mousemove似乎是完全由用户掌控了，屏蔽了基类的mousemove事件，但是mousemoveevent可以通过返回true or false
//去决定是否在处理完自己的事情之后，交给基类继续处理，比如我们在这里面就把以前的Mousemove换成了mousemoveevent，并且都返回
//false，表示：Return false if ZedGraph should go ahead and process the MouseMove event.意思是交给基类继续处理，
//比如拖拽就是基类完成的，如果这里返回true,那么就表示完全掌控了，不会交给基类继续处理了，所以也就无法拖拽了。
//完工以后，可以再继续研读zedgraph的原代码

/// <summary>
/// Subscribe to this event to provide notification of MouseMove events over graph
/// objects
/// </summary>
/// <remarks>
/// This event provides for a notification when the mouse is moving over on the control.
/// The boolean value that you return from this handler determines whether
/// or not the <see cref="ZedGraphControl"/> will do any further handling of the
/// MouseMove event (see <see cref="ZedMouseEventHandler" />).  Return true if you
/// have handled the MouseMove event entirely, and you do not
/// want the <see cref="ZedGraphControl"/> to do any further action.
/// Return false if ZedGraph should go ahead and process the MouseMove event.
/// </remarks>
//[Bindable(true), Category("Events"),
// Description("Subscribe to be notified when the mouse is moved inside the control")]
//public event ZedMouseEventHandler MouseMoveEvent;

/// <summary>
/// Hide the standard control MouseMove event so that the ZedGraphControl.MouseMoveEvent
/// can be used.  This is so that the user must return true/false in order to indicate
/// whether or not we should respond to the event.
/// </summary>
//[Bindable(false), Browsable(false)]
//private new event MouseEventHandler MouseMove;


//类似于MC一样，TB等，打开一张K线图表，只需要设置相关的进即可。
//那么，需要哪些参数，就可以构成一张K线图的最基本的入参？名称，周期，K线类型？？
//必须进行分类，对象化
//那么对于名称，简称，数据源等，这个是包含在查询合约的最基本的contractData里面的。
//而对于需要订阅的数据，设置，比如，周期？开始时间？结束时间？是包含在subscribeRequst里面的。
//所以我们在双击打开一张K线图表的时候，其实就是构建两个对象，一个是这只票的最基础的信息
//contractData和订阅请求subscribeRequest请求，两个对象，作为这个K线图的获取数据以及后期处理的
//等等各种各样的最基础的入参。
//而对于之前一个版本，我们直接传入ticker,以及图表名称string,实际上，是没有做好共有抽象的结果，
//后面会造成大量的信息不对齐。而且不会在K线出中线底层的数据结构，上层的数据结构和数据类型全部是
//我们自己定义的数据类型，比如不会出现swap = OKExSDK.Models.Swap;的引用等。

//首先进来 -
//1.定义标题；
//2.初始化各类控件值
//3.同时 - 发布订阅请求(tick/bar但是订阅的一般都是TIck数据流) - 按照要求合成InterveK线从OnBar广播出来，Tick通过OnTick广播出来
//4.同时请求一波历史数据，历史数据从OnBar广播出来
//5.加载图表

//注意：实时推送的ontick数据（或者合成的interve数据）要求在历史数据查询完毕，并加载完毕之后再加载到图表上来
//注意：跨线程调用问题
//注意：对于订阅来说，订阅只是一个上层的行为，具体每一个接口如何处理是每个接口自己的事情。比如有的订阅实际上在接口里是需要安装定时器轮询的，
//注意：有的是直接订阅之后，接口回调推送到前台的，但是我们对外依旧只是暴露最原生的【订阅】这个动作，屏蔽掉各自内部的所有处理模式。
//注意：这个问题在之前的股票客户端和之前的数字货币客户端同样有遇到，就是订阅的公有流数据是非私有对象的，也就是说，如果再开一个相同的symbol
//注意：哪怕symbol是不相同的，因为我们是订阅的同一个数据源，当一个图表去主动请求回调的时候，会同时广播到其他对象中。但是这个问题在私有推送中是不存在的。
//注意：这个一定要务必注意。
//注意：这里存在一个有意思的是，对于同一个proxy，ObBar,Ontick主动查询类才会多个重复收到，但是不同proxy不会，因为走的是不同的proxy对象
//对于combox_datasource的buug,因为刚开始初始化了一次，问题在这里。
//另外一个隐形BUG就是双击之后，需要刷新K线才会出来，okex需要刷，但是tusahre不会，查一下原因，需要；

//注意：打开图表时候，要订阅所有proxy的账户响应，凡是有登陆的，都需要添加到图表的账户列表里，实现在不同的行情和交易之间穿透
//注意：同时添加上委托类型的枚举列表
//注意：账户是所有proxy的账户OnAccount的消息，但是其余的OnBar等，按照需要是订阅自己的Proxy的消息流；
//.....这里是有所区别的，所以不存在疑问，还需要在这里特地说明一下；

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TALibraryInCSharp;
using TestProxy;
using WeifenLuo.WinFormsUI.Docking;
using ZedGraph;
using TestService;

namespace WindowsFormsApp1
{
    public partial class ZedKLineForm : DockContent
    {
        /// <summary>
        /// 互斥锁-多线程同步问题
        /// </summary>
        private object m_mutxObj = new object();

        /// <summary>
        /// K线序列
        /// </summary>
        private JapaneseCandleStickItem m_myCurve;

        /// <summary>
        /// K线点序列
        /// </summary>
        private StockPointList m_splList = new StockPointList();

        /// <summary>
        /// 合约信息
        /// </summary>
        private ContractData m_contractData = new ContractData();

        /// <summary>
        /// 历史数据查询信息
        /// </summary>
        private HistoryRequest m_hisRequest = new HistoryRequest();

        /// <summary>
        /// K线合成服务
        /// </summary>
        private BarMakerService m_BarMakerService = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="cd"></param>
        /// <param name="hQ"></param>
        public ZedKLineForm(ContractData cd, HistoryRequest hQ)//合约i出信息
        {
            InitializeComponent();

            //初始化数据信息和历史请求信息
            m_contractData = cd;
            m_hisRequest = hQ;

            //初始化控件
            InitControls();

            //BTC永续合约 -K线图1.0 1Min Bar -AutoTrader标题需要标注的重点描述性对象
            this.Text = cd.Proxy.ToString() + " " + cd.Symbol + " " + hQ.Interval.ToString();
        }

        /// <summary>
        /// 初始化控件
        /// </summary>
        private void InitControls()
        {

            //////////////////////////////////////////////////////////////////////////
            string tagX = "X";
            m_xTextObj = new TextObj(tagX, 0, 0, CoordType.XScaleYChartFraction, AlignH.Left, AlignV.Center);
            m_xTextObj.FontSpec.Border.IsVisible = true;
            m_xTextObj.FontSpec.FontColor = Color.White;
            m_xTextObj.FontSpec.Fill.IsVisible = true;
            m_xTextObj.FontSpec.Fill.Color = System.Drawing.Color.DarkGray;
            m_xTextObj.FontSpec.Angle = 0;
            this.zedGraphControl1.GraphPane.GraphObjList.Add(m_xTextObj);

            string tagY = "Y";
            m_yTextObj = new TextObj(tagY, 0, 0, CoordType.XChartFractionYScale, AlignH.Left, AlignV.Center);
            m_yTextObj.FontSpec.Border.IsVisible = true;
            m_yTextObj.FontSpec.FontColor = Color.White;
            m_yTextObj.FontSpec.Fill.IsVisible = true;
            m_yTextObj.FontSpec.Fill.Color = System.Drawing.Color.DarkGray;
            m_yTextObj.FontSpec.Angle = 0;
            this.zedGraphControl1.GraphPane.GraphObjList.Add(m_yTextObj);

            //////////////////////////////////////////////////////////////////////////////
            this.zedGraphControl1.GraphPane.XAxis.MajorGrid.IsVisible = true;
            this.zedGraphControl1.GraphPane.YAxis.MajorGrid.IsVisible = true;
            this.zedGraphControl1.GraphPane.XAxis.MajorGrid.Color = Color.FromArgb(65, 65, 65);
            this.zedGraphControl1.GraphPane.YAxis.MajorGrid.Color = Color.FromArgb(65, 65, 65);

            this.zedGraphControl1.IsZoomOnMouseCenter = false;//使用滚轮时以鼠标所在点进行缩放还是以图形中心进行缩放  true为以鼠标所在点进行缩放

            this.zedGraphControl1.GraphPane.XAxis.Color = Color.Red;
            this.zedGraphControl1.GraphPane.YAxis.Color = Color.Red;

            this.zedGraphControl1.GraphPane.XAxis.Scale.FontSpec.FontColor = Color.White;
            this.zedGraphControl1.GraphPane.YAxis.Scale.FontSpec.FontColor = Color.White;

            //this.zedGraphControl1.GraphPane.XAxis.MajorGrid.Color = Color.Red;
            //this.zedGraphControl1.GraphPane.XAxis.MinorGrid.Color = Color.Red;

            this.zedGraphControl1.GraphPane.YAxis.MajorGrid.IsZeroLine = false;


            this.zedGraphControl1.GraphPane.XAxis.MajorTic.Color = Color.Red;
            this.zedGraphControl1.GraphPane.XAxis.MinorTic.Color = Color.Red;

            this.zedGraphControl1.GraphPane.YAxis.MajorTic.Color = Color.Red;
            this.zedGraphControl1.GraphPane.YAxis.MinorTic.Color = Color.Red;

            this.zedGraphControl1.GraphPane.Chart.Border.IsVisible = false;//首先设置边框为无
            this.zedGraphControl1.GraphPane.XAxis.MajorTic.IsOpposite = false;//然后设置X轴对面轴大间隔为无
            this.zedGraphControl1.GraphPane.XAxis.MinorTic.IsOpposite = false;//设置Y轴对面轴小间隔为无
            this.zedGraphControl1.GraphPane.YAxis.MajorTic.IsOpposite = false;//设置Y轴对面轴大间隔为无
            this.zedGraphControl1.GraphPane.YAxis.MinorTic.IsOpposite = false;//设置Y轴对面轴小间隔为无

            this.zedGraphControl1.GraphPane.XAxis.Type = AxisType.DateAsOrdinal;//为什么date不可以，这里的格式-见上面详细说明
            this.zedGraphControl1.GraphPane.XAxis.Scale.Format = "yyyy-MM-dd HH:mm";

            //this.zedGraphControl1.GraphPane.XAxis.Scale.MinorUnit = DateUnit.Minute;
            //this.zedGraphControl1.GraphPane.XAxis.Scale.MajorUnit = DateUnit.Hour;

            //this.zedGraphControl1.GraphPane.XAxis.Scale.MinAuto = true;
            //this.zedGraphControl1.GraphPane.XAxis.Scale.MajorStepAuto = true;
            //this.zedGraphControl1.GraphPane.XAxis.Scale.MaxAuto = true;

            this.zedGraphControl1.GraphPane.XAxis.CrossAuto = true;//容许x轴的自动放大或缩小
            this.zedGraphControl1.GraphPane.YAxis.CrossAuto = true;//容许y轴的自动放大或缩小
            this.zedGraphControl1.PanModifierKeys = Keys.None;//鼠标拖拽可移动

        }

        /// <summary>
        /// 窗口初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Load(object sender, EventArgs e)
        {
            //初始化图表 - 先添加一条空的曲线candle并设置好曲线
            GraphPane myPane = this.zedGraphControl1.GraphPane;
            myPane.Title.Text = "";
            myPane.XAxis.Title.Text = "";
            myPane.YAxis.Title.Text = "";
            StockPointList spl = new StockPointList();

            m_myCurve = myPane.AddJapaneseCandleStick("", spl);
            //中间那条细线的颜色
            m_myCurve.Stick.Color = Color.Orange;
            //当收盘价高于开盘价body的颜色
            m_myCurve.Stick.RisingFill = new Fill(Color.FromArgb(255, 0, 0));
            //当收盘价低于开盘价body的颜色
            m_myCurve.Stick.FallingFill = new Fill(Color.FromArgb(0, 254, 4));
            //当收盘价高于开盘价border的颜色
            m_myCurve.Stick.RisingBorder = new Border(Color.FromArgb(255, 0, 0), 1.0f);
            //当收盘价低于开盘价border的颜色
            m_myCurve.Stick.FallingBorder = new Border(Color.FromArgb(0, 254, 4), 1.0f);

            //myPane.XAxis.Type=AxisType.DateAsOrdinal;
            //myPane.XAxis.Scale.Min=new XDate(2006,1,1);
            myPane.Chart.Fill = new Fill(Color.Black, Color.Black, 45.0f);
            myPane.Fill = new Fill(Color.Black, Color.Black, 45.0f);
            this.zedGraphControl1.AxisChange();

            //订阅所有Proxy的OnAccount
            //获取所有Manager的Proxy,每个Proxy都有自己的AccountData,获取所有连接的AccoutData-
            //先在打开的时候默认把登陆的proxy的缓存都查一遍放进去，后面再有登陆的，直接监听，添加
            foreach (PROXYTHROUGH proxy in Enum.GetValues(typeof(PROXYTHROUGH)))
            {
                if (null == ProxyManager.GetInstance().GetProxy(proxy)) continue;

                ProxyManager.GetInstance().GetProxy(proxy).OnAccountEvent += ZedKLineForm_OnAccountEvent;

                List<AccountData> accList = ProxyManager.GetInstance().GetProxy(proxy).AccountData;
                if (accList == null || accList.Count <= 0) continue;
                foreach (AccountData d in accList)
                {
                    if (d == null) continue;
                    this.toolStripComboBox_accountID.Items.Add(d.AccountName);
                    this.toolStripComboBox_DrawAccountID.Items.Add(d.AccountName);
                }

            }

            //初始化下单委托类型
            this.toolStripComboBox_orderType.Items.Add("市价单");
            this.toolStripComboBox_orderType.Items.Add("限价单");

            //订阅OnBar
            ProxyManager.GetInstance().GetProxy(m_contractData.Proxy).OnBarEvent += ZedKLineForm_OnBarEvent;

            //订阅OnTick
            ProxyManager.GetInstance().GetProxy(m_contractData.Proxy).OnTickEvent += ZedKLineForm_OnTickEvent;

            //查询根据HisRequest查询历史数据 - Onbar返回回来添加
            ProxyManager.GetInstance().GetProxy(m_contractData.Proxy).QueryHistory(m_hisRequest);

            //订阅合约实时行情
            SubscribeRequest sQ = new SubscribeRequest()
            {
                Proxy = m_contractData.Proxy,
                Exchange = m_contractData.Exchange,
                Symbol = m_hisRequest.Symbol
            };
            ProxyManager.GetInstance().GetProxy(m_contractData.Proxy).SubScribe(sQ);

            //合成K线-根据打开的图表的Interval合成
            m_BarMakerService = new BarMakerService(m_hisRequest, m_contractData, m_hisRequest.Proxy);
        }

        /// <summary>
        /// 动态账户登录添加
        /// </summary>
        /// <param name="accD"></param>
        private void ZedKLineForm_OnAccountEvent(List<AccountData> accD)
        {
             
        }

        private StockPt pt = null;
        /// <summary>
        /// Tick回调 - 实时数据
        /// </summary>
        /// <param name="tickD"></param>
        private void ZedKLineForm_OnTickEvent(List<TickData> tickD)
        {
            //重复的proxy打开图表，主动查询，会都推，所以需要过滤(requestID，Or 唯一确认？OR Symbol过滤？)
            //所以如果回来的数据不是和我们关心的我们请求的数据相同的数据，全部过滤掉
            if (tickD == null) return;
            if (tickD.Count <= 0) return;

            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<List<TickData>>(ZedKLineForm_OnTickEvent), tickD);
                return;
            }

            foreach (TickData t in tickD)
            {
                if (t.Symbol != m_hisRequest.Symbol) continue; //过滤-因为这个list里面的tick有可能是多个合约，有可能是来自订阅的一个合约，所以在這里这么一过滤，可以兼容多合约返回和单个合约List的返回
                Debug.WriteLine(t.DTime + " " + t.Symbol + " " + t.LastPrice);
                //在这里处理自己的业务

                this.richTextBox_ChartAndIndicatorsLog.AppendText("\n" + t.DTime + " " + t.Symbol + " " + t.LastPrice);

                BarData bMake = m_BarMakerService.MakeBar(t, m_hisRequest);
                if (bMake == null)
                {
                    if (pt == null)
                    {
                        pt = new StockPt();
                        double x = (double)new XDate(t.DTime.Year, t.DTime.Month, t.DTime.Day, t.DTime.Hour, t.DTime.Minute, t.DTime.Second);
                        pt.Date = x;//zedgraph自动转换的，这里只要按照规定的zedgraph XDate转一下即可
                        pt.High = t.LastPrice;
                        pt.Low = t.LastPrice;
                        pt.Open = t.LastPrice;
                        pt.Close = t.LastPrice;
                        (m_myCurve.Points as StockPointList).Add(pt);
                        this.zedGraphControl1.AxisChange();
                        this.zedGraphControl1.Refresh();
                        return;
                    }
                    else
                    {
                        StockPt pt = (m_myCurve.Points as StockPointList).GetAt((m_myCurve.Points as StockPointList).Count - 1);

                        StockPt ptClone = new StockPt(pt);

                        if (t.LastPrice > ptClone.High)
                        {
                            ptClone.High = t.LastPrice;
                        }
                        else
                        {
                            ptClone.High = pt.High;
                        }

                        if (t.LastPrice < ptClone.Low)
                        {
                            ptClone.Low = t.LastPrice;
                        }
                        else
                        {
                            ptClone.Low = pt.Low;
                        }

                        ptClone.Close = t.LastPrice;
                        ptClone.Open = pt.Open;

                        (m_myCurve.Points as StockPointList).RemoveAt((m_myCurve.Points as StockPointList).Count - 1);
                        (m_myCurve.Points as StockPointList).Add(ptClone);

                        this.zedGraphControl1.AxisChange();
                        this.zedGraphControl1.Refresh();
                        return;
                    }
                }
                else
                {
                    double x = (double)new XDate(bMake.DTime.Year, bMake.DTime.Month, bMake.DTime.Day, bMake.DTime.Hour, bMake.DTime.Minute, bMake.DTime.Second);
                    StockPt ptMake = new StockPt();
                    ptMake.Date = x;//zedgraph自动转换的，这里只要按照规定的zedgraph XDate转一下即可
                    ptMake.High = bMake.HighPrice;
                    ptMake.Low = bMake.LowPrice;
                    ptMake.Open = bMake.OpenPrice;
                    ptMake.Close = bMake.ClosePrice;
                    (m_myCurve.Points as StockPointList).RemoveAt((m_myCurve.Points as StockPointList).Count - 1);
                    (m_myCurve.Points as StockPointList).Add(ptMake);
                    this.zedGraphControl1.AxisChange();
                    this.zedGraphControl1.Refresh();

                    pt = null;

                    return;
                }
            }
        }

        /// <summary>
        /// Bar回调 - 历史数据
        /// </summary>
        private void ZedKLineForm_OnBarEvent(List<BarData> tickD)
        {
            //重复的proxy打开图表，主动查询，会都推，所以需要过滤(requestID，Or 唯一确认？OR Symbol过滤？)
            //所以如果回来的数据不是和我们关心的我们请求的数据相同的数据，全部过滤掉
            if (tickD == null) return;
            if (tickD.Count <= 0) return;
            ////////////////////////////////////////////////////////////////////////////////////
            ///过滤之后开始自己图表关心的内容的处理
            ///
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<List<BarData>>(ZedKLineForm_OnBarEvent), tickD);
                return;
            }

            //Debug.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());//只是观察线程对象

            GraphPane myPane = this.zedGraphControl1.GraphPane;

            foreach (BarData bD in tickD)
            {
                if (bD.Symbol != m_hisRequest.Symbol) continue; //过滤-因为这个list里面的bar有可能是多个合约，有可能是来自订阅的一个合约，所以在這里这么一过滤，可以兼容多合约返回和单个合约List的返回

                double x = (double)new XDate(bD.DTime.Year, bD.DTime.Month, bD.DTime.Day, bD.DTime.Hour, bD.DTime.Minute, bD.DTime.Second);
                double dateTime = x/*DateTimeAction.TransIntervalDouble(bD)*//*bD.DTime.ToOADate()*/;
                double open = bD.OpenPrice;
                double close = bD.ClosePrice;
                double hi = bD.HighPrice;
                double low = bD.LowPrice;
                StockPt pt = new StockPt(dateTime, hi, low, open, close, 100);
                m_splList.Add(pt);
            }
            m_myCurve = myPane.AddJapaneseCandleStick("", m_splList);
            //中间那条细线的颜色
            m_myCurve.Stick.Color = Color.Orange;
            //当收盘价高于开盘价body的颜色
            m_myCurve.Stick.RisingFill = new Fill(Color.FromArgb(255, 0, 0));
            //当收盘价低于开盘价body的颜色
            m_myCurve.Stick.FallingFill = new Fill(Color.FromArgb(0, 254, 4));
            //当收盘价高于开盘价border的颜色
            m_myCurve.Stick.RisingBorder = new Border(Color.FromArgb(255, 0, 0), 1.0f);
            //当收盘价低于开盘价border的颜色
            m_myCurve.Stick.FallingBorder = new Border(Color.FromArgb(0, 254, 4), 1.0f);

            myPane.XAxis.Type = AxisType.Date;////为什么date不可以，这里的格式-见上面详细说明?
            myPane.XAxis.Scale.Format = "yyyy-MM-dd HH:mm:ss";

            //myPane.XAxis.Scale.Min = new XDate(2006, 1, 1);
            myPane.Chart.Fill = new Fill(Color.Black, Color.Black, 45.0f);
            myPane.Fill = new Fill(Color.Black, Color.Black, 45.0f);

            this.zedGraphControl1.ZoomOut(this.zedGraphControl1.GraphPane);
            this.zedGraphControl1.AxisChange();
            this.zedGraphControl1.Refresh();

        }

        #region 画线下单专区

        private bool m_isOrderPress = false;
        private int m_nowMoveKey = -2;
        private TextObj m_xTextObj = null;
        private TextObj m_yTextObj = null;

        /// <summary>
        /// 画线下单动作
        /// </summary>
        private enum LineOrderTradeType
        {
            /// <summary>
            /// 买 - 卖 - 平 - 反 - 盈 -损
            /// </summary>
            B = 0,
            S,
            C,
            R,
            P,
            L
        }

        /// <summary>
        /// 下单状态
        /// </summary>
        private enum LineOrderStatus
        {
            /// <summary>
            /// 委托 - 成交
            /// </summary>
            O = 0,
            T
        }

        /// <summary>
        /// 用于统一画线下单的类
        /// </summary>
        private class PutOrderDraw
        {
            /// <summary>
            /// 保存所有的单子
            /// </summary>
            public static Dictionary<int, List<GraphObj>> m_orderObjDic = new Dictionary<int, List<GraphObj>>();
            public static Dictionary<int, List<GraphObj>> OrderObjDic
            {
                get
                {
                    return m_orderObjDic;
                }
            }

            private static int RequestOrderID = -1;

            /// <summary>
            /// 新增订单
            /// </summary>
            /// <param name="zedGraphControl"></param>
            /// <param name="type"></param>
            /// <param name="status"></param>
            /// <param name="OrderShares"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public static bool AddOrder(ZedGraphControl zedGraphControl, LineOrderTradeType type, LineOrderStatus status, int OrderShares, double y)
            {
                try
                {
                    //例如:"挂|买|1|-3000"
                    string OrderStr = string.Format("{0}|{1}|{2}|{3}", status.ToString(), type.ToString(), OrderShares.ToString(), "-200");
                    TextObj text = new TextObj(OrderStr, 0.5f, y, CoordType.XChartFractionYScale, AlignH.Left, AlignV.Center);
                    text.FontSpec.Border.IsVisible = true;
                    text.FontSpec.Fill.IsVisible = true;
                    text.FontSpec.Fill.Color = System.Drawing.Color.Red;
                    text.FontSpec.Angle = 0;
                    text.Tag = false;
                    zedGraphControl.GraphPane.GraphObjList.Add(text);

                    LineObj lineObj = new LineObj(Color.White, zedGraphControl.GraphPane.Rect.Left, y, zedGraphControl.Width, y);
                    lineObj.Line.Color = Color.White;
                    lineObj.Line.DashOn = 0.8f;
                    lineObj.Line.IsVisible = true;
                    lineObj.Tag = false;
                    zedGraphControl.GraphPane.GraphObjList.Add(lineObj);

                    //ImageObj imObj = new ImageObj(Image.FromFile(@"C:\Users\Administrator\Desktop\222.png"), new RectangleF(0.5f,(float)y,10,10),CoordType.AxisXYScale,AlignH.Left,AlignV.Center);
                    //imObj.IsVisible = true;
                    //imObj.Tag = false;
                    //zedGraphControl.GraphPane.GraphObjList.Add(imObj);

                    string tagCancel = "X";
                    TextObj textCancel = new TextObj(tagCancel, 0.48f, y, CoordType.XChartFractionYScale, AlignH.Left, AlignV.Center);
                    textCancel.FontSpec.Border.IsVisible = true;
                    textCancel.FontSpec.FontColor = Color.White;
                    textCancel.FontSpec.Fill.IsVisible = true;
                    textCancel.FontSpec.Fill.Color = System.Drawing.Color.Green;
                    textCancel.FontSpec.Angle = 0;
                    textCancel.Tag = false;
                    textCancel.IsClippedToChartRect = true;
                    zedGraphControl.GraphPane.GraphObjList.Add(textCancel);

                    //BoxObj bObj = new BoxObj(x,y,10,10);
                    //this.zg1.GraphPane.GraphObjList.Add(bObj);

                    List<GraphObj> orderObj = new List<GraphObj>();
                    orderObj.Add(text);
                    orderObj.Add(lineObj);
                    orderObj.Add(textCancel);

                    m_orderObjDic.Add(RequestOrderID++, orderObj);
                    zedGraphControl.Refresh();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            /// <summary>
            /// 删除指定订单
            /// </summary>
            /// <param name="zedGraphControl"></param>
            /// <param name="keyOrder"></param>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public static bool DeleteOrder(ZedGraphControl zedGraphControl, float x, float y)
            {
                //首先鼠标移动到指定的订单上方，判断X在控件范围内，找到这个X所属于的key，从字典和全局graphObjList中删除掉；
                try
                {
                    int delKey = -2;
                    List<GraphObj> obJList = null;
                    foreach (KeyValuePair<int, List<GraphObj>> kv in PutOrderDraw.OrderObjDic)
                    {
                        int key = kv.Key;
                        List<GraphObj> value = kv.Value;
                        foreach (GraphObj oJ in value)
                        {
                            //1.在line内；2.在X-TextObj内
                            if (oJ.PointInBox(new PointF(x, y), zedGraphControl.GraphPane, zedGraphControl.CreateGraphics(), 0.01f))
                            {
                                //这里坐标转换时参考ZedgraphControl源代码-PanBase里的
                                //internal PointF TransformCoord( double x, double y, CoordType coord )进行坐标的转换
                                //其中ptPix.X = (float)(chartRect.Left + x * chartRect.Width)进行反推，得到如下公式
                                //把鼠标左边转换为屏幕横坐标占reac的百分比进行比较，得到是不是在X-Obj的内部，决定是否进行删除操作
                                double xFraction = (x - zedGraphControl.GraphPane.Chart.Rect.Left) / zedGraphControl.GraphPane.Chart.Rect.Width;

                                //鼠标的横坐标在0.48f-0.50f之间，刚好是X的坐标间距
                                if (xFraction >= 0.48f && xFraction <= 0.50f)
                                {
                                    delKey = key;
                                    obJList = kv.Value;
                                    break;
                                }
                            }
                        }
                    }

                    if (delKey == -2 || obJList == null) return false;

                    //删掉自己管理的统一三个画线集合
                    m_orderObjDic.Remove(delKey);

                    //删除zedgraph内部管理的所有的画线集合体指定的画线蔟
                    List<GraphObj> delObjectList = obJList;
                    foreach (GraphObj obj in delObjectList)
                    {
                        zedGraphControl.GraphPane.GraphObjList.Remove(obj);
                    }

                    zedGraphControl.Refresh();
                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }


                return true;
            }

            /// <summary>
            /// 改变订单状态
            /// </summary>
            /// <param name="zedGraphControl"></param>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public static int ChangeOrderSelectStatus(ZedGraphControl zedGraphControl, float x, float y)
            {
                foreach (KeyValuePair<int, List<GraphObj>> kv in m_orderObjDic)
                {
                    int key = kv.Key;
                    List<GraphObj> value = kv.Value;
                    foreach (GraphObj oJ in value)
                    {
                        if (!oJ.PointInBox(new PointF(x, y), zedGraphControl.GraphPane, zedGraphControl.CreateGraphics(), 0.01f)) continue;

                        if (true == (bool)oJ.Tag)
                        {
                            oJ.Tag = false;
                            return -2;
                        }
                        else
                        {
                            oJ.Tag = true;
                            return key;
                        }

                    }
                }
                return -2;
            }

            /// <summary>
            /// 移动订单到指定的位置
            /// </summary>
            /// <param name="zedGraphControl"></param>
            /// <param name="keyOrder"></param>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public static bool MoveOrder(ZedGraphControl zedGraphControl, int keyOrder, float x, float y)
            {
                try
                {
                    foreach (KeyValuePair<int, List<GraphObj>> kv in PutOrderDraw.OrderObjDic)
                    {
                        int key = kv.Key;
                        List<GraphObj> value = kv.Value;
                        if (key != keyOrder) continue;

                        foreach (GraphObj oJ in value)
                        {
                            double xScal = 0.00;
                            double yScal = 0.00;
                            PointF mousePt = new PointF(x, y);
                            if (zedGraphControl.GraphPane != null)
                            {
                                zedGraphControl.GraphPane.ReverseTransform(mousePt, out xScal, out yScal);
                            }
                            oJ.Location.Y = yScal;
                        }
                    }
                    zedGraphControl.Refresh();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            /// <summary>
            /// 判断所有的划线，只要在区域内，不分是哪一笔，都返回true;
            /// </summary>
            /// <param name="zedGraphControl"></param>
            /// <param name="keyOrder"></param>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public static bool IsSlected(ZedGraphControl zedGraphControl, int keyOrder, float x, float y)
            {
                try
                {
                    foreach (KeyValuePair<int, List<GraphObj>> kv in PutOrderDraw.OrderObjDic)
                    {
                        int key = kv.Key;
                        List<GraphObj> value = kv.Value;

                        foreach (GraphObj oJ in value)
                        {
                            if (!oJ.PointInBox(new PointF(x, y), zedGraphControl.GraphPane, zedGraphControl.CreateGraphics(), 0.01f)) continue;
                            return true;
                        }
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

        }

        public bool IsCursorCross
        {
            get;
            set;
        }

        private void ZedMouseLeave(object sender, EventArgs e)
        {
            m_xTextObj.IsVisible = false;
            m_yTextObj.IsVisible = false;

            //这里要刷新重绘一下，因为可能在不同的对象之间切换十字线等还存在
            this.zedGraphControl1.Refresh();
        }

        /// <summary>
        /// 注意和mousemoveEvent的区别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZedMouseMove(object sender, MouseEventArgs e)
        {

            //// Save the mouse location
            //PointF mousePt = new PointF(e.X, e.Y);
            //string tooltip = string.Empty;
            //// Find the Chart rect that contains the current mouse location
            //GraphPane pane = ((ZedGraphControl)sender).MasterPane.FindChartRect(mousePt);
            //// If pane is non-null, we have a valid location.  Otherwise, the mouse is not
            //// within any chart rect.
            //if (pane != null)
            //{
            //    double x, y;
            //    // Convert the mouse location to X, and Y scale values
            //    pane.ReverseTransform(mousePt, out x, out y);
            //    // 获取横纵坐标信息
            //    tooltip = "(" + x.ToString("f2") + ", " + y.ToString("f2") + ")";

            //    m_xTextObj.IsVisible = true;
            //    m_xTextObj.Location.X = x;
            //    m_xTextObj.Location.Y = 1;//这里注意显示的模式，因为初始化选择的是fratin模式，是百分比占用模式，所以这里是1，就是在最底部，如果是0就在最上面
            //    m_xTextObj.Text = x.ToString();

            //    m_yTextObj.IsVisible = true;
            //    m_yTextObj.Location.X = 0;
            //    m_yTextObj.Location.Y = y;
            //    m_yTextObj.Text = y.ToString("f2");
            //    this.zedGraphControl1.Refresh();
            //}
            ////toolTips1.SetToolTip(this.zedGraphControl1, tooltip);
            /////////////////////////////////////////////////////////////////////
            //if (m_isOrderPress)
            //{

            //    using (Graphics gc = this.zedGraphControl1.CreateGraphics())
            //    using (Pen pen = new Pen(Color.White))
            //    {
            //        //设置画笔的宽度
            //        pen.Width = 1;
            //        pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            //        RectangleF rect = this.zedGraphControl1.GraphPane.Chart.Rect;
            //        //确保在画图区域
            //        if (rect.Contains(e.Location))
            //        {
            //            this.zedGraphControl1.Refresh();
            //            //画横线
            //            gc.DrawLine(pen, rect.Left, e.Y, rect.Right, e.Y);

            //        }

            //    }
            //    return;
            //}
            //else
            //{
            //    if (IsCursorCross)
            //    {
            //        this.Cursor = Cursors.Cross;
            //        if (PutOrderDraw.IsSlected(this.zedGraphControl1, m_nowMoveKey, e.X, e.Y))
            //        {
            //            this.Cursor = Cursors.Hand;
            //        }

            //        if (m_nowMoveKey != -2)
            //        {
            //            PutOrderDraw.MoveOrder(this.zedGraphControl1, m_nowMoveKey, e.X, e.Y);
            //            this.Cursor = Cursors.Hand;
            //            return;
            //        }
            //    }
            //    else
            //    {
            //        if (PutOrderDraw.IsSlected(this.zedGraphControl1, m_nowMoveKey, e.X, e.Y))
            //        {
            //            this.Cursor = Cursors.Hand;
            //        }


            //        if (m_nowMoveKey != -2)
            //        {
            //            PutOrderDraw.MoveOrder(this.zedGraphControl1, m_nowMoveKey, e.X, e.Y);
            //            this.Cursor = Cursors.Hand;
            //            return;
            //        }

            //        using (Graphics gc = this.zedGraphControl1.CreateGraphics())
            //        using (Pen pen = new Pen(Color.White))
            //        {
            //            //设置画笔的宽度
            //            pen.Width = 1;
            //            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            //            RectangleF rect = this.zedGraphControl1.GraphPane.Chart.Rect;
            //            //确保在画图区域
            //            if (rect.Contains(e.Location))
            //            {
            //                this.zedGraphControl1.Refresh();
            //                //画竖线
            //                gc.DrawLine(pen, e.X, rect.Top, e.X, rect.Bottom);
            //                //画横线
            //                gc.DrawLine(pen, rect.Left, e.Y, rect.Right, e.Y);
            //            }
            //        }
            //        return;
            //    }
            //}

        }

        /// <summary>
        /// 注意和mousemoveEvent的区别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private bool ZedMouseMoveEvent(ZedGraphControl sender, MouseEventArgs e)
        {
            // Save the mouse location
            PointF mousePt = new PointF(e.X, e.Y);
            string tooltip = string.Empty;
            // Find the Chart rect that contains the current mouse location
            GraphPane pane = ((ZedGraphControl)sender).MasterPane.FindChartRect(mousePt);
            // If pane is non-null, we have a valid location.  Otherwise, the mouse is not
            // within any chart rect.
            if (pane != null)
            {
                double x, y;
                // Convert the mouse location to X, and Y scale values
                pane.ReverseTransform(mousePt, out x, out y);
                // 获取横纵坐标信息
                tooltip = "(" + x.ToString("f2") + ", " + y.ToString("f2") + ")";

                m_xTextObj.IsVisible = true;
                m_xTextObj.Location.X = x;
                m_xTextObj.Location.Y = 1;//这里注意显示的模式，因为初始化选择的是fratin模式，是百分比占用模式，所以这里是1，就是在最底部，如果是0就在最上面


                XDate xdate = new XDate(x);                
                m_xTextObj.Text = XDate.ToString(xdate,"yyyy-MM-dd hh:mm:ss");

                m_yTextObj.IsVisible = true;
                m_yTextObj.Location.X = 0;
                m_yTextObj.Location.Y = y;
                m_yTextObj.Text = y.ToString("f2");
                this.zedGraphControl1.Refresh();
            }
            //toolTips1.SetToolTip(this.zedGraphControl1, tooltip);
            ///////////////////////////////////////////////////////////////////
            if (m_isOrderPress)
            {

                using (Graphics gc = this.zedGraphControl1.CreateGraphics())
                using (Pen pen = new Pen(Color.White))
                {
                    //设置画笔的宽度
                    pen.Width = 1;
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
                    RectangleF rect = this.zedGraphControl1.GraphPane.Chart.Rect;
                    //确保在画图区域
                    if (rect.Contains(e.Location))
                    {
                        this.zedGraphControl1.Refresh();
                        //画横线
                        gc.DrawLine(pen, rect.Left, e.Y, rect.Right, e.Y);

                    }

                }
                return false;
            }
            else
            {
                if (IsCursorCross)
                {
                    this.Cursor = Cursors.Cross;
                    if (PutOrderDraw.IsSlected(this.zedGraphControl1, m_nowMoveKey, e.X, e.Y))
                    {
                        this.Cursor = Cursors.Hand;
                    }

                    if (m_nowMoveKey != -2)
                    {
                        PutOrderDraw.MoveOrder(this.zedGraphControl1, m_nowMoveKey, e.X, e.Y);
                        this.Cursor = Cursors.Hand;
                        return false;
                    }
                }
                else
                {
                    if (PutOrderDraw.IsSlected(this.zedGraphControl1, m_nowMoveKey, e.X, e.Y))
                    {
                        this.Cursor = Cursors.Hand;
                    }


                    if (m_nowMoveKey != -2)
                    {
                        PutOrderDraw.MoveOrder(this.zedGraphControl1, m_nowMoveKey, e.X, e.Y);
                        this.Cursor = Cursors.Hand;
                        return false;
                    }

                    using (Graphics gc = this.zedGraphControl1.CreateGraphics())
                    using (Pen pen = new Pen(Color.White))
                    {
                        //设置画笔的宽度
                        pen.Width = 1;
                        pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
                        RectangleF rect = this.zedGraphControl1.GraphPane.Chart.Rect;
                        //确保在画图区域
                        if (rect.Contains(e.Location))
                        {
                            this.zedGraphControl1.Refresh();
                            //画竖线
                            gc.DrawLine(pen, e.X, rect.Top, e.X, rect.Bottom);
                            //画横线
                            gc.DrawLine(pen, rect.Left, e.Y, rect.Right, e.Y);
                        }
                    }
                    return false;
                }
            }

            return false;
        }

        private bool ZedMouseDownEvent(ZedGraphControl sender, MouseEventArgs e)
        {
            //（1）点击的时候，如果下单按钮被激活了，就只负责下单（不做单子区域判断移动）/ 下单完毕，下单按钮的状态要恢复初始状态，直接返回
            //（2）点击的时候，如果下单按钮未被激活，就负责判断是否存在区域单子，改变区域单子状态即可,true->false,false->true

            if (m_isOrderPress)
            {
                PointF mousePt = new PointF(e.X, e.Y);
                GraphPane pane = ((ZedGraphControl)sender).MasterPane.FindChartRect(mousePt);

                double x = 0.00;
                double y = 0.00;
                if (pane != null)
                {
                    pane.ReverseTransform(mousePt, out x, out y);
                }

                bool putResult = PutOrderDraw.AddOrder(this.zedGraphControl1, LineOrderTradeType.B, LineOrderStatus.O, 1, y);
                m_isOrderPress = false;
                return false;
            }
            else
            {
                bool delResult = PutOrderDraw.DeleteOrder(this.zedGraphControl1, e.X, e.Y);


                int key = PutOrderDraw.ChangeOrderSelectStatus(this.zedGraphControl1, e.X, e.Y);
                m_nowMoveKey = key;
                return false;
            }
        }

        private void OrderBuyClick(object sender, EventArgs e)
        {
            if (m_isOrderPress == false)
            {
                m_isOrderPress = true;
                return;
            }
            else
            {
                m_isOrderPress = false;
                return;
            }
        }

        #endregion

        #region 人工下单区

        /// <summary>
        /// 买入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_buy_Click(object sender, EventArgs e)
        {
            SendActionOrder(Direction.LONG,Offset.OPEN);
        }

        /// <summary>
        /// 卖空
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_sellshort_Click(object sender, EventArgs e)
        {
            SendActionOrder(Direction.SHORT, Offset.OPEN);
        }

        /// <summary>
        /// 委托下单-B/S/C
        /// </summary>
        private void SendActionOrder(Direction direc,Offset offset)
        {
            OrderRequest orReq = new OrderRequest();
            orReq.Symbol = m_contractData.Symbol;
            orReq.Exchange = m_contractData.Exchange;
            orReq.Direction = direc;
            orReq.OrderType = this.toolStripComboBox_orderType.SelectedIndex ==0? OrderType.MARKET:OrderType.MARKET;
            
            orReq.Volume = Convert.ToDouble(this.toolStripTextBox_volume.Text);
            orReq.Price = Convert.ToDouble(this.toolStripTextBox_price.Text);
            orReq.Offset = offset;

            ProxyManager.GetInstance().GetProxy(m_contractData.Proxy).SendOrder(orReq);
        }

        #endregion

        #region 画线指标区

        #endregion

        #region 指标设置区

        #endregion


    }
}
