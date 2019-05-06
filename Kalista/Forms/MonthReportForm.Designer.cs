namespace Kalista
{
    partial class MonthReportForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_month = new System.Windows.Forms.ComboBox();
            this.tb_year = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rb_night = new System.Windows.Forms.RadioButton();
            this.rb_day = new System.Windows.Forms.RadioButton();
            this.button_create = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.checkBox_useDefaultTemplate = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_useDefaultTemplate);
            this.groupBox1.Controls.Add(this.cb_month);
            this.groupBox1.Controls.Add(this.tb_year);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rb_night);
            this.groupBox1.Controls.Add(this.rb_day);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(131, 122);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // cb_month
            // 
            this.cb_month.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_month.FormattingEnabled = true;
            this.cb_month.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.cb_month.Location = new System.Drawing.Point(46, 65);
            this.cb_month.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cb_month.Name = "cb_month";
            this.cb_month.Size = new System.Drawing.Size(68, 20);
            this.cb_month.TabIndex = 5;
            // 
            // tb_year
            // 
            this.tb_year.Location = new System.Drawing.Point(46, 45);
            this.tb_year.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_year.Name = "tb_year";
            this.tb_year.Size = new System.Drawing.Size(68, 21);
            this.tb_year.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 65);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "月份：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "年份：";
            // 
            // rb_night
            // 
            this.rb_night.AutoSize = true;
            this.rb_night.Location = new System.Drawing.Point(67, 24);
            this.rb_night.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rb_night.Name = "rb_night";
            this.rb_night.Size = new System.Drawing.Size(47, 16);
            this.rb_night.TabIndex = 1;
            this.rb_night.TabStop = true;
            this.rb_night.Text = "夜班";
            this.rb_night.UseVisualStyleBackColor = true;
            // 
            // rb_day
            // 
            this.rb_day.AutoSize = true;
            this.rb_day.Checked = true;
            this.rb_day.Location = new System.Drawing.Point(15, 24);
            this.rb_day.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rb_day.Name = "rb_day";
            this.rb_day.Size = new System.Drawing.Size(47, 16);
            this.rb_day.TabIndex = 0;
            this.rb_day.TabStop = true;
            this.rb_day.Text = "白班";
            this.rb_day.UseVisualStyleBackColor = true;
            // 
            // button_create
            // 
            this.button_create.Location = new System.Drawing.Point(12, 137);
            this.button_create.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_create.Name = "button_create";
            this.button_create.Size = new System.Drawing.Size(50, 21);
            this.button_create.TabIndex = 1;
            this.button_create.Text = "生成";
            this.button_create.UseVisualStyleBackColor = true;
            this.button_create.Click += new System.EventHandler(this.button_create_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_cancel.Location = new System.Drawing.Point(88, 137);
            this.button_cancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(50, 21);
            this.button_cancel.TabIndex = 2;
            this.button_cancel.Text = "取消";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // checkBox_useDefaultTemplate
            // 
            this.checkBox_useDefaultTemplate.AutoSize = true;
            this.checkBox_useDefaultTemplate.Location = new System.Drawing.Point(15, 93);
            this.checkBox_useDefaultTemplate.Name = "checkBox_useDefaultTemplate";
            this.checkBox_useDefaultTemplate.Size = new System.Drawing.Size(96, 16);
            this.checkBox_useDefaultTemplate.TabIndex = 6;
            this.checkBox_useDefaultTemplate.Text = "使用默认模板";
            this.checkBox_useDefaultTemplate.UseVisualStyleBackColor = true;
            // 
            // MonthReportForm
            // 
            this.AcceptButton = this.button_create;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_cancel;
            this.ClientSize = new System.Drawing.Size(149, 165);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_create);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MonthReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MonthReportForm";
            this.Load += new System.EventHandler(this.MonthReportForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cb_month;
        private System.Windows.Forms.TextBox tb_year;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rb_night;
        private System.Windows.Forms.RadioButton rb_day;
        private System.Windows.Forms.Button button_create;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.CheckBox checkBox_useDefaultTemplate;
    }
}