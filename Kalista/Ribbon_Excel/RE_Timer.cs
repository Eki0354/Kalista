using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelApp = Microsoft.Office.Interop.Excel.Application;

namespace Kalista
{
    public partial class Ribbon_Excel
    {
        System.Threading.Timer _ThreadTimer = new System.Threading.Timer(
                new System.Threading.TimerCallback(_TimerCallback), null, 0, 60000);
        static int _BackupTimerCount = -1;

        private static void _TimerCallback(object state)
        {
            _ResetDate();
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
                if (!wbName.Contains("房态表") || !wbName.Contains(year))
                    continue;
                Worksheet ws = wb.Sheets[today.ToString("MM月")];
                Range yR = ws.Cells[2, today.Day + 3];
                Range tR = ws.Cells[2, today.Day + 4];
                if (tR.Interior.Color == 65535 || today.Hour < 6) //黄色；早上六点后更新
                    break;
                yR.Interior.Color = 16764057;//蓝色
                tR.Interior.Color = 65535;//黄色
                break;
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
                    wb.SaveCopyAs(backupDir + now.ToString(@"\\HHmmss.xl\s\m"));
                }
                catch
                {

                }
                break;
            }
            AddIn_YuI.App.DisplayAlerts = true;
        }
    }
}
