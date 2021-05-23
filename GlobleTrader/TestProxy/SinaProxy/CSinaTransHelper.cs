using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProxy
{
    public static class CSinaTransHelper
    {
        /// <summary>
        /// CSina标准时间周期转CSina时间周期字符串
        /// </summary>
        /// <param name="interval"></param>
        /// <returns></returns>
        public static string CommonInterval_TransToCSina(Interval interval)
        {
            switch (interval)
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
                    return "60m"; //注意这里不是1h,新浪这里是60m传参
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

        /// <summary>
        /// CSina判断该Symbol是否为股指期货，否则为商品期货
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public static bool IsSymbolIndexFuture(string symbol)
        {
            if (symbol == "") return false;
            if(symbol.Contains("IF")|| symbol.Contains("IC") || symbol.Contains("IH"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// CSina根据symbol,interval生成请求历史数据的URL
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="interval"></param>
        /// <returns></returns>
        public static string GetRequestURL(HistoryRequest hisReq)
        {
            //对于商品期货
            //http://stock2.finance.sina.com.cn/futures/api/json.php/IndexService.getInnerFuturesMiniKLine15m?symbol=M0

            //对于股指期货
            //http://stock2.finance.sina.com.cn/futures/api/json.php/CffexFuturesService.getCffexFuturesMiniKLine30m?symbol=IF1306

            string symbol = hisReq.Symbol;
            string interval = CommonInterval_TransToCSina(hisReq.Interval);

            string url = string.Empty;
            //需要判断Symbol是否为股指
            if(IsSymbolIndexFuture(hisReq.Symbol))
            {
                //分钟返回请求URL
                if(hisReq.Interval == Interval.Minute_1 ||
                    hisReq.Interval == Interval.Minute_3 || hisReq.Interval == Interval.Minute_5
                    || hisReq.Interval == Interval.Minute_15 || hisReq.Interval == Interval.Minute_30 ||
                    hisReq.Interval == Interval.Hour_1)
                {
                    url = string.Format("http://stock2.finance.sina.com.cn/futures/api/json.php/CffexFuturesService.getCffexFuturesMiniKLine{0}?symbol={1}", interval, symbol);
                    return url;
                }

                //日线返回请求URL
                if (hisReq.Interval == Interval.Day_1)
                {
                    url = string.Format("http://stock2.finance.sina.com.cn/futures/api/json.php/CffexFuturesService.getCffexFuturesDailyKLine?symbol={0}", symbol);
                    return url;
                }

                //其余返回请求URL-使得查回为null
                return "";
            }
            else
            {
                if (hisReq.Interval == Interval.Minute_1 ||
                    hisReq.Interval == Interval.Minute_3 || hisReq.Interval == Interval.Minute_5
                    || hisReq.Interval == Interval.Minute_15 || hisReq.Interval == Interval.Minute_30 ||
                    hisReq.Interval == Interval.Hour_1)
                {
                    url = string.Format("http://stock2.finance.sina.com.cn/futures/api/json.php/IndexService.getInnerFuturesMiniKLine{0}?symbol={1}", interval, symbol);
                    return url;
                }

                if (hisReq.Interval == Interval.Day_1)
                {
                    url = string.Format("http://stock2.finance.sina.com.cn/futures/api/json.php/IndexService.getInnerFuturesDailyKLine?symbol={0}", symbol);
                    return url;
                }

                return "";
            }
        }

        /// <summary>
        /// CSina返回所有Sina包含的连续合约的连续品种合约名表，也可以由自己去查询找，在这里默认给一些，不一定全，可参考
        /// 指定合约的查询，需要自己去主动填写了，暂时Sina没有主动接口可查询，例如:M2101
        /// </summary>
        /// <returns></returns>
        public static List<ContractData> GetSymbolsSeriesList()
        {
            List<ContractData> cDList = new List<ContractData>();

            //M0,RB0....




            return cDList;
        }
    }
}
