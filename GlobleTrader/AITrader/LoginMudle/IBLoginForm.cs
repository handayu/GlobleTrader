using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestProxy;

namespace WindowsFormsApp1
{
    public partial class IBLoginForm : Form
    {
        public IBLoginForm()
        {
            InitializeComponent();
        }

        private void button_Connect_Click(object sender, EventArgs e)
        {
            ReqLoginData data = new ReqLoginData();
            data.IP = this.textBox_IP.Text;
            data.Port = this.textBox_Port.Text;
            data.Exdata = this.textBox_ClientID.Text;

            //ReqHistoryData hisData = new ReqHistoryData();
            //hisData.Code = this.textBox_testStockCode.Text;
            //hisData.Interval = Interval.Day;
            //hisData.Product = Product.Stock;
            //hisData.StartDate = this.dateTimePicker_start.Value;
            //hisData.EndDate = this.dateTimePicker_end.Value;
            //初始化信息
            ProxyManager.GetInstance().GetProxy(PROXYTHROUGH.IB).Init(data);

            ///查询历史数据信息
            //ProxyManager.GetInstance().GetProxy(PROXYTHROUGH.TuShare).QueryHistory(hisData);

            ///订阅数据
            ProxyManager.GetInstance().GetProxy(PROXYTHROUGH.IB).OnLogEvent += IBLoginForm_OnLogEvent; ;
        }

        private void IBLoginForm_OnLogEvent(string info)
        {
            if(this.InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(IBLoginForm_OnLogEvent), info);
                return;
            }
            this.richTextBox_Log.AppendText("\n" + info);
        }
    }
}
