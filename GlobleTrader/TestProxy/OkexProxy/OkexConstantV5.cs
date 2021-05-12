using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProxy
{
    #region V5账户查询
    public class DetailsItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string availBal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string availEq { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cashBal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ccy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string crossLiab { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string disEq { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string eq { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string frozenBal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string interest { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isoEq { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isoLiab { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string liab { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string maxLoan { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string mgnRatio { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ordFrozen { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string twap { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string uTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string upl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string uplLiab { get; set; }
    }

    public class DataItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string adjEq { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<DetailsItem> details { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string imr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isoEq { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string mgnRatio { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string mmr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ordFroz { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string totalEq { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string uTime { get; set; }
    }

    public class AccountV5
    {
        /// <summary>
        /// 
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<DataItem> data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string msg { get; set; }
    }
    #endregion

    #region V5持仓查询
    public class PositionDetail
    {
        /// <summary>
        /// 
        /// </summary>
        public string adl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string availPos { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string avgPx { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ccy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string deltaBS { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string deltaPA { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string gammaBS { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string gammaPA { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string imr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string instId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string instType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string interest { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string last { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string lever { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string liab { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string liabCcy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string liqPx { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string margin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string mgnMode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string mgnRatio { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string mmr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string optVal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string pos { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string posCcy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string posId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string posSide { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string thetaBS { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string thetaPA { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string tradeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string uTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string upl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string uplRatio { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string vegaBS { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string vegaPA { get; set; }
    }
    public class PositionV5
    {
        /// <summary>
        /// 
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<PositionDetail> data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string msg { get; set; }
    }
    #endregion

    #region V5合约查询
    public class ContractDetail
    {
        /// <summary>
        /// 
        /// </summary>
        public string alias { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string baseCcy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string category { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ctMult { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ctType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ctVal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ctValCcy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string expTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string instId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string instType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string lever { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string listTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string lotSz { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string minSz { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string optType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string quoteCcy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string settleCcy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string state { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string stk { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string tickSz { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string uly { get; set; }
    }
    public class ContractV5
    {
        /// <summary>
        /// 
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ContractDetail> data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string msg { get; set; }
    }
    #endregion

    #region V5Tick行情
    public class TickDetail
    {
        /// <summary>
        /// 
        /// </summary>
        public string instType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string instId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string last { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string lastSz { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string askPx { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string askSz { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string bidPx { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string bidSz { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string open24h { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string high24h { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string low24h { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string volCcy24h { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string vol24h { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sodUtc0 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sodUtc8 { get; set; }
    }

    public class TickV5
    {
        /// <summary>
        /// 
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<TickDetail> data { get; set; }
    }

    #endregion

    #region V5历史数据
    public class HisDataV5
    {
        /// <summary>
        /// 
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<List<string>> data { get; set; }
    }
    #endregion
}
