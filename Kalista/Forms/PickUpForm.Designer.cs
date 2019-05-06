namespace Kalista
{
    partial class PickUpForm
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
            this.gB_details = new System.Windows.Forms.GroupBox();
            this.cB_staff = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tB_persons = new System.Windows.Forms.TextBox();
            this.cB_car = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tB_name = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cB_minute = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cB_hour = new System.Windows.Forms.ComboBox();
            this.tB_city = new System.Windows.Forms.TextBox();
            this.tB_flight = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_set = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_copy = new System.Windows.Forms.Button();
            this.gB_details.SuspendLayout();
            this.SuspendLayout();
            // 
            // gB_details
            // 
            this.gB_details.Controls.Add(this.cB_staff);
            this.gB_details.Controls.Add(this.label9);
            this.gB_details.Controls.Add(this.tB_persons);
            this.gB_details.Controls.Add(this.cB_car);
            this.gB_details.Controls.Add(this.label8);
            this.gB_details.Controls.Add(this.tB_name);
            this.gB_details.Controls.Add(this.label7);
            this.gB_details.Controls.Add(this.label6);
            this.gB_details.Controls.Add(this.label5);
            this.gB_details.Controls.Add(this.cB_minute);
            this.gB_details.Controls.Add(this.label4);
            this.gB_details.Controls.Add(this.cB_hour);
            this.gB_details.Controls.Add(this.tB_city);
            this.gB_details.Controls.Add(this.tB_flight);
            this.gB_details.Controls.Add(this.label3);
            this.gB_details.Controls.Add(this.label2);
            this.gB_details.Controls.Add(this.label1);
            this.gB_details.Location = new System.Drawing.Point(18, 18);
            this.gB_details.Margin = new System.Windows.Forms.Padding(4);
            this.gB_details.Name = "gB_details";
            this.gB_details.Padding = new System.Windows.Forms.Padding(4);
            this.gB_details.Size = new System.Drawing.Size(390, 392);
            this.gB_details.TabIndex = 0;
            this.gB_details.TabStop = false;
            this.gB_details.Text = "详情";
            // 
            // cB_staff
            // 
            this.cB_staff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cB_staff.FormattingEnabled = true;
            this.cB_staff.Location = new System.Drawing.Point(114, 328);
            this.cB_staff.Name = "cB_staff";
            this.cB_staff.Size = new System.Drawing.Size(172, 26);
            this.cB_staff.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(52, 332);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 18);
            this.label9.TabIndex = 16;
            this.label9.Text = "员工:";
            // 
            // tB_persons
            // 
            this.tB_persons.Location = new System.Drawing.Point(116, 238);
            this.tB_persons.Name = "tB_persons";
            this.tB_persons.Size = new System.Drawing.Size(170, 28);
            this.tB_persons.TabIndex = 15;
            // 
            // cB_car
            // 
            this.cB_car.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cB_car.FormattingEnabled = true;
            this.cB_car.Items.AddRange(new object[] {
            "四座车",
            "六座车",
            "大巴车"});
            this.cB_car.Location = new System.Drawing.Point(116, 285);
            this.cB_car.Margin = new System.Windows.Forms.Padding(4);
            this.cB_car.Name = "cB_car";
            this.cB_car.Size = new System.Drawing.Size(170, 26);
            this.cB_car.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(122, 290);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 18);
            this.label8.TabIndex = 14;
            this.label8.Text = "Bumblebee";
            this.label8.Visible = false;
            // 
            // tB_name
            // 
            this.tB_name.Location = new System.Drawing.Point(116, 189);
            this.tB_name.Margin = new System.Windows.Forms.Padding(4);
            this.tB_name.Name = "tB_name";
            this.tB_name.Size = new System.Drawing.Size(248, 28);
            this.tB_name.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(52, 290);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 18);
            this.label7.TabIndex = 9;
            this.label7.Text = "车型:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(52, 242);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 18);
            this.label6.TabIndex = 8;
            this.label6.Text = "人数:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 194);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = "客人姓名:";
            // 
            // cB_minute
            // 
            this.cB_minute.FormattingEnabled = true;
            this.cB_minute.Location = new System.Drawing.Point(219, 143);
            this.cB_minute.Margin = new System.Windows.Forms.Padding(4);
            this.cB_minute.Name = "cB_minute";
            this.cB_minute.Size = new System.Drawing.Size(67, 26);
            this.cB_minute.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(194, 148);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = ":";
            // 
            // cB_hour
            // 
            this.cB_hour.FormattingEnabled = true;
            this.cB_hour.Location = new System.Drawing.Point(116, 143);
            this.cB_hour.Margin = new System.Windows.Forms.Padding(4);
            this.cB_hour.Name = "cB_hour";
            this.cB_hour.Size = new System.Drawing.Size(67, 26);
            this.cB_hour.TabIndex = 4;
            // 
            // tB_city
            // 
            this.tB_city.Location = new System.Drawing.Point(114, 90);
            this.tB_city.Margin = new System.Windows.Forms.Padding(4);
            this.tB_city.Name = "tB_city";
            this.tB_city.Size = new System.Drawing.Size(250, 28);
            this.tB_city.TabIndex = 3;
            // 
            // tB_flight
            // 
            this.tB_flight.Location = new System.Drawing.Point(114, 45);
            this.tB_flight.Margin = new System.Windows.Forms.Padding(4);
            this.tB_flight.Name = "tB_flight";
            this.tB_flight.Size = new System.Drawing.Size(250, 28);
            this.tB_flight.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 146);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "到达时间:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 98);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "出发城市:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "航班号:";
            // 
            // button_set
            // 
            this.button_set.Location = new System.Drawing.Point(18, 430);
            this.button_set.Margin = new System.Windows.Forms.Padding(4);
            this.button_set.Name = "button_set";
            this.button_set.Size = new System.Drawing.Size(112, 34);
            this.button_set.TabIndex = 1;
            this.button_set.Text = "设置";
            this.button_set.UseVisualStyleBackColor = true;
            this.button_set.Click += new System.EventHandler(this.button_set_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_cancel.Location = new System.Drawing.Point(296, 430);
            this.button_cancel.Margin = new System.Windows.Forms.Padding(4);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(112, 34);
            this.button_cancel.TabIndex = 2;
            this.button_cancel.Text = "取消";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_copy
            // 
            this.button_copy.Location = new System.Drawing.Point(156, 430);
            this.button_copy.Margin = new System.Windows.Forms.Padding(4);
            this.button_copy.Name = "button_copy";
            this.button_copy.Size = new System.Drawing.Size(112, 34);
            this.button_copy.TabIndex = 3;
            this.button_copy.Text = "复制";
            this.button_copy.UseVisualStyleBackColor = true;
            this.button_copy.Click += new System.EventHandler(this.button_copy_Click);
            // 
            // PickUpForm
            // 
            this.AcceptButton = this.button_set;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_cancel;
            this.ClientSize = new System.Drawing.Size(428, 482);
            this.Controls.Add(this.button_copy);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_set);
            this.Controls.Add(this.gB_details);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PickUpForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PickUpForm";
            this.gB_details.ResumeLayout(false);
            this.gB_details.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gB_details;
        private System.Windows.Forms.TextBox tB_city;
        private System.Windows.Forms.TextBox tB_flight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_set;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.ComboBox cB_minute;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cB_hour;
        private System.Windows.Forms.Button button_copy;
        private System.Windows.Forms.ComboBox cB_car;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tB_name;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tB_persons;
        private System.Windows.Forms.ComboBox cB_staff;
        private System.Windows.Forms.Label label9;
    }
}