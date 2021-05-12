
namespace WindowsFormsApp1
{
    partial class CTPLoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CTPLoginForm));
            this.textBox_Investor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_appID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Code = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_productInfo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_QuoteAddr = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_TradeAddr = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_broker = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button_Login = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_Investor
            // 
            this.textBox_Investor.Location = new System.Drawing.Point(162, 18);
            this.textBox_Investor.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Investor.Name = "textBox_Investor";
            this.textBox_Investor.Size = new System.Drawing.Size(256, 28);
            this.textBox_Investor.TabIndex = 8;
            this.textBox_Investor.Text = "090822";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "用户名：";
            // 
            // textBox_appID
            // 
            this.textBox_appID.Location = new System.Drawing.Point(162, 220);
            this.textBox_appID.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_appID.Name = "textBox_appID";
            this.textBox_appID.Size = new System.Drawing.Size(256, 28);
            this.textBox_appID.TabIndex = 10;
            this.textBox_appID.Text = "simnow_client_test";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 234);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "产品名称：";
            // 
            // textBox_Code
            // 
            this.textBox_Code.Location = new System.Drawing.Point(162, 270);
            this.textBox_Code.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Code.Name = "textBox_Code";
            this.textBox_Code.Size = new System.Drawing.Size(256, 28);
            this.textBox_Code.TabIndex = 12;
            this.textBox_Code.Text = "0000000000000000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 278);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 18);
            this.label3.TabIndex = 11;
            this.label3.Text = "授权编码：";
            // 
            // textBox_productInfo
            // 
            this.textBox_productInfo.Location = new System.Drawing.Point(162, 310);
            this.textBox_productInfo.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_productInfo.Name = "textBox_productInfo";
            this.textBox_productInfo.Size = new System.Drawing.Size(256, 28);
            this.textBox_productInfo.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 318);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 18);
            this.label4.TabIndex = 13;
            this.label4.Text = "产品信息：";
            // 
            // textBox_QuoteAddr
            // 
            this.textBox_QuoteAddr.Location = new System.Drawing.Point(162, 180);
            this.textBox_QuoteAddr.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_QuoteAddr.Name = "textBox_QuoteAddr";
            this.textBox_QuoteAddr.Size = new System.Drawing.Size(256, 28);
            this.textBox_QuoteAddr.TabIndex = 16;
            this.textBox_QuoteAddr.Text = "180.168.146.187:10110";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 188);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 18);
            this.label5.TabIndex = 15;
            this.label5.Text = "行情服务器：";
            // 
            // textBox_TradeAddr
            // 
            this.textBox_TradeAddr.Location = new System.Drawing.Point(162, 140);
            this.textBox_TradeAddr.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_TradeAddr.Name = "textBox_TradeAddr";
            this.textBox_TradeAddr.Size = new System.Drawing.Size(256, 28);
            this.textBox_TradeAddr.TabIndex = 18;
            this.textBox_TradeAddr.Text = "180.168.146.187:10100";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 147);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 18);
            this.label6.TabIndex = 17;
            this.label6.Text = "交易服务器：";
            // 
            // textBox_broker
            // 
            this.textBox_broker.Location = new System.Drawing.Point(162, 99);
            this.textBox_broker.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_broker.Name = "textBox_broker";
            this.textBox_broker.Size = new System.Drawing.Size(256, 28);
            this.textBox_broker.TabIndex = 20;
            this.textBox_broker.Text = "9999";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 104);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 18);
            this.label7.TabIndex = 19;
            this.label7.Text = "经纪商代码：";
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(162, 58);
            this.textBox_password.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.PasswordChar = '*';
            this.textBox_password.Size = new System.Drawing.Size(256, 28);
            this.textBox_password.TabIndex = 22;
            this.textBox_password.Text = "196910";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(38, 66);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 18);
            this.label8.TabIndex = 21;
            this.label8.Text = "密码：";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.richTextBox1.Location = new System.Drawing.Point(429, 18);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(420, 330);
            this.richTextBox1.TabIndex = 23;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // button_Login
            // 
            this.button_Login.Location = new System.Drawing.Point(616, 519);
            this.button_Login.Margin = new System.Windows.Forms.Padding(4);
            this.button_Login.Name = "button_Login";
            this.button_Login.Size = new System.Drawing.Size(112, 34);
            this.button_Login.TabIndex = 24;
            this.button_Login.Text = "登陆";
            this.button_Login.UseVisualStyleBackColor = true;
            this.button_Login.Click += new System.EventHandler(this.button_Login_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.richTextBox2.Location = new System.Drawing.Point(42, 358);
            this.richTextBox2.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(806, 150);
            this.richTextBox2.TabIndex = 25;
            this.richTextBox2.Text = "日志信息:";
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(738, 519);
            this.button_Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(112, 34);
            this.button_Cancel.TabIndex = 26;
            this.button_Cancel.Text = "登出";
            this.button_Cancel.UseVisualStyleBackColor = true;
            // 
            // CTPLoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(860, 560);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.button_Login);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox_broker);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_TradeAddr);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_QuoteAddr);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_productInfo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_Code);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_appID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_Investor);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CTPLoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SIMNow期货仿真CTP交易登陆";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Investor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_appID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Code;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_productInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_QuoteAddr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_TradeAddr;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_broker;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button_Login;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button button_Cancel;
    }
}