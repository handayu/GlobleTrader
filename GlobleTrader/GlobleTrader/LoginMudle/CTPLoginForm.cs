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
    public partial class CTPLoginForm : Form
    {
        public CTPLoginForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Login_Click(object sender, EventArgs e)
        {
            //投资者 - 密码 - broker - autoCode - appId - productInfo - frontAddr

            LoginRequest data = new LoginRequest();
            data.Exdata = this.textBox_Investor.Text + "|" + 
                this.textBox_password.Text+ "|" + 
                this.textBox_broker.Text + "|" + 
                this.textBox_Code.Text + "|" + 
                this.textBox_appID.Text + "|" + 
                this.textBox_productInfo.Text + "|" + 
                this.textBox_TradeAddr.Text + "|" + 
                this.textBox_QuoteAddr;

            //初始化信息
            ProxyManager.GetInstance().GetProxy(PROXYTHROUGH.SimNow).Init(data);
            ProxyManager.GetInstance().GetProxy(PROXYTHROUGH.SimNow).Connect();
            ProxyManager.GetInstance().GetProxy(PROXYTHROUGH.SimNow).Login();


        }

        private void button_cancel_Click(object sender, EventArgs e)
        {

        }


    }
}
