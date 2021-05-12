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
    public partial class QueryContractForm : Form
    {
        private PROXYTHROUGH m_proxy = PROXYTHROUGH.NULL;
        private BindingList<ContractData> m_bindContractDataList = new BindingList<ContractData>();

        private List<ProductComboBox> m_productDataSourceList = new List<ProductComboBox>();
        private List<ExchangeComboBox> m_exchangeDataSourceList = new List<ExchangeComboBox>();
        private List<OptionComboBox> m_optionDataSourceList = new List<OptionComboBox>();

        public QueryContractForm(PROXYTHROUGH proxy)
        {
            InitializeComponent();
            m_proxy = proxy;

            //
            this.comboBox_product.DataSource = m_productDataSourceList;
            this.comboBox_exchange.DataSource = m_exchangeDataSourceList;
            this.comboBox_putCall.DataSource = m_optionDataSourceList;

        }

        public class ProductComboBox
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

            public Product EnumValue
            {
                get;
                set;
            }

        }

        public class ExchangeComboBox
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

            public Exchange EnumValue
            {
                get;
                set;
            }

        }

        public class OptionComboBox
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

            public OptionType EnumValue
            {
                get;
                set;
            }

        }

        private void button_query_Click(object sender, EventArgs e)
        {
            ContractRequest rQ = new ContractRequest();
            rQ.Proxy = m_proxy;
            rQ.Symbol = this.textBox_symbol.Text;

            int indexP = this.comboBox_product.SelectedIndex;
            Product pro = (Product)(indexP);

            rQ.Product = pro;

            int indexO = this.comboBox_putCall.SelectedIndex;
            OptionType opt = (OptionType)(indexO);
            rQ.OpType = opt;

            int indexE = this.comboBox_exchange.SelectedIndex;
            Exchange exc = (Exchange)(indexE);
            rQ.Exchange = exc;

            rQ.Curreny = Currency.NULL;

            ProxyManager.GetInstance().GetProxy(m_proxy).QueryContract(rQ);
        }

        private void Form_Load(object sender, EventArgs e)
        {
            //初始化Combox
            InitProductCombox();
            InitExchageCombox();
            InitOptionCombox();

            //绑定对应proxy-Contract
            ProxyManager.GetInstance().GetProxy(m_proxy).OnContractEvent += QueryContractForm_OnContractEvent;
            this.dataGridView_instruments.DataSource = m_bindContractDataList;
        }

        private void InitProductCombox()
        {
            Type productType = typeof(Product);
            foreach (int index in Enum.GetValues(productType))
            {
                string name = Enum.GetName(productType, index);
                string value = index.ToString();

                ProductComboBox iT = new ProductComboBox();
                iT.DisplayName = name;
                iT.Value = value;
                int iS = 0;
                int.TryParse(value, out iS);
                iT.EnumValue = (Product)(iS);
                m_productDataSourceList.Add(iT);
            }

            this.comboBox_product.DisplayMember = "DisplayName";
            this.comboBox_product.ValueMember = "EnumValue";
        }

        private void InitExchageCombox()
        {
            Type exchangeType = typeof(Exchange);
            foreach (int index in Enum.GetValues(exchangeType))
            {
                string name = Enum.GetName(exchangeType, index);
                string value = index.ToString();

                ExchangeComboBox iT = new ExchangeComboBox();
                iT.DisplayName = name;
                iT.Value = value;
                int iS = 0;
                int.TryParse(value, out iS);
                iT.EnumValue = (Exchange)(iS);
                m_exchangeDataSourceList.Add(iT);
            }

            this.comboBox_exchange.DisplayMember = "DisplayName";
            this.comboBox_exchange.ValueMember = "EnumValue";
        }

        private void InitOptionCombox()
        {
            Type optionType = typeof(OptionType);
            foreach (int index in Enum.GetValues(optionType))
            {
                string name = Enum.GetName(optionType, index);
                string value = index.ToString();

                OptionComboBox iT = new OptionComboBox();
                iT.DisplayName = name;
                iT.Value = value;
                int iS = 0;
                int.TryParse(value, out iS);
                iT.EnumValue = (OptionType)(iS);
                m_optionDataSourceList.Add(iT);
            }

            this.comboBox_putCall.DisplayMember = "DisplayName";
            this.comboBox_putCall.ValueMember = "EnumValue";
        }

        private void QueryContractForm_OnContractEvent(List<ContractData> contDList)
        {
            foreach(ContractData contD in contDList)
            {
                m_bindContractDataList.Add(contD);
            }
        }

        private void button_Quit_Click(object sender, EventArgs e)
        {
            ProxyManager.GetInstance().GetProxy(m_proxy).OnContractEvent -= QueryContractForm_OnContractEvent;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
