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
    public class CTestProxy : BaseProxy
    {
        //推行情
        private System.Threading.Thread m_OnMarketDataEvent;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="proxyName"></param>
        public CTestProxy(PROXYTHROUGH proxyThrough)
        {
            this.m_proxyThroughEnum = proxyThrough;

            m_OnMarketDataEvent = new System.Threading.Thread(BroadCastMarketdataEvent);

        }


        /// <summary>
        /// 查询历史重载-可以直接调基类回调返回
        /// </summary>
        public override void QueryHistory(HistoryRequest hisData)
        {
            List<BarData> hisBarList = CTestProxyData.GetRadomBarSymbolDatas(hisData);
            this.OnBar(hisBarList);
            return;
        }

        public override void Init(LoginRequest loginData)
        {
            if (this.m_mdIsLogin == false || this.m_tdIsLogin == false)
            {
                this.m_mdIsLogin = true;
                this.m_tdIsLogin = true;

                //查账户
                QueryAccount();

                //查持仓
                QueryPosition();

                //查委托
                QueryOrder();

                //查成交
                QueryTrade();
            }
        }

        public override void Connect()
        {
        }

        public override void Login()
        {
        }

        protected override List<AccountData> QueryAccount()
        {
            //LogData args = new LogData();

            //try
            //{
            //    List<Account> swapAccount = accountsInfo.info;

            //    List<AccountData> acDList = new List<AccountData>();
            //    foreach (Account a in swapAccount)
            //    {
            //        AccountData selfAcData = new AccountData()
            //        {
            //            AccountName = a.instrument_id,
            //            AccountValue = a.equity,
            //            AccountCurrency = "USD"
            //        };
            //        acDList.Add(selfAcData);

            //        this.m_accounts.Clear();
            //        this.m_accounts.Add(selfAcData);
            //    }

            //    OnAccount(acDList);

            //    args.Msg = "登陆成功，账户查询成功！";
            //    args.Level = 1;
            //    this.OnLog(args);

            //}
            //catch (Exception ex)
            //{
            //    args.Msg = ex.Message + ":由于计算机长时间未登陆到远程主机，请查询网络连接后重试...";
            //    args.Level = 1;
            //    this.OnLog(args);
            //}


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
            List<ContractData> cList = CTestProxyData.GetSymbols();

            this.ContractData.Clear();
            this.ContractData.AddRange(cList);

            this.OnContract(cList);

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

        private bool m_isMDThreadStart = false;
        public override void SubScribe(SubscribeRequest sQ)
        {
            if (false == m_isMDThreadStart)
            {
                m_OnMarketDataEvent.Start();
                m_isMDThreadStart = true;
            }
        }

        public override void Close()
        {
            this.m_mdIsLogin = false;
            this.m_tdIsLogin = false;

            if(this.m_OnMarketDataEvent != null && this.m_OnMarketDataEvent.IsAlive)
            {
                this.m_OnMarketDataEvent.Abort();
                System.Threading.Thread.Sleep(3000);
            }
        }

        private void BroadCastMarketdataEvent()
        {
            while (true)
            {

                List<TickData> tList = CTestProxyData.GetRadomTickSymbolDatas();

                this.OnTick(tList);
                System.Threading.Thread.Sleep(1000);
            }
        }

    }
}

