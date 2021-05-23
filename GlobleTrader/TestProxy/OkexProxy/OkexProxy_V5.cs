using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OKExSDK_V5;

namespace TestProxy
{

    public class OkexProxy_V5 : BaseProxy
    {
        private PublicDataApi m_publicDataApi = null;
        private TradeApi m_tradeApi = null;
        private MarketDataApi m_marketApi = null;
        private AccountApi m_accountApi = null;

        /// <summary>
        /// 定时任务-查询实时行情返回
        /// </summary>
        private System.Threading.Timer m_timerQueryMarket = null;
        private System.Threading.Timer m_timerQueryTrade = null;

        /// <summary>
        /// 多线程事务锁
        /// </summary>
        private object m_Mutx = new object();

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="proxyName"></param>
        public OkexProxy_V5(PROXYTHROUGH proxyThrough)
        {
            this.m_proxyThroughEnum = proxyThrough;
        }

        /// <summary>
        /// 查询历史重载-可以直接调基类回调返回
        /// </summary>
        public override void QueryHistory(HistoryRequest hisData)
        {
            QueryV5History(hisData);
        }

        /// <summary>
        /// 查询历史K线
        /// </summary>
        /// <param name="hisData"></param>
        private async void QueryV5History(HistoryRequest hisData)
        {
            Dictionary<string, string> m_hisDic = new Dictionary<string, string>();
            m_hisDic["instId"] = hisData.Symbol;
            //m_hisDic["after"] = DateTimeAction.DateTimeToUnixTime(hisData.eTime).ToString();
            m_hisDic["bar"] = OkexCommon.Trans_CommonInterval_ToOkexV5(hisData.Interval);   //其余参数为非必填
            string hisStr = await m_marketApi.GetCandlesticks(m_hisDic);   //查账户明细

            HisDataV5 hisDV5 = JsonDataContractJsonSerializer.DeserializeJsonToObject<HisDataV5>(hisStr);
            //...缓存 - 发布 
            if (hisDV5 != null && hisDV5.code == "0" && hisDV5.data.Count > 0)
            {
                List<BarData> barList = new List<BarData>();

                List<List<string>> bList = hisDV5.data;
                foreach (List<string> item in bList)
                {
                    List<string> barInfo = item;
                    BarData selfBData = new BarData()
                    {
                        Proxy = hisData.Proxy,
                        Symbol = hisData.Symbol,
                        Exchange = Exchange.OKEX,
                        DTime = DateTimeAction.UnixTimeToDateTime(MathCommon.TransStrToDouble(barInfo[0])),
                        Interval = hisData.Interval,
                        Volume = MathCommon.TransStrToInt(barInfo[5]),
                        OpenPrice = MathCommon.TransStrToDouble(barInfo[1]),
                        HighPrice = MathCommon.TransStrToDouble(barInfo[2]),
                        LowPrice = MathCommon.TransStrToDouble(barInfo[3]),
                        ClosePrice = MathCommon.TransStrToDouble(barInfo[4]),

                    };
                    barList.Add(selfBData);
                }

                barList.Reverse();
                this.OnBar(barList);
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="loginData"></param>
        public override void Init(LoginRequest loginData)
        {
            if (m_publicDataApi == null || m_tradeApi == null || m_marketApi == null)
            {
                //key- secr - phrease
                m_publicDataApi = new PublicDataApi(loginData.IP, loginData.Port, loginData.Exdata);
                m_tradeApi = new TradeApi(loginData.IP, loginData.Port, loginData.Exdata);
                m_marketApi = new MarketDataApi(loginData.IP, loginData.Port, loginData.Exdata);
                m_accountApi = new AccountApi(loginData.IP, loginData.Port, loginData.Exdata);

                this.m_mdIsLogin = true;
                this.m_tdIsLogin = true;

                //查询账户 - 查询持仓 - 查询委托 - 查询成交 -查基础信息(因为合约很多，后面再去分别查询)             
                QueryV5Account();//注意直接调用的死锁问题，导致task.result一直在单线程中等待结果，所以使用异步方法查询
                QueryV5Position();
                QueryV5Trade();
                QueryV5Order();

                //开始交易定时器，定时轮询HTTP业务
                if (null == m_timerQueryTrade)
                {
                    //m_timerQueryTrade = new System.Threading.Timer(QueryTradeData, null, 0, 1000);
                }
            }
        }

        /// <summary>
        /// 查询账户
        /// </summary>
        private async void QueryV5Account()
        {
            LogData args = new LogData();

            Dictionary<string, string> m_accountDic = new Dictionary<string, string>();
            string accountStr = await m_accountApi.GetBalance(m_accountDic);   //查账户明细

            AccountV5 accountV5 = JsonDataContractJsonSerializer.DeserializeJsonToObject<AccountV5>(accountStr);
            //...缓存 - 发布 
            if (accountV5 != null && accountV5.code == "0" && accountV5.data.Count > 0)
            {
                List<AccountData> acDList = new List<AccountData>();

                List<DataItem> accountList = accountV5.data;
                foreach (DataItem item in accountList)
                {
                    List<DetailsItem> detaiList = item.details;
                    foreach (DetailsItem dItem in detaiList)
                    {
                        AccountData selfAcData = new AccountData()
                        {
                            Proxy = PROXYTHROUGH.Okex_V5_Swap,
                            AccountName = dItem.ccy,
                            AccountValue = dItem.availEq,
                            AccountCurrency = dItem.crossLiab
                        };
                        acDList.Add(selfAcData);
                    }
                }

                this.m_accounts.Clear();
                this.m_accounts = acDList;

                OnAccount(acDList);

                args.Msg = "Okex-V5登陆成功，账户查询成功！";
                args.Level = 1;

                this.OnLog(args);
            }
        }

        /// <summary>
        /// 查询持仓
        /// </summary>
        private async void QueryV5Position()
        {
            LogData args = new LogData();

            Dictionary<string, string> m_postionDic = new Dictionary<string, string>();
            string positionStr = await m_accountApi.GetPositions(m_postionDic); //查持仓明细

            PositionV5 positionV5 = JsonDataContractJsonSerializer.DeserializeJsonToObject<PositionV5>(positionStr);
            //...缓存 - 发布 
            if (positionV5 != null && positionV5.code == "0" && positionV5.data.Count > 0)
            {
                List<PositionData> pDList = new List<PositionData>();

                List<PositionDetail> positionList = positionV5.data;
                foreach (PositionDetail item in positionList)
                {

                    PositionData selfData = new PositionData()
                    {
                        Proxy = PROXYTHROUGH.Okex_V5_Swap,
                        Symbol = item.ccy,
                        Exchange = Exchange.OKEX,
                        Direction = OkexCommon.Trans_OkexV5_ToCommonDirection(item.posSide),
                        Volume = MathCommon.TransStrToDouble(item.pos),
                        Frozen = 0.00,
                        Price = MathCommon.TransStrToDouble(item.avgPx),
                        PNL = MathCommon.TransStrToDouble(item.upl),
                        YdVolume = 0.00

                    };
                    pDList.Add(selfData);
                }

                this.m_positions.Clear();
                this.m_positions = pDList;

                OnPosition(pDList);

                args.Msg = "Okex-V5查询持仓成功！";
                args.Level = 1;

                this.OnLog(args);
            }
        }

        /// <summary>
        /// 查询成交
        /// </summary>
        private async void QueryV5Trade()
        {
            Dictionary<string, string> m_tradeDic = new Dictionary<string, string>();
            string tradeDic = await m_tradeApi.GetOrderList(m_tradeDic); //查成交明细 --四种业务异步同步等待



            //...缓存 - 发布 
        }

        /// <summary>
        /// 查询委托
        /// </summary>
        private async void QueryV5Order()
        {
            Dictionary<string, string> m_orderDic = new Dictionary<string, string>();
            m_orderDic["instType"] = OkexCommon.Trans_CommonProduct_ToOkexV5(Product.INDEX); //-
            string orderDic = await m_tradeApi.GetOrderHistory_7days(m_orderDic); //查委托明细 --四种业务异步同步等待

            //...缓存 - 发布 
        }

        /// <summary>
        /// 查询合约
        /// </summary>
        private async void QueryV5Contract(ContractRequest cQ)
        {
            LogData args = new LogData();

            Dictionary<string, string> m_contractDic = new Dictionary<string, string>();
            m_contractDic["instType"] = OkexCommon.Trans_CommonProduct_ToOkexV5(cQ.Product);

            string contractDic = await m_publicDataApi.GetInstruments(m_contractDic); //查委托明细

            ContractV5 contractV5 = JsonDataContractJsonSerializer.DeserializeJsonToObject<ContractV5>(contractDic);
            //...缓存 - 发布 
            if (contractV5 != null && contractV5.code == "0" && contractV5.data.Count > 0)
            {
                List<ContractData> cDList = new List<ContractData>();

                List<ContractDetail> cDetailList = contractV5.data;
                foreach (ContractDetail item in cDetailList)
                {

                    ContractData selfData = new ContractData()
                    {
                        Proxy = PROXYTHROUGH.Okex_V5_Swap,
                        Symbol = item.instId,
                        Exchange = Exchange.OKEX,
                        Name = item.instId,
                        Product = OkexCommon.Trans_OkexV5Product_ToCommon(item.instType),
                        PriceTick = MathCommon.TransStrToDouble(item.tickSz),
                        MinVolume = MathCommon.TransStrToDouble(item.minSz)
                    };
                    cDList.Add(selfData);
                }

                this.m_contracts.Clear();
                this.m_contracts = cDList;

                OnContract(cDList);

                args.Msg = "Okex-V5查询合约成功！";
                args.Level = 1;

                this.OnLog(args);
            }
        }

        /// <summary>
        /// 查询实时行情
        /// </summary>
        /// <param name="pD"></param>
        private async void QueryV5TickData(Product pD)
        {
            LogData args = new LogData();

            Dictionary<string, string> m_ticDic = new Dictionary<string, string>();
            m_ticDic["instType"] = OkexCommon.Trans_CommonProduct_ToOkexV5(pD);

            string tickDic = await m_marketApi.GetTickers(m_ticDic); //查委托明细

            TickV5 tickV5 = JsonDataContractJsonSerializer.DeserializeJsonToObject<TickV5>(tickDic);
            //...缓存 - 发布 
            if (tickV5 != null && tickV5.code == "0" && tickV5.data.Count > 0)
            {
                List<TickData> tList = new List<TickData>();

                List<TickDetail> tDetailList = tickV5.data;
                foreach (TickDetail item in tDetailList)
                {
                    TickData selfData = new TickData()
                    {
                        Proxy = PROXYTHROUGH.Okex_V5_Swap,
                        Symbol = item.instId,
                        Exchange = Exchange.OKEX,
                        Name = item.instId,
                        LastPrice = MathCommon.TransStrToDouble(item.last),
                        LastVolume = MathCommon.TransStrToDouble(item.lastSz),
                        AskPrice1 = MathCommon.TransStrToDouble(item.askPx),
                        AskVolume1 = MathCommon.TransStrToDouble(item.askSz),
                        BidPrice1 = MathCommon.TransStrToDouble(item.bidPx),
                        BidVolume1 = MathCommon.TransStrToDouble(item.bidSz),
                        DTime = DateTimeAction.UnixTimeToDateTime(MathCommon.TransStrToDouble(item.ts))
                    };
                    tList.Add(selfData);
                }

                lock(m_Mutx)
                {
                    this.OnTick(tList);
                }
            }

        }

        private async void SendV5Order(OrderRequest orderReq)
        {
            LogData args = new LogData();

            Dictionary<string, string> m_placeOrderDic = new Dictionary<string, string>();
            //传参
            m_placeOrderDic["instId"] = orderReq.Symbol;
            m_placeOrderDic["tdMode"] = this.m_proxyConfig.Data;
            m_placeOrderDic["side"] = orderReq.Direction == Direction.LONG ? "buy" : "sell";  //buy-sell
            m_placeOrderDic["ordType"] = orderReq.OrderType == OrderType.MARKET ? "market" : "limit";//market-limit-post_only-fok-ioc
            m_placeOrderDic["sz"] = orderReq.Volume.ToString();
            m_placeOrderDic["px"] = orderReq.Price.ToString();

            string placeOrderStr = await m_tradeApi.PlaceOrder(m_placeOrderDic);   //查账户明细

            //placeOrderV5 accountV5 = JsonDataContractJsonSerializer.DeserializeJsonToObject<AccountV5>(accountStr);
            ////...缓存 - 发布 
            //if (accountV5 != null && accountV5.code == "0" && accountV5.data.Count > 0)
            //{
            //    List<AccountData> acDList = new List<AccountData>();

            //    List<DataItem> accountList = accountV5.data;
            //    foreach (DataItem item in accountList)
            //    {
            //        List<DetailsItem> detaiList = item.details;
            //        foreach (DetailsItem dItem in detaiList)
            //        {
            //            AccountData selfAcData = new AccountData()
            //            {
            //                Proxy = PROXYTHROUGH.Okex_V5_Swap,
            //                AccountName = dItem.ccy,
            //                AccountValue = dItem.availEq,
            //                AccountCurrency = dItem.crossLiab
            //            };
            //            acDList.Add(selfAcData);
            //        }
            //    }

            //    this.m_accounts.Clear();
            //    this.m_accounts = acDList;

            //    OnAccount(acDList);

            //    args.Msg = "Okex-V5登陆成功，账户查询成功！";
            //    args.Level = 1;

            //    this.OnLog(args);
        }

        public override void Connect()
        {

        }

        public override void Login()
        {

        }

        protected override List<AccountData> QueryAccount()
        {
            return AccountData;
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
            return null;
        }

        public override bool QueryContract(ContractRequest cQ)
        {
            QueryV5Contract(cQ);
            return true;
        }

        public override void SendOrder(OrderRequest orderReq)
        {
            SendV5Order(orderReq);
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
            //对于OKexV5来说，在这里直接订阅所有行情推送-也可以按照合约订阅，后面可以优化
            //
            if (null == m_timerQueryMarket)
            {
                m_timerQueryMarket = new System.Threading.Timer(QueryRealDepthMarketData, null, 0, 500);
            }
        }

        private void QueryRealDepthMarketData(object state)
        {
            try
            {
                QueryV5TickData(Product.SPOT);
                QueryV5TickData(Product.FUTURES);
                QueryV5TickData(Product.INDEX);
                QueryV5TickData(Product.OPTION);
            }
            catch(System.Net.WebException ex)
            {
                Debug.WriteLine(ex.Message);
            }
           
        }

        private void QueryTradeData(object state)
        {
            //轮询账户
            QueryV5Account();

            //轮询持仓
            QueryV5Position();

            //轮询交易
            QueryV5Trade();

            //轮询委托
            QueryV5Order();
        }

        public override void Close()
        {

        }


    }
}
