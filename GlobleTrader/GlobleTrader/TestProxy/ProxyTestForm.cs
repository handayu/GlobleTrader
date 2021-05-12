using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestProxy;

namespace WindowsFormsApp1
{
    public partial class ProxyTestForm : Form
    {


        public ProxyTestForm()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            ProxyManager.GetInstance().GetProxy(PROXYTHROUGH.Demo).OnContractEvent += ProxyTestForm_OnContractEvent; ;

        }

        private void ProxyTestForm_OnContractEvent(List<ContractData> contD)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<List<ContractData>>(ProxyTestForm_OnContractEvent), contD);
                return;
            }

            foreach(ContractData d in contD)
            {
                this.richTextBox_log.AppendText(d.Symbol + " " + d.Proxy + " " + d.Exchange + " " + d.Product);
            }
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            ProxyManager.GetInstance().GetProxy(PROXYTHROUGH.Demo).Init(null);
            ProxyManager.GetInstance().GetProxy(PROXYTHROUGH.Demo).Login();
        }

        private void button_logout_Click(object sender, EventArgs e)
        {
            ProxyManager.GetInstance().GetProxy(PROXYTHROUGH.Demo).Close();
        }

        private void button_dingyue_Click(object sender, EventArgs e)
        {
            ProxyManager.GetInstance().GetProxy(PROXYTHROUGH.Demo).QueryContract(null);
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
