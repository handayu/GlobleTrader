using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestProxy;

namespace WindowsFormsApp1
{
    public partial class OrderAccountListForm : Form
    {

        private BindingList<AccountData> m_accountList = new BindingList<AccountData>();
        private BindingList<PositionData> m_positionList = new BindingList<PositionData>();

        public OrderAccountListForm()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            this.dataGridView_account.DataSource = m_accountList;
            this.dataGridView_position.DataSource = m_positionList;

            GetAccount();
            GetPosition();
        }

        /// <summary>
        /// 内存查询所有账户信息缓存
        /// </summary>
        private void GetAccount()
        {
            //获取所有Manager的Proxy,每个Proxy都有自己的AccountData,获取所有连接的AccoutData
            foreach (PROXYTHROUGH proxy in Enum.GetValues(typeof(PROXYTHROUGH)))
            {
                if (null == ProxyManager.GetInstance().GetProxy(proxy)) continue;

                List<AccountData> accList = ProxyManager.GetInstance().GetProxy(proxy).AccountData;
                if (accList == null || accList.Count <= 0) continue;
                foreach (AccountData d in accList)
                {
                    if (d == null) continue;
                    m_accountList.Add(d);
                }

            }
        }

        /// <summary>
        /// 内存查询所有持仓信息缓存
        /// </summary>
        private void GetPosition()
        {
            //获取所有Manager的Proxy,每个Proxy都有自己的AccountData,获取所有连接的AccoutData
            foreach (PROXYTHROUGH proxy in Enum.GetValues(typeof(PROXYTHROUGH)))
            {
                if (null == ProxyManager.GetInstance().GetProxy(proxy)) continue;

                List<PositionData> pDList = ProxyManager.GetInstance().GetProxy(proxy).Positions;
                if (pDList == null || pDList.Count <= 0) continue;
                foreach (PositionData d in pDList)
                {
                    if (d == null) continue;
                    m_positionList.Add(d);
                }

            }
        }
    }
}
