
namespace WindowsFormsApp1
{
    partial class IBAccountUserControl
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
            this.accSummaryRequest = new System.Windows.Forms.Button();
            this.accSummaryGrid = new System.Windows.Forms.DataGridView();
            this.tag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountSummaryAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.accSummaryGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // accSummaryRequest
            // 
            this.accSummaryRequest.Dock = System.Windows.Forms.DockStyle.Left;
            this.accSummaryRequest.Location = new System.Drawing.Point(0, 0);
            this.accSummaryRequest.Name = "accSummaryRequest";
            this.accSummaryRequest.Size = new System.Drawing.Size(75, 22);
            this.accSummaryRequest.TabIndex = 1;
            this.accSummaryRequest.Text = "查询";
            this.accSummaryRequest.UseVisualStyleBackColor = true;
            this.accSummaryRequest.Click += new System.EventHandler(this.accSummaryRequest_Click);
            // 
            // accSummaryGrid
            // 
            this.accSummaryGrid.AllowUserToAddRows = false;
            this.accSummaryGrid.AllowUserToDeleteRows = false;
            this.accSummaryGrid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.accSummaryGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.accSummaryGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tag,
            this.value,
            this.currency,
            this.accountSummaryAccount});
            this.accSummaryGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.accSummaryGrid.Location = new System.Drawing.Point(0, 0);
            this.accSummaryGrid.Name = "accSummaryGrid";
            this.accSummaryGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.accSummaryGrid.Size = new System.Drawing.Size(702, 519);
            this.accSummaryGrid.TabIndex = 0;
            this.accSummaryGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DataError);
            // 
            // tag
            // 
            this.tag.DataPropertyName = "AccountTag";
            this.tag.HeaderText = "Tag";
            this.tag.Name = "tag";
            this.tag.ReadOnly = true;
            this.tag.Width = 150;
            // 
            // value
            // 
            this.value.DataPropertyName = "AccountValue";
            this.value.HeaderText = "Value";
            this.value.Name = "value";
            this.value.ReadOnly = true;
            this.value.Width = 150;
            // 
            // currency
            // 
            this.currency.DataPropertyName = "AccountCurrency";
            this.currency.HeaderText = "Currency";
            this.currency.Name = "currency";
            this.currency.ReadOnly = true;
            this.currency.Width = 150;
            // 
            // accountSummaryAccount
            // 
            this.accountSummaryAccount.DataPropertyName = "AccountName";
            this.accountSummaryAccount.HeaderText = "Account";
            this.accountSummaryAccount.Name = "accountSummaryAccount";
            this.accountSummaryAccount.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.accSummaryRequest);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(702, 22);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.accSummaryGrid);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(702, 519);
            this.panel2.TabIndex = 5;
            // 
            // IBAccountUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "IBAccountUserControl";
            this.Size = new System.Drawing.Size(702, 541);
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accSummaryGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button accSummaryRequest;
        private System.Windows.Forms.DataGridView accSummaryGrid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn tag;
        private System.Windows.Forms.DataGridViewTextBoxColumn value;
        private System.Windows.Forms.DataGridViewTextBoxColumn currency;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountSummaryAccount;
    }
}
