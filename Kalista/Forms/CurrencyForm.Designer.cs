namespace Kalista.Forms
{
    partial class CurrencyForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_currency = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_rate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_rmb = new System.Windows.Forms.TextBox();
            this.button_count = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_currencyType = new System.Windows.Forms.ComboBox();
            this.checkBox_autoGetNetRate = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_receipt = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(111, 288);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "外币金额：";
            // 
            // textBox_currency
            // 
            this.textBox_currency.Location = new System.Drawing.Point(216, 282);
            this.textBox_currency.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_currency.Name = "textBox_currency";
            this.textBox_currency.Size = new System.Drawing.Size(121, 28);
            this.textBox_currency.TabIndex = 2;
            this.textBox_currency.Text = "100";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(102, 330);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "100元汇率：";
            // 
            // textBox_rate
            // 
            this.textBox_rate.Location = new System.Drawing.Point(216, 322);
            this.textBox_rate.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_rate.Name = "textBox_rate";
            this.textBox_rate.Size = new System.Drawing.Size(121, 28);
            this.textBox_rate.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(129, 368);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "人民币：";
            // 
            // textBox_rmb
            // 
            this.textBox_rmb.Location = new System.Drawing.Point(216, 362);
            this.textBox_rmb.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_rmb.Name = "textBox_rmb";
            this.textBox_rmb.Size = new System.Drawing.Size(121, 28);
            this.textBox_rmb.TabIndex = 6;
            // 
            // button_count
            // 
            this.button_count.Location = new System.Drawing.Point(114, 408);
            this.button_count.Margin = new System.Windows.Forms.Padding(4);
            this.button_count.Name = "button_count";
            this.button_count.Size = new System.Drawing.Size(94, 34);
            this.button_count.TabIndex = 7;
            this.button_count.Text = "计算";
            this.button_count.UseVisualStyleBackColor = true;
            this.button_count.Click += new System.EventHandler(this.button_count_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_cancel.Location = new System.Drawing.Point(231, 408);
            this.button_cancel.Margin = new System.Windows.Forms.Padding(4);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(94, 34);
            this.button_cancel.TabIndex = 8;
            this.button_cancel.Text = "取消";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(147, 248);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "币种：";
            // 
            // comboBox_currencyType
            // 
            this.comboBox_currencyType.FormattingEnabled = true;
            this.comboBox_currencyType.Location = new System.Drawing.Point(216, 242);
            this.comboBox_currencyType.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_currencyType.Name = "comboBox_currencyType";
            this.comboBox_currencyType.Size = new System.Drawing.Size(121, 26);
            this.comboBox_currencyType.TabIndex = 10;
            this.comboBox_currencyType.Text = "美元";
            // 
            // checkBox_autoGetNetRate
            // 
            this.checkBox_autoGetNetRate.AutoSize = true;
            this.checkBox_autoGetNetRate.Checked = true;
            this.checkBox_autoGetNetRate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_autoGetNetRate.Location = new System.Drawing.Point(105, 208);
            this.checkBox_autoGetNetRate.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_autoGetNetRate.Name = "checkBox_autoGetNetRate";
            this.checkBox_autoGetNetRate.Size = new System.Drawing.Size(142, 22);
            this.checkBox_autoGetNetRate.TabIndex = 11;
            this.checkBox_autoGetNetRate.Text = "自动获取汇率";
            this.checkBox_autoGetNetRate.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_receipt);
            this.groupBox1.Location = new System.Drawing.Point(16, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(408, 178);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "票据内容";
            // 
            // label_receipt
            // 
            this.label_receipt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_receipt.Location = new System.Drawing.Point(16, 32);
            this.label_receipt.Name = "label_receipt";
            this.label_receipt.Size = new System.Drawing.Size(375, 128);
            this.label_receipt.TabIndex = 0;
            // 
            // CurrencyForm
            // 
            this.AcceptButton = this.button_count;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_cancel;
            this.ClientSize = new System.Drawing.Size(441, 456);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBox_autoGetNetRate);
            this.Controls.Add(this.comboBox_currencyType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_count);
            this.Controls.Add(this.textBox_rmb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_rate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_currency);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CurrencyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CurrencyForm";
            this.Load += new System.EventHandler(this.CurrencyForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_currency;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_rate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_rmb;
        private System.Windows.Forms.Button button_count;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_currencyType;
        private System.Windows.Forms.CheckBox checkBox_autoGetNetRate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_receipt;
    }
}