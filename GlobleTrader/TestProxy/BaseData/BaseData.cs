//"""
//Basic data structure used for general trading function in VN Trader.
//"""

//from dataclasses import dataclass
//from datetime import datetime
//from logging import INFO

//from .constant import Direction, Exchange, Interval, Offset, Status, Product, OptionType, OrderType

//ACTIVE_STATUSES = set([Status.SUBMITTING, Status.NOTTRADED, Status.PARTTRADED])


//@dataclass
//class BaseData :
//    """
//    Any data object needs a gateway_name as source
//    and should inherit base data.
//    """

//    gateway_name: str


//@dataclass
//class TickData(BaseData):
//    """
//    Tick data contains information about:
//        *last trade in market
//       * orderbook snapshot
//        * intraday market statistics.
//    """

//    symbol: str
//    exchange: Exchange
//    datetime: datetime

//    name: str = ""
//    volume: float = 0
//    open_interest: float = 0
//    last_price: float = 0
//    last_volume: float = 0
//    limit_up: float = 0
//    limit_down: float = 0

//    open_price: float = 0
//    high_price: float = 0
//    low_price: float = 0
//    pre_close: float = 0

//    bid_price_1: float = 0
//    bid_price_2: float = 0
//    bid_price_3: float = 0
//    bid_price_4: float = 0
//    bid_price_5: float = 0

//    ask_price_1: float = 0
//    ask_price_2: float = 0
//    ask_price_3: float = 0
//    ask_price_4: float = 0
//    ask_price_5: float = 0

//    bid_volume_1: float = 0
//    bid_volume_2: float = 0
//    bid_volume_3: float = 0
//    bid_volume_4: float = 0
//    bid_volume_5: float = 0

//    ask_volume_1: float = 0
//    ask_volume_2: float = 0
//    ask_volume_3: float = 0
//    ask_volume_4: float = 0
//    ask_volume_5: float = 0

//    def __post_init__(self):
//        """"""
//        self.vt_symbol = f"{self.symbol}.{self.exchange.value}"


//@dataclass
//class BarData(BaseData):
//    """
//    Candlestick bar data of a certain trading period.
//    """

//    symbol: str
//    exchange: Exchange
//    datetime: datetime

//    interval: Interval = None
//    volume: float = 0
//    open_interest: float = 0
//    open_price: float = 0
//    high_price: float = 0
//    low_price: float = 0
//    close_price: float = 0

//    def __post_init__(self):
//        """"""
//        self.vt_symbol = f"{self.symbol}.{self.exchange.value}"




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProxy
{
    #region 公共数据基类
    public class BaseData
    {
        public PROXYTHROUGH Proxy { get; set; }
    }
    #endregion

    #region 公共日志数据
    public class LogData:BaseData
    {
        public string Msg { get; set; }
        public int Level { get; set; }
    }
    #endregion

    #region 公共请求数据
    public class LoginRequest : BaseData
    {
        public string IP { get; set; }
        public string Port { get; set; }
        public string Exdata { get; set; }
    }

    public class ContractRequest : BaseData
    {
        public string Symbol { get; set; }
        public Product Product { get; set; }
        public OptionType OpType { get; set; }
        public Exchange Exchange { get; set; }
        public Currency Curreny { get; set; }
    }

    public class OrderRequest : BaseData
    {
        public string Symbol { get; set; }
        public Exchange Exchange { get; set; }
        public Direction Direction { get; set; }
        public OrderType OrderType { get; set; }
        public double Volume { get; set; }
        public double Price { get; set; }
        public Offset Offset { get; set; }
        public string Reference { get; set; }
    }

    public class SubscribeRequest : BaseData
    {
        public string Symbol { get; set; }
        public Exchange Exchange { get; set; }
    }

    public class HistoryRequest : BaseData
    {
        public string Symbol { get; set; }
        public Exchange Exchange { get; set; }
        public DateTime STime { get; set; }
        public DateTime eTime { get; set; }
        public Interval Interval { get; set; }
    }
    #endregion

    #region 公共返回数据
    public class TickData : BaseData
    {
        public string Symbol { get; set; }
        public Exchange Exchange { get; set; }
        public DateTime DTime { get; set; }
        public string  Name { get; set; }
        public double Volume { get; set; }
        public double OpenInterest { get; set; }
        public double LastPrice { get; set; }
        public double LastVolume { get; set; }
        public double LimitUp { get; set; }
        public double LimitDown { get; set; }
        public double OpenPrice { get; set; }
        public double HighPrice { get; set; }
        public double LowPrice { get; set; }
        public double PreClose { get; set; }
        public double BidPrice1 { get; set; }
        public double BidPrice2 { get; set; }
        public double BidPrice3 { get; set; }
        public double BidPrice4 { get; set; }
        public double BidPrice5 { get; set; }
        public double AskPrice1 { get; set; }
        public double AskPrice2 { get; set; }
        public double AskPrice3 { get; set; }
        public double AskPrice4 { get; set; }
        public double AskPrice5 { get; set; }
        public double BidVolume1 { get; set; }
        public double BidVolume2 { get; set; }
        public double BidVolume3 { get; set; }
        public double BidVolume4 { get; set; }
        public double BidVolume5 { get; set; }
        public double AskVolume1 { get; set; }
        public double AskVolume2 { get; set; }
        public double AskVolume3 { get; set; }
        public double AskVolume4 { get; set; }
        public double AskVolume5 { get; set; }
    }

    public class BarData : BaseData
    {
        public string Symbol { get; set; }
        public Exchange Exchange { get; set; }
        public DateTime DTime { get; set; }
        public Interval Interval { get; set; }
        public double Volume { get; set; }
        public double OpenInterest  { get; set; }
        public double OpenPrice { get; set; }
        public double HighPrice { get; set; }
        public double LowPrice { get; set; }
        public double ClosePrice { get; set; }
    }

    public class TradeData : BaseData
    {
        public string Symbol { get; set; }
        public Exchange Exchange { get; set; }
        public string OrderId { get; set; }
        public string TradeId { get; set; }
        public Direction Direction { get; set; } 
        public Offset Offset { get; set; }
        public double Price { get; set; }
        public double Volume { get; set; }
        public DateTime DTime { get; set; }

    }

    public class OrderData : BaseData
    {
        public string Symbol { get; set; }
        public Exchange Exchange { get; set; }
        public string OrderId { get; set; }

        public OrderType OrderType { get; set; }
        public  Direction Direction{ get; set; }
        public Offset Offset { get; set; } 
        public double Price { get; set; }
        public double Volume { get; set; }
        public double Traded { get; set; }
        public Status Status { get; set; }
        public DateTime DTime { get; set; }
        public string Reference { get; set; }

    }

    public class PositionData : BaseData
    {

        public string Symbol { get; set; }
        public Exchange Exchange { get; set; }
        public Direction Direction { get; set; }
        public double Volume { get; set; }
        public double Frozen { get; set; }
        public double Price { get; set; }
        public double PNL { get; set; }
        public double YdVolume { get; set; }

    }

    public class AccountData : BaseData
    {
        public string AccountName { get; set; }

        public string AccountValue { get; set; }
        public string AccountCurrency { get; set; }
    }

    public class ContractData : BaseData
    {

        public string Symbol { get; set; }
        public Exchange Exchange { get; set; }
        public string Name { get; set; }
        public Product Product { get; set; }
        public double Size { get; set; }
        public double PriceTick { get; set; }
        public double MinVolume { get; set; }           //# minimum trading volume of the contract
        public bool StopSupported { get; set; }    //# whether server supports stop order
        public bool NetPosition { get; set; }       //# whether gateway uses net position volume
        public bool HistoryData { get; set; }       //# whether gateway provides bar history data
        public double OptionStrike { get; set; }
        public string OptionUnderlying { get; set; }     //# vt_symbol of underlying contract
        public OptionType OptionType { get; set; }
        public DateTime OptionExpiry { get; set; }
        public string OptionPortfolio { get; set; }
        public string OptionIndex { get; set; }          //#for identifying options with same strike price

    }
    #endregion

    #region 公共配置数据
    public class ProxyConfig : BaseData
    {
        /// <summary>
        /// 配置数据 - 按需配置
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// 配置说明
        /// </summary>
        public string Reference { get; set; }
    }
    #endregion
}
