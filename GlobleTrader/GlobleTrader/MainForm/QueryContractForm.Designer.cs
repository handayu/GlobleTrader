
namespace WindowsFormsApp1
{
    partial class QueryContractForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_Quit = new System.Windows.Forms.Button();
            this.button_query = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBox_putCall = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_currency = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_exchange = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_product = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_symbol = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView_instruments = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_instruments)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.59236F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.40765F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView_instruments, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(628, 229);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.30493F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.69507F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(160, 223);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.button_Quit);
            this.panel1.Controls.Add(this.button_query);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 190);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(154, 30);
            this.panel1.TabIndex = 0;
            // 
            // button_Quit
            // 
            this.button_Quit.Location = new System.Drawing.Point(78, 4);
            this.button_Quit.Name = "button_Quit";
            this.button_Quit.Size = new System.Drawing.Size(63, 23);
            this.button_Quit.TabIndex = 1;
            this.button_Quit.Text = "退出";
            this.button_Quit.UseVisualStyleBackColor = true;
            this.button_Quit.Click += new System.EventHandler(this.button_Quit_Click);
            // 
            // button_query
            // 
            this.button_query.Location = new System.Drawing.Point(9, 4);
            this.button_query.Name = "button_query";
            this.button_query.Size = new System.Drawing.Size(63, 23);
            this.button_query.TabIndex = 0;
            this.button_query.Text = "查询添加";
            this.button_query.UseVisualStyleBackColor = true;
            this.button_query.Click += new System.EventHandler(this.button_query_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Controls.Add(this.comboBox_putCall);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.textBox_currency);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.comboBox_exchange);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.comboBox_product);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.textBox_symbol);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(154, 181);
            this.panel2.TabIndex = 1;
            // 
            // comboBox_putCall
            // 
            this.comboBox_putCall.FormattingEnabled = true;
            this.comboBox_putCall.Location = new System.Drawing.Point(55, 154);
            this.comboBox_putCall.Name = "comboBox_putCall";
            this.comboBox_putCall.Size = new System.Drawing.Size(71, 20);
            this.comboBox_putCall.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "Put/Call:";
            // 
            // textBox_currency
            // 
            this.textBox_currency.Location = new System.Drawing.Point(55, 104);
            this.textBox_currency.Name = "textBox_currency";
            this.textBox_currency.Size = new System.Drawing.Size(71, 21);
            this.textBox_currency.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "币种:";
            // 
            // comboBox_exchange
            // 
            this.comboBox_exchange.FormattingEnabled = true;
            this.comboBox_exchange.Location = new System.Drawing.Point(55, 71);
            this.comboBox_exchange.Name = "comboBox_exchange";
            this.comboBox_exchange.Size = new System.Drawing.Size(71, 20);
            this.comboBox_exchange.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "交易所:";
            // 
            // comboBox_product
            // 
            this.comboBox_product.FormattingEnabled = true;
            this.comboBox_product.Location = new System.Drawing.Point(55, 38);
            this.comboBox_product.Name = "comboBox_product";
            this.comboBox_product.Size = new System.Drawing.Size(71, 20);
            this.comboBox_product.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "产品:";
            // 
            // textBox_symbol
            // 
            this.textBox_symbol.Location = new System.Drawing.Point(55, 4);
            this.textBox_symbol.Name = "textBox_symbol";
            this.textBox_symbol.Size = new System.Drawing.Size(71, 21);
            this.textBox_symbol.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "合约:";
            // 
            // dataGridView_instruments
            // 
            this.dataGridView_instruments.AllowUserToAddRows = false;
            this.dataGridView_instruments.AllowUserToDeleteRows = false;
            this.dataGridView_instruments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_instruments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_instruments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dataGridView_instruments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_instruments.Location = new System.Drawing.Point(169, 3);
            this.dataGridView_instruments.Name = "dataGridView_instruments";
            this.dataGridView_instruments.ReadOnly = true;
            this.dataGridView_instruments.RowTemplate.Height = 23;
            this.dataGridView_instruments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_instruments.Size = new System.Drawing.Size(456, 223);
            this.dataGridView_instruments.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Symbol";
            this.Column1.HeaderText = "合约";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 40;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Exchange";
            this.Column2.HeaderText = "交易所";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 70;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Name";
            this.Column3.HeaderText = "简称";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 60;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Product";
            this.Column4.HeaderText = "产品";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 60;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "MinVolume";
            this.Column5.HeaderText = "最小交易量";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 90;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "OptionType";
            this.Column6.HeaderText = "期权类型";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 80;
            // 
            // QueryContractForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 229);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "QueryContractForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "合约查询";
            this.Load += new System.EventHandler(this.Form_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_instruments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dataGridView_instruments;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_query;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBox_putCall;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_currency;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_exchange;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_product;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_symbol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Button button_Quit;
    }
}