using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProxy
{
    public class CMyMDApi : CBaseDemoMDSpi
    {
        private CDemoMDApi m_api;
        
        /// <summary>
        /// 线程安全的回调队列
        /// </summary>
        private ConcurrentQueue<SpiStruct> m_spiQueue = new ConcurrentQueue<SpiStruct>();

        /// <summary>
        /// 对外属性
        /// </summary>
        public ConcurrentQueue<SpiStruct> SpiQueue
        {
            get
            {
                return m_spiQueue;
            }
        }

        //虚拟队列回推行情
        private System.Threading.Thread m_OnMarketDataEvent;

        private bool m_isMDInit = false;
        public bool ISMdInit
        {
            get
            {
                return m_isMDInit;
            }
            set
            {
                m_isMDInit = value;
            }
        }

        private bool m_isMDLogin = false;
        public bool ISMdLogin
        {
            get
            {
                return m_isMDLogin;
            }
            set
            {
                m_isMDLogin = value;
            }
        }

        public CMyMDApi()
        {

            m_OnMarketDataEvent = new System.Threading.Thread(BroadCastMarketdataEvent);
        }

        public void CreateMdApi()
        {
            m_api = new CDemoMDApi();
        }

        public string GetApiVersion()
        {
            if (m_api != null)
                return m_api.GetApiVersion();
            return "";
        }

        public void Release()
        {
            if(m_api != null)
            m_api.Release();
        }

        public void Init()
        {
            if (m_api != null)
                 m_api.Init();
        }

        public void Join()
        {
            if (m_api != null)
                 m_api.Join();
        }

        public DateTime GetTradingDay()
        {
            if (m_api != null)
                return m_api.GetTradingDay();
            return DateTime.Now;
        }

        public void RegisterFront(string frontAddress)
        {
            if (m_api != null)
                m_api.RegisterFront(frontAddress);
        }

        public void RegisterSpi(CBaseDemoMDSpi userSpi)
        {
            if (m_api != null)
                 m_api.RegisterSpi(userSpi);
        }

        public int SubscribeMarketData(string[] pInstrumentStr, int nCount)
        {
            if (m_api != null)
                return m_api.SubscribeMarketData(pInstrumentStr, nCount);
            return 1;
        }

        public int UnSubscribeMarketData(string[] pInstrumentStr, int nCount)
        {
            if (m_api != null)
                return m_api.UnSubscribeMarketData(pInstrumentStr, nCount);
            return 1;
        }

        public int ReqUserLogin()
        {
            if (m_api != null)
                return m_api.ReqUserLogin();
            return 1;

        }

        public int ReqUserLogout()
        {
            if (m_api != null)
               return m_api.ReqUserLogout();
            return 1;
        }

        public override void OnFrontConnected()
        {
            m_isMDInit = true;
        }

        public override void OnFrontDisconnected(int nReason)
        {
            
        }

        public override void OnHeartBeatWarning(int nTimeLapse)
        {
        }

        public override void OnRspUserLogin()
        {
            SpiStruct s;
            s.spiEventEnum = SPIEVNETEENUM.OnLogin;
            s.spiObject = "";
            m_spiQueue.Enqueue(s);

            m_isMDLogin = true;
        }

        public override void OnRspUserLogout()
        {
            
        }

        public override void OnRspError()
        {
        }

        public override void OnRspSubMarketData()
        {
           
        }

        public override void OnRspUnSubMarketData()
        {
        }

        public override void OnRtnDepthMarketData()
        {
            m_OnMarketDataEvent.Start();
        }

        private void BroadCastMarketdataEvent()
        {
            while(true)
            {
                SpiStruct s = new SpiStruct();
                s.spiEventEnum = SPIEVNETEENUM.OnTick;
                TickData hD = new TickData();
                hD.Symbol = "TestSymbol";
                hD.Volume = 1000;
                hD.Proxy = PROXYTHROUGH.Demo;
                hD.PreClose = 2000;
                hD.OpenPrice = 85.24;
                hD.LowPrice = 81.23;
                hD.LastPrice = 80.24;
                hD.DTime = DateTime.Now;
                hD.Exchange = Exchange.NULL;
                hD.HighPrice = 87.78;

                s.spiObject = hD;
                m_spiQueue.Enqueue(s);

                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
