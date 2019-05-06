namespace Kalista
{
    partial class SheetToImageForm
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
            this.RadioButton_Printer = new System.Windows.Forms.RadioButton();
            this.RadioButton_Screen = new System.Windows.Forms.RadioButton();
            this.RadioButton_Cell = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.ListBox_Sheet = new System.Windows.Forms.ListBox();
            this.button_copyImage = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RadioButton_Selected = new System.Windows.Forms.RadioButton();
            this.RadioButton_Used = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RadioButton_Printer);
            this.groupBox1.Controls.Add(this.RadioButton_Screen);
            this.groupBox1.Controls.Add(this.RadioButton_Cell);
            this.groupBox1.Location = new System.Drawing.Point(9, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(320, 78);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "图片生成模式";
            // 
            // RadioButton_Printer
            // 
            this.RadioButton_Printer.AutoSize = true;
            this.RadioButton_Printer.Location = new System.Drawing.Point(236, 30);
            this.RadioButton_Printer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RadioButton_Printer.Name = "RadioButton_Printer";
            this.RadioButton_Printer.Size = new System.Drawing.Size(69, 22);
            this.RadioButton_Printer.TabIndex = 2;
            this.RadioButton_Printer.TabStop = true;
            this.RadioButton_Printer.Text = "打印";
            this.RadioButton_Printer.UseVisualStyleBackColor = true;
            // 
            // RadioButton_Screen
            // 
            this.RadioButton_Screen.AutoSize = true;
            this.RadioButton_Screen.Location = new System.Drawing.Point(123, 30);
            this.RadioButton_Screen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RadioButton_Screen.Name = "RadioButton_Screen";
            this.RadioButton_Screen.Size = new System.Drawing.Size(69, 22);
            this.RadioButton_Screen.TabIndex = 1;
            this.RadioButton_Screen.Text = "屏幕";
            this.RadioButton_Screen.UseVisualStyleBackColor = true;
            // 
            // RadioButton_Cell
            // 
            this.RadioButton_Cell.AutoSize = true;
            this.RadioButton_Cell.Checked = true;
            this.RadioButton_Cell.Location = new System.Drawing.Point(9, 30);
            this.RadioButton_Cell.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RadioButton_Cell.Name = "RadioButton_Cell";
            this.RadioButton_Cell.Size = new System.Drawing.Size(87, 22);
            this.RadioButton_Cell.TabIndex = 0;
            this.RadioButton_Cell.TabStop = true;
            this.RadioButton_Cell.Text = "单元格";
            this.RadioButton_Cell.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 178);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "选择工作表:";
            // 
            // ListBox_Sheet
            // 
            this.ListBox_Sheet.FormattingEnabled = true;
            this.ListBox_Sheet.ItemHeight = 18;
            this.ListBox_Sheet.Location = new System.Drawing.Point(9, 213);
            this.ListBox_Sheet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ListBox_Sheet.Name = "ListBox_Sheet";
            this.ListBox_Sheet.Size = new System.Drawing.Size(151, 256);
            this.ListBox_Sheet.TabIndex = 2;
            // 
            // button_copyImage
            // 
            this.button_copyImage.Location = new System.Drawing.Point(211, 258);
            this.button_copyImage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_copyImage.Name = "button_copyImage";
            this.button_copyImage.Size = new System.Drawing.Size(112, 34);
            this.button_copyImage.TabIndex = 3;
            this.button_copyImage.Text = "复制图片";
            this.button_copyImage.UseVisualStyleBackColor = true;
            this.button_copyImage.Click += new System.EventHandler(this.button_copyImage_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_cancel.Location = new System.Drawing.Point(211, 320);
            this.button_cancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(112, 34);
            this.button_cancel.TabIndex = 4;
            this.button_cancel.Text = "取消";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RadioButton_Selected);
            this.groupBox2.Controls.Add(this.RadioButton_Used);
            this.groupBox2.Location = new System.Drawing.Point(9, 94);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(320, 75);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "区域";
            // 
            // RadioButton_Selected
            // 
            this.RadioButton_Selected.AutoSize = true;
            this.RadioButton_Selected.Location = new System.Drawing.Point(164, 30);
            this.RadioButton_Selected.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RadioButton_Selected.Name = "RadioButton_Selected";
            this.RadioButton_Selected.Size = new System.Drawing.Size(141, 22);
            this.RadioButton_Selected.TabIndex = 1;
            this.RadioButton_Selected.Text = "当前选中区域";
            this.RadioButton_Selected.UseVisualStyleBackColor = true;
            this.RadioButton_Selected.CheckedChanged += new System.EventHandler(this.RadioButton_Selected_CheckedChanged);
            // 
            // RadioButton_Used
            // 
            this.RadioButton_Used.AutoSize = true;
            this.RadioButton_Used.Checked = true;
            this.RadioButton_Used.Location = new System.Drawing.Point(9, 30);
            this.RadioButton_Used.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RadioButton_Used.Name = "RadioButton_Used";
            this.RadioButton_Used.Size = new System.Drawing.Size(105, 22);
            this.RadioButton_Used.TabIndex = 0;
            this.RadioButton_Used.TabStop = true;
            this.RadioButton_Used.Text = "已用区域";
            this.RadioButton_Used.UseVisualStyleBackColor = true;
            // 
            // SheetToImageForm
            // 
            this.AcceptButton = this.button_copyImage;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_cancel;
            this.ClientSize = new System.Drawing.Size(336, 483);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_copyImage);
            this.Controls.Add(this.ListBox_Sheet);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SheetToImageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SheetToImageForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RadioButton_Printer;
        private System.Windows.Forms.RadioButton RadioButton_Screen;
        private System.Windows.Forms.RadioButton RadioButton_Cell;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox ListBox_Sheet;
        private System.Windows.Forms.Button button_copyImage;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RadioButton_Selected;
        private System.Windows.Forms.RadioButton RadioButton_Used;
    }
}