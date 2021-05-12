using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ConnectListForm : Form
    {
        private BindingList<ThroughSupport> m_dataLIst = new BindingList<ThroughSupport>();
        private BindingList<ThroughSupport> m_brokerLIst = new BindingList<ThroughSupport>();

        public ConnectListForm()
        {
            InitializeComponent();

        }

        private void Form_Load(object sender, EventArgs e)
        {
            this.dataGridView_dataList.DataSource = m_dataLIst;
            this.dataGridView_TradeList.DataSource = m_brokerLIst;

            //加载账户配置文件
            //string path = System.Windows.Forms.Application.StartupPath + "\\BrokerConfig.ini";
            //IniOperationClass c = new IniOperationClass(path);

            try
            {
                //for (int i = 1; i < 8; i++)
                //{
                //    string name = c.IniReadValue(string.Format("{0}DataThrough", i), "name");
                //    string phone = c.IniReadValue(string.Format("{0}DataThrough", i), "phone");
                //    string link = c.IniReadValue(string.Format("{0}DataThrough", i), "link");
                //    string isok = c.IniReadValue(string.Format("{0}DataThrough", i), "isok");
                //    string info = c.IniReadValue(string.Format("{0}DataThrough", i), "info");
                //    string support = c.IniReadValue(string.Format("{0}DataThrough", i), "support");

                //    ThroughSupport dS = new ThroughSupport()
                //    {
                //        Name = name,
                //        Phone = phone,
                //        Link = link,
                //        //Isok = Image.FromFile(@"./image/start.png"),//窗口设计器默认了
                //        Info = info,
                //        Support = support
                //    };

                //    m_dataLIst.Add(dS);

                //}

                List<ThroughSupport> datList = HoldThroughList.GetAllDataThrough();
                foreach(ThroughSupport tS in datList)
                {
                    m_dataLIst.Add(tS);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// DataThrough数据源点击切换展示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ThroughSupport sP = this.dataGridView_dataList.Rows[e.RowIndex].DataBoundItem as ThroughSupport;

            this.richTextBox_dataInfo.Clear();
            this.richTextBox_datasupportinfo.Clear();

            this.richTextBox_dataInfo.AppendText(">>官方开户/API等信息:" + "\n" + sP.Info);
            this.richTextBox_datasupportinfo.AppendText(">>>>数据支持:" + "\n" + sP.Support);

        }

        /// <summary>
        /// TradeThrough交易通道点击切换展示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TradeCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ThroughSupport sP = this.dataGridView_TradeList.Rows[e.RowIndex].DataBoundItem as ThroughSupport;

            this.richTextBox_tradeInfo.Clear();
            this.richTextBox_tradesupportInfo.Clear();

            this.richTextBox_tradeInfo.AppendText(">>官方开户/API等信息:" + "/n" + sP.Info);
            this.richTextBox_tradesupportInfo.AppendText(">>>>数据支持:" + "/n" + sP.Support);
        }
    }

    public class ThroughSupport
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Link { get; set; }
        public Image Isok { get; set; }
        public string Info { get; set; }
        public string Support { get; set; }

    }



    public static class HoldThroughList
    {
        public static List<ThroughSupport> GetAllTradeThrough()
        {
            List<ThroughSupport> tList = new List<ThroughSupport>();



            return tList;
        }

        public static List<ThroughSupport> GetAllDataThrough()
        {
            List<ThroughSupport> dList = new List<ThroughSupport>();

            ThroughSupport tushare = new ThroughSupport()
            {
                Name = "toShare",
                Phone = "QQ620613926",
                Link = "https://tushare.pro/",
                //Isok = 
                Info = "官网注册后，按照积分拥有数据权限，包含沪深股票，指数，基金，期权，债券，外汇，港美股等。" +
                "使用注册后的token在登陆界面进行测试获取数据，并在主界面开启图表进行分析使用，可提供数据下载。",
                Support = "数据支持历史数据日线，中高频分钟行情，Tick行情。"
            };

            ThroughSupport Wangyi = new ThroughSupport()
            {
                Name = "网易财经数据",
                Phone = "010-82558163-7687",
                Link = "https://money.163.com/",
                //Isok = 
                Info = "",
                Support = ""
            };

            ThroughSupport TianQin = new ThroughSupport()
            {
                Name = "天勤量化",
                Phone = "619870862",
                Link = "https://www.shinnytech.com/tianqin/",
                //Isok = 
                Info = "暂时支持国内四大期货交易所实时数据，以及历史数据，未来支持股票数据和股票实时行情，当前可在官网进行注册免费版本试用，" +
                "并提供一个免费使用权限的实盘账号绑定。",
                Support = "四大期货交易所实时Tick数据，分钟级别历史数据"
            };

            ThroughSupport IQFeed = new ThroughSupport()
            {
                Name = "IQFeed境外数据中心",
                Phone = "800-475-4755",
                Link = "http://www.iqfeed.net/",
                //Isok = 
                Info = "IQFeed被公认为以最佳的整体价格为交易者提供最全面的服务。",
                Support = "关于美国和加拿大股票（纽约证券交易所，纳斯达克，纽约证券交易所，加拿大证券交易所）的实时，逐笔交易数据，"+
                "无法实时接收交易所的延迟数据（延迟的数据可能收取交易所费用）实时股票 / 指数期权和外汇数据需要额外收费市场深度 / 纳斯达克二级数据需要额外付费实时指数报价 * *超过700个市场统计 / 宽度指标（TICK，TRIN等），其中大多数每1秒更新一次！日历历史记录的180个日历日（包括上市后交易），带有微秒级的时间戳（如果可以从交易所供稿获得）***超过11年的1分钟OHLCV历史数据，有关交易所 / 数据的授权取决于仪器和我们何时开始收集数据。***外汇回到2005年2月Eminis回到2005年9月美国股票/期货/指数可追溯到2007年5月伦敦股票和FTSE指数可追溯至2016年2月" + 
                "每天，每周和每月OHLCVOI长达80多年的历史数据取决于仪器和我们何时开始收集数据。†索引最早可追溯至1929年早在1994年的美国股票早在1993年的外汇早在1959年的美国期货早在1985年的伦敦股票和FTSE指数美国股票基本数据"
            };

            ThroughSupport WenHua = new ThroughSupport()
            {
                Name = "文华财经",
                Phone = "400-811-3366",
                Link = "https://www.wenhua.com.cn/",
                //Isok = 
                Info = "",
                Support = ""
            };

            ThroughSupport Wind = new ThroughSupport()
            {
                Name = "Wind资讯",
                Phone = "+86 400-820-9463",
                Link = "https://www.wind.com.cn/",
                //Isok = 
                Info = "",
                Support = ""
            };

            ThroughSupport SelfDefine = new ThroughSupport()
            {
                Name = "外部自定义数据源",
                Phone = "******",
                Link = "******",
                //Isok = 
                Info = "",
                Support = ""
            };

            dList.Add(tushare);
            dList.Add(Wangyi);
            dList.Add(TianQin);
            dList.Add(IQFeed);
            dList.Add(WenHua);
            dList.Add(Wind);
            dList.Add(SelfDefine);

            return dList;
        }

    }

}
