using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kalista
{
    public static class WorkbookExtension
    {
        public static bool IsSheetExisted(this Workbook wb, string name)
        {
            foreach(Worksheet sheet in wb.Sheets)
            {
                if (sheet.Name == name) return true;
            }
            return false;
        }

        public static bool IsRoomStatusWorkbook(this Workbook wb) =>
            new Regex(@"\d{4}年房态表").IsMatch(wb.Name);
        
        public static void ExecuteInRoomStatusWorkbook(this Workbook wb, System.Action action)
        {
            if (wb.IsRoomStatusWorkbook()) action();
        }

    }
}
