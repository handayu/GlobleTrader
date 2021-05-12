
namespace WindowsFormsApp1
{
    partial class IBMarketDataUserControl
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.primaryExchange = new System.Windows.Forms.TextBox();
            this.primaryExchLabel = new System.Windows.Forms.Label();
            this.genericTickList = new System.Windows.Forms.TextBox();
            this.genericTickListLabel = new System.Windows.Forms.Label();
            this.mdRightLabel = new System.Windows.Forms.Label();
            this.mdContractRight = new System.Windows.Forms.ComboBox();
            this.putcall_label_TMD_MDT = new System.Windows.Forms.Label();
            this.multiplier_TMD_MDT = new System.Windows.Forms.TextBox();
            this.symbol_label_TMD_MDT = new System.Windows.Forms.Label();
            this.secType_TMD_MDT = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.exchange_label_TMD_MDT = new System.Windows.Forms.Label();
            this.localSymbol_TMD_MDT = new System.Windows.Forms.TextBox();
            this.currency_label_TMD_MDT = new System.Windows.Forms.Label();
            this.lastTradeDateOrContractMonth_TMD_MDT = new System.Windows.Forms.TextBox();
            this.symbol_TMD_MDT = new System.Windows.Forms.TextBox();
            this.strike_TMD_MDT = new System.Windows.Forms.TextBox();
            this.currency_TMD_MDT = new System.Windows.Forms.TextBox();
            this.exchange_TMD_MDT = new System.Windows.Forms.TextBox();
            this.localSymbol_label_TMD_MDT = new System.Windows.Forms.Label();
            this.lastTradeDate_label_TMD_MDT = new System.Windows.Forms.Label();
            this.strike_label_TMD_MDT = new System.Windows.Forms.Label();
            this.requestMatchingSymbolsMD = new System.Windows.Forms.Button();
            this.cancelMarketDataRequests = new System.Windows.Forms.Button();
            this.marketData_Button = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbKeepUpToDate = new System.Windows.Forms.CheckBox();
            this.headTimestamp_button = new System.Windows.Forms.Button();
            this.contractMDRTH = new System.Windows.Forms.CheckBox();
            this.realTime_Button = new System.Windows.Forms.Button();
            this.histData_Button = new System.Windows.Forms.Button();
            this.hdEndDate_label_HDT = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.hdRequest_EndTime = new System.Windows.Forms.TextBox();
            this.hdRequest_WhatToShow = new System.Windows.Forms.ComboBox();
            this.hdRequest_Duration = new System.Windows.Forms.TextBox();
            this.includeExpired = new System.Windows.Forms.CheckBox();
            this.hdRequest_BarSize = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.hdRequest_TimeUnit = new System.Windows.Forms.ComboBox();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.requestMatchingSymbolsMD);
            this.groupBox1.Controls.Add(this.cancelMarketDataRequests);
            this.groupBox1.Controls.Add(this.marketData_Button);
            this.groupBox1.Controls.Add(this.genericTickList);
            this.groupBox1.Controls.Add(this.primaryExchange);
            this.groupBox1.Controls.Add(this.genericTickListLabel);
            this.groupBox1.Controls.Add(this.mdRightLabel);
            this.groupBox1.Controls.Add(this.primaryExchLabel);
            this.groupBox1.Controls.Add(this.mdContractRight);
            this.groupBox1.Controls.Add(this.symbol_label_TMD_MDT);
            this.groupBox1.Controls.Add(this.putcall_label_TMD_MDT);
            this.groupBox1.Controls.Add(this.localSymbol_label_TMD_MDT);
            this.groupBox1.Controls.Add(this.multiplier_TMD_MDT);
            this.groupBox1.Controls.Add(this.exchange_TMD_MDT);
            this.groupBox1.Controls.Add(this.lastTradeDateOrContractMonth_TMD_MDT);
            this.groupBox1.Controls.Add(this.strike_TMD_MDT);
            this.groupBox1.Controls.Add(this.currency_TMD_MDT);
            this.groupBox1.Controls.Add(this.lastTradeDate_label_TMD_MDT);
            this.groupBox1.Controls.Add(this.symbol_TMD_MDT);
            this.groupBox1.Controls.Add(this.strike_label_TMD_MDT);
            this.groupBox1.Controls.Add(this.currency_label_TMD_MDT);
            this.groupBox1.Controls.Add(this.localSymbol_TMD_MDT);
            this.groupBox1.Controls.Add(this.exchange_label_TMD_MDT);
            this.groupBox1.Controls.Add(this.secType_TMD_MDT);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(418, 384);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "合约设置";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.zedGraphControl1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(418, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(288, 384);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "行情显示";
            // 
            // primaryExchange
            // 
            this.primaryExchange.Location = new System.Drawing.Point(86, 135);
            this.primaryExchange.Name = "primaryExchange";
            this.primaryExchange.Size = new System.Drawing.Size(100, 21);
            this.primaryExchange.TabIndex = 61;
            // 
            // primaryExchLabel
            // 
            this.primaryExchLabel.AutoSize = true;
            this.primaryExchLabel.Location = new System.Drawing.Point(2, 138);
            this.primaryExchLabel.Name = "primaryExchLabel";
            this.primaryExchLabel.Size = new System.Drawing.Size(83, 12);
            this.primaryExchLabel.TabIndex = 60;
            this.primaryExchLabel.Text = "Primary Exch.";
            // 
            // genericTickList
            // 
            this.genericTickList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.genericTickList.Location = new System.Drawing.Point(304, 15);
            this.genericTickList.Name = "genericTickList";
            this.genericTickList.Size = new System.Drawing.Size(104, 21);
            this.genericTickList.TabIndex = 59;
            // 
            // genericTickListLabel
            // 
            this.genericTickListLabel.AutoSize = true;
            this.genericTickListLabel.Location = new System.Drawing.Point(190, 18);
            this.genericTickListLabel.Name = "genericTickListLabel";
            this.genericTickListLabel.Size = new System.Drawing.Size(107, 12);
            this.genericTickListLabel.TabIndex = 58;
            this.genericTickListLabel.Text = "Generic tick list";
            // 
            // mdRightLabel
            // 
            this.mdRightLabel.AutoSize = true;
            this.mdRightLabel.Location = new System.Drawing.Point(224, 80);
            this.mdRightLabel.Name = "mdRightLabel";
            this.mdRightLabel.Size = new System.Drawing.Size(53, 12);
            this.mdRightLabel.TabIndex = 57;
            this.mdRightLabel.Text = "Put/Call";
            // 
            // mdContractRight
            // 
            this.mdContractRight.FormattingEnabled = true;
            this.mdContractRight.Location = new System.Drawing.Point(304, 79);
            this.mdContractRight.Name = "mdContractRight";
            this.mdContractRight.Size = new System.Drawing.Size(104, 20);
            this.mdContractRight.TabIndex = 56;
            // 
            // putcall_label_TMD_MDT
            // 
            this.putcall_label_TMD_MDT.AutoSize = true;
            this.putcall_label_TMD_MDT.Location = new System.Drawing.Point(220, 132);
            this.putcall_label_TMD_MDT.Name = "putcall_label_TMD_MDT";
            this.putcall_label_TMD_MDT.Size = new System.Drawing.Size(65, 12);
            this.putcall_label_TMD_MDT.TabIndex = 6;
            this.putcall_label_TMD_MDT.Text = "Multiplier";
            // 
            // multiplier_TMD_MDT
            // 
            this.multiplier_TMD_MDT.Location = new System.Drawing.Point(304, 132);
            this.multiplier_TMD_MDT.Name = "multiplier_TMD_MDT";
            this.multiplier_TMD_MDT.Size = new System.Drawing.Size(104, 21);
            this.multiplier_TMD_MDT.TabIndex = 12;
            // 
            // symbol_label_TMD_MDT
            // 
            this.symbol_label_TMD_MDT.AutoSize = true;
            this.symbol_label_TMD_MDT.Location = new System.Drawing.Point(32, 17);
            this.symbol_label_TMD_MDT.Name = "symbol_label_TMD_MDT";
            this.symbol_label_TMD_MDT.Size = new System.Drawing.Size(41, 12);
            this.symbol_label_TMD_MDT.TabIndex = 1;
            this.symbol_label_TMD_MDT.Text = "Symbol";
            // 
            // secType_TMD_MDT
            // 
            this.secType_TMD_MDT.FormattingEnabled = true;
            this.secType_TMD_MDT.Items.AddRange(new object[] {
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
            this.secType_TMD_MDT.Location = new System.Drawing.Point(86, 37);
            this.secType_TMD_MDT.Name = "secType_TMD_MDT";
            this.secType_TMD_MDT.Size = new System.Drawing.Size(100, 20);
            this.secType_TMD_MDT.TabIndex = 2;
            this.secType_TMD_MDT.Text = "CASH";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "SecType";
            // 
            // exchange_label_TMD_MDT
            // 
            this.exchange_label_TMD_MDT.AutoSize = true;
            this.exchange_label_TMD_MDT.Location = new System.Drawing.Point(18, 86);
            this.exchange_label_TMD_MDT.Name = "exchange_label_TMD_MDT";
            this.exchange_label_TMD_MDT.Size = new System.Drawing.Size(53, 12);
            this.exchange_label_TMD_MDT.TabIndex = 7;
            this.exchange_label_TMD_MDT.Text = "Exchange";
            // 
            // localSymbol_TMD_MDT
            // 
            this.localSymbol_TMD_MDT.Location = new System.Drawing.Point(86, 111);
            this.localSymbol_TMD_MDT.Name = "localSymbol_TMD_MDT";
            this.localSymbol_TMD_MDT.Size = new System.Drawing.Size(100, 21);
            this.localSymbol_TMD_MDT.TabIndex = 15;
            // 
            // currency_label_TMD_MDT
            // 
            this.currency_label_TMD_MDT.AutoSize = true;
            this.currency_label_TMD_MDT.Location = new System.Drawing.Point(24, 62);
            this.currency_label_TMD_MDT.Name = "currency_label_TMD_MDT";
            this.currency_label_TMD_MDT.Size = new System.Drawing.Size(53, 12);
            this.currency_label_TMD_MDT.TabIndex = 8;
            this.currency_label_TMD_MDT.Text = "Currency";
            // 
            // lastTradeDateOrContractMonth_TMD_MDT
            // 
            this.lastTradeDateOrContractMonth_TMD_MDT.Location = new System.Drawing.Point(304, 43);
            this.lastTradeDateOrContractMonth_TMD_MDT.Name = "lastTradeDateOrContractMonth_TMD_MDT";
            this.lastTradeDateOrContractMonth_TMD_MDT.Size = new System.Drawing.Size(104, 21);
            this.lastTradeDateOrContractMonth_TMD_MDT.TabIndex = 14;
            // 
            // symbol_TMD_MDT
            // 
            this.symbol_TMD_MDT.Location = new System.Drawing.Point(86, 14);
            this.symbol_TMD_MDT.Name = "symbol_TMD_MDT";
            this.symbol_TMD_MDT.Size = new System.Drawing.Size(100, 21);
            this.symbol_TMD_MDT.TabIndex = 0;
            this.symbol_TMD_MDT.Text = "EUR";
            // 
            // strike_TMD_MDT
            // 
            this.strike_TMD_MDT.Location = new System.Drawing.Point(304, 105);
            this.strike_TMD_MDT.Name = "strike_TMD_MDT";
            this.strike_TMD_MDT.Size = new System.Drawing.Size(104, 21);
            this.strike_TMD_MDT.TabIndex = 13;
            // 
            // currency_TMD_MDT
            // 
            this.currency_TMD_MDT.Location = new System.Drawing.Point(86, 62);
            this.currency_TMD_MDT.Name = "currency_TMD_MDT";
            this.currency_TMD_MDT.Size = new System.Drawing.Size(100, 21);
            this.currency_TMD_MDT.TabIndex = 10;
            this.currency_TMD_MDT.Text = "USD";
            // 
            // exchange_TMD_MDT
            // 
            this.exchange_TMD_MDT.Location = new System.Drawing.Point(86, 86);
            this.exchange_TMD_MDT.Name = "exchange_TMD_MDT";
            this.exchange_TMD_MDT.Size = new System.Drawing.Size(100, 21);
            this.exchange_TMD_MDT.TabIndex = 11;
            this.exchange_TMD_MDT.Text = "IDEALPRO";
            // 
            // localSymbol_label_TMD_MDT
            // 
            this.localSymbol_label_TMD_MDT.AutoSize = true;
            this.localSymbol_label_TMD_MDT.Location = new System.Drawing.Point(3, 111);
            this.localSymbol_label_TMD_MDT.Name = "localSymbol_label_TMD_MDT";
            this.localSymbol_label_TMD_MDT.Size = new System.Drawing.Size(77, 12);
            this.localSymbol_label_TMD_MDT.TabIndex = 9;
            this.localSymbol_label_TMD_MDT.Text = "Local Symbol";
            // 
            // lastTradeDate_label_TMD_MDT
            // 
            this.lastTradeDate_label_TMD_MDT.Location = new System.Drawing.Point(199, 43);
            this.lastTradeDate_label_TMD_MDT.Name = "lastTradeDate_label_TMD_MDT";
            this.lastTradeDate_label_TMD_MDT.Size = new System.Drawing.Size(92, 26);
            this.lastTradeDate_label_TMD_MDT.TabIndex = 4;
            this.lastTradeDate_label_TMD_MDT.Text = "Last trade date / contract month";
            // 
            // strike_label_TMD_MDT
            // 
            this.strike_label_TMD_MDT.AutoSize = true;
            this.strike_label_TMD_MDT.Location = new System.Drawing.Point(235, 105);
            this.strike_label_TMD_MDT.Name = "strike_label_TMD_MDT";
            this.strike_label_TMD_MDT.Size = new System.Drawing.Size(41, 12);
            this.strike_label_TMD_MDT.TabIndex = 5;
            this.strike_label_TMD_MDT.Text = "Strike";
            // 
            // requestMatchingSymbolsMD
            // 
            this.requestMatchingSymbolsMD.Location = new System.Drawing.Point(10, 171);
            this.requestMatchingSymbolsMD.Name = "requestMatchingSymbolsMD";
            this.requestMatchingSymbolsMD.Size = new System.Drawing.Size(75, 21);
            this.requestMatchingSymbolsMD.TabIndex = 68;
            this.requestMatchingSymbolsMD.Text = "Match Symb";
            this.requestMatchingSymbolsMD.UseVisualStyleBackColor = true;
            // 
            // cancelMarketDataRequests
            // 
            this.cancelMarketDataRequests.Location = new System.Drawing.Point(201, 171);
            this.cancelMarketDataRequests.Name = "cancelMarketDataRequests";
            this.cancelMarketDataRequests.Size = new System.Drawing.Size(75, 21);
            this.cancelMarketDataRequests.TabIndex = 66;
            this.cancelMarketDataRequests.Text = "Stop";
            this.cancelMarketDataRequests.UseVisualStyleBackColor = true;
            // 
            // marketData_Button
            // 
            this.marketData_Button.Location = new System.Drawing.Point(111, 171);
            this.marketData_Button.Name = "marketData_Button";
            this.marketData_Button.Size = new System.Drawing.Size(75, 21);
            this.marketData_Button.TabIndex = 67;
            this.marketData_Button.Text = "Add Ticker";
            this.marketData_Button.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbKeepUpToDate);
            this.groupBox3.Controls.Add(this.headTimestamp_button);
            this.groupBox3.Controls.Add(this.contractMDRTH);
            this.groupBox3.Controls.Add(this.realTime_Button);
            this.groupBox3.Controls.Add(this.histData_Button);
            this.groupBox3.Controls.Add(this.hdEndDate_label_HDT);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.hdRequest_EndTime);
            this.groupBox3.Controls.Add(this.hdRequest_WhatToShow);
            this.groupBox3.Controls.Add(this.hdRequest_Duration);
            this.groupBox3.Controls.Add(this.includeExpired);
            this.groupBox3.Controls.Add(this.hdRequest_BarSize);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.hdRequest_TimeUnit);
            this.groupBox3.Location = new System.Drawing.Point(10, 210);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(395, 165);
            this.groupBox3.TabIndex = 69;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Bar request";
            // 
            // cbKeepUpToDate
            // 
            this.cbKeepUpToDate.AutoSize = true;
            this.cbKeepUpToDate.Location = new System.Drawing.Point(221, 61);
            this.cbKeepUpToDate.Name = "cbKeepUpToDate";
            this.cbKeepUpToDate.Size = new System.Drawing.Size(114, 16);
            this.cbKeepUpToDate.TabIndex = 62;
            this.cbKeepUpToDate.Text = "Keep up to date";
            this.cbKeepUpToDate.UseVisualStyleBackColor = true;
            // 
            // headTimestamp_button
            // 
            this.headTimestamp_button.Location = new System.Drawing.Point(221, 135);
            this.headTimestamp_button.Name = "headTimestamp_button";
            this.headTimestamp_button.Size = new System.Drawing.Size(91, 21);
            this.headTimestamp_button.TabIndex = 61;
            this.headTimestamp_button.Text = "Head timestamp";
            this.headTimestamp_button.UseVisualStyleBackColor = true;
            // 
            // contractMDRTH
            // 
            this.contractMDRTH.AutoSize = true;
            this.contractMDRTH.Location = new System.Drawing.Point(221, 18);
            this.contractMDRTH.Name = "contractMDRTH";
            this.contractMDRTH.Size = new System.Drawing.Size(72, 16);
            this.contractMDRTH.TabIndex = 60;
            this.contractMDRTH.Text = "RTH only";
            this.contractMDRTH.UseVisualStyleBackColor = true;
            // 
            // realTime_Button
            // 
            this.realTime_Button.Location = new System.Drawing.Point(140, 135);
            this.realTime_Button.Name = "realTime_Button";
            this.realTime_Button.Size = new System.Drawing.Size(75, 21);
            this.realTime_Button.TabIndex = 56;
            this.realTime_Button.Text = "Real Time";
            this.realTime_Button.UseVisualStyleBackColor = true;
            // 
            // histData_Button
            // 
            this.histData_Button.Location = new System.Drawing.Point(59, 135);
            this.histData_Button.Name = "histData_Button";
            this.histData_Button.Size = new System.Drawing.Size(75, 21);
            this.histData_Button.TabIndex = 54;
            this.histData_Button.Text = "Historical";
            this.histData_Button.UseVisualStyleBackColor = true;
            // 
            // hdEndDate_label_HDT
            // 
            this.hdEndDate_label_HDT.AutoSize = true;
            this.hdEndDate_label_HDT.Location = new System.Drawing.Point(27, 17);
            this.hdEndDate_label_HDT.Name = "hdEndDate_label_HDT";
            this.hdEndDate_label_HDT.Size = new System.Drawing.Size(23, 12);
            this.hdEndDate_label_HDT.TabIndex = 46;
            this.hdEndDate_label_HDT.Text = "End";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 86);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 53;
            this.label12.Text = "Show";
            // 
            // hdRequest_EndTime
            // 
            this.hdRequest_EndTime.Location = new System.Drawing.Point(59, 17);
            this.hdRequest_EndTime.Name = "hdRequest_EndTime";
            this.hdRequest_EndTime.Size = new System.Drawing.Size(156, 21);
            this.hdRequest_EndTime.TabIndex = 45;
            this.hdRequest_EndTime.Text = "20130808 23:59:59 GMT";
            // 
            // hdRequest_WhatToShow
            // 
            this.hdRequest_WhatToShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hdRequest_WhatToShow.FormattingEnabled = true;
            this.hdRequest_WhatToShow.Items.AddRange(new object[] {
            "TRADES",
            "MIDPOINT",
            "BID",
            "ASK",
            "BID_ASK",
            "HISTORICAL_VOLATILITY",
            "OPTION_IMPLIED_VOLATILITY",
            "YIELD_BID",
            "YIELD_ASK",
            "YIELD_BID_ASK",
            "YIELD_LAST",
            "ADJUSTED_LAST"});
            this.hdRequest_WhatToShow.Location = new System.Drawing.Point(59, 85);
            this.hdRequest_WhatToShow.Name = "hdRequest_WhatToShow";
            this.hdRequest_WhatToShow.Size = new System.Drawing.Size(156, 20);
            this.hdRequest_WhatToShow.TabIndex = 52;
            this.hdRequest_WhatToShow.Text = "MIDPOINT";
            // 
            // hdRequest_Duration
            // 
            this.hdRequest_Duration.Location = new System.Drawing.Point(59, 38);
            this.hdRequest_Duration.Name = "hdRequest_Duration";
            this.hdRequest_Duration.Size = new System.Drawing.Size(67, 21);
            this.hdRequest_Duration.TabIndex = 47;
            this.hdRequest_Duration.Text = "10";
            // 
            // includeExpired
            // 
            this.includeExpired.AutoSize = true;
            this.includeExpired.Location = new System.Drawing.Point(221, 42);
            this.includeExpired.Name = "includeExpired";
            this.includeExpired.Size = new System.Drawing.Size(66, 16);
            this.includeExpired.TabIndex = 56;
            this.includeExpired.Text = "Expired";
            this.includeExpired.UseVisualStyleBackColor = true;
            // 
            // hdRequest_BarSize
            // 
            this.hdRequest_BarSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hdRequest_BarSize.FormattingEnabled = true;
            this.hdRequest_BarSize.Items.AddRange(new object[] {
            "1 sec",
            "5 secs",
            "15 secs",
            "30 secs",
            "1 min",
            "2 mins",
            "3 mins",
            "5 mins",
            "15 mins",
            "30 mins",
            "1 hour",
            "1 day",
            "1 week",
            "1 month"});
            this.hdRequest_BarSize.Location = new System.Drawing.Point(59, 61);
            this.hdRequest_BarSize.Name = "hdRequest_BarSize";
            this.hdRequest_BarSize.Size = new System.Drawing.Size(156, 21);
            this.hdRequest_BarSize.TabIndex = 51;
            this.hdRequest_BarSize.Text = "1 day";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 38);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 48;
            this.label10.Text = "Duration";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 65);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 50;
            this.label11.Text = "Bar Size";
            // 
            // hdRequest_TimeUnit
            // 
            this.hdRequest_TimeUnit.FormattingEnabled = true;
            this.hdRequest_TimeUnit.Items.AddRange(new object[] {
            "S",
            "D",
            "W",
            "M",
            "Y"});
            this.hdRequest_TimeUnit.Location = new System.Drawing.Point(132, 38);
            this.hdRequest_TimeUnit.Name = "hdRequest_TimeUnit";
            this.hdRequest_TimeUnit.Size = new System.Drawing.Size(83, 20);
            this.hdRequest_TimeUnit.TabIndex = 49;
            this.hdRequest_TimeUnit.Text = "D";
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControl1.Location = new System.Drawing.Point(3, 17);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(282, 364);
            this.zedGraphControl1.TabIndex = 0;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            // 
            // IBMarketDataUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "IBMarketDataUserControl";
            this.Size = new System.Drawing.Size(706, 384);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox primaryExchange;
        private System.Windows.Forms.Label primaryExchLabel;
        private System.Windows.Forms.TextBox genericTickList;
        private System.Windows.Forms.Label genericTickListLabel;
        private System.Windows.Forms.Label mdRightLabel;
        private System.Windows.Forms.ComboBox mdContractRight;
        private System.Windows.Forms.Label putcall_label_TMD_MDT;
        private System.Windows.Forms.TextBox multiplier_TMD_MDT;
        private System.Windows.Forms.Label symbol_label_TMD_MDT;
        private System.Windows.Forms.ComboBox secType_TMD_MDT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label exchange_label_TMD_MDT;
        private System.Windows.Forms.TextBox localSymbol_TMD_MDT;
        private System.Windows.Forms.Label currency_label_TMD_MDT;
        private System.Windows.Forms.TextBox lastTradeDateOrContractMonth_TMD_MDT;
        private System.Windows.Forms.TextBox symbol_TMD_MDT;
        private System.Windows.Forms.TextBox strike_TMD_MDT;
        private System.Windows.Forms.TextBox currency_TMD_MDT;
        private System.Windows.Forms.TextBox exchange_TMD_MDT;
        private System.Windows.Forms.Label localSymbol_label_TMD_MDT;
        private System.Windows.Forms.Label lastTradeDate_label_TMD_MDT;
        private System.Windows.Forms.Label strike_label_TMD_MDT;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbKeepUpToDate;
        private System.Windows.Forms.Button headTimestamp_button;
        private System.Windows.Forms.CheckBox contractMDRTH;
        private System.Windows.Forms.Button realTime_Button;
        private System.Windows.Forms.Button histData_Button;
        private System.Windows.Forms.Label hdEndDate_label_HDT;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox hdRequest_EndTime;
        private System.Windows.Forms.ComboBox hdRequest_WhatToShow;
        private System.Windows.Forms.TextBox hdRequest_Duration;
        private System.Windows.Forms.CheckBox includeExpired;
        private System.Windows.Forms.ComboBox hdRequest_BarSize;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox hdRequest_TimeUnit;
        private System.Windows.Forms.Button requestMatchingSymbolsMD;
        private System.Windows.Forms.Button cancelMarketDataRequests;
        private System.Windows.Forms.Button marketData_Button;
        private ZedGraph.ZedGraphControl zedGraphControl1;
    }
}
