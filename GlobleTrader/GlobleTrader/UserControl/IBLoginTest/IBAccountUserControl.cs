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
    public partial class IBAccountUserControl : UserControl
    {
        private BindingList<AccountData> m_bindAccountList = new BindingList<AccountData>();

        public IBAccountUserControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 查询资金
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void accSummaryRequest_Click(object sender, EventArgs e)
        {
            try
            {
                this.m_bindAccountList.Clear();

                BaseProxy proxyIb = TestProxy.ProxyManager.GetInstance().GetProxy(TestProxy.PROXYTHROUGH.IB);
                if (proxyIb.IsMdLogin && proxyIb.IsTdLogin)
                {
                    List<AccountData> accountsList = proxyIb.AccountData;

                    //添加到绑定的数据类型上
                    foreach (AccountData a in accountsList)
                    {
                        m_bindAccountList.Add(a);
                    }

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Form_Load(object sender, EventArgs e)
        {
            this.accSummaryGrid.DataSource = m_bindAccountList;
        }

        private void DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
