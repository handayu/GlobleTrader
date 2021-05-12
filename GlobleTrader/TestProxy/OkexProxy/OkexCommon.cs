using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProxy
{
    /// <summary>
    /// Okex工具类，主要是把上层的类型转化为Okex的类型的工具类
    /// </summary>
    public static class OkexCommon
    {
        /// <summary>
        /// Commom标准Interval类型转化为Okex-V3传参的数据类型
        /// </summary>
        /// <param name="interval"></param>
        /// <returns></returns>
        public static int GetOkexInterval(Interval interval)
        {
            /// <param name="granularity">时间粒度，以秒为单位，必须为60的倍数</param>
            switch(interval)
            {
                case Interval.Minute_1:
                    return 60;
                case Interval.Minute_3:
                    return 60 * 3;
                case Interval.Minute_5:
                    return 60 * 5;
                case Interval.Minute_15:
                    return 60 * 15;
                case Interval.Minute_30:
                    return 60 * 30;
                case Interval.Hour_1:
                    return 60 * 60;
                case Interval.Hour_2:
                    return 60 * 60 * 2;
                case Interval.Hour_4:
                    return 60 * 60 * 4;
                case Interval.Day_1:
                    return 60 * 60 * 24;
                case Interval.Week_1:
                    return 60 * 60 * 24 * 7;
                case Interval.Month_1:
                    return 60 * 60 * 24 * 30;
                case Interval.NULL:
                    return 0;
            }

            return 0;
        }

        /// <summary>
        /// Okex_v5 direction转为Common-Direction类型
        /// </summary>
        /// <param name="okex_v5_direction"></param>
        /// <returns></returns>
        public static Direction Trans_OkexV5_ToCommonDirection(string okex_v5_direction)
        {
            if(okex_v5_direction == "long")
            {
                return Direction.LONG;
            }
            else if(okex_v5_direction == "short")
            {
                return Direction.SHORT;
            }
            else if(okex_v5_direction == "net")
            {
                return Direction.NET;
            }

            return Direction.NET;
        }

        /// <summary>
        /// Common标准Product类型转为OkexV5-Product类型
        /// </summary>
        /// <param name="pd"></param>
        /// <returns></returns>
        public static string Trans_CommonProduct_ToOkexV5(Product pd)
        {
            switch(pd)
            {
                case Product.SPOT:
                    return "SPOT";
                case Product.FUTURES:
                    return "FUTURES";
                case Product.INDEX:
                    return "SWAP";
                case Product.OPTION:
                    return "OPTION";
                default:
                    return "";
            }
        }

        /// <summary>
        /// OkexV5-Product类型转为标准Product类型
        /// </summary>
        /// <param name="pd"></param>
        /// <returns></returns>
        public static Product Trans_OkexV5Product_ToCommon(string pD)
        {
            if(pD == "SPOT")
            {
                return Product.SPOT;
            }
            else if(pD == "FUTURES")
            {
                return Product.FUTURES;
            }
            else if (pD == "SWAP")
            {
                return Product.INDEX;
            }
            else if (pD == "OPTION")
            {
                return Product.OPTION;
            }

            return Product.NULL;
        }
    
    
        public static string Trans_CommonInterval_ToOkexV5(Interval it)
        {
            switch(it)
            {
                case Interval.Minute_1:
                    return "1m";
                case Interval.Minute_3:
                    return "3m";
                case Interval.Minute_5:
                    return "5m";
                case Interval.Minute_15:
                    return "15m";
                case Interval.Minute_30:
                    return "30m";
                case Interval.Hour_1:
                    return "1H";
                case Interval.Hour_2:
                    return "2H";
                case Interval.Hour_4:
                    return "4H";
                case Interval.Day_1:
                    return "1D";
                case Interval.Week_1:
                    return "1W";
                case Interval.Month_1:
                    return "1M";
                default:
                    return "";
            }
        }
    }
}
