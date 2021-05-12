using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProxy
{
    public static class DateTimeAction
    {
        /// <summary>
        /// 把返回的BarData里面的DateTime转换为double供zedGraph使用，zedgraph只认double，
        /// 但是double的值需要根据bardata的Interval去确定应该精确到什么精度，比如分钟：那就应该double到202104181428代表
        /// 2020/04/18/14/28分，但是如果是Interval是小时的话，那么double应该是202104181400代表2020/04/18/14/00小时
        /// </summary>
        /// <param name="interval"></param>
        /// <returns></returns>
        public static double TransIntervalDouble(BarData bD)
        {
            switch (bD.Interval)
            {
                case Interval.Minute_1:
                    string tTime = bD.DTime.ToString(string.Format("yyyyMMddHHmm{0}", "00", "00"));
                    double dTime = 0;
                    double.TryParse(tTime, out dTime);
                    return dTime;
                case Interval.Minute_3:
                    string tTime1 = bD.DTime.ToString(string.Format("yyyyMMddHHmm{0}", "00", "00"));
                    double dTime1 = 0;
                    double.TryParse(tTime1, out dTime);
                    return dTime1;
                case Interval.Minute_5:
                    string tTime2 = bD.DTime.ToString(string.Format("yyyyMMddHHmm{0}", "00", "00"));
                    double dTime2 = 0;
                    double.TryParse(tTime2, out dTime);
                    return dTime2;
                case Interval.Minute_15:
                    string tTime3 = bD.DTime.ToString(string.Format("yyyyMMddHHmm{0}", "00", "00"));
                    double dTime3 = 0;
                    double.TryParse(tTime3, out dTime);
                    return dTime3;
                case Interval.Minute_30:
                    string tTime4 = bD.DTime.ToString(string.Format("yyyyMMddHHmm{0}", "00", "00"));
                    double dTime4 = 0;
                    double.TryParse(tTime4, out dTime);
                    return dTime4;
                case Interval.Hour_1:
                    string tTime5 = bD.DTime.ToString(string.Format("yyyyMMddHH{0}{1}", "00", "00"));
                    double dTime5 = 0;
                    double.TryParse(tTime5, out dTime);
                    return dTime5;
                case Interval.Hour_2:
                    string tTime6 = bD.DTime.ToString(string.Format("yyyyMMddHH{0}{1}", "00", "00"));
                    double dTime6 = 0;
                    double.TryParse(tTime6, out dTime);
                    return dTime6;
                case Interval.Hour_4:
                    string tTime7 = bD.DTime.ToString(string.Format("yyyyMMddHH{0}{1}", "00", "00"));
                    double dTime7 = 0;
                    double.TryParse(tTime7, out dTime);
                    return dTime7;
                case Interval.Day_1:
                    string tTime8 = bD.DTime.ToString(string.Format("yyyyMMdd{0}{1}{2}", "00", "00", "00"));
                    double dTime8 = 0;
                    double.TryParse(tTime8, out dTime);
                    return dTime8;
                case Interval.Week_1:
                    string tTime9 = bD.DTime.ToString(string.Format("yyyyMMdd{0}{1}{2}", "00", "00", "00"));
                    double dTime9 = 0;
                    double.TryParse(tTime9, out dTime);
                    return dTime9;
                case Interval.Month_1:
                    string tTime10 = bD.DTime.ToString(string.Format("yyyyMM{0}{1}{2}{3}", "00", "00", "00", "00"));
                    double dTime10 = 0;
                    double.TryParse(tTime10, out dTime);
                    return dTime10;
                case Interval.NULL:
                    return 0;
            }

            return 0;
        }

        /// <summary>
        /// 将dateTime格式转换为Unix时间戳
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static int DateTimeToUnixTime(DateTime dateTime)
        {
            return (int)(dateTime - TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1))).TotalSeconds;
        }

        /// <summary>
        /// 将Unix时间戳转换为dateTime格式
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static DateTime UnixTimeToDateTime(double time)
        {
            if (time < 0)
                throw new ArgumentOutOfRangeException("time is out of range");

            return TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddMilliseconds(time);
        }
    }
}
