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
    public partial class AddInstruments : Form
    {
        private List<ItemComboBox> m_exthroughDataSourceList = new List<ItemComboBox>();
        private List<ItemComboBoxInterval> m_intervalDataSourceList = new List<ItemComboBoxInterval>();


        private BindingList<ContractData> m_insAllList = new BindingList<ContractData>();

        public delegate void OpenKLineHandle(ContractData cD,HistoryRequest hQ);
        public event OpenKLineHandle OpenKLineEvent;

        public AddInstruments()
        {
            InitializeComponent();

            //这句话放在Form_Load里会报dataSource为null，在这里不会抛出异常
            this.comboBox_dataSource.DataSource = m_exthroughDataSourceList;
            this.comboBox_Interval.DataSource = m_intervalDataSourceList;
        }

        public class ItemComboBox
        {
            public string DisplayName
            {
                get;
                set;
            }

            public string Value
            {
                get;
                set;
            }

            public PROXYTHROUGH EnumValue
            {
                get;
                set;
            }

        }

        public class ItemComboBoxInterval
        {
            public string DisplayName
            {
                get;
                set;
            }

            public string Value
            {
                get;
                set;
            }

            public Interval EnumValue
            {
                get;
                set;
            }

        }

        private void Form_Load(object sender, EventArgs e)
        {
            //添加数据源Combox - 数据源
            Type parematerType = typeof(PROXYTHROUGH);
            foreach (int index in Enum.GetValues(parematerType))
            {
                string name = Enum.GetName(parematerType, index);
                string value = index.ToString();
                //需要增加引用：System.Web
                //引用命名空间：using System.Web.UI.WebControls;
                //ListBox 也可用这个方法
                ItemComboBox iT = new ItemComboBox();
                iT.DisplayName = name;
                iT.Value = value;
                int iS = 0;
                int.TryParse(value, out iS);
                iT.EnumValue = (PROXYTHROUGH)(iS);
                m_exthroughDataSourceList.Add(iT);
            }

            this.comboBox_dataSource.DisplayMember = "DisplayName";
            this.comboBox_dataSource.ValueMember = "EnumValue";


            //添加数据源周期 - 枚举值
            Type interValType = typeof(Interval);
            foreach (int index in Enum.GetValues(interValType))
            {
                string name = Enum.GetName(interValType, index);
                string value = index.ToString();
                //需要增加引用：System.Web
                //引用命名空间：using System.Web.UI.WebControls;
                //ListBox 也可用这个方法
                ItemComboBoxInterval iT = new ItemComboBoxInterval();
                iT.DisplayName = name;
                iT.Value = value;
                int iS = 0;
                int.TryParse(value, out iS);
                iT.EnumValue = (Interval)(iS);
                m_intervalDataSourceList.Add(iT);
            }

            this.comboBox_Interval.DisplayMember = "DisplayName";
            this.comboBox_Interval.ValueMember = "EnumValue";


            //绑定DataGridView数据（所有datagridview都绑定到同一个回调上）
            //this.dataGridView_Stock1.CellContentDoubleClick += DataGridView_CellContentDoubleClick;
            this.dataGridView_allIns.DataSource = m_insAllList;

            InitControl();

        }

        /// <summary>
        /// 初始化订阅型控件
        /// </summary>
        private void InitControl()
        {
            this.comboBox_Interval.SelectedIndex = 1;//一分钟
            this.comboBox_AskBidtype.SelectedIndex = 0;
            this.comboBox_ChartType.SelectedIndex = 0;
            this.comboBox_Utc.SelectedIndex = 0;
            this.comboBox_volumeBase.SelectedIndex = 0;
            this.dateTimePicker_StartTime.Value = this.dateTimePicker_StartTime.Value.AddDays(-100);
            this.dateTimePicker_endTime.Value = DateTime.Now;
        }

        /// <summary>
        /// 承载所有数据源的回调，在这里组合Combox合约，并查询历史数据-订阅实时行情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //HoldQueryContract();
        }

        private void button_addInstrument_Click(object sender, EventArgs e)
        {
            int index = this.comboBox_dataSource.SelectedIndex;
            PROXYTHROUGH selProxy = (PROXYTHROUGH)(index);

            QueryContractForm f = new QueryContractForm(selProxy);
            if(DialogResult.Cancel ==  f.ShowDialog())
            {
                //在Uqery里查询后，内存里已经加了包含原来的有一份了，需要清空datagrid_view_all同一个数据源可以累加，结合combo_proxy，把查询的添加到grid
                m_insAllList.Clear();
                List<ContractData> cList = ProxyManager.GetInstance().GetProxy(selProxy).ContractData;
                foreach(ContractData c in cList)
                {
                    m_insAllList.Add(c);
                }
            }    
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        /// <summary>
        /// 所有合约Tab-DataGridView双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CellContentDoubleClick_AllInsDataGridView(object sender, DataGridViewCellEventArgs e)
        {
            if(OpenKLineEvent != null)
            {
                ContractData cD = this.dataGridView_allIns.Rows[e.RowIndex].DataBoundItem as ContractData;

                int index = this.comboBox_dataSource.SelectedIndex;
                PROXYTHROUGH selProxy = (PROXYTHROUGH)(index);

                int indexInterVal = this.comboBox_Interval.SelectedIndex;
                Interval selInterVal = (Interval)(indexInterVal);

                //构造订阅的参数 - (行情周期，开始时间，结束时间，时区，数据类型[ask/bid/traded]..有的可以默认，有的可以暂时不计)
                HistoryRequest hQ = new HistoryRequest();
                hQ.Proxy = selProxy; //数据源
                hQ.Symbol = cD.Symbol;//品种
                hQ.Exchange = cD.Exchange;//交易所
                hQ.STime = this.dateTimePicker_StartTime.Value;//开始时间
                hQ.eTime = this.dateTimePicker_endTime.Value;//结束时间
                hQ.Interval = selInterVal;//订阅的交易周期

                if (null == cD) return;
                OpenKLineEvent(cD, hQ);//两个对象解决问题

                //this.Hide();
            }
        }

        private void SelectIndexChanged_DataSource(object sender, EventArgs e)
        {
            int index = this.comboBox_dataSource.SelectedIndex;
            PROXYTHROUGH selProxy = (PROXYTHROUGH)(index);

            m_insAllList.Clear();//来自不同的数据源-需要清空

            List<ContractData> cList = ProxyManager.GetInstance().GetProxy(selProxy).ContractData;
            foreach (ContractData c in cList)
            {
                m_insAllList.Add(c);
            }
        }
    }
}
