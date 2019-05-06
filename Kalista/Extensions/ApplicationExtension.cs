using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace Kalista
{
    public static class ApplicationExtension
    {
        public static void ExecuteWithoutUpdate(this Application app, System.Action action)
        {
            app.ScreenUpdating = false;
            action();
            app.ScreenUpdating = true;
        }

        public static void ExecuteWithoutAlerts(this Application app, System.Action action)
        {
            app.DisplayAlerts = false;
            action();
            app.DisplayAlerts = true;
        }

        public static void ExecuteWithoutUpdateAndAlerts(this Application app, System.Action action)
        {
            try
            {
                app.ScreenUpdating = false;
                app.DisplayAlerts = false;
                action?.Invoke();
            }
            catch
            {

            }
            finally
            {
                app.ScreenUpdating = true;
                app.DisplayAlerts = true;
            }
        }

        public static void DisableUpdateAndAlerts(this Application app)
        {
            app.ScreenUpdating = false;
            app.DisplayAlerts = false;
        }

        public static void EnableUpdateAndAlerts(this Application app)
        {
            app.ScreenUpdating = true;
            app.DisplayAlerts = true;
        }

        public static Range GetRangeByDate(this Application app, DateTime date, int row)
        {
            Worksheet sheet = app.GetWorksheetByDate(date);
            return sheet is null ? null : 
                sheet.Cells[row, date.Day + Setter.Day0ColumnIndex];
        }


        public static Worksheet GetWorksheetByDate(this Application app, DateTime date)
        {
            Workbook wb = app.GetWorkbookByDate(date);
            try
            {
                return wb.Worksheets[date.ToString("MM月")];
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("未打开当前日期的房态表！");
                return null;
            }
        }

        public static Workbook GetWorkbookByDate(this Application app, DateTime date)
        {
            foreach(Workbook wb in app.Workbooks)
            {
                if (Setter.YearRegex.IsMatch(wb.Name)) return wb;
            }
            return null;
        }
    }
}
