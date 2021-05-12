//这个类和testProxy一样，都是极其纯粹的类，和上层Chart没有任何关系，只是构建最基础的基础设施。
//可以作为独立组件独立发布，是耦合度及其低的类，只是简单的依赖proxy存在。
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProxy;

namespace TestService
{
    /// <summary>
    /// 按照tick生成BarK线，并通过事件机制对外发布 - 其中需要生成的K线类型，按照
    /// proxy中给定的Intervel列表给出详细如下：
    /// public enum Interval
    //    {
    //        Tick = 0, - 不需要生成，由各自的组件去直接订阅onTick事件 - proxy
    //        Minute_1,
    //        Minute_3,
    //        Minute_5,
    //        Minute_15,
    //        Minute_30,
    //        Hour_1,
    //        Hour_2,
    //        Hour_4,
    //        Day_1,
    //        Week_1,
    //        Month_1,
    //        NULL
    //}
    /// </summary>

    public class BarMakerService
    {
        private List<BarData> m_1MinBar = new List<BarData>();
        private List<BarData> m_3MinBar = new List<BarData>();
        private List<BarData> m_5MinBar = new List<BarData>();
        private List<BarData> m_15MinBar = new List<BarData>();
        private List<BarData> m_30MinBar = new List<BarData>();
        private List<BarData> m_1Hour = new List<BarData>();
        private List<BarData> m_2Hour = new List<BarData>();
        private List<BarData> m_4Hour = new List<BarData>();
        private List<BarData> m_1Day = new List<BarData>();
        private List<BarData> m_1Week = new List<BarData>();
        private List<BarData> m_1Month = new List<BarData>();

        /// <summary>
        /// 历史请求 - 除了给chat，这里也需要知道，生成的frame要和历史图表对应起来
        /// </summary>
        private HistoryRequest m_hisRequest;

        /// <summary>
        /// 合约基础信息 - 这里需要到时候返回回去
        /// </summary>
        private ContractData m_conData;

        /// <summary>
        /// 数据源代理 - 主要拿来订阅tick数据用的订阅具体的proxy的tick数据
        /// </summary>
        private PROXYTHROUGH m_proxy;

        /// <summary>
        /// Bar发布器
        /// </summary>
        /// <param name="renkoBar"></param>
        public delegate void BarComingHandle(BarData bar, HistoryRequest hQ, ContractData cD, PROXYTHROUGH proxy);
        public event BarComingHandle BarComingEvent;


        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="ins"></param>
        /// <param name="boxSize"></param>
        public BarMakerService(HistoryRequest hisInfo, ContractData cDInfo, PROXYTHROUGH proxy)
        {
            if (hisInfo == null || cDInfo == null || proxy == PROXYTHROUGH.NULL)
            {
                throw new Exception("the info is null");
            }

            if (hisInfo.Symbol.CompareTo(string.Empty) == 0 || cDInfo.Symbol.CompareTo(string.Empty) == 0)
            {
                throw new Exception("the Instrument is is null");
            }

            if (hisInfo.Interval == Interval.NULL)
            {
                throw new Exception("the DataFrame or CandleType is is null");
            }


            m_proxy = proxy;
            m_hisRequest = hisInfo;
            m_conData = cDInfo;

            //订阅实时数据
            ProxyManager.GetInstance().GetProxy(m_proxy).OnTickEvent += BarMakerService_OnTickEvent;

        }

        private void BarMakerService_OnTickEvent(List<TickData> tickD)
        {
            if (tickD == null) return;
            if (tickD.Count <= 0) return;

            foreach (TickData t in tickD)
            {
                if (t.Symbol != m_hisRequest.Symbol) continue; //过滤-因为这个list里面的tick有可能是多个合约，有可能是来自订阅的一个合约，所以在這里这么一过滤，可以兼容多合约返回和单个合约List的返回
                                                               //在这里开始处理自己的业务

                //        Minute_1,
                //        Minute_3,
                //        Minute_5,
                //        Minute_15,
                //        Minute_30,
                //        Hour_1,
                //        Hour_2,
                //        Hour_4,
                //        Day_1,
                //        Week_1,
                //        Month_1,
                //        NULL

                if (m_hisRequest.Interval == Interval.Minute_1)
                {
                    PublishKlineMinute_1Bar(t, m_hisRequest);
                }

                //if (m_hisRequest.Interval == Interval.Minute_3)
                //{
                //    PublishKlineMinute_3Bar(t, m_hisRequest);
                //}

                //if (m_hisRequest.Interval == Interval.Minute_5)
                //{
                //    PublishKlineMinute_5Bar(t, m_hisRequest);
                //}

                //if (m_hisRequest.Interval == Interval.Minute_15)
                //{
                //    PublishKlineMinute_15Bar(t, m_hisRequest);
                //}

                //if (m_hisRequest.Interval == Interval.Minute_30)
                //{
                //    PublishKlineMinute_30Bar(t, m_hisRequest);
                //}

                //if (m_hisRequest.Interval == Interval.Hour_1)
                //{
                //    PublishKlineHour_1Bar(t, m_hisRequest);
                //}

                //if (m_hisRequest.Interval == Interval.Hour_2)
                //{
                //    PublishKlineHour_2Bar(t, m_hisRequest);
                //}

                //if (m_hisRequest.Interval == Interval.Hour_4)
                //{
                //    PublishKlineHour_4Bar(t, m_hisRequest);
                //}

                //if (m_hisRequest.Interval == Interval.Day_1)
                //{
                //    PublishKlineDay_1Bar(t, m_hisRequest);
                //}

                //if (m_hisRequest.Interval == Interval.Week_1)
                //{
                //    PublishKlineWeek_1Bar(t, m_hisRequest);
                //}

                //if (m_hisRequest.Interval == Interval.Month_1)
                //{
                //    PublishKlineMonth_1Bar(t, m_hisRequest);
                //}




                break;
            }
        }


        #region 在这里合成K线发布
        /// <summary>
        /// 发布30分K线--分钟数是否==30计算
        /// </summary>
        /// <param name="ticLiet"></param>
        //private void PublishKline30Bar(TickData t, HistoryRequest hisRq)
        //{
        //    //记录第一笔进来的tick的时间戳，
        //    if (m_30MinBar.Count <= 0)
        //    {
        //        TestData.KlineOkex Bar30 = new TestData.KlineOkex()
        //        {
        //            insment = t.instrument_id,
        //            d = t.timestamp,
        //            o = t.last,
        //            h = t.last,
        //            l = t.last,
        //            c = t.last,
        //            unkonwn1 = t.high_24h,
        //            unkonwn2 = t.high_24h,
        //        };

        //        m_30MinBar.Add(Bar30);
        //    }
        //    else
        //    {
        //        //如果分钟不能被5整除，比较开高低收合成--如果不相等了，直接发布，并把这个不相等的第一笔作为最新的一个起始点
        //        if (t.timestamp.Minute != 0 || t.timestamp.Minute != 30)
        //        {
        //            if (t.last >= m_30MinBar[0].h)
        //            {
        //                m_30MinBar[0].h = t.last;
        //            }

        //            if (t.last <= m_30MinBar[0].l)
        //            {
        //                m_30MinBar[0].l = t.last;
        //            }
        //        }
        //        else
        //        {
        //            m_30MinBar[0].c = t.last;

        //            //克隆一个--因为发布出去之后，List里的引用值会改变
        //            TestData.KlineOkex BarClone30Min = new TestData.KlineOkex()
        //            {
        //                insment = m_30MinBar[0].insment,
        //                d = m_30MinBar[0].d,
        //                o = m_30MinBar[0].o,
        //                h = m_30MinBar[0].h,
        //                l = m_30MinBar[0].l,
        //                c = m_30MinBar[0].c,
        //                unkonwn1 = m_30MinBar[0].unkonwn1,
        //                unkonwn2 = m_30MinBar[0].unkonwn2,
        //            };

        //            SafeRiseBarComingEvent(BarClone30Min, frame);

        //            m_30MinBar[0].insment = t.instrument_id;
        //            m_30MinBar[0].d = t.timestamp;
        //            m_30MinBar[0].o = t.last;
        //            m_30MinBar[0].h = t.last;
        //            m_30MinBar[0].l = t.last;
        //            m_30MinBar[0].c = t.last;
        //            m_30MinBar[0].unkonwn1 = t.high_24h;
        //            m_30MinBar[0].unkonwn2 = t.high_24h;

        //        }
        //    }
        //}

        ///// <summary>
        ///// 发布60分K线
        ///// </summary>
        ///// <param name="ticLiet"></param>
        //private void PublishKline60Bar(TickData t, HistoryRequest hisRq)
        //{
        //    //记录第一笔进来的tick的时间戳，
        //    if (m_60MinBar.Count <= 0)
        //    {
        //        TestData.KlineOkex Bar60 = new TestData.KlineOkex()
        //        {
        //            insment = t.instrument_id,
        //            d = t.timestamp,
        //            o = t.last,
        //            h = t.last,
        //            l = t.last,
        //            c = t.last,
        //            unkonwn1 = t.high_24h,
        //            unkonwn2 = t.high_24h,
        //        };

        //        m_60MinBar.Add(Bar60);
        //    }
        //    else
        //    {
        //        //如果分钟不能被5整除，比较开高低收合成--如果不相等了，直接发布，并把这个不相等的第一笔作为最新的一个起始点
        //        if (t.timestamp.Hour == m_60MinBar[0].d.Hour)
        //        {
        //            if (t.last >= m_60MinBar[0].h)
        //            {
        //                m_60MinBar[0].h = t.last;
        //            }

        //            if (t.last <= m_60MinBar[0].l)
        //            {
        //                m_60MinBar[0].l = t.last;
        //            }
        //        }
        //        else
        //        {
        //            m_60MinBar[0].c = t.last;

        //            //克隆一个--因为发布出去之后，List里的引用值会改变
        //            TestData.KlineOkex BarClone60Min = new TestData.KlineOkex()
        //            {
        //                insment = m_60MinBar[0].insment,
        //                d = m_60MinBar[0].d,
        //                o = m_60MinBar[0].o,
        //                h = m_60MinBar[0].h,
        //                l = m_60MinBar[0].l,
        //                c = m_60MinBar[0].c,
        //                unkonwn1 = m_60MinBar[0].unkonwn1,
        //                unkonwn2 = m_60MinBar[0].unkonwn2,
        //            };

        //            SafeRiseBarComingEvent(BarClone60Min, frame);

        //            m_60MinBar[0].insment = t.instrument_id;
        //            m_60MinBar[0].d = t.timestamp;
        //            m_60MinBar[0].o = t.last;
        //            m_60MinBar[0].h = t.last;
        //            m_60MinBar[0].l = t.last;
        //            m_60MinBar[0].c = t.last;
        //            m_60MinBar[0].unkonwn1 = t.high_24h;
        //            m_60MinBar[0].unkonwn2 = t.high_24h;

        //        }
        //    }
        //}

        ///// <summary>
        ///// 发布15分K线--分钟线能被15整除
        ///// </summary>
        ///// <param name="ticLiet"></param>
        //private void PublishKline15Bar(TickData t, HistoryRequest hisRq)
        //{
        //    //记录第一笔进来的tick的时间戳，更新分钟相同情况下的开高低收，直到分钟能被5整除发布，然后重新开始
        //    if (m_15MinBar.Count <= 0)
        //    {
        //        TestData.KlineOkex Bar15 = new TestData.KlineOkex()
        //        {
        //            insment = t.instrument_id,
        //            d = t.timestamp,
        //            o = t.last,
        //            h = t.last,
        //            l = t.last,
        //            c = t.last,
        //            unkonwn1 = t.high_24h,
        //            unkonwn2 = t.high_24h,
        //        };

        //        m_15MinBar.Add(Bar15);
        //    }
        //    else
        //    {
        //        //如果分钟不能被5整除，比较开高低收合成--如果不相等了，直接发布，并把这个不相等的第一笔作为最新的一个起始点
        //        if (t.timestamp.Minute % 15 != 0)
        //        {
        //            if (t.last >= m_15MinBar[0].h)
        //            {
        //                m_15MinBar[0].h = t.last;
        //            }

        //            if (t.last <= m_15MinBar[0].l)
        //            {
        //                m_15MinBar[0].l = t.last;
        //            }
        //        }
        //        else
        //        {
        //            m_15MinBar[0].c = t.last;

        //            //克隆一个--因为发布出去之后，List里的引用值会改变
        //            TestData.KlineOkex BarClone15Min = new TestData.KlineOkex()
        //            {
        //                insment = m_15MinBar[0].insment,
        //                d = m_15MinBar[0].d,
        //                o = m_15MinBar[0].o,
        //                h = m_15MinBar[0].h,
        //                l = m_15MinBar[0].l,
        //                c = m_15MinBar[0].c,
        //                unkonwn1 = m_15MinBar[0].unkonwn1,
        //                unkonwn2 = m_15MinBar[0].unkonwn2,
        //            };

        //            SafeRiseBarComingEvent(BarClone15Min, frame);

        //            m_15MinBar[0].insment = t.instrument_id;
        //            m_15MinBar[0].d = t.timestamp;
        //            m_15MinBar[0].o = t.last;
        //            m_15MinBar[0].h = t.last;
        //            m_15MinBar[0].l = t.last;
        //            m_15MinBar[0].c = t.last;
        //            m_15MinBar[0].unkonwn1 = t.high_24h;
        //            m_15MinBar[0].unkonwn2 = t.high_24h;

        //        }
        //    }
        //}

        ///// <summary>
        ///// 发布5MinK--分钟能否被5整除的原理
        ///// </summary>
        ///// <param name="ticLiet"></param>
        //private void PublishKline5Bar(TickData t, HistoryRequest hisRq)
        //{
        //    //记录第一笔进来的tick的时间戳，更新分钟相同情况下的开高低收，直到分钟能被5整除发布，然后重新开始
        //    if (m_5MinBar.Count <= 0)
        //    {
        //        TestData.KlineOkex Bar5 = new TestData.KlineOkex()
        //        {
        //            insment = t.instrument_id,
        //            d = t.timestamp,
        //            o = t.last,
        //            h = t.last,
        //            l = t.last,
        //            c = t.last,
        //            unkonwn1 = t.high_24h,
        //            unkonwn2 = t.high_24h,
        //        };

        //        m_5MinBar.Add(Bar5);
        //    }
        //    else
        //    {
        //        //如果分钟不能被5整除，比较开高低收合成--如果不相等了，直接发布，并把这个不相等的第一笔作为最新的一个起始点
        //        if (t.timestamp.Minute % 5 != 0)
        //        {
        //            if (t.last >= m_5MinBar[0].h)
        //            {
        //                m_5MinBar[0].h = t.last;
        //            }

        //            if (t.last <= m_5MinBar[0].l)
        //            {
        //                m_5MinBar[0].l = t.last;
        //            }
        //        }
        //        else
        //        {
        //            m_5MinBar[0].c = t.last;

        //            //克隆一个--因为发布出去之后，List里的引用值会改变
        //            TestData.KlineOkex BarClone5Min = new TestData.KlineOkex()
        //            {
        //                insment = m_5MinBar[0].insment,
        //                d = m_5MinBar[0].d,
        //                o = m_5MinBar[0].o,
        //                h = m_5MinBar[0].h,
        //                l = m_5MinBar[0].l,
        //                c = m_5MinBar[0].c,
        //                unkonwn1 = m_5MinBar[0].unkonwn1,
        //                unkonwn2 = m_5MinBar[0].unkonwn2,
        //            };

        //            SafeRiseBarComingEvent(BarClone5Min, frame);

        //            m_5MinBar[0].insment = t.instrument_id;
        //            m_5MinBar[0].d = t.timestamp;
        //            m_5MinBar[0].o = t.last;
        //            m_5MinBar[0].h = t.last;
        //            m_5MinBar[0].l = t.last;
        //            m_5MinBar[0].c = t.last;
        //            m_5MinBar[0].unkonwn1 = t.high_24h;
        //            m_5MinBar[0].unkonwn2 = t.high_24h;

        //        }
        //    }
        //}

        /// <summary>
        /// 发布1MinK--分钟进行比较的原理
        /// </summary>
        /// <param name="ticLiet"></param>
        private void PublishKlineMinute_1Bar(TickData t, HistoryRequest hisRq)
        {
            //记录第一笔进来的tick的时间戳，更新分钟相同情况下的开高低收，直到分钟不再一样，14:00:59  14:01:00驱动推送上一分钟的K线
            if (m_1MinBar.Count <= 0)
            {
                //public string Symbol { get; set; }
                //public Exchange Exchange { get; set; }
                //public DateTime DTime { get; set; }
                //public Interval Interval { get; set; }
                //public double Volume { get; set; }
                //public double OpenInterest { get; set; }
                //public double OpenPrice { get; set; }
                //public double HighPrice { get; set; }
                //public double LowPrice { get; set; }
                //public double ClosePrice { get; set; }

                BarData Bar1 = new BarData()
                {
                    Symbol = t.Symbol,
                    DTime = t.DTime,
                    Exchange = t.Exchange,
                    Interval = m_hisRequest.Interval,
                    Volume = t.Volume,
                    OpenInterest = t.OpenInterest,
                    OpenPrice = t.LastPrice,
                    HighPrice = t.LastPrice,
                    LowPrice = t.LastPrice,
                    ClosePrice = t.LastPrice
                };

                m_1MinBar.Add(Bar1);
            }
            else
            {
                //如果分钟数相等的话，比较开高低收合成--如果不相等了，直接发布，并把这个不相等的第一笔作为最新的一个起始点
                if (t.DTime.Minute == m_1MinBar[0].DTime.Minute)
                {
                    if (t.LastPrice >= m_1MinBar[0].HighPrice)
                    {
                        m_1MinBar[0].HighPrice = t.LastPrice;
                    }

                    if (t.LastPrice <= m_1MinBar[0].LowPrice)
                    {
                        m_1MinBar[0].LowPrice = t.LastPrice;
                    }
                }
                else
                {
                    m_1MinBar[0].ClosePrice = t.LastPrice;

                    //克隆一个--因为发布出去之后，List里的引用值会改变
                    BarData BarClone1Min = new BarData()
                    {
                        Symbol = m_1MinBar[0].Symbol,
                        DTime = m_1MinBar[0].DTime,
                        Exchange = m_1MinBar[0].Exchange,
                        Interval = m_hisRequest.Interval,
                        Volume = m_1MinBar[0].Volume,
                        OpenInterest = m_1MinBar[0].OpenInterest,
                        OpenPrice = m_1MinBar[0].OpenPrice,
                        HighPrice = m_1MinBar[0].HighPrice,
                        LowPrice = m_1MinBar[0].LowPrice,
                        ClosePrice = m_1MinBar[0].ClosePrice
                    };


                    SafeRiseBarComingEvent(BarClone1Min, m_hisRequest,m_conData,m_proxy);

                    m_1MinBar[0].Symbol = t.Symbol;
                    m_1MinBar[0].DTime = t.DTime;
                     m_1MinBar[0].Exchange = t.Exchange;
                    m_1MinBar[0].Interval = m_hisRequest.Interval;
                    m_1MinBar[0].Volume = t.Volume;
                    m_1MinBar[0].OpenInterest = t.OpenInterest;
                    m_1MinBar[0].OpenPrice = t.LastPrice;
                    m_1MinBar[0].HighPrice = t.HighPrice;
                    m_1MinBar[0].LowPrice = t.LowPrice;
                    m_1MinBar[0].ClosePrice = t.LastPrice;
                }
            }
        }

        #endregion

        /// <summary>
        /// 安全的发布Bar
        /// </summary>
        /// <param name="Bar"></param>
        private void SafeRiseBarComingEvent(BarData bD, HistoryRequest hisRq, ContractData cD, PROXYTHROUGH proxy)
        {
            if (BarComingEvent != null)
            {
                BarComingEvent(bD, m_hisRequest, m_conData, m_proxy);
            }
        }



        private BarData m_1TestMinBar = null;

        //被动根据Tick去生成，测试
        public BarData MakeBar(TickData t, HistoryRequest hisRq)
        {
            //记录第一笔进来的tick的时间戳，更新分钟相同情况下的开高低收，直到分钟不再一样，14:00:59  14:01:00驱动推送上一分钟的K线
            if (m_1TestMinBar == null)
            {
                m_1TestMinBar = new BarData()
                {
                    Symbol = t.Symbol,
                    DTime = t.DTime,
                    Exchange = t.Exchange,
                    Interval = m_hisRequest.Interval,
                    Volume = t.Volume,
                    OpenInterest = t.OpenInterest,
                    OpenPrice = t.LastPrice,
                    HighPrice = t.LastPrice,
                    LowPrice = t.LastPrice,
                    ClosePrice = t.LastPrice
                };

                return null;
            }
            else
            {
                //如果分钟数相等的话，比较开高低收合成--如果不相等了，直接发布，并把这个不相等的第一笔作为最新的一个起始点
                if (t.DTime.Minute == m_1TestMinBar.DTime.Minute)
                {
                    if (t.LastPrice >= m_1TestMinBar.HighPrice)
                    {
                        m_1TestMinBar.HighPrice = t.LastPrice;
                    }

                    if (t.LastPrice <= m_1TestMinBar.LowPrice)
                    {
                        m_1TestMinBar.LowPrice = t.LastPrice;
                    }
                }
                else
                {
                    m_1TestMinBar.ClosePrice = t.LastPrice;

                    //克隆一个--因为发布出去之后，List里的引用值会改变
                    BarData BarClone1Min = new BarData()
                    {
                        Symbol = m_1TestMinBar.Symbol,
                        DTime = m_1TestMinBar.DTime,
                        Exchange = m_1TestMinBar.Exchange,
                        Interval = m_hisRequest.Interval,
                        Volume = m_1TestMinBar.Volume,
                        OpenInterest = m_1TestMinBar.OpenInterest,
                        OpenPrice = m_1TestMinBar.OpenPrice,
                        HighPrice = m_1TestMinBar.HighPrice,
                        LowPrice = m_1TestMinBar.LowPrice,
                        ClosePrice = m_1TestMinBar.ClosePrice
                    };


                    m_1TestMinBar = null;

                    return BarClone1Min;

                }
            }
            return null;
        }

    }
}
