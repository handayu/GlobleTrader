using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProxy
{
    public class FutuProxy : BaseProxy
    {
        public override void Init(LoginRequest loginData)
        {
            
        }
        public override void Close()
        {
            return;
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
            return true;
        }

        public override void QueryHistory(HistoryRequest hisData)
        {
            //throw new NotImplementedException();
        }


    }
}
