//Sina实时数据
//【例子】
//http://hq.sinajs.cn/list=M0
//豆粕连续 M0
//返回值如下：
//var hq_str_M0 = "豆粕连续,145958,3170,3190,3145,3178,3153,3154,3154,3162,3169,1325,223,1371608,1611074,连,豆粕,2013-06-28";
//查看 http://finance.sina.com.cn/futures/quotes/M0.shtml 页面，发现含义如下：
//最新价:  3154 开盘价:  3170 最高价:  3190   最低价:  3145
//结算价:  3162 昨结算:  3169 持仓量:  1371608 成交量:  1611074
//买 价:  3153 卖 价:  3154 买 量:  1325  卖 量:  223

//新浪期货数据各品种代码（商品连续）如下
// RB0 螺纹钢
// AG0 白银
// AU0 黄金
// CU0 沪铜
// AL0 沪铝
// ZN0 沪锌
// PB0 沪铅
// RU0 橡胶
// FU0 燃油
// WR0 线材
// A0 大豆
// M0 豆粕
// Y0 豆油
// J0 焦炭
// C0 玉米
// L0 乙烯
// P0 棕油
// V0 PVC
// RS0 菜籽
// RM0 菜粕
// FG0 玻璃
// CF0 棉花
// WS0 强麦
// ER0 籼稻
// ME0 甲醇
// RO0 菜油
// TA0 甲酸
// CFF_RE_IF1307  股指期货好像没有期指连续
//品种名 + 0 （数字0），代表品种连续，如果是其他月份，请使用品种名 + YYYMM
//例如豆粕 2013年09月，M1309
//http://hq.sinajs.cn/list=M1309

//新浪历史数据:

//商品期货
//http://stock2.finance.sina.com.cn/futures/api/json.php/IndexService.getInnerFuturesMiniKLineXm?symbol=CODE
//例子：
//http://stock2.finance.sina.com.cn/futures/api/json.php/IndexService.getInnerFuturesMiniKLine5m?symbol=M0
//5分钟
//http://stock2.finance.sina.com.cn/futures/api/json.php/IndexService.getInnerFuturesMiniKLine5m?symbol=M0
//15分钟
//http://stock2.finance.sina.com.cn/futures/api/json.php/IndexService.getInnerFuturesMiniKLine15m?symbol=M0
//30分钟
//http://stock2.finance.sina.com.cn/futures/api/json.php/IndexService.getInnerFuturesMiniKLine30m?symbol=M0
//60分钟
//http://stock2.finance.sina.com.cn/futures/api/json.php/IndexService.getInnerFuturesMiniKLine60m?symbol=M0
//日K线
//http://stock2.finance.sina.com.cn/futures/api/json.php/IndexService.getInnerFuturesDailyKLine?symbol=M0
//http://stock2.finance.sina.com.cn/futures/api/json.php/IndexService.getInnerFuturesDailyKLine?symbol=M1401

//股指期货 5分钟
//http://stock2.finance.sina.com.cn/futures/api/json.php/CffexFuturesService.getCffexFuturesMiniKLine5m?symbol=IF1306
//15分钟
//http://stock2.finance.sina.com.cn/futures/api/json.php/CffexFuturesService.getCffexFuturesMiniKLine15m?symbol=IF1306
//30分钟
//http://stock2.finance.sina.com.cn/futures/api/json.php/CffexFuturesService.getCffexFuturesMiniKLine30m?symbol=IF1306
//60分钟
//http://stock2.finance.sina.com.cn/futures/api/json.php/CffexFuturesService.getCffexFuturesMiniKLine60m?symbol=IF1306
//日线
//http://stock2.finance.sina.com.cn/futures/api/json.php/CffexFuturesService.getCffexFuturesDailyKLine?symbol=IF1306


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;

namespace TestProxy
{
    public class CSinaAPI
    {
        /// <summary>
        /// Sina返回的数据
        /// </summary>
        //public class CSinaRoot
        //{
        //    public List<List<string>> DataItemList { get; set; }
        //}

        /// <summary>
        /// Post-HTTP爬虫数据
        /// </summary>
        /// <param name="hisData"></param>
        /// <returns></returns>
        public StockData QueryHistory(HistoryRequest hisData)
        {
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(CSinaTransHelper.GetRequestURL(hisData));
            req.Method = "POST";
            req.Timeout = 6000;//设置请求超时时间，单位为毫秒
            req.ContentType = "text/plain";
            //byte[] data = Encoding.UTF8.GetBytes(json1);
            //req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                //reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            //获取响应内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }

            //反序列化-这里直接反序列化为List
            List<List<string>> rootData = JsonDataContractJsonSerializer.DeserializeJsonToList<List<string>>(result);

            StockData sD = new StockData();
            sD.StockName = hisData.Symbol;
            sD.Items = rootData;

            return sD;
        }
    }
}
