using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ExcelApp = Microsoft.Office.Interop.Excel.Application;

namespace Kalista
{
    public partial class Ribbon_Excel
    {
        static string lastBKFilePath = null;
        System.Threading.Timer _ThreadTimer = new System.Threading.Timer(
                new System.Threading.TimerCallback(_TimerCallback), null, 0, 60000);
        static int _BackupTimerCount = 8;

        private static void _TimerCallback(object state)
        {
            try
            {
            _ResetDate();
            }
            catch
            {

            }
            _BackupTimerCount++;
            if (_BackupTimerCount % 10 == 0)
            {
                _AutoBackup();
                _BackupTimerCount = 0;
            }
        }

        private static void _ResetDate()
        {
            DateTime today = DateTime.Now;
            string year = today.Year.ToString();
            ExcelApp app = AddIn_YuI.App;
            if (app is null) return;
            foreach (Workbook wb in app.Workbooks)
            {
                string wbName = wb.Name;
                if (wb.ReadOnly || !new Regex(today.Year + "年房态表").IsMatch(wb.Name))
                    continue;
                try
                {
                Worksheet ws = wb.Sheets[today.ToString("MM月")];
                    Range yR = ws.Cells[Setter.DayRowIndex, today.Day + Setter.Day0ColumnIndex - 1];
                    Range tR = ws.Cells[Setter.DayRowIndex, today.Day + Setter.Day0ColumnIndex];
                if (tR.Interior.Color == 65535 || today.Hour < 6) //黄色；早上六点后更新
                        return;
                yR.Interior.Color = 16764057;//蓝色
                tR.Interior.Color = 65535;//黄色
                break;
            }
                catch
                {

        }
                return;
            }
        }

        private static void _AutoBackup()
        {
            ExcelApp app = AddIn_YuI.App;
            if (app is null) return;
            app.DisplayAlerts = false;
            foreach (Workbook wb in AddIn_YuI.App.Workbooks)
            {
                if (wb.ReadOnly || !wb.IsRoomStatusWorkbook()) continue;
                try
                {
                    int year = int.Parse(wb.Name.Substring(0, 4));
                    DateTime now = DateTime.Now;
                    if (now.Year != year) continue;
                    string backupDir = string.Format("{0}\\房态备份\\{1}",
                    wb.Path, now.ToString(@"yyyy\\MM\\dd"));
                    if (!Directory.Exists(backupDir)) Directory.CreateDirectory(backupDir);
                string bkPath = backupDir + now.ToString(@"\\HH时mm分ss秒ffff.xl\s\m");
                bool isRetry = true;
                int retryTime = 0;
                while (isRetry && retryTime < 3)
                {
                    if (_AutoBackup(wb, bkPath))
                        isRetry = false;
                    retryTime++;
                    System.Threading.Thread.Sleep(1000);
                }
                lastBKFilePath = bkPath;
                break;
            }
                }

        static bool _AutoBackup(Workbook wb, string bkPath)
        {
            try
                {
                if (File.Exists(bkPath))
                    File.Delete(bkPath);
                wb.Save();
                wb.SaveCopyAs(bkPath);
                return true;
                }
            catch(Exception ex)
            {
                ExLogger.SaveEx(ex);
                return false;
            }
            AddIn_YuI.App.DisplayAlerts = true;
        }
    }
}
