using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;
using System.IO;

namespace Kalista
{
    public enum RoomStateType
    {
        NEW,
        EXTEND,
        CHANGED,
        EMPTY
    }

    public partial class Ribbon_Excel
    {
        #region ROOMSTATE

        static Regex _Regex_Transfered = new Regex("[0-9\\-]+转至");

        public void CreateCurrentRoomStatusSheet()
        {
            AddIn_YuI.App.DisplayAlerts = false;
            AddIn_YuI.App.ScreenUpdating = false;
            DateTime today = DateTime.Today;
            DateTime lastday = today.AddDays(-1);
            int ci_today = today.Day + Setter.Day0ColumnIndex;
            int ci_yesterday = lastday.Day + Setter.Day0ColumnIndex;
            List<SheetRoomStatusCellItem> rs_today = GetRoomStatus(today);
            List<SheetRoomStatusCellItem> rs_lastday = GetRoomStatus(lastday);
            //更改房态属性，默认为空房
            rs_today.ForEach(rsItem =>
            {
                if(!rsItem.IsEmpty && !string.IsNullOrEmpty(rsItem.Name))
                {
                    SheetRoomStatusCellItem lastItem =
                        rs_lastday.Find(item => item.Name == rsItem.Name);
                    if (lastItem is null)
                    {
                        rsItem.Status = RoomStatus.New;
                    }
                    else
                    {
                        rsItem.Status = RoomStatus.Extended;
                        if (lastItem.RoomNum != rsItem.RoomNum)
                            rsItem.TRoomNum = lastItem.RoomNum;
                    }
                }
            });
            InitializeRSSheet();
            Worksheet ws_rs = AddIn_YuI.App.Worksheets["房态表"];
            FillRSSheet(ws_rs, FixRSItems(rs_today));
            ws_rs.Activate();
            AddIn_YuI.App.DisplayAlerts = true;
            AddIn_YuI.App.ScreenUpdating = true;
        }

        public List<SheetRoomStatusCellItem> GetRoomStatus(DateTime date)
        {
            List<SheetRoomStatusCellItem> rsList = new List<SheetRoomStatusCellItem>();
            Worksheet ws = AddIn_YuI.App.GetWorksheetByDate(date);
            for (int ri = Setter.RoomState_MinRowIndex; ri <= Setter.RoomState_MaxRowIndex; ri++)
            {
                int roomNum;
                int bedNum;
                string name;
                bool isEmpty;
                (roomNum, bedNum) = RoomNumCell.GetRoomNumberPair(
                    ws.Cells[ri, Setter.RoomNumberColumnIndex] as Range);
                (name, isEmpty) = RoomCell.GetRoomCellStatus(
                    ws.Cells[ri, date.Day + Setter.Day0ColumnIndex] as Range);
                rsList.Add(new SheetRoomStatusCellItem(roomNum, bedNum, name, isEmpty));
            }
            return rsList;
        }

        private List<SheetRoomStatusCellItem> FixRSItems(List<SheetRoomStatusCellItem> rsItems)
        {
            Dictionary<int, List<int>> roomBedsDict = new Dictionary<int, List<int>>()
            {
                { 4,  new List<int>() { 101, 102, 111, 215, 216, 315, 415 } },
                { 6,  new List<int>() { 218, 219 } },
                { 3,  new List<int>() { 316, 317, 416 } },
                { 2,  new List<int>() { 103, 104, 105 } }
            };
            foreach (KeyValuePair<int, List<int>> pair in roomBedsDict)
            {
                pair.Value.ForEach(roomNum =>
                {
                    List<SheetRoomStatusCellItem> items =
                        rsItems.FindAll(item => item.RoomNum == roomNum);
                    if (items.Count < 1) return;
                    SheetRoomStatusCellItem itemA = items[0];
                    if (items.Count == pair.Key &&
                        items.All(item => item.Status == itemA.Status))
                    {
                        List<string> names = new List<string>();
                        items.ForEach(item =>
                        {
                            names.Add(item.Name);
                            rsItems.Remove(item);
                        });
                        SheetRoomStatusCellItem newItem = new SheetRoomStatusCellItem(
                            itemA.RoomNum,
                            0,
                            string.Join(";", names.ToArray()))
                        {
                            Status = itemA.Status
                        };
                        rsItems.Add(newItem);
                    }
                });
            }
            return rsItems;
        }

        private void FillRSSheet(Worksheet ws_rs, List<SheetRoomStatusCellItem> rsItems)
        {
            int firstRI = 4;
            int roomCI = 1;
            int nameCI = 2;
            foreach (RoomStatus status in Enum.GetValues(typeof(RoomStatus)))
            {
                int fillRI = firstRI;
                List<SheetRoomStatusCellItem> items = 
                    rsItems.FindAll(item => item.Status == status);
                items.Sort(new RSSheetFormRoomBedNumComparer());
                items.ForEach(item =>
                {
                    switch (status)
                    {
                        case RoomStatus.Empty:
                            (ws_rs.Cells[fillRI, roomCI] as Range).Value = (item.BedNum == 0) ?
                                item.RoomNum.ToString() : item.RoomNum + "-" + item.BedNum;
                            break;
                        case RoomStatus.New:
                            (ws_rs.Cells[fillRI, roomCI] as Range).Value = (item.BedNum == 0) ?
                                item.RoomNum.ToString() : item.RoomNum + "-" + item.BedNum;
                            (ws_rs.Cells[fillRI, nameCI] as Range).Value = item.Name;
                            break;
                        case RoomStatus.Extended:
                            (ws_rs.Cells[fillRI, roomCI] as Range).Value = (item.BedNum == 0) ?
                                item.RoomNum.ToString() : item.RoomNum + "-" + item.BedNum;
                            (ws_rs.Cells[fillRI, nameCI] as Range).Value = item.TRoomNum == 0 ?
                                item.Name :
                                string.Format("({0}转至){1}", item.TRoomNum, item.Name);
                            break;
                    }
                    fillRI++;
                });
                roomCI += 2;
                nameCI += 2;
            }
            #region Format

            //标题行
            ws_rs.Range["A1"].Formula = string.Format("{0}房态表", 
                DateTime.Now.ToString("yyyy年MM月dd日"));
            ws_rs.Range["A1"].Font.Bold = true;
            ws_rs.Range["A1:E1"].Merge();
            Range range_empty = ws_rs.Range["E2"];
            range_empty.Font.Size = 15;
            ws_rs.Range["A1:E1"].Font.Size = 15;
            Range headerRange = ws_rs.Columns["A:E"];
            headerRange.ColumnWidth = 15;
            headerRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            headerRange.VerticalAlignment = XlVAlign.xlVAlignBottom;
            ws_rs.Columns["A"].ColumnWidth = 12;
            ws_rs.Columns["B"].ColumnWidth = 27;
            ws_rs.Columns["C"].ColumnWidth = 12;
            ws_rs.Columns["D"].ColumnWidth = 27;
            ws_rs.Columns["E"].ColumnWidth = 12;
            ws_rs.Range["A2"].FormulaR1C1 = "今日入住";
            ws_rs.Range["C2"].FormulaR1C1 = "今日续住";
            ws_rs.Range["E2"].FormulaR1C1 = "空房";
            ws_rs.Range["A3"].FormulaR1C1 = "房号";
            ws_rs.Range["B3"].FormulaR1C1 = "姓名";
            ws_rs.Range["C3"].FormulaR1C1 = "房号";
            ws_rs.Range["D3"].FormulaR1C1 = "姓名";
            ws_rs.Range["E3"].FormulaR1C1 = "房号";
            ws_rs.Range["A2:B2"].Merge();
            ws_rs.Range["C2:D2"].Merge();
            ws_rs.Range["A2:E2"].Font.Size = 15;
            ws_rs.Range["A3:E3"].Font.Size = 12;
            ws_rs.Range["A1"].Select();
            Range allRange = ws_rs.Range["A1:E" + ws_rs.UsedRange.Rows.Count];
            Ribbon_Excel.BordersAll(allRange);
            allRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            allRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
            allRange.WrapText = true;
            ws_rs.Range["4:" + ws_rs.UsedRange.Rows.Count].Font.Size = 12;
            PageSetup ps = ws_rs.PageSetup;
            ps.LeftMargin = App.InchesToPoints(0.1);
            ps.RightMargin = App.InchesToPoints(0.1);
            ps.TopMargin = App.InchesToPoints(0.1);
            ps.BottomMargin = App.InchesToPoints(0.1);
            ps.HeaderMargin = App.InchesToPoints(0.1);
            ps.FooterMargin = App.InchesToPoints(0.1);

            #endregion
        }

        private class RSSheetFormStatusComparer : IComparer<SheetRoomStatusCellItem>
        {
            public int Compare(SheetRoomStatusCellItem x, SheetRoomStatusCellItem y) =>
                x.Status == y.Status ? 0 : (x.Status < y.Status ? -1 : 1);
        }

        private class RSSheetFormRoomBedNumComparer : IComparer<SheetRoomStatusCellItem>
        {
            public int Compare(SheetRoomStatusCellItem x, SheetRoomStatusCellItem y) =>
                x.RoomNum == y.RoomNum ?
                    (x.BedNum == y.BedNum ?
                        0 :
                        (x.BedNum < y.BedNum ? -1 : 1)
                    ) :
                    (x.RoomNum < y.RoomNum ? -1 : 1);
        }

        private class RSSheetFormDailyComparer : IComparer<SheetRoomStatusCellItem>
        {
            public int Compare(SheetRoomStatusCellItem x, SheetRoomStatusCellItem y)=>
                x.Status == y.Status ? 
                    (x.RoomNum == y.RoomNum ?
                        (x.BedNum == y.BedNum ?
                            0 :
                            (x.BedNum < y.BedNum ? -1 : 1)
                        ) :
                        (x.RoomNum < y.RoomNum ? -1 : 1)
                    ) : 
                    (x.Status < y.Status ? -1 : 1);
        }

        #endregion

        #region SHEET_ROOMSTATE

        private Worksheet InitializeRSSheet()
        {
            Worksheet ws_rs = null;
            Sheets sheets = AddIn_YuI.App.Worksheets;
            try
            {
                ws_rs = sheets["房态表"];
                ws_rs.Delete();
            }
            catch
            {

            }
            ws_rs = sheets.Add();
            ws_rs.Name = "房态表";
            ws_rs.Move(sheets[sheets.Count]);
            sheets[sheets.Count].Move(ws_rs);
            ws_rs.Select();
            return ws_rs;
        }

        private void FormatRSSheet(Worksheet ws_rs)
        {
            Range range = ws_rs.Range["A1:E1"];
            range.Merge();
            range.Font.Size = 15;
            ws_rs.Range["A:A,C:C"].ColumnWidth = 15;
            ws_rs.Range["B:B,D:D"].ColumnWidth = 25;
            ws_rs.Range["E:E"].ColumnWidth = 12;
            range = ws_rs.Range["A1:E" + ws_rs.UsedRange.Rows.Count];
            range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = XlVAlign.xlVAlignCenter;
            range.Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            range.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            range.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            range.Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
            range.Borders[XlBordersIndex.xlInsideHorizontal].LineStyle = XlLineStyle.xlContinuous;
            range.Borders[XlBordersIndex.xlInsideVertical].LineStyle = XlLineStyle.xlContinuous;
            range.WrapText = true;
            ws_rs.PageSetup.LeftMargin = AddIn_YuI.App.InchesToPoints(0.3);
            ws_rs.PageSetup.RightMargin = AddIn_YuI.App.InchesToPoints(0.3);
            ws_rs.PageSetup.TopMargin = AddIn_YuI.App.InchesToPoints(0.3);
            ws_rs.PageSetup.BottomMargin = AddIn_YuI.App.InchesToPoints(0.3);
            ws_rs.PageSetup.HeaderMargin = AddIn_YuI.App.InchesToPoints(0.1);
            ws_rs.PageSetup.FooterMargin = AddIn_YuI.App.InchesToPoints(0.1);
        }

        #endregion

        #region CELL_SHARED
        
        public string GetRoomNumber(Worksheet ws, int rowIndex)
        {
            Range range = ws.Cells[rowIndex, 4];
            if (range == null || range.Value == null || range.Value.ToString() == "")
            {
                if (rowIndex > 92)
                {
                    return "爆房";
                    return Microsoft.VisualBasic.Interaction.InputBox(
                        "EEAT讨厌爆房。\r\n呈上房号：",
                        "抱怨");
                }
                else if (rowIndex > 1)
                {
                    return GetRoomNumber(ws, rowIndex - 1);
                }
                else
                {
                    return null;
                    System.Windows.Forms.MessageBox.Show("EETA不想点第一；\r\nEEAT永远第一。");
                    return null;
                }
            }
            string value = range.Value.ToString();
            int index = value.IndexOf("\r");
            if (index < 0) index = value.IndexOf("\n");
            if (index < 0)
                return value;
            else
                return value.Substring(0, index);
        }
        
        private bool IsEmpty(Range range)
        {
            if (range.Value == null) return true;
            if (range.Value.ToString() == "") return true;
            long color = range.Interior.Color;
            return color != (long)ResCellColor.Blue && color != (long)ResCellColor.Red;
        }

        private string ModifyName(Range range)
        {   //若单元格内容带换行符，则返回最后一行；否则返回完整内容。返回前清除首尾空格
            string value = range.Value.ToString();
            int index = value.LastIndexOf("\n");
            return value.LastIndexOf("\n") > -1 ? value.Substring(index + 1).Trim() : value.Trim();
        }
        
        #endregion
        
        private static bool IsDayShift =>
            DateTime.Now.Hour > 11 && DateTime.Now.Hour <= 23;

        public static string Shift => IsDayShift ? "白班" : "夜班";

    }
}
