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
    public partial class OkexLoginForm : Form
    {
        public OkexLoginForm()
        {
            InitializeComponent();
        }

        #region V3版本
        private void button_Login_Click(object sender, EventArgs e)
        {
            LoginRequest lRequest = new LoginRequest()
            {
                IP = this.textBox_apiKey.Text,
                Port = this.textBox_secrests.Text,
                Exdata = this.textBox_apiPhrease.Text
            };

            ProxyManager.GetInstance().GetProxy(PROXYTHROUGH.Okex_V3_Swap).OnLogEvent += OkexLoginForm_OnLogEvent;
            ProxyManager.GetInstance().GetProxy(PROXYTHROUGH.Okex_V3_Swap).Init(lRequest);
            ProxyManager.GetInstance().GetProxy(PROXYTHROUGH.Okex_V3_Swap).OnContractEvent += OkexLoginForm_OnContractEvent;

        }

        private void OkexLoginForm_OnContractEvent(List<ContractData> contDList)
        {
            foreach (ContractData contD in contDList)
            {
                string info = contD.Symbol + " | " + contD.Exchange.ToString() + "|" + contD.Product.ToString();
                this.richTextBox_QueryContract.AppendText("\n" + info);
            }

        }

        private void OkexLoginForm_OnLogEvent(LogData logD)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<LogData>(OkexLoginForm_OnLogEvent), logD);
                return;
            }
            this.richTextBox_log.AppendText("\n" + logD.Msg);
        }


        private void button_TestQueryAccount_Click(object sender, EventArgs e)
        {
            ContractRequest r = new ContractRequest();
            ProxyManager.GetInstance().GetProxy(PROXYTHROUGH.Okex_V3_Swap).QueryContract(r);
        }

        private void button_CloseAPi_Click(object sender, EventArgs e)
        {
            this.richTextBox_QueryContract.Clear();

            ProxyManager.GetInstance().GetProxy(PROXYTHROUGH.Okex_V3_Swap).OnLogEvent -= OkexLoginForm_OnLogEvent;
            ProxyManager.GetInstance().GetProxy(PROXYTHROUGH.Okex_V3_Swap).OnContractEvent -= OkexLoginForm_OnContractEvent; ;

            ProxyManager.GetInstance().GetProxy(PROXYTHROUGH.Okex_V3_Swap).Close();
        }

        #endregion

        #region V5版本
        private void button_Login_V5_Click(object sender, EventArgs e)
        {
            LoginRequest lRequest = new LoginRequest()
            {
                IP = this.textBox_apiKey_V5.Text,
                Port = this.textBox_secrets_V5.Text,
                Exdata = this.textBox_phrease_V5.Text
            };
            
            //订阅Log
            ProxyManager.GetInstance().GetProxy(PROXYTHROUGH.Okex_V5_Swap).OnLogEvent += OkexLoginForm_OnLogEventV5;
            
            //登陆
            ProxyManager.GetInstance().GetProxy(PROXYTHROUGH.Okex_V5_Swap).Init(lRequest);

            //登陆完毕设置账户模式
            //配置设置已经在Form_Load初始化radio_button_check时初始化了，切换可以radio_btn进行

            //ProxyManager.GetInstance().GetProxy(PROXYTHROUGH.Okex_V5_Swap).OnContractEvent += OkexLoginForm_OnContractEvent;
        }

        private void OkexLoginForm_OnLogEventV5(LogData logD)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<LogData>(OkexLoginForm_OnLogEventV5), logD);
                return;
            }
            this.richTextBox_log_V5.AppendText("\n" + logD.Msg);
        }

        private void button_CloseApi_V5_Click(object sender, EventArgs e)
        {
            this.richTextBox_Contract_V5.Clear();

            ProxyManager.GetInstance().GetProxy(PROXYTHROUGH.Okex_V5_Swap).OnLogEvent -= OkexLoginForm_OnLogEvent;
            ProxyManager.GetInstance().GetProxy(PROXYTHROUGH.Okex_V5_Swap).OnContractEvent -= OkexLoginForm_OnContractEvent; ;

            ProxyManager.GetInstance().GetProxy(PROXYTHROUGH.Okex_V5_Swap).Close();
        }

        private void button_TestQueryContract_V5_Click(object sender, EventArgs e)
        {
            ContractRequest r = new ContractRequest();
            ProxyManager.GetInstance().GetProxy(PROXYTHROUGH.Okex_V5_Swap).QueryContract(r);
        }
        #endregion

        #region 公共设置
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            this.radioButton_BBCash_V5.Checked = false;
            this.radioButton_BBCross_V5.Checked = false;
            this.radioButton_SwapCross_V5.Checked = true;
            this.radioButton_SwapIoslated_V5.Checked = false;
        }

        #endregion

        #region V5配置设置
        private void radioButton_BBCash_V5_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.radioButton_BBCash_V5.Checked) return;

            ProxyConfig pConfig = new ProxyConfig();
            pConfig.Data = "cash";
            ProxyManager.GetInstance().GetProxy(PROXYTHROUGH.Okex_V5_Swap).ProxyConfig = pConfig;
        }

        private void radioButton_BBCross_V5_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.radioButton_BBCross_V5.Checked) return;

            ProxyConfig pConfig = new ProxyConfig();
            pConfig.Data = "cross";
            ProxyManager.GetInstance().GetProxy(PROXYTHROUGH.Okex_V5_Swap).ProxyConfig = pConfig;
        }

        private void radioButton_SwapCross_V5_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.radioButton_SwapCross_V5.Checked) return;

            ProxyConfig pConfig = new ProxyConfig();
            pConfig.Data = "cross";
            ProxyManager.GetInstance().GetProxy(PROXYTHROUGH.Okex_V5_Swap).ProxyConfig = pConfig;
        }

        private void radioButton_SwapIoslated_V5_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.radioButton_SwapIoslated_V5.Checked) return;

            ProxyConfig pConfig = new ProxyConfig();
            pConfig.Data = "isolated";
            ProxyManager.GetInstance().GetProxy(PROXYTHROUGH.Okex_V5_Swap).ProxyConfig = pConfig;
        }
        #endregion
    }
}
