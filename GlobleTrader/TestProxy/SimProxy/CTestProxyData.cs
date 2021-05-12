using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProxy
{
    public static class CTestProxyData
    {
        private static Random randtick = new Random();
        private static double openTick = 50.0;
        private static DateTime dateTimeTick = DateTime.Now;
        /// <summary>
        /// 获取品种随机Tick信息
        /// </summary>
        public static List<TickData> GetRadomTickSymbolDatas()
        {
            List<TickData> l = new List<TickData>();
            TickData td = new TickData();
            td.DTime = DateTime.Now;
            td.Symbol = "Symbol001";
            td.Proxy = PROXYTHROUGH.Demo;
            td.Exchange = Exchange.NULL;
            td.LastPrice = Math.Round(openTick + randtick.NextDouble() * 10.0 - 5.0,2);//保留两位
            openTick = td.LastPrice;
            l.Add(td);
            return l;
        }

        /// <summary>
        /// 获取品种信息
        /// </summary>
        public static List<ContractData> GetSymbols()
        {
            List<ContractData> cdList = new List<ContractData>();
            ContractData cD = new ContractData();
            cD.Exchange = Exchange.NULL;
            cD.Symbol = "Symbol001";
            cD.Proxy = PROXYTHROUGH.Demo;
            cD.Product = Product.NULL;
            cdList.Add(cD);
            return cdList;
        }

        private static Random rand = new Random();
        private static double open = 50.0;
        private static DateTime dateTime = DateTime.Now.AddYears(-1);
        /// <summary>
        /// 获取品种Bar历史信息
        /// </summary>
        public static List<BarData> GetRadomBarSymbolDatas(HistoryRequest hisData)
        {
            List<BarData> bList = new List<BarData>();

            //返回仿真的五分钟历史数据
            for (int i = 0; i < 500; i++)
            {
                BarData bD = new BarData();
                bD.Symbol = "Symbol001";
                bD.Proxy = PROXYTHROUGH.Demo;
                bD.Exchange = Exchange.NULL;

                switch (hisData.Interval)
                {
                    case Interval.Minute_1:
                        bD.DTime = dateTime.AddMinutes(1);
                        break;
                    case Interval.Minute_3:
                        bD.DTime = dateTime.AddMinutes(3);
                        break;
                    case Interval.Minute_5:
                        bD.DTime = dateTime.AddMinutes(5);
                        break;
                    case Interval.Minute_15:
                        bD.DTime = dateTime.AddMinutes(15);
                        break;
                    case Interval.Minute_30:
                        bD.DTime = dateTime.AddMinutes(30);
                        break;
                    case Interval.Hour_1:
                        bD.DTime = dateTime.AddHours(1);
                        break;
                    case Interval.Hour_2:
                        bD.DTime = dateTime.AddHours(2);
                        break;
                    case Interval.Hour_4:
                        bD.DTime = dateTime.AddHours(4);
                        break;
                    case Interval.Day_1:
                        bD.DTime = dateTime.AddDays(1);
                        break;
                    case Interval.Month_1:
                        bD.DTime = dateTime.AddMonths(1);
                        break;
                    case Interval.Tick:
                        bD.DTime = dateTime.AddSeconds(1);
                        break;
                    case Interval.Week_1:
                        bD.DTime = dateTime.AddDays(7);
                        break;
                    default:
                        break;
                }

                bD.OpenPrice = open;
                bD.ClosePrice = open + rand.NextDouble() * 10.0 - 5.0;
                bD.HighPrice = Math.Max(open, bD.ClosePrice) + rand.NextDouble() * 5.0;
                bD.LowPrice = Math.Min(open, bD.ClosePrice) - rand.NextDouble() * 3.0;
                bD.Interval = hisData.Interval;

                open = bD.ClosePrice;
                dateTime = bD.DTime;

                bList.Add(bD);
            }

            return bList;
        }


    }
}
