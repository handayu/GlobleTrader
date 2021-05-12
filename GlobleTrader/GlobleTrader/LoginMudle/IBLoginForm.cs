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
        //private IBMarketDataUserControl ibMarketDataUserControl1;
        //private IBAccountUserControl ibAccountUserControl1;
        //private IBContractUserControl ibContractUserControl1;

        public IBLoginForm()
        {
            InitializeComponent();

            //AddControl();
        }

        //private void AddControl()
        //{

        //    this.ibMarketDataUserControl1 = new IBMarketDataUserControl();
        //    this.ibAccountUserControl1 = new IBAccountUserControl();
        //    this.ibContractUserControl1 = new IBContractUserControl();


        //    this.tabPage5.Controls.Add(this.ibMarketDataUserControl1);
        //    this.tabPage9.Controls.Add(this.ibContractUserControl1);
        //    this.tabPage6.Controls.Add(this.ibAccountUserControl1);

        //    // 
        //    // ibMarketDataUserControl1
        //    // 
        //    this.ibMarketDataUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
        //    this.ibMarketDataUserControl1.Location = new System.Drawing.Point(3, 3);
        //    this.ibMarketDataUserControl1.Name = "ibMarketDataUserControl1";
        //    this.ibMarketDataUserControl1.Size = new System.Drawing.Size(633, 382);
        //    this.ibMarketDataUserControl1.TabIndex = 0;
        //    // 
        //    // ibAccountUserControl1
        //    // 
        //    this.ibAccountUserControl1.BackColor = System.Drawing.Color.Transparent;
        //    this.ibAccountUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
        //    this.ibAccountUserControl1.Location = new System.Drawing.Point(3, 3);
        //    this.ibAccountUserControl1.Name = "ibAccountUserControl1";
        //    this.ibAccountUserControl1.Size = new System.Drawing.Size(633, 382);
        //    this.ibAccountUserControl1.TabIndex = 0;
        //    // 
        //    // ibContractUserControl1
        //    // 
        //    this.ibContractUserControl1.BackColor = System.Drawing.Color.White;
        //    this.ibContractUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
        //    this.ibContractUserControl1.Location = new System.Drawing.Point(0, 0);
        //    this.ibContractUserControl1.Name = "ibContractUserControl1";
        //    this.ibContractUserControl1.Size = new System.Drawing.Size(639, 388);
        //    this.ibContractUserControl1.TabIndex = 0;
        //}

        private void IBLoginForm_OnLogEvent(LogData info)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<LogData>(IBLoginForm_OnLogEvent), info);
                return;
            }
            this.richTextBox_Log.AppendText("\n" + info.Msg);
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            LoginRequest data = new LoginRequest();
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
            ProxyManager.GetInstance().GetProxy(PROXYTHROUGH.IB).OnLogEvent += IBLoginForm_OnLogEvent;
        }

        private void button_logout_Click(object sender, EventArgs e)
        {

        }

        private void button_cancel_Click(object sender, EventArgs e)
        {

        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
