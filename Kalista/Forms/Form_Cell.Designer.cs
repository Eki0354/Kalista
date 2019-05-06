namespace Kalista
{
    partial class Form_Cell
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
            this.listBox_guests = new System.Windows.Forms.ListBox();
            this.button_ok = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.comboBox_leftTag = new System.Windows.Forms.ComboBox();
            this.button_addGuest = new System.Windows.Forms.Button();
            this.button_deleteGuest = new System.Windows.Forms.Button();
            this.textBox_channel = new System.Windows.Forms.TextBox();
            this.comboBox_rightTag = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F);
            this.label1.Location = new System.Drawing.Point(8, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 140);
            this.label1.TabIndex = 0;
            this.label1.Text = "预定方式：\r\n\r\n  左标记：\r\n\r\n  右标记：\r\n\r\n客人姓名：";
            // 
            // listBox_guests
            // 
            this.listBox_guests.Font = new System.Drawing.Font("宋体", 15F);
            this.listBox_guests.FormattingEnabled = true;
            this.listBox_guests.ItemHeight = 20;
            this.listBox_guests.Location = new System.Drawing.Point(126, 140);
            this.listBox_guests.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBox_guests.Name = "listBox_guests";
            this.listBox_guests.Size = new System.Drawing.Size(143, 144);
            this.listBox_guests.TabIndex = 4;
            this.listBox_guests.SelectedIndexChanged += new System.EventHandler(this.listBox_guests_SelectedIndexChanged);
            // 
            // button_ok
            // 
            this.button_ok.Font = new System.Drawing.Font("宋体", 15F);
            this.button_ok.Location = new System.Drawing.Point(21, 203);
            this.button_ok.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(83, 31);
            this.button_ok.TabIndex = 6;
            this.button_ok.Text = "确定";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_cancel.Font = new System.Drawing.Font("宋体", 15F);
            this.button_cancel.Location = new System.Drawing.Point(21, 251);
            this.button_cancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(83, 31);
            this.button_cancel.TabIndex = 7;
            this.button_cancel.Text = "取消";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // comboBox_leftTag
            // 
            this.comboBox_leftTag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_leftTag.Font = new System.Drawing.Font("宋体", 15F);
            this.comboBox_leftTag.FormattingEnabled = true;
            this.comboBox_leftTag.Location = new System.Drawing.Point(126, 55);
            this.comboBox_leftTag.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox_leftTag.Name = "comboBox_leftTag";
            this.comboBox_leftTag.Size = new System.Drawing.Size(143, 28);
            this.comboBox_leftTag.TabIndex = 9;
            // 
            // button_addGuest
            // 
            this.button_addGuest.Font = new System.Drawing.Font("宋体", 12F);
            this.button_addGuest.Location = new System.Drawing.Point(279, 140);
            this.button_addGuest.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_addGuest.Name = "button_addGuest";
            this.button_addGuest.Size = new System.Drawing.Size(24, 23);
            this.button_addGuest.TabIndex = 10;
            this.button_addGuest.Text = "+";
            this.button_addGuest.UseVisualStyleBackColor = true;
            // 
            // button_deleteGuest
            // 
            this.button_deleteGuest.Font = new System.Drawing.Font("宋体", 12F);
            this.button_deleteGuest.Location = new System.Drawing.Point(279, 177);
            this.button_deleteGuest.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_deleteGuest.Name = "button_deleteGuest";
            this.button_deleteGuest.Size = new System.Drawing.Size(24, 23);
            this.button_deleteGuest.TabIndex = 11;
            this.button_deleteGuest.Text = "-";
            this.button_deleteGuest.UseVisualStyleBackColor = true;
            // 
            // textBox_channel
            // 
            this.textBox_channel.Font = new System.Drawing.Font("宋体", 15F);
            this.textBox_channel.Location = new System.Drawing.Point(126, 15);
            this.textBox_channel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_channel.Name = "textBox_channel";
            this.textBox_channel.Size = new System.Drawing.Size(143, 30);
            this.textBox_channel.TabIndex = 12;
            // 
            // comboBox_rightTag
            // 
            this.comboBox_rightTag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_rightTag.Font = new System.Drawing.Font("宋体", 15F);
            this.comboBox_rightTag.FormattingEnabled = true;
            this.comboBox_rightTag.Location = new System.Drawing.Point(126, 97);
            this.comboBox_rightTag.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox_rightTag.Name = "comboBox_rightTag";
            this.comboBox_rightTag.Size = new System.Drawing.Size(143, 28);
            this.comboBox_rightTag.TabIndex = 13;
            // 
            // Form_Cell
            // 
            this.AcceptButton = this.button_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_cancel;
            this.ClientSize = new System.Drawing.Size(315, 300);
            this.Controls.Add(this.comboBox_rightTag);
            this.Controls.Add(this.textBox_channel);
            this.Controls.Add(this.button_deleteGuest);
            this.Controls.Add(this.button_addGuest);
            this.Controls.Add(this.comboBox_leftTag);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.listBox_guests);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form_Cell";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "房态编辑";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Cell_Closing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox_guests;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.ComboBox comboBox_leftTag;
        private System.Windows.Forms.Button button_addGuest;
        private System.Windows.Forms.Button button_deleteGuest;
        private System.Windows.Forms.TextBox textBox_channel;
        private System.Windows.Forms.ComboBox comboBox_rightTag;
    }
}