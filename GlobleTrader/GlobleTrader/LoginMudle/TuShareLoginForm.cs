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
    public partial class TuShareLoginForm : Form
    {
        public TuShareLoginForm()
        {
            InitializeComponent();
        }

        private void button_Test_Click(object sender, EventArgs e)
        {
            LoginRequest data = new LoginRequest();
            data.Exdata = this.textBox_apiName.Text + "|" + this.textBox_tocken.Text;

            HistoryRequest hisData = new HistoryRequest();
            hisData.Symbol = this.textBox_testStockCode.Text;
            hisData.Interval = Interval.Day_1;
            hisData.Proxy = PROXYTHROUGH.TuShare;
            hisData.STime = this.dateTimePicker_start.Value;
            hisData.eTime = this.dateTimePicker_end.Value;

            //初始化信息
            ProxyManager.GetInstance().GetProxy(PROXYTHROUGH.TuShare).Init(data);

            ///订阅数据 - 在这里注意顺序（是先订阅，再去查询，不然先去查询再去订阅是收不到的）
            ProxyManager.GetInstance().GetProxy(PROXYTHROUGH.TuShare).OnBarEvent += TuShareLoginForm_OnBarEvent;

            ///查询历史数据信息
            ProxyManager.GetInstance().GetProxy(PROXYTHROUGH.TuShare).QueryHistory(hisData);
         
        }

        private void TuShareLoginForm_OnBarEvent(List<BarData> barDList)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<List<BarData>>(TuShareLoginForm_OnBarEvent), barDList);
                return;
            }

            foreach(BarData barD in barDList)
            {
                this.richTextBox_Log.AppendText("\n" + barD.Symbol + " | " + barD.DTime + " | " + barD.ClosePrice.ToString());
            }
        }

        private void Form_Load(object sender, EventArgs e)
        {
            this.dateTimePicker_start.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker_start.CustomFormat = "yyyyMMdd";

            this.dateTimePicker_end.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker_end.CustomFormat = "yyyyMMdd";
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
