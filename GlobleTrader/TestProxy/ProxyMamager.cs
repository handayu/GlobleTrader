using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProxy
{

    /// <summary>
    /// 单例模式的实现
    /// </summary>
    public class ProxyManager
    {
        private static ProxyManager Instance;

        //private CMyDemoProxy demoProxy;
        private CTestProxy testProxy;
        private CToShareProxy toShareProxy;
        private CIBProxy iBProxy;
        private OkexProxy_V3 okexProxy_v3;
        private OkexProxy_V5 okexProxy_v5;
        private CSimNowProxy simNowProxy;
        private CSinaProxy sinaProxy;
        private ProxyManager()
        {
            //demoProxy = new CMyDemoProxy(PROXYTHROUGH.Demo);
            testProxy = new CTestProxy(PROXYTHROUGH.Demo);
            toShareProxy = new CToShareProxy(PROXYTHROUGH.TuShare);
            iBProxy = new CIBProxy(PROXYTHROUGH.IB);
            okexProxy_v3 = new OkexProxy_V3(PROXYTHROUGH.Okex_V3_Swap);
            okexProxy_v5 = new OkexProxy_V5(PROXYTHROUGH.Okex_V5_Swap);
            simNowProxy = new CSimNowProxy(PROXYTHROUGH.SimNow);
            sinaProxy = new CSinaProxy(PROXYTHROUGH.Sina);
        }

        public static ProxyManager GetInstance()
        {
            if (Instance == null)
            {
                Instance = new ProxyManager();
            }
            return Instance;
        }



        public BaseProxy GetProxy(PROXYTHROUGH proxyThrough)
        {
            switch (proxyThrough)
            {
                case PROXYTHROUGH.Demo:
                    return testProxy;
                case PROXYTHROUGH.TuShare:
                    return toShareProxy;
                case PROXYTHROUGH.IB:
                    return iBProxy;
                case PROXYTHROUGH.Okex_V3_Swap:
                    return okexProxy_v3;
                case PROXYTHROUGH.Okex_V5_Swap:
                    return okexProxy_v5;
                case PROXYTHROUGH.SimNow:
                    return simNowProxy;
                case PROXYTHROUGH.Sina:
                    return sinaProxy;
                default:
                    break;
            }
            return null;
        }

    }
}


