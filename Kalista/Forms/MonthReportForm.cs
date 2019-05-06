using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalista
{

    public partial class MonthReportForm : Form
    {
        public MonthReportForm()
        {
            InitializeComponent();
        }

        private void MonthReportForm_Load(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            tb_year.Text = date.Year.ToString();
            cb_month.SelectedIndex = date.Month - 1;
            if (date.Hour > 11 && date.Hour <= 23)
            {
                rb_day.Checked = true;
                rb_night.Checked = false;
            }
            else
            {
                rb_day.Checked = false;
                rb_night.Checked = true;
            }
                
        }

        private void button_create_Click(object sender, EventArgs e)
        {
            CreateReceptionReportWorkbook(rb_day.Checked,
                int.Parse(tb_year.Text),
                int.Parse(cb_month.SelectedItem as string));
            this.Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void CreateReceptionReportWorkbook(bool isDayShift, int year,int month)
        {
            string templatePath = Environment.GetFolderPath(
                Environment.SpecialFolder.MyDocuments) + "\\自定义 Office 模板\\收入报表模板.xltx";
            if (!File.Exists(templatePath))
            {
                byte[] templateBytes = Properties.Resources.收入报表模板;
                FileStream fs = new FileStream(templatePath, FileMode.Create);
                fs.Write(templateBytes, 0, templateBytes.Length);
                fs.Close();
            }
            string shift = isDayShift ? "白班" : "夜班";
            Workbook newWb = AddIn_YuI.App.Workbooks.Add(templatePath);
            Worksheet sourceWs = newWb.Sheets[shift];
            bool isDisplayAlerts = AddIn_YuI.App.DisplayAlerts;
            AddIn_YuI.App.DisplayAlerts = false;
            int days = DateTime.DaysInMonth(year, month);
            string yearStr = year.ToString();
            string monthStr = month.ToString().PadLeft(2, '0');
            string titleFormatString = Properties.Resources.Report_Title;
            for (int i = 1; i < days + 1; i++)
            {
                Worksheet ws = newWb.Sheets[i + 1];
                sourceWs.Copy(After: ws);
                ws = newWb.Sheets[i + 2];
                string dayStr = i.ToString().PadLeft(2, '0');
                ws.Name = dayStr + "日";
                ws.Cells[1, 1].Value = string.Format(titleFormatString,
                    yearStr,
                    monthStr,
                    dayStr,
                    shift);
            }
            newWb.Sheets["白班"].Delete();
            newWb.Sheets["夜班"].Delete();
            newWb.Sheets["01日"].Select();
            newWb.Activate();
            AddIn_YuI.App.DisplayAlerts = isDisplayAlerts;
        }

        public static void ShowMonthReportForm()
        {
            MonthReportForm form = new MonthReportForm();
            form.ShowDialog();
        }
    }
}
