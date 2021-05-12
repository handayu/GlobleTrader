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

            ProxyManager.GetInstance().GetProxy(PROXYTHROUGH.Okex_V5_Swap).OnLogEvent += OkexLoginForm_OnLogEventV5;
            ProxyManager.GetInstance().GetProxy(PROXYTHROUGH.Okex_V5_Swap).Init(lRequest);
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
        #endregion

    }
}
