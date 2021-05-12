using Newtonsoft.Json.Linq;
using OKExSDK;
using OKExSDK.Models;
using OKExSDK.Models.Swap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using swap = OKExSDK.Models.Swap;

namespace TestProxy
{
    public class OkexProxy_V3 : BaseProxy
    {
        //string api = this.textBox_apikey.Text;
        //string ser = this.textBox_serkets.Text;
        //string pas = this.textBox_passphear.Text;


        //ConnectManager.CreateInstance().CONNECTION.AnsyLoginEvent += AnsyLoginSubEvent;

        //    //查合约
        //    ConnectManager.CreateInstance().CONNECTION.AnsyGetInsEvent += AnsyGetInsSubEvent;

        //    //查成交-委托-持仓
        //    ConnectManager.CreateInstance().CONNECTION.AnsyOrderEvent += AnsyOrderSubEvent;
        //    ConnectManager.CreateInstance().CONNECTION.AnsyPositionEvent += AnsyPositionSubEvent;
        //    ConnectManager.CreateInstance().CONNECTION.AnsyTradeEvent += AnsyTradeSubEvent;


        //    //主FormLiad的时候已经初始化生成了对象现在给值---登陆
        //    ConnectManager.CreateInstance().CONNECTION.InitApiLogin(api, ser, pas);

        //    //开始开启永续和币币交易线程推送实时行情
        //    ConnectManager.CreateInstance().CONNECTION.StartThreadTicker();
        //    ConnectManager.CreateInstance().CONNECTION.StartSpotThreadTicker();


        //    m_BackgroundWorker.DoWork += BGWorker_DoWork;
        //    m_BackgroundWorker.RunWorkerAsync();

        private SwapApi m_swapApi = null;/*new SwapApi(loginInfo.SwapApiKey, loginInfo.SwapSecret, loginInfo.SwapPassPhrase)*/

        //swap深度tick报价需要轮询处理，这里使用定时器，在订阅的时候->转为定时器轮询，然后广播，订阅的行为背后是轮询实现的，不是后台主动推送
        private System.Threading.Timer m_timer = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="proxyName"></param>
        public OkexProxy_V3(PROXYTHROUGH proxyThrough)
        {
            this.m_proxyThroughEnum = proxyThrough;
            //m_api = new CToShareAPI();
            //m_OnHisDataThread = new System.Threading.Thread(new ParameterizedThreadStart(BrocastHisData));
        }


        /// <summary>
        /// 查询历史重载-可以直接调基类回调返回
        /// </summary>
        public override void QueryHistory(HistoryRequest hisData)
        {
            /// <param name="granularity">时间粒度，以秒为单位，必须为60的倍数</param>

            string symbol = hisData.Symbol;
            //DateTime sT = hisData.STime;
            //DateTime eT = hisData.eTime;
            int interVal = OkexCommon.GetOkexInterval(hisData.Interval);

            DateTime startTime = DateTime.Now.AddMinutes(-240);
            DateTime endTime = DateTime.Now;//格式可能有误，暂时在下面方法填写的null返回默认200根处理

            //异步方法，相当于新开一个线程执行该方法-使得异步多线程操作更简洁
            AnsyGetKLineSwap(symbol, startTime, endTime, interVal,hisData);
            return;
        }

        public override void Init(LoginRequest loginData)
        {
            if (m_swapApi == null)
            {
                //key- secr - phrease
                m_swapApi = new SwapApi(loginData.IP, loginData.Port, loginData.Exdata);
                this.m_mdIsLogin = true;
                this.m_tdIsLogin = true;
                AnsyAccountsSwap();
            }
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
            //throw new NotImplementedException();
            return null;

        }

        public override bool QueryContract(ContractRequest cQ)
        {
            AnsyGetInstrumentsSwap();
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
            //对于OKex来说，在这里直接订阅所有行情推送
            //
            if (null == m_timer)
            {
                m_timer = new System.Threading.Timer(QuerySpotRealDepthMarketData, null, 0, 500);
            }
        }

        private void QuerySpotRealDepthMarketData(object state)
        {
            AnsyGetMarketDepthDataSwap();
        }

        public override void Close()
        {
            //throw new NotImplementedException();
            m_swapApi = null;
            this.m_mdIsLogin = false;
            this.m_tdIsLogin = false;
        }

        /// <summary>
        /// 获取永续合约信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async Task AnsyGetInstrumentsSwap()
        {
            if (m_swapApi == null) return;

            LogData log = new LogData();

            try
            {
                var resResult = await m_swapApi.getInstrumentsAsync();
                if (resResult.Type == JTokenType.Object)
                {
                    JToken codeJToken;
                    if (((JObject)resResult).TryGetValue("code", out codeJToken))
                    {
                        var errorInfo = resResult.ToObject<ErrorResult>();

                        log.Msg = errorInfo.message;
                        log.Level = 0;

                        this.OnLog(log);
                    }
                }
                else
                {
                    List<swap.Instrument> instruments = resResult.ToObject<List<swap.Instrument>>();
                    List<ContractData> conDataList = new List<ContractData>();
                    foreach (swap.Instrument sI in instruments)
                    {
                        ContractData d = new ContractData()
                        {
                            Symbol = sI.instrument_id,
                            Exchange = Exchange.OKEX,
                            Proxy = PROXYTHROUGH.Okex_V3_Swap,
                            Product = Product.COIN,
                            MinVolume = (double)sI.size_increment
                        };

                        if (!conDataList.Contains(d)) conDataList.Add(d);
                    }

                    //缓存
                    m_contracts = conDataList;

                    //发布
                    this.OnContract(conDataList);
                }
            }
            catch (Exception ex)
            {
                log.Msg = ex.Message;
                log.Level = 0;

                this.OnLog(log);
            }
        }
        /// <summary>
        /// 获取永续合约账户信息
        /// </summary>
        /// <returns></returns>
        private async Task AnsyAccountsSwap()
        {
            LogData args = new LogData();

            try
            {
                var resResult = await this.m_swapApi.getAccountsAsync();
                JToken codeJToken;
                if (resResult.TryGetValue("code", out codeJToken))
                {
                    var errorInfo = resResult.ToObject<ErrorResult>();

                    args.Msg = errorInfo.message;
                    args.Level = 1;

                    this.OnLog(args);
                }
                else
                {
                    swap.AccountsResult accountsInfo = resResult.ToObject<swap.AccountsResult>();
                    List<Account> swapAccount = accountsInfo.info;

                    List<AccountData> acDList = new List<AccountData>();
                    foreach (Account a in swapAccount)
                    {
                        AccountData selfAcData = new AccountData()
                        {
                            Proxy = PROXYTHROUGH.Okex_V3_Swap,
                            AccountName = a.instrument_id,
                            AccountValue = a.equity,
                            AccountCurrency = "USD"
                        };
                        acDList.Add(selfAcData);                
                    }

                    this.m_accounts.Clear();
                    this.m_accounts = acDList;

                    OnAccount(acDList);

                    args.Msg = "Okex-V3登陆成功，账户查询成功！";
                    args.Level = 1;

                    this.OnLog(args);
                }
            }
            catch (System.Net.WebException ex)
            {
                args.Msg = ex.Message;
                args.Level = 1;
                this.OnLog(args);
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                args.Msg = ex.Message;
                args.Level = 1;
                this.OnLog(args);
            }
            catch (System.Net.HttpListenerException ex)
            {
                args.Msg = ex.Message;
                args.Level = 1;
                this.OnLog(args);
            }
            catch (Exception ex)
            {
                args.Msg = ex.Message + ":由于计算机长时间未登陆到远程主机，请查询网络连接后重试...";
                args.Level = 1;
                this.OnLog(args);
            }
        }

        /// <summary>
        /// 获取永续合约K线历史数据
        /// </summary>
        /// "BTC-USD-SWAP", DateTime.UtcNow.AddMinutes(-1), DateTime.UtcNow, 60
        /// </summary>
        /// <param name="instrument_id">合约名称，如BTC-USD-SWAP</param>
        /// <param name="start">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <param name="granularity">时间粒度，以秒为单位，必须为60的倍数</param>
        /// <returns></returns>
        /// <param name="e"></param>
        private async Task AnsyGetKLineSwap(string ins, DateTime startTime, DateTime endTime, int frame,HistoryRequest rq)
        {
            //之前的这里的K线解析有问题，所以改用下面的根据字符串暴力解析
            //try
            //{
            //    var resResult = await m_swapApi.getCandlesDataAsync(ins, startTime, endTime, frame);
            //    if (resResult.Type == JTokenType.Object)
            //    {
            //        JToken codeJToken;
            //        if (((JObject)resResult).TryGetValue("code", out codeJToken))
            //        {
            //            var errorInfo = resResult.ToObject<ErrorResult>();
            //            AIEventArgs args = new AIEventArgs()
            //            {
            //                EventData = errorInfo,
            //                ReponseMessage = RESONSEMESSAGE.HOLDKLINE_FAILED
            //            };

            //            SafeRiseAnsyKLineEvent(args);
            //        }
            //    }
            //    else
            //    {
            //        var candles = resResult.ToObject<TestData.klineRoot>();
            //        AIEventArgs args = new AIEventArgs()
            //        {
            //            EventData = candles,
            //            ReponseMessage = RESONSEMESSAGE.HOLDKLINE_SUCCESS
            //        };

            //        SafeRiseAnsyKLineEvent(args);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    AIEventArgs args = new AIEventArgs()
            //    {
            //        EventData = ex,
            //        ReponseMessage = RESONSEMESSAGE.HOLDKLINE_FAILED
            //    };

            //    SafeRiseAnsyKLineEvent(args);
            //}

            //之前的这里的K线解析有问题，所以改用下面的暴力解析
            //  {[
            //  [
            //    "2019-04-27T10:27:00Z",
            //    "5152.4",
            //    "5152.4",
            //    "5152.4",
            //    "5152.4",
            //    "0",
            //    "0"
            //  ],
            //  [
            //    "2019-04-27T10:26:00Z",
            //    "5154.4",
            //    "5154.4",
            //    "5152.4",
            //    "5152.4",
            //    "197",
            //    "3.8225"
            //  ]
            //  ]}

            LogData args = new LogData();

            try
            {
                var resResult = await m_swapApi.getCandlesDataAsync(ins, null, null, frame);//这里暂时开始/结束时间都用null处理，好像是传入的时区时间格式的问题，都传Null目前返回到当前200根临时处理
                if (resResult.Type == JTokenType.Object)
                {
                    JToken codeJToken;
                    if (((JObject)resResult).TryGetValue("code", out codeJToken))
                    {
                        var errorInfo = resResult.ToObject<ErrorResult>();
                        args.Msg = errorInfo.message;
                        args.Level = 0;
                        args.Proxy = PROXYTHROUGH.Okex_V3_Swap;
                        this.OnLog(args);
                    }
                }
                else
                {
                    List<JToken> jList = resResult.Root.ToList();
                    if (jList == null || jList.Count <= 0) return;

                    //这里okex返回来的数据是正向的序列，需要返转为正常的时间序列，再发布出去
                    jList.Reverse();
                    //List<JToken> jListReserve = new List<JToken>();
                    //for (int i = jList.Count -1;i>=0;i--)
                    //{
                    //    jListReserve.Add(jList[i]);
                    //}

                    List<BarData> bList = new List<BarData>();
                    foreach (JToken j in jList)
                    {
                        BarData okLine = new BarData()
                        {
                            Symbol = ins,
                            Proxy = rq.Proxy,
                            DTime = ((DateTime)j[0]).AddHours(8),//将返回来的utc时区时间转换为北京时间
                            OpenPrice = (double)j[1],
                            HighPrice = (double)j[2],
                            LowPrice = (double)j[3],
                            ClosePrice = (double)j[4],
                            //unkonwn1 = (decimal)j[5],
                            //unkonwn2 = (decimal)j[6],
                            Exchange = Exchange.OKEX,
                            Interval = rq.Interval


                        };
                        bList.Add(okLine);

                        //缓存 - 因为这里有可能查到很多历史数据，且不同周期的数据，所以基类的List<>需要再考虑，
                        //且是否进缓存要考虑
                        //if(m_)
                    }

                    //发布
                    this.OnBar(bList);
                }
            }
            catch (Exception ex)
            {
                args.Msg = ex.Message;
                args.Level = 0;
                args.Proxy = PROXYTHROUGH.Okex_V3_Swap;
                this.OnLog(args);
            }

        }
        /// <summary>
        /// 获取永续合约深度报价-所有合约
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async Task AnsyGetMarketDepthDataSwap()
        {
            LogData args = new LogData();

            try
            {
                var resResult = await m_swapApi.getTickersAsync();
                if (resResult.Type == JTokenType.Object)
                {
                    JToken codeJToken;
                    if (((JObject)resResult).TryGetValue("code", out codeJToken))
                    {
                        var errorInfo = resResult.ToObject<ErrorResult>();

                        args.Msg = errorInfo.message;
                        args.Level = 1;
                        this.OnLog(args);
                    }
                }
                else
                {
                    List<swap.Ticker> ticker = resResult.ToObject<List<swap.Ticker>>();
                    List<TickData> tDList = new List<TickData>();
                    foreach (swap.Ticker t in ticker)
                    {
                        TickData tD = new TickData();
                        tD.Symbol = t.instrument_id;
                        tD.Proxy = PROXYTHROUGH.Okex_V3_Swap;
                        tD.Name = t.instrument_id;
                        tD.Exchange = Exchange.OKEX;
                        tD.DTime = t.timestamp.AddHours(8);//转换时区为中国时区
                        tD.LastPrice = (double)t.last;
                        tD.HighPrice = (double)t.last;
                        tD.LowPrice = (double)t.last;
                        tD.PreClose = (double)t.last;//？在这里HLC用last替代是因为三个其实是一样的，而且okex swap这里不提供五档等数据。
                        tD.OpenInterest = t.volume_24h;//?这里只有24小时的成交量，没有tick的，所以在这里暂时替代用这个

                        tDList.Add(tD);
                    }
                    this.OnTick(tDList);
                }
            }
            catch (Exception ex)
            {
                args.Msg = ex.Message;
                args.Level = 1;
                this.OnLog(args);
            }
        }
    }
}
