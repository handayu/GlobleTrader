
namespace WindowsFormsApp1
{
    partial class IBContractUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.requestMatchingSymbolsCD = new System.Windows.Forms.Button();
            this.searchContractDetails = new System.Windows.Forms.Button();
            this.conDetSymbolLabel = new System.Windows.Forms.Label();
            this.conDetRightLabel = new System.Windows.Forms.Label();
            this.contractDetailsGroupBox = new System.Windows.Forms.GroupBox();
            this.conDetStrikeLabel = new System.Windows.Forms.Label();
            this.conDetRight = new System.Windows.Forms.ComboBox();
            this.conDetLastTradeDateLabel = new System.Windows.Forms.Label();
            this.conDetSecType = new System.Windows.Forms.ComboBox();
            this.conDetMultiplierLabel = new System.Windows.Forms.Label();
            this.conDetSecTypeLabel = new System.Windows.Forms.Label();
            this.conDetLocalSymbolLabel = new System.Windows.Forms.Label();
            this.conDetExchangeLabel = new System.Windows.Forms.Label();
            this.conDetExchange = new System.Windows.Forms.TextBox();
            this.conDetLocalSymbol = new System.Windows.Forms.TextBox();
            this.conDetMultiplier = new System.Windows.Forms.TextBox();
            this.conDetCurrencyLabel = new System.Windows.Forms.Label();
            this.conDetCurrency = new System.Windows.Forms.TextBox();
            this.conDetLastTradeDateOrContractMonth = new System.Windows.Forms.TextBox();
            this.conDetStrike = new System.Windows.Forms.TextBox();
            this.conDetSymbol = new System.Windows.Forms.TextBox();
            this.contractDetailsGrid = new System.Windows.Forms.DataGridView();
            this.conResSymbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conResLocalSymbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conResSecType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conResCurrency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conResExchange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conResPrimaryExch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conResLastTradeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conResMultiplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conResStrike = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conResRight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conResConId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conResMdSizeMultiplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conResAggGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conResUnderSymbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conResUnderSecType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conResMarketRuleIds = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conResRealExpirationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conResContractMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conResLastTradeTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conResTimeZoneId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contractDetailsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contractDetailsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // requestMatchingSymbolsCD
            // 
            this.requestMatchingSymbolsCD.Location = new System.Drawing.Point(211, 133);
            this.requestMatchingSymbolsCD.Name = "requestMatchingSymbolsCD";
            this.requestMatchingSymbolsCD.Size = new System.Drawing.Size(75, 21);
            this.requestMatchingSymbolsCD.TabIndex = 60;
            this.requestMatchingSymbolsCD.Text = "Match Symb";
            this.requestMatchingSymbolsCD.UseVisualStyleBackColor = true;
            // 
            // searchContractDetails
            // 
            this.searchContractDetails.Location = new System.Drawing.Point(309, 133);
            this.searchContractDetails.Name = "searchContractDetails";
            this.searchContractDetails.Size = new System.Drawing.Size(75, 21);
            this.searchContractDetails.TabIndex = 34;
            this.searchContractDetails.Text = "Search";
            this.searchContractDetails.UseMnemonic = false;
            this.searchContractDetails.UseVisualStyleBackColor = true;
            // 
            // conDetSymbolLabel
            // 
            this.conDetSymbolLabel.AutoSize = true;
            this.conDetSymbolLabel.Location = new System.Drawing.Point(20, 24);
            this.conDetSymbolLabel.Name = "conDetSymbolLabel";
            this.conDetSymbolLabel.Size = new System.Drawing.Size(41, 12);
            this.conDetSymbolLabel.TabIndex = 17;
            this.conDetSymbolLabel.Text = "Symbol";
            // 
            // conDetRightLabel
            // 
            this.conDetRightLabel.AutoSize = true;
            this.conDetRightLabel.Location = new System.Drawing.Point(16, 117);
            this.conDetRightLabel.Name = "conDetRightLabel";
            this.conDetRightLabel.Size = new System.Drawing.Size(53, 12);
            this.conDetRightLabel.TabIndex = 59;
            this.conDetRightLabel.Text = "Put/Call";
            // 
            // contractDetailsGroupBox
            // 
            this.contractDetailsGroupBox.Controls.Add(this.requestMatchingSymbolsCD);
            this.contractDetailsGroupBox.Controls.Add(this.searchContractDetails);
            this.contractDetailsGroupBox.Controls.Add(this.conDetSymbolLabel);
            this.contractDetailsGroupBox.Controls.Add(this.conDetRightLabel);
            this.contractDetailsGroupBox.Controls.Add(this.conDetStrikeLabel);
            this.contractDetailsGroupBox.Controls.Add(this.conDetRight);
            this.contractDetailsGroupBox.Controls.Add(this.conDetLastTradeDateLabel);
            this.contractDetailsGroupBox.Controls.Add(this.conDetSecType);
            this.contractDetailsGroupBox.Controls.Add(this.conDetMultiplierLabel);
            this.contractDetailsGroupBox.Controls.Add(this.conDetSecTypeLabel);
            this.contractDetailsGroupBox.Controls.Add(this.conDetLocalSymbolLabel);
            this.contractDetailsGroupBox.Controls.Add(this.conDetExchangeLabel);
            this.contractDetailsGroupBox.Controls.Add(this.conDetExchange);
            this.contractDetailsGroupBox.Controls.Add(this.conDetLocalSymbol);
            this.contractDetailsGroupBox.Controls.Add(this.conDetMultiplier);
            this.contractDetailsGroupBox.Controls.Add(this.conDetCurrencyLabel);
            this.contractDetailsGroupBox.Controls.Add(this.conDetCurrency);
            this.contractDetailsGroupBox.Controls.Add(this.conDetLastTradeDateOrContractMonth);
            this.contractDetailsGroupBox.Controls.Add(this.conDetStrike);
            this.contractDetailsGroupBox.Controls.Add(this.conDetSymbol);
            this.contractDetailsGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.contractDetailsGroupBox.Location = new System.Drawing.Point(0, 0);
            this.contractDetailsGroupBox.Name = "contractDetailsGroupBox";
            this.contractDetailsGroupBox.Size = new System.Drawing.Size(407, 160);
            this.contractDetailsGroupBox.TabIndex = 34;
            this.contractDetailsGroupBox.TabStop = false;
            this.contractDetailsGroupBox.Text = "Contract details";
            // 
            // conDetStrikeLabel
            // 
            this.conDetStrikeLabel.AutoSize = true;
            this.conDetStrikeLabel.Location = new System.Drawing.Point(234, 84);
            this.conDetStrikeLabel.Name = "conDetStrikeLabel";
            this.conDetStrikeLabel.Size = new System.Drawing.Size(41, 12);
            this.conDetStrikeLabel.TabIndex = 21;
            this.conDetStrikeLabel.Text = "Strike";
            // 
            // conDetRight
            // 
            this.conDetRight.FormattingEnabled = true;
            this.conDetRight.Location = new System.Drawing.Point(86, 117);
            this.conDetRight.Name = "conDetRight";
            this.conDetRight.Size = new System.Drawing.Size(100, 20);
            this.conDetRight.TabIndex = 58;
            // 
            // conDetLastTradeDateLabel
            // 
            this.conDetLastTradeDateLabel.Location = new System.Drawing.Point(196, 47);
            this.conDetLastTradeDateLabel.Name = "conDetLastTradeDateLabel";
            this.conDetLastTradeDateLabel.Size = new System.Drawing.Size(86, 30);
            this.conDetLastTradeDateLabel.TabIndex = 20;
            this.conDetLastTradeDateLabel.Text = "Last trade date / contract month";
            // 
            // conDetSecType
            // 
            this.conDetSecType.FormattingEnabled = true;
            this.conDetSecType.Items.AddRange(new object[] {
            "STK",
            "OPT",
            "FUT",
            "CONTFUT",
            "CASH",
            "BOND",
            "CFD",
            "FOP",
            "WAR",
            "IOPT",
            "FWD",
            "BAG",
            "IND",
            "BILL",
            "FUND",
            "FIXED",
            "SLB",
            "NEWS",
            "CMDTY",
            "BSK",
            "ICU",
            "ICS"});
            this.conDetSecType.Location = new System.Drawing.Point(86, 44);
            this.conDetSecType.Name = "conDetSecType";
            this.conDetSecType.Size = new System.Drawing.Size(100, 20);
            this.conDetSecType.TabIndex = 18;
            this.conDetSecType.Text = "STK";
            // 
            // conDetMultiplierLabel
            // 
            this.conDetMultiplierLabel.AutoSize = true;
            this.conDetMultiplierLabel.Location = new System.Drawing.Point(220, 24);
            this.conDetMultiplierLabel.Name = "conDetMultiplierLabel";
            this.conDetMultiplierLabel.Size = new System.Drawing.Size(65, 12);
            this.conDetMultiplierLabel.TabIndex = 22;
            this.conDetMultiplierLabel.Text = "Multiplier";
            // 
            // conDetSecTypeLabel
            // 
            this.conDetSecTypeLabel.AutoSize = true;
            this.conDetSecTypeLabel.Location = new System.Drawing.Point(11, 44);
            this.conDetSecTypeLabel.Name = "conDetSecTypeLabel";
            this.conDetSecTypeLabel.Size = new System.Drawing.Size(47, 12);
            this.conDetSecTypeLabel.TabIndex = 19;
            this.conDetSecTypeLabel.Text = "SecType";
            // 
            // conDetLocalSymbolLabel
            // 
            this.conDetLocalSymbolLabel.AutoSize = true;
            this.conDetLocalSymbolLabel.Location = new System.Drawing.Point(198, 108);
            this.conDetLocalSymbolLabel.Name = "conDetLocalSymbolLabel";
            this.conDetLocalSymbolLabel.Size = new System.Drawing.Size(77, 12);
            this.conDetLocalSymbolLabel.TabIndex = 25;
            this.conDetLocalSymbolLabel.Text = "Local Symbol";
            // 
            // conDetExchangeLabel
            // 
            this.conDetExchangeLabel.AutoSize = true;
            this.conDetExchangeLabel.Location = new System.Drawing.Point(6, 93);
            this.conDetExchangeLabel.Name = "conDetExchangeLabel";
            this.conDetExchangeLabel.Size = new System.Drawing.Size(53, 12);
            this.conDetExchangeLabel.TabIndex = 23;
            this.conDetExchangeLabel.Text = "Exchange";
            // 
            // conDetExchange
            // 
            this.conDetExchange.Location = new System.Drawing.Point(86, 93);
            this.conDetExchange.Name = "conDetExchange";
            this.conDetExchange.Size = new System.Drawing.Size(100, 21);
            this.conDetExchange.TabIndex = 27;
            this.conDetExchange.Text = "SMART";
            // 
            // conDetLocalSymbol
            // 
            this.conDetLocalSymbol.Location = new System.Drawing.Point(289, 108);
            this.conDetLocalSymbol.Name = "conDetLocalSymbol";
            this.conDetLocalSymbol.Size = new System.Drawing.Size(100, 21);
            this.conDetLocalSymbol.TabIndex = 31;
            // 
            // conDetMultiplier
            // 
            this.conDetMultiplier.Location = new System.Drawing.Point(290, 18);
            this.conDetMultiplier.Name = "conDetMultiplier";
            this.conDetMultiplier.Size = new System.Drawing.Size(100, 21);
            this.conDetMultiplier.TabIndex = 28;
            // 
            // conDetCurrencyLabel
            // 
            this.conDetCurrencyLabel.AutoSize = true;
            this.conDetCurrencyLabel.Location = new System.Drawing.Point(12, 69);
            this.conDetCurrencyLabel.Name = "conDetCurrencyLabel";
            this.conDetCurrencyLabel.Size = new System.Drawing.Size(53, 12);
            this.conDetCurrencyLabel.TabIndex = 24;
            this.conDetCurrencyLabel.Text = "Currency";
            // 
            // conDetCurrency
            // 
            this.conDetCurrency.Location = new System.Drawing.Point(86, 69);
            this.conDetCurrency.Name = "conDetCurrency";
            this.conDetCurrency.Size = new System.Drawing.Size(100, 21);
            this.conDetCurrency.TabIndex = 26;
            this.conDetCurrency.Text = "USD";
            // 
            // conDetLastTradeDateOrContractMonth
            // 
            this.conDetLastTradeDateOrContractMonth.Location = new System.Drawing.Point(288, 54);
            this.conDetLastTradeDateOrContractMonth.Name = "conDetLastTradeDateOrContractMonth";
            this.conDetLastTradeDateOrContractMonth.Size = new System.Drawing.Size(100, 21);
            this.conDetLastTradeDateOrContractMonth.TabIndex = 30;
            // 
            // conDetStrike
            // 
            this.conDetStrike.Location = new System.Drawing.Point(289, 84);
            this.conDetStrike.Name = "conDetStrike";
            this.conDetStrike.Size = new System.Drawing.Size(100, 21);
            this.conDetStrike.TabIndex = 29;
            this.conDetStrike.Text = "10";
            // 
            // conDetSymbol
            // 
            this.conDetSymbol.Location = new System.Drawing.Point(86, 21);
            this.conDetSymbol.Name = "conDetSymbol";
            this.conDetSymbol.Size = new System.Drawing.Size(100, 21);
            this.conDetSymbol.TabIndex = 16;
            this.conDetSymbol.Text = "IBKR";
            // 
            // contractDetailsGrid
            // 
            this.contractDetailsGrid.AllowUserToAddRows = false;
            this.contractDetailsGrid.AllowUserToDeleteRows = false;
            this.contractDetailsGrid.AllowUserToOrderColumns = true;
            this.contractDetailsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.contractDetailsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.conResSymbol,
            this.conResLocalSymbol,
            this.conResSecType,
            this.conResCurrency,
            this.conResExchange,
            this.conResPrimaryExch,
            this.conResLastTradeDate,
            this.conResMultiplier,
            this.conResStrike,
            this.conResRight,
            this.conResConId,
            this.conResMdSizeMultiplier,
            this.conResAggGroup,
            this.conResUnderSymbol,
            this.conResUnderSecType,
            this.conResMarketRuleIds,
            this.conResRealExpirationDate,
            this.conResContractMonth,
            this.conResLastTradeTime,
            this.conResTimeZoneId});
            this.contractDetailsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contractDetailsGrid.Location = new System.Drawing.Point(0, 160);
            this.contractDetailsGrid.Name = "contractDetailsGrid";
            this.contractDetailsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.contractDetailsGrid.Size = new System.Drawing.Size(407, 234);
            this.contractDetailsGrid.TabIndex = 35;
            // 
            // conResSymbol
            // 
            this.conResSymbol.HeaderText = "Symbol";
            this.conResSymbol.Name = "conResSymbol";
            this.conResSymbol.ReadOnly = true;
            // 
            // conResLocalSymbol
            // 
            this.conResLocalSymbol.HeaderText = "Local Symbol";
            this.conResLocalSymbol.Name = "conResLocalSymbol";
            this.conResLocalSymbol.ReadOnly = true;
            // 
            // conResSecType
            // 
            this.conResSecType.HeaderText = "Type";
            this.conResSecType.Name = "conResSecType";
            this.conResSecType.ReadOnly = true;
            // 
            // conResCurrency
            // 
            this.conResCurrency.HeaderText = "Currency";
            this.conResCurrency.Name = "conResCurrency";
            this.conResCurrency.ReadOnly = true;
            // 
            // conResExchange
            // 
            this.conResExchange.HeaderText = "Exchange";
            this.conResExchange.Name = "conResExchange";
            this.conResExchange.ReadOnly = true;
            // 
            // conResPrimaryExch
            // 
            this.conResPrimaryExch.HeaderText = "Primary Exch.";
            this.conResPrimaryExch.Name = "conResPrimaryExch";
            this.conResPrimaryExch.ReadOnly = true;
            // 
            // conResLastTradeDate
            // 
            this.conResLastTradeDate.HeaderText = "LastTradeDate";
            this.conResLastTradeDate.Name = "conResLastTradeDate";
            this.conResLastTradeDate.ReadOnly = true;
            this.conResLastTradeDate.Width = 150;
            // 
            // conResMultiplier
            // 
            this.conResMultiplier.HeaderText = "Multiplier";
            this.conResMultiplier.Name = "conResMultiplier";
            this.conResMultiplier.ReadOnly = true;
            // 
            // conResStrike
            // 
            this.conResStrike.HeaderText = "Strike";
            this.conResStrike.Name = "conResStrike";
            this.conResStrike.ReadOnly = true;
            // 
            // conResRight
            // 
            this.conResRight.HeaderText = "P/C";
            this.conResRight.Name = "conResRight";
            this.conResRight.ReadOnly = true;
            // 
            // conResConId
            // 
            this.conResConId.HeaderText = "ConId";
            this.conResConId.Name = "conResConId";
            this.conResConId.ReadOnly = true;
            // 
            // conResMdSizeMultiplier
            // 
            this.conResMdSizeMultiplier.HeaderText = "MD Size Mult";
            this.conResMdSizeMultiplier.Name = "conResMdSizeMultiplier";
            // 
            // conResAggGroup
            // 
            this.conResAggGroup.HeaderText = "Agg Group";
            this.conResAggGroup.Name = "conResAggGroup";
            // 
            // conResUnderSymbol
            // 
            this.conResUnderSymbol.HeaderText = "Under Symb";
            this.conResUnderSymbol.Name = "conResUnderSymbol";
            // 
            // conResUnderSecType
            // 
            this.conResUnderSecType.HeaderText = "Under SecType";
            this.conResUnderSecType.Name = "conResUnderSecType";
            this.conResUnderSecType.Width = 120;
            // 
            // conResMarketRuleIds
            // 
            this.conResMarketRuleIds.HeaderText = "Market Rule Ids";
            this.conResMarketRuleIds.Name = "conResMarketRuleIds";
            this.conResMarketRuleIds.Width = 300;
            // 
            // conResRealExpirationDate
            // 
            this.conResRealExpirationDate.HeaderText = "Real Exp Date";
            this.conResRealExpirationDate.Name = "conResRealExpirationDate";
            // 
            // conResContractMonth
            // 
            this.conResContractMonth.HeaderText = "Contract Month";
            this.conResContractMonth.Name = "conResContractMonth";
            // 
            // conResLastTradeTime
            // 
            this.conResLastTradeTime.HeaderText = "Last Trade Time";
            this.conResLastTradeTime.Name = "conResLastTradeTime";
            // 
            // conResTimeZoneId
            // 
            this.conResTimeZoneId.HeaderText = "Time Zone";
            this.conResTimeZoneId.Name = "conResTimeZoneId";
            // 
            // IBContractUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.contractDetailsGrid);
            this.Controls.Add(this.contractDetailsGroupBox);
            this.Name = "IBContractUserControl";
            this.Size = new System.Drawing.Size(407, 394);
            this.contractDetailsGroupBox.ResumeLayout(false);
            this.contractDetailsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contractDetailsGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button requestMatchingSymbolsCD;
        private System.Windows.Forms.Button searchContractDetails;
        private System.Windows.Forms.Label conDetSymbolLabel;
        private System.Windows.Forms.Label conDetRightLabel;
        private System.Windows.Forms.GroupBox contractDetailsGroupBox;
        private System.Windows.Forms.Label conDetStrikeLabel;
        private System.Windows.Forms.ComboBox conDetRight;
        private System.Windows.Forms.Label conDetLastTradeDateLabel;
        private System.Windows.Forms.ComboBox conDetSecType;
        private System.Windows.Forms.Label conDetMultiplierLabel;
        private System.Windows.Forms.Label conDetSecTypeLabel;
        private System.Windows.Forms.Label conDetLocalSymbolLabel;
        private System.Windows.Forms.Label conDetExchangeLabel;
        private System.Windows.Forms.TextBox conDetExchange;
        private System.Windows.Forms.TextBox conDetLocalSymbol;
        private System.Windows.Forms.TextBox conDetMultiplier;
        private System.Windows.Forms.Label conDetCurrencyLabel;
        private System.Windows.Forms.TextBox conDetCurrency;
        private System.Windows.Forms.TextBox conDetLastTradeDateOrContractMonth;
        private System.Windows.Forms.TextBox conDetStrike;
        private System.Windows.Forms.TextBox conDetSymbol;
        private System.Windows.Forms.DataGridView contractDetailsGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn conResSymbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn conResLocalSymbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn conResSecType;
        private System.Windows.Forms.DataGridViewTextBoxColumn conResCurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn conResExchange;
        private System.Windows.Forms.DataGridViewTextBoxColumn conResPrimaryExch;
        private System.Windows.Forms.DataGridViewTextBoxColumn conResLastTradeDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn conResMultiplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn conResStrike;
        private System.Windows.Forms.DataGridViewTextBoxColumn conResRight;
        private System.Windows.Forms.DataGridViewTextBoxColumn conResConId;
        private System.Windows.Forms.DataGridViewTextBoxColumn conResMdSizeMultiplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn conResAggGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn conResUnderSymbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn conResUnderSecType;
        private System.Windows.Forms.DataGridViewTextBoxColumn conResMarketRuleIds;
        private System.Windows.Forms.DataGridViewTextBoxColumn conResRealExpirationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn conResContractMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn conResLastTradeTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn conResTimeZoneId;
    }
}
