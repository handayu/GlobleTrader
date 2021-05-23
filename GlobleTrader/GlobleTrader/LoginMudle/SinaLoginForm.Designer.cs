
namespace WindowsFormsApp1
{
    partial class SinaLoginForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_socketUrl = new System.Windows.Forms.TextBox();
            this.textBox_testStockCode = new System.Windows.Forms.TextBox();
            this.dateTimePicker_start = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker_end = new System.Windows.Forms.DateTimePicker();
            this.richTextBox_Log = new System.Windows.Forms.RichTextBox();
            this.button_Test = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "test_stock_code：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "date_start：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "web_socket_url：";
            // 
            // textBox_socketUrl
            // 
            this.textBox_socketUrl.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox_socketUrl.Location = new System.Drawing.Point(127, 12);
            this.textBox_socketUrl.Name = "textBox_socketUrl";
            this.textBox_socketUrl.ReadOnly = true;
            this.textBox_socketUrl.Size = new System.Drawing.Size(171, 21);
            this.textBox_socketUrl.TabIndex = 5;
            this.textBox_socketUrl.Text = "http://stock2.finance.sina.com.cn/futures/api/json.php/IndexService.getInnerFutur" +
    "esDailyKLine?";
            // 
            // textBox_testStockCode
            // 
            this.textBox_testStockCode.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox_testStockCode.Location = new System.Drawing.Point(126, 40);
            this.textBox_testStockCode.Name = "textBox_testStockCode";
            this.textBox_testStockCode.Size = new System.Drawing.Size(172, 21);
            this.textBox_testStockCode.TabIndex = 8;
            this.textBox_testStockCode.Text = "CU0";
            // 
            // dateTimePicker_start
            // 
            this.dateTimePicker_start.Location = new System.Drawing.Point(126, 70);
            this.dateTimePicker_start.Name = "dateTimePicker_start";
            this.dateTimePicker_start.Size = new System.Drawing.Size(172, 21);
            this.dateTimePicker_start.TabIndex = 9;
            this.dateTimePicker_start.Value = new System.DateTime(2020, 11, 1, 0, 0, 0, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "date_end：";
            // 
            // dateTimePicker_end
            // 
            this.dateTimePicker_end.Location = new System.Drawing.Point(126, 98);
            this.dateTimePicker_end.Name = "dateTimePicker_end";
            this.dateTimePicker_end.Size = new System.Drawing.Size(172, 21);
            this.dateTimePicker_end.TabIndex = 11;
            // 
            // richTextBox_Log
            // 
            this.richTextBox_Log.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.richTextBox_Log.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox_Log.Location = new System.Drawing.Point(17, 156);
            this.richTextBox_Log.Name = "richTextBox_Log";
            this.richTextBox_Log.Size = new System.Drawing.Size(516, 78);
            this.richTextBox_Log.TabIndex = 12;
            this.richTextBox_Log.Text = "";
            // 
            // button_Test
            // 
            this.button_Test.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_Test.Location = new System.Drawing.Point(17, 127);
            this.button_Test.Name = "button_Test";
            this.button_Test.Size = new System.Drawing.Size(75, 23);
            this.button_Test.TabIndex = 13;
            this.button_Test.Text = "Test";
            this.button_Test.UseVisualStyleBackColor = false;
            this.button_Test.Click += new System.EventHandler(this.button_Test_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(304, 45);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(233, 12);
            this.label10.TabIndex = 17;
            this.label10.Text = "PS:期货代码,注意连续合约和指定月份后缀";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(304, 73);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 12);
            this.label11.TabIndex = 18;
            this.label11.Text = "PS:开始日期";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(305, 102);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 12);
            this.label12.TabIndex = 19;
            this.label12.Text = "PS:截至日期";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(105, 132);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(287, 12);
            this.label13.TabIndex = 20;
            this.label13.Text = "PS:由于是Http无状态获取数据，非长连接，状态即时";
            // 
            // SinaLoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(542, 240);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button_Test);
            this.Controls.Add(this.richTextBox_Log);
            this.Controls.Add(this.dateTimePicker_end);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateTimePicker_start);
            this.Controls.Add(this.textBox_testStockCode);
            this.Controls.Add(this.textBox_socketUrl);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SinaLoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新浪数据源登陆";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.Load += new System.EventHandler(this.Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_socketUrl;
        private System.Windows.Forms.TextBox textBox_testStockCode;
        private System.Windows.Forms.DateTimePicker dateTimePicker_start;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker_end;
        private System.Windows.Forms.RichTextBox richTextBox_Log;
        private System.Windows.Forms.Button button_Test;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}