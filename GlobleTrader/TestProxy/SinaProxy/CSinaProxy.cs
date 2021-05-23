using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestProxy
{
    class CSinaProxy : BaseProxy
    {
        private CSinaAPI m_api;

        private System.Threading.Thread m_OnHisDataThread;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="proxyName"></param>
        public CSinaProxy(PROXYTHROUGH proxyThrough)
        {
            this.m_proxyThroughEnum = proxyThrough;
            m_api = new CSinaAPI();
            //m_OnHisDataThread = new System.Threading.Thread(new ParameterizedThreadStart(BrocastHisData));
        }

        /// <summary>
        /// 线程广播历史数据
        /// </summary>
        private void BrocastHisData(object hDParam)
        {
            //StockData dT = m_api.QueryHistory(hDParam as HistoryRequest);
            //List<List<String>> dList = dT.Items;

            //List<BarData> bDList = new List<BarData>();
            //for (int i = 0; i < dList.Count; i++)
            //{
            //    BarData hD = new BarData();
            //    hD.Proxy = PROXYTHROUGH.TuShare;
            //    hD.Exchange = Exchange.SSE;
            //    hD.Interval = Interval.Day;

            //    int dTime = 0;
            //    int.TryParse(dList[i][1], out dTime);
            //    DateTime b = DateTime.ParseExact(dTime.ToString(), "yyyyMMdd", null);

            //    hD.DTime = b;
            //    hD.Symbol = dT.StockName;

            //    double open = 0.00;
            //    double.TryParse(dList[i][2], out open);
            //    hD.OpenPrice = open;

            //    double high = 0.00;
            //    double.TryParse(dList[i][3], out high);
            //    hD.HighPrice = high;

            //    double low = 0.00;
            //    double.TryParse(dList[i][4], out low);
            //    hD.LowPrice = low;

            //    double close = 0.00;
            //    double.TryParse(dList[i][5], out close);
            //    hD.ClosePrice = close;

            //    bDList.Add(hD);
            //}
            //OnBar(bDList);

            //m_OnHisDataThread.Abort();  //这里查询过一次之后，再次查询会提示线程无法退出或者正在进行中的异常，所以暂时直接同步查；
        }

        /// <summary>
        /// 查询历史重载-可以直接调基类回调返回
        /// </summary>
        public override void QueryHistory(HistoryRequest hisData)
        {
            try
            {
                StockData dT = m_api.QueryHistory(hisData);
                if (null == dT) return;

                List<List<String>> dList = dT.Items;

                List<BarData> bDList = new List<BarData>();
                for (int i = 0; i < dList.Count; i++)
                {
                    BarData hD = new BarData();
                    hD.Proxy = PROXYTHROUGH.Sina;
                    hD.Exchange = Exchange.NULL;
                    hD.Interval = hisData.Interval;

                    DateTime b = DateTime.ParseExact(dList[i][0], "yyyy-MM-dd", null);

                    hD.DTime = b;
                    hD.Symbol = dT.StockName;

                    double open = 0.00;
                    double.TryParse(dList[i][1], out open);
                    hD.OpenPrice = open;

                    double high = 0.00;
                    double.TryParse(dList[i][2], out high);
                    hD.HighPrice = high;

                    double low = 0.00;
                    double.TryParse(dList[i][3], out low);
                    hD.LowPrice = low;

                    double close = 0.00;
                    double.TryParse(dList[i][4], out close);
                    hD.ClosePrice = close;

                    bDList.Add(hD);
                }

                //时间保证到前端是正向排列的
                OnBar(bDList);
            }
            catch(Exception ex)
            {
                LogData log = new LogData();
                log.Msg = ex.Message;
                log.Level = 0;
                this.OnLog(log);
            }

        }

        public override void Init(LoginRequest loginData)
        {
        }

        public override void Connect()
        {
            //throw new NotImplementedException();
        }

        public override void Login()
        {
            //throw new NotImplementedException();
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
            //对于Sina来说，他们暂时没有维护一个COntract的列表，所以在这里，我们这样处理
            //收到查询合约的请求之后，主动去查一笔行情，如果能查回来，说明合约存在，加入到缓存和发布；
            LogData log = new LogData();

            try
            {
                HistoryRequest hQ = new HistoryRequest();
                hQ.Proxy = cQ.Proxy;
                hQ.Exchange = cQ.Exchange;
                hQ.Symbol = cQ.Symbol;
                hQ.Interval = Interval.Day_1;

                StockData dT = m_api.QueryHistory(hQ);
                if (null == dT) return false;
                List<List<String>> dList = dT.Items;

                if (dList.Count > 0)
                {
                    List<ContractData> cDList = new List<ContractData>();

                    ContractData cd = new ContractData();
                    cd.Symbol = cQ.Symbol;
                    cd.Proxy = cQ.Proxy;
                    cd.Exchange = Exchange.NULL;

                    cDList.Add(cd);

                    if (!m_contracts.Contains(cd)) m_contracts.Add(cd);

                    //发布
                    this.OnContract(cDList);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                log.Msg = ex.Message;
                log.Level = 0;

                this.OnLog(log);
            }

            return true;
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
