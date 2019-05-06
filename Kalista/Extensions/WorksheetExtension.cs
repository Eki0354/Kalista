using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kalista
{
    public static class WorksheetExtension
    {
        public static string GetValue(this Worksheet sheet, int rowIndex, int columnIndex)
        {
            Range r = sheet.Cells[rowIndex, columnIndex];
            return GetValue(sheet, r);
        }

        public static string GetValue(this Worksheet sheet, Range r)
        {
            if (r is null) return null;
            return r.Value as string;
        }

        public static void SuperShowAllData(this Worksheet sheet)
        {
            try
            {
                sheet.ShowAllData();
            }
            catch
            {

            }
            finally
            {
                sheet.ShowAllRooms();
            }
        }

        public static void ShowAllRooms(this Worksheet sheet)
        {
            (sheet.Rows[string.Format("{0}:{1}",
                    Setter.RoomState_MinRowIndex,
                    Setter.RoomState_MaxRowIndex)] as Range).EntireRow.Hidden = false;
        }

        public static void HideAllRooms(this Worksheet sheet)
        {
            (sheet.Rows[string.Format("{0}:{1}",
                    Setter.RoomState_MinRowIndex,
                    Setter.RoomState_MaxRowIndex)] as Range).EntireRow.Hidden = true;
        }

        public static bool CellValueContains(this Worksheet sheet,
            int rowIndex, int columnIndex, string keyString) =>
            (sheet.Cells[rowIndex, columnIndex] as Range).ValueContains(keyString);

        public static bool IsRoomStatusWorksheet(this Worksheet sheet) =>
            (sheet.Parent as Workbook).IsRoomStatusWorkbook() &&
            new Regex(@"\d{1,2}月").IsMatch(sheet.Name);

    }
}
