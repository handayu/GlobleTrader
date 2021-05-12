using IBApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IBDLL;
using IBSampleApp;
using IBSampleApp.messages;

/// <summary>
/// 只维护最原始API，返回的响应统一进队列
/// </summary>
namespace TestProxy
{
    public class CIBProxy : BaseProxy
    {
        private IBClient m_ibClient;
        private EReaderMonitorSignal m_signal;
        private int m_reqID = -1;

        public CIBProxy(PROXYTHROUGH proxyThrough)
        {
            m_signal = new EReaderMonitorSignal();
            m_ibClient = new IBClient(m_signal);

            this.m_proxyThroughEnum = proxyThrough;

            m_ibClient.Error += OnRspError;
            // m_ibClient.ConnectionClosed += ibClient_ConnectionClosed;
            // m_ibClient.CurrentTime += time => addTextToBox("Current Time: " + time + "\n");
            // m_ibClient.TickPrice += ibClient_Tick;
            // m_ibClient.TickSize += ibClient_Tick;
            // m_ibClient.TickString += (tickerId, tickType, value) => addTextToBox("Tick string. Ticker Id:" + tickerId + ", Type: " + TickType.getField(tickType) + ", Value: " + value + "\n");
            // m_ibClient.TickGeneric += (tickerId, field, value) => addTextToBox("Tick Generic. Ticker Id:" + tickerId + ", Field: " + TickType.getField(field) + ", Value: " + value + "\n");
            // m_ibClient.TickEFP += (tickerId, tickType, basisPoints, formattedBasisPoints, impliedFuture, holdDays, futureLastTradeDate, dividendImpact, dividendsToLastTradeDate) => addTextToBox("TickEFP. " + tickerId + ", Type: " + tickType + ", BasisPoints: " + basisPoints + ", FormattedBasisPoints: " + formattedBasisPoints + ", ImpliedFuture: " + impliedFuture + ", HoldDays: " + holdDays + ", FutureLastTradeDate: " + futureLastTradeDate + ", DividendImpact: " + dividendImpact + ", DividendsToLastTradeDate: " + dividendsToLastTradeDate + "\n");
            // m_ibClient.TickSnapshotEnd += tickerId => addTextToBox("TickSnapshotEnd: " + tickerId + "\n");
            // m_ibClient.NextValidId += UpdateUI;
            // m_ibClient.DeltaNeutralValidation += (reqId, deltaNeutralContract) =>
            //     addTextToBox("DeltaNeutralValidation. " + reqId + ", ConId: " + deltaNeutralContract.ConId + ", Delta: " + deltaNeutralContract.Delta + ", Price: " + deltaNeutralContract.Price + "\n");

            // m_ibClient.ManagedAccounts += UpdateUI;
            // m_ibClient.TickOptionCommunication += HandleTickMessage;

            m_ibClient.AccountSummary += OnRspIBClientAccount;
            m_ibClient.AccountSummaryEnd += OnRspIBClientAccountEnd;
            // m_ibClient.UpdateAccountValue += accountManager.HandleAccountValue;
            // m_ibClient.UpdatePortfolio += UpdateUI;

            // m_ibClient.UpdateAccountTime += message => accUpdatesLastUpdateValue.Text = message.Timestamp;
            // //ibClient.AccountDownloadEnd += (do nothing)
            // m_ibClient.OrderStatus += orderManager.HandleOrderStatus;

            // m_ibClient.OpenOrder += orderManager.handleOpenOrder;
            // //ibClient.OpenOrderEnd += (do nothing)
            //m_ibClient.ContractDetails += HandleContractDataMessage;
            //m_ibClient.ContractDetailsEnd += reqId => UpdateUI(new ContractDetailsEndMessage());
            // m_ibClient.ExecDetails += orderManager.HandleExecutionMessage;
            // m_ibClient.ExecDetailsEnd += reqId => addTextToBox("ExecDetailsEnd. " + reqId + "\n");
            // m_ibClient.CommissionReport += commissionReport => orderManager.HandleCommissionMessage(new CommissionMessage(commissionReport));
            // m_ibClient.FundamentalData += UpdateUI;

            // m_ibClient.HistoricalData += historicalDataManager.UpdateUI;
            // m_ibClient.HistoricalDataUpdate += historicalDataManager.UpdateUI;
            // m_ibClient.HistoricalDataEnd += historicalDataManager.UpdateUI;

            // m_ibClient.MarketDataType += UpdateUI;
            // m_ibClient.UpdateMktDepth += deepBookManager.UpdateUI;
            // m_ibClient.UpdateMktDepthL2 += deepBookManager.UpdateUI;
            // m_ibClient.UpdateNewsBulletin += (msgId, msgType, message, origExchange) =>
            //     addTextToBox("News Bulletins. " + msgId + " - Type: " + msgType + ", Message: " + message + ", Exchange of Origin: " + origExchange + "\n");

            //m_ibClient.Position += accountManager.HandlePosition;
            //m_ibClient.PositionEnd += () => addTextToBox("PositionEnd \n");
            //m_ibClient.RealtimeBar += realTimeBarManager.UpdateUI;
            //m_ibClient.ScannerParameters += xml => scannerManager.UpdateUI(new ScannerParametersMessage(xml));
            //m_ibClient.ScannerParameters += UpdateUi;
            //m_ibClient.ScannerData += scannerManager.UpdateUI;
            //m_ibClient.ScannerDataEnd += reqId => addTextToBox("ScannerDataEnd. " + reqId + "\r\n");
            //m_ibClient.ReceiveFA += advisorManager.UpdateUI;
            //m_ibClient.BondContractDetails += contractManager.HandleBondContractMessage;
            //m_ibClient.VerifyMessageAPI += apiData => addTextToBox("verifyMessageAPI: " + apiData);
            //m_ibClient.VerifyCompleted += (isSuccessful, errorText) => addTextToBox("verifyCompleted. IsSuccessfule: " + isSuccessful + " - Error: " + errorText);
            //m_ibClient.VerifyAndAuthMessageAPI += (apiData, xyzChallenge) => addTextToBox("verifyAndAuthMessageAPI: " + apiData + " " + xyzChallenge);
            //m_ibClient.VerifyAndAuthCompleted += (isSuccessful, errorText) => addTextToBox("verifyAndAuthCompleted. IsSuccessfule: " + isSuccessful + " - Error: " + errorText);
            //m_ibClient.DisplayGroupList += (reqId, groups) => addTextToBox("DisplayGroupList. Request: " + reqId + ", Groups" + groups);
            //m_ibClient.DisplayGroupUpdated += (reqId, contractInfo) => addTextToBox("displayGroupUpdated. Request: " + reqId + ", ContractInfo: " + contractInfo);
            //m_ibClient.PositionMulti += acctPosMultiManager.HandlePositionMulti;
            //m_ibClient.PositionMultiEnd += reqId => acctPosMultiManager.HandlePositionMultiEnd(new PositionMultiEndMessage(reqId));
            //m_ibClient.AccountUpdateMulti += acctPosMultiManager.HandleAccountUpdateMulti;
            //m_ibClient.AccountUpdateMultiEnd += reqId => acctPosMultiManager.HandleAccountUpdateMultiEnd(new AccountUpdateMultiEndMessage(reqId));
            // m_ibClient.SecurityDefinitionOptionParameter += optionsManager.UpdateUI;
            // //ibClient.SecurityDefinitionOptionParameterEnd += (do nothing)
            // m_ibClient.SoftDollarTiers += orderManager.HandleSoftDollarTiers;
            // m_ibClient.FamilyCodes += (familyCodes) => accountManager.HandleFamilyCodes(new FamilyCodesMessage(familyCodes));
            // m_ibClient.SymbolSamples += UpdateUI;
            // m_ibClient.MktDepthExchanges += (depthMktDataDescriptions) => deepBookManager.HandleMktDepthExchangesMessage(new MktDepthExchangesMessage(depthMktDataDescriptions));
            // m_ibClient.TickNews += newsManager.UpdateUI;
            // m_ibClient.TickReqParams += UpdateUI;
            // m_ibClient.SmartComponents += (reqId, theMap) => theMap.ToList().ForEach(i => dataGridViewSmartComponents.Rows.Add(new object[] { i.Key, i.Value.Key, i.Value.Value }));
            // m_ibClient.NewsProviders += (newsProviders) => newsManager.HandleNewsProviders(new NewsProvidersMessage(newsProviders));
            // m_ibClient.NewsArticle += newsManager.UpdateUI;
            // m_ibClient.HistoricalNews += newsManager.UpdateUI;
            // m_ibClient.HistoricalNewsEnd += newsManager.UpdateUI;
            // m_ibClient.HeadTimestamp += UpdateUI;
            // m_ibClient.HistogramData += UpdateUI;
            // m_ibClient.RerouteMktDataReq += (reqId, conId, exchange) => addTextToBox("Re-route market data request. ReqId: " + reqId + ", ConId: " + conId + ", Exchange: " + exchange + "\n");
            // m_ibClient.RerouteMktDepthReq += (reqId, conId, exchange) => addTextToBox("Re-route market depth request. ReqId: " + reqId + ", ConId: " + conId + ", Exchange: " + exchange + "\n");
            // m_ibClient.MarketRule += contractManager.HandleMarketRuleMessage;
            // m_ibClient.pnl += msg => pnldataTable.Rows.Add(msg.DailyPnL, msg.UnrealizedPnL, msg.RealizedPnL);
            // m_ibClient.pnlSingle += msg => pnlSingledataTable.Rows.Add(msg.Pos, msg.DailyPnL, msg.UnrealizedPnL, msg.RealizedPnL, msg.Value);
            // m_ibClient.historicalTick += UpdateUI;
            // m_ibClient.historicalTickBidAsk += UpdateUI;
            // m_ibClient.historicalTickLast += UpdateUI;
            // m_ibClient.tickByTickAllLast += UpdateUI;
            // m_ibClient.tickByTickBidAsk += UpdateUI;
            // m_ibClient.tickByTickMidPoint += UpdateUI;
            // m_ibClient.OrderBound += msg => addTextToBox("Order bound. OrderId: " + msg.OrderId + ", ApiClientId: " + msg.ApiClientId + ", ApiOrderId: " + msg.ApiOrderId);
            // m_ibClient.CompletedOrder += orderManager.handleCompletedOrder;
        }

        /// <summary>
        /// 账户返回结束
        /// </summary>
        /// <param name="obj"></param>
        private void OnRspIBClientAccountEnd(IBSampleApp.messages.AccountSummaryEndMessage obj)
        {
            AccountData ac = new AccountData();
            ac.AccountName = m_as.Account;
            ac.AccountCurrency = m_as.Currency;
            ac.AccountValue = m_as.Value;

            //更新内存
            this.m_accounts.Clear();
            this.m_accounts.Add(ac);

            List<AccountData> aDList = new List<AccountData>();
            aDList.Add(ac);
            //广播
            OnAccount(aDList);
        }

        private AccountSummaryMessage m_as = new AccountSummaryMessage(0, "", "", "", "");
        /// <summary>
        /// 账户返回 - 插入缓存 - 对外广播
        /// </summary>
        /// <param name="obj"></param>
        private void OnRspIBClientAccount(IBSampleApp.messages.AccountSummaryMessage obj)
        {
            //这里比较特殊，因为返回值一直在变化，所以这里只改变返回的对象，到end标志返回里进行缓存和广播
            if (null == obj) return;
            m_as.Account = obj.Account;
            m_as.Currency = obj.Currency;
            m_as.RequestId = obj.RequestId;
            m_as.Tag = obj.Tag;
            m_as.Value = obj.Value;
        }

        /// <summary>
        /// 内部请求账户
        /// </summary>
        private void ReqIBAccount()
        {
            bool accountSummaryRequestActive = false;
            int ACCOUNT_ID_BASE = 50000000;
            int ACCOUNT_SUMMARY_ID = ACCOUNT_ID_BASE + 1;

            string ACCOUNT_SUMMARY_TAGS = "AccountType,NetLiquidation,TotalCashValue,SettledCash,AccruedCash,BuyingPower,EquityWithLoanValue,PreviousEquityWithLoanValue,"
             + "GrossPositionValue,ReqTEquity,ReqTMargin,SMA,InitMarginReq,MaintMarginReq,AvailableFunds,ExcessLiquidity,Cushion,FullInitMarginReq,FullMaintMarginReq,FullAvailableFunds,"
             + "FullExcessLiquidity,LookAheadNextChange,LookAheadInitMarginReq ,LookAheadMaintMarginReq,LookAheadAvailableFunds,LookAheadExcessLiquidity,HighestSeverity,DayTradesRemaining,Leverage";

            if (!accountSummaryRequestActive)
            {
                accountSummaryRequestActive = true;
                m_ibClient.ClientSocket.reqAccountSummary(ACCOUNT_SUMMARY_ID, "All", ACCOUNT_SUMMARY_TAGS);
            }
            else
            {
                m_ibClient.ClientSocket.cancelAccountSummary(ACCOUNT_SUMMARY_ID);
            }
        }

        public override void Init(LoginRequest loginData)
        {
            if (loginData == null) return;
            string ip = loginData.IP;
            string port = loginData.Port;
            string client_id = loginData.Exdata;

            if (ip == null || ip.Equals(""))
                ip = "127.0.0.1";
            try
            {
                m_ibClient.ClientId = Int32.Parse(client_id);
                m_ibClient.ClientSocket.eConnect(ip, Int32.Parse(port), m_ibClient.ClientId);

                var reader = new EReader(m_ibClient.ClientSocket, m_signal);

                reader.Start();

                new Thread(() => { while (m_ibClient.ClientSocket.IsConnected()) { m_signal.waitForSignal(); reader.processMsgs(); } }) { IsBackground = true }.Start();

                //查询主动查询一遍 资金- 持仓- 委托 - 成交 - 合约？返回：1.存入到base的缓存 - 缓存统一的数据类型；2.对外基类发布出去 - 发布统一的数据类型
                //之所以不再外部填参查询，就是为了不暴露各自独立的接口入参，如果进行统一，会造成巨大的接口参数冗余和参数适配问题
                this.m_mdIsLogin = true;
                this.m_tdIsLogin = true;

                //全部查询一遍
                ReqIBAccount();
                //.....
            }
            catch (Exception ex)
            {
                OnRspError(-1, -1, "Please check your connection attributes.", ex);
                m_mdIsLogin = false;
                m_tdIsLogin = false;
                m_ibClient.ClientSocket.eDisconnect();
            }
        }
        public override void Close()
        {
            if (m_mdIsLogin || m_tdIsLogin) m_ibClient.ClientSocket.eDisconnect();
            return;
        }

        private void OnRspError(int id, int errorCode, string str, Exception ex)
        {
            LogData d = new LogData();
            d.Proxy = PROXYTHROUGH.IB;
            d.Level = 0;
            d.Msg = str;

            OnLog(d);
        }

        public override void Connect()
        {
            return;
        }

        public override void Login()
        {
            return;
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
            this.m_ibClient.ClientSocket.reqMatchingSymbols(++m_reqID, cQ.Symbol);
            return true;
        }

        public override void QueryHistory(HistoryRequest hisData)
        {
            //throw new NotImplementedException();
        }

    }
}
