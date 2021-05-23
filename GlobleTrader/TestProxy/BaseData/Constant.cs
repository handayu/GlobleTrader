using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProxy
{
    /// <summary>
    /// VNPY - StructRefrence
    /// </summary>
    //    class Direction(Enum):
    //    """
    //    Direction of order/trade/position.
    //    """
    //    LONG = "多"
    //    SHORT = "空"
    //    NET = "净"


    //class Offset(Enum):
    //    """
    //    Offset of order/trade.
    //    """
    //    NONE = ""
    //    OPEN = "开"
    //    CLOSE = "平"
    //    CLOSETODAY = "平今"
    //    CLOSEYESTERDAY = "平昨"


    //class Status(Enum):
    //    """
    //    Order status.
    //    """
    //    SUBMITTING = "提交中"
    //    NOTTRADED = "未成交"
    //    PARTTRADED = "部分成交"
    //    ALLTRADED = "全部成交"
    //    CANCELLED = "已撤销"
    //    REJECTED = "拒单"


    //class Product(Enum):
    //    """
    //    Product class.
    //    """
    //    EQUITY = "股票"
    //    FUTURES = "期货"
    //    OPTION = "期权"
    //    INDEX = "指数"
    //    FOREX = "外汇"
    //    SPOT = "现货"
    //    ETF = "ETF"
    //    BOND = "债券"
    //    WARRANT = "权证"
    //    SPREAD = "价差"
    //    FUND = "基金"


    //class OrderType(Enum):
    //    """
    //    Order type.
    //    """
    //    LIMIT = "限价"
    //    MARKET = "市价"
    //    STOP = "STOP"
    //    FAK = "FAK"
    //    FOK = "FOK"
    //    RFQ = "询价"


    //class OptionType(Enum):
    //    """
    //    Option type.
    //    """
    //    CALL = "看涨期权"
    //    PUT = "看跌期权"


    //class Exchange(Enum):
    //    """
    //    Exchange.
    //    """
    //    # Chinese
    //    CFFEX = "CFFEX"         # China Financial Futures Exchange
    //    SHFE = "SHFE"           # Shanghai Futures Exchange
    //    CZCE = "CZCE"           # Zhengzhou Commodity Exchange
    //    DCE = "DCE"             # Dalian Commodity Exchange
    //    INE = "INE"             # Shanghai International Energy Exchange
    //    SSE = "SSE"             # Shanghai Stock Exchange
    //    SZSE = "SZSE"           # Shenzhen Stock Exchange
    //    SGE = "SGE"             # Shanghai Gold Exchange
    //    WXE = "WXE"             # Wuxi Steel Exchange
    //    CFETS = "CFETS"         # China Foreign Exchange Trade System

    //    # Global
    //    SMART = "SMART"         # Smart Router for US stocks
    //    NYSE = "NYSE"           # New York Stock Exchnage
    //    NASDAQ = "NASDAQ"       # Nasdaq Exchange
    //    ARCA = "ARCA"           # ARCA Exchange
    //    EDGEA = "EDGEA"         # Direct Edge Exchange
    //    ISLAND = "ISLAND"       # Nasdaq Island ECN
    //    BATS = "BATS"           # Bats Global Markets
    //    IEX = "IEX"             # The Investors Exchange
    //    NYMEX = "NYMEX"         # New York Mercantile Exchange
    //    COMEX = "COMEX"         # COMEX of CME
    //    GLOBEX = "GLOBEX"       # Globex of CME
    //    IDEALPRO = "IDEALPRO"   # Forex ECN of Interactive Brokers
    //    CME = "CME"             # Chicago Mercantile Exchange
    //    ICE = "ICE"             # Intercontinental Exchange
    //    SEHK = "SEHK"           # Stock Exchange of Hong Kong
    //    HKFE = "HKFE"           # Hong Kong Futures Exchange
    //    HKSE = "HKSE"           # Hong Kong Stock Exchange
    //    SGX = "SGX"             # Singapore Global Exchange
    //    CBOT = "CBT"            # Chicago Board of Trade
    //    CBOE = "CBOE"           # Chicago Board Options Exchange
    //    CFE = "CFE"             # CBOE Futures Exchange
    //    DME = "DME"             # Dubai Mercantile Exchange
    //    EUREX = "EUX"           # Eurex Exchange
    //    APEX = "APEX"           # Asia Pacific Exchange
    //    LME = "LME"             # London Metal Exchange
    //    BMD = "BMD"             # Bursa Malaysia Derivatives
    //    TOCOM = "TOCOM"         # Tokyo Commodity Exchange
    //    EUNX = "EUNX"           # Euronext Exchange
    //    KRX = "KRX"             # Korean Exchange
    //    OTC = "OTC"             # OTC Product (Forex/CFD/Pink Sheet Equity)
    //    IBKRATS = "IBKRATS"     # Paper Trading Exchange of IB

    //    # CryptoCurrency
    //    BITMEX = "BITMEX"
    //    OKEX = "OKEX"
    //    HUOBI = "HUOBI"
    //    BITFINEX = "BITFINEX"
    //    BINANCE = "BINANCE"
    //    BYBIT = "BYBIT"         # bybit.com
    //    COINBASE = "COINBASE"
    //    DERIBIT = "DERIBIT"
    //    GATEIO = "GATEIO"
    //    BITSTAMP = "BITSTAMP"

    //    # Special Function
    //    LOCAL = "LOCAL"         # For local generated data


    //class Currency(Enum):
    //    """
    //    Currency.
    //    """
    //    USD = "USD"
    //    HKD = "HKD"
    //    CNY = "CNY"


    //class Interval(Enum):
    //    """
    //    Interval of bar data.
    //    """
    //    MINUTE = "1m"
    //    HOUR = "1h"
    //    DAILY = "d"
    //    WEEKLY = "w"
    //    TICK = "tick"

    /// <summary>
    /// Direction of order/trade/position.
    /// </summary>
    public enum Direction
    {
        /// <summary>
        /// 多
        /// </summary>
        LONG = 0,

        /// <summary>
        /// 空
        /// </summary>
        SHORT,

        /// <summary>
        /// 净
        /// </summary>
        NET
    }

    /// <summary>
    /// Offset of order/trade.
    /// </summary>
    public enum Offset
    {
        NONE = 0,

        /// <summary>
        /// 开仓 
        /// </summary>
        OPEN,

        /// <summary>
        /// 平仓
        /// </summary>
        CLOSE,

        /// <summary>
        /// 平今
        /// </summary>
        CLOSETODAY,

        /// <summary>
        /// 平昨
        /// </summary>
        CLOSEYESTERDAY
    }

    /// <summary>
    /// Order status
    /// </summary>
    public enum Status
    {
        SUBMITTING = 0,//"提交中"
        NOTTRADED,//"未成交"
        PARTTRADED, //"部分成交"
        ALLTRADED,//"全部成交"
        CANCELLED, //"已撤销"
        REJECTED,  //"拒单"
        NULL
    }

    /// <summary>
    /// Product class.
    /// </summary>
    public enum Product
    {
        EQUITY = 0,//"股票"
        FUTURES,//"期货"
        OPTION, //"期权"
        INDEX,  //"指数"
        FOREX, //"外汇"
        SPOT,  //"现货"
        ETF, //"ETF"
        BOND,  //"债券"
        WARRANT,  //"权证"
        SPREAD,//"价差"
        FUND, //"基金"
        COIN,
        NULL

    }

    /// <summary>
    /// Order type
    /// </summary>
    public enum OrderType
    {
        LIMIT = 0, //"限价"
        MARKET, //"市价"
        STOP, //"STOP"
        FAK,  //"FAK"
        FOK, //"FOK"
        RFQ, //"询价"
        NULL
    }

    /// <summary>
    /// Option type
    /// </summary>
    public enum OptionType
    {
        CALL = 0,//"看涨期权"
        PUT,  //"看跌期权"
        NULL
    }

    /// <summary>
    /// Exchange
    /// </summary>
    public enum Exchange
    {
        //Chinese
        CFFEX = 0,          //"CFFEX" # China Financial Futures Exchange
        SHFE, //"SHFE"           //# Shanghai Futures Exchange
        CZCE, //"CZCE"           //# Zhengzhou Commodity Exchange
        DCE, //"DCE"             //# Dalian Commodity Exchange
        INE, //"INE"             //# Shanghai International Energy Exchange
        SSE, //"SSE"             //# Shanghai Stock Exchange
        SZSE, //"SZSE"           //# Shenzhen Stock Exchange
        SGE, //"SGE"             //# Shanghai Gold Exchange
        WXE, //"WXE"             //# Wuxi Steel Exchange
        CFETS, //"CFETS"         //# China Foreign Exchange Trade System

        //#Global
        SMART, //"SMART"         //# Smart Router for US stocks
        NYSE, //"NYSE"           //# New York Stock Exchnage
        NASDAQ, //"NASDAQ"       //# Nasdaq Exchange
        ARCA, //"ARCA"           //# ARCA Exchange
        EDGEA, //"EDGEA"         //# Direct Edge Exchange
        ISLAND, //"ISLAND"       //# Nasdaq Island ECN
        BATS, //"BATS"           //# Bats Global Markets
        IEX, //"IEX"             //# The Investors Exchange
        NYMEX, //"NYMEX"         //# New York Mercantile Exchange
        COMEX, //"COMEX"         //# COMEX of CME
        GLOBEX, //"GLOBEX"       //# Globex of CME
        IDEALPRO, //"IDEALPRO"   //# Forex ECN of Interactive Brokers
        CME, //"CME"             //# Chicago Mercantile Exchange
        ICE, //"ICE"             //# Intercontinental Exchange
        SEHK, //"SEHK"           //# Stock Exchange of Hong Kong
        HKFE, //"HKFE"           //# Hong Kong Futures Exchange
        HKSE, //"HKSE"           //# Hong Kong Stock Exchange
        SGX, //"SGX"             //# Singapore Global Exchange
        CBOT, //"CBT"            //# Chicago Board of Trade
        CBOE, //"CBOE"           //# Chicago Board Options Exchange
        CFE, //"CFE"             //# CBOE Futures Exchange
        DME, //"DME"             //# Dubai Mercantile Exchange
        EUREX, //"EUX"           //# Eurex Exchange
        APEX, //"APEX"           //# Asia Pacific Exchange
        LME, //"LME"             //# London Metal Exchange
        BMD, //"BMD"             //# Bursa Malaysia Derivatives
        TOCOM, //"TOCOM"         //# Tokyo Commodity Exchange
        EUNX, //"EUNX"           //# Euronext Exchange
        KRX, //"KRX"             //# Korean Exchange
        OTC, //"OTC"             //# OTC Product (Forex/CFD/Pink Sheet Equity)
        IBKRATS, //"IBKRATS"     //# Paper Trading Exchange of IB

        //CryptoCurrency
        BITMEX, //"BITMEX"
        OKEX, //"OKEX"
        HUOBI, //"HUOBI"
        BITFINEX, //"BITFINEX"
        BINANCE, //"BINANCE"
        BYBIT, //"BYBIT"         # bybit.com
        COINBASE, //"COINBASE"
        DERIBIT, //"DERIBIT"
        GATEIO, //"GATEIO"
        BITSTAMP, //"BITSTAMP"

        //Special Function
        LOCAL,  //"LOCAL"         //# For local generated data
        NULL
    }


    /// <summary>
    /// Currency
    /// </summary>
    public enum Currency
    {
        USD = 0,//"USD"
        HKD, //"HKD"
        CNY, //"CNY"
        GBP,
        NULL
    }


    /// <summary>
    /// Interval of bar data.
    /// </summary>
    public enum Interval
    {
        Tick = 0,
        Minute_1,
        Minute_3,
        Minute_5,
        Minute_15,
        Minute_30,
        Hour_1,
        Hour_2,
        Hour_4,
        Day_1,
        Week_1,
        Month_1,
        NULL
    }

    public enum SPIEVNETEENUM
    {
        OnLogin,
        OnClose,
        OnSubscribe,
        OnTick,
        OnBar,
        OnTrade,
        OnOrder,
        OnPosition,
        OnAccount,
        OnLog,
        OnCOntract
    }

    public struct SpiStruct
    {
        public SPIEVNETEENUM spiEventEnum;

        public Object spiObject;
    }

    public enum PROXYTHROUGH
    {
        CTP = 0,
        SimNow,
        IB,
        Tiger,
        HTZQ,
        Okex_V3_Swap,
        Okex_V5_Swap,
        MT4,
        XTP,
        Sina,
        HuaXin,
        Demo,
        TuShare,
        TianQin,
        IQFeed,
        NULL
    }

}
