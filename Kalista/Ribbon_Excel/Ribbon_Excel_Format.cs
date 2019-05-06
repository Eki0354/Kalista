using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace Kalista
{
    public partial class Ribbon_Excel
    {

        #region VALUE

        private void InitRange(Range r)
        {
            r.Application.ExecuteWithoutUpdate(delegate ()
            {
                r.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                r.VerticalAlignment = XlVAlign.xlVAlignCenter;
                BordersAll(r);
            });
        }

        public void ItinializeActiveCell()
        {
            InitRange(AddIn_YuI.App.ActiveCell);
        }
        
        public void ItinializeSelected()
        {
            InitRange(AddIn_YuI.App.Selection);
        }

        public static void BordersAll(Range r)
        {
            r.Copy();
            AddIn_YuI.App.CutCopyMode = 0;
            r.Borders[XlBordersIndex.xlDiagonalDown].LineStyle = XlLineStyle.xlLineStyleNone;
            r.Borders[XlBordersIndex.xlDiagonalUp].LineStyle = XlLineStyle.xlLineStyleNone;
            List<Border> bL = new List<Border>
            {
                r.Borders[XlBordersIndex.xlEdgeLeft],
                r.Borders[XlBordersIndex.xlEdgeTop],
                r.Borders[XlBordersIndex.xlEdgeBottom],
                r.Borders[XlBordersIndex.xlEdgeRight],
                r.Borders[XlBordersIndex.xlInsideVertical],
                r.Borders[XlBordersIndex.xlInsideHorizontal]
            };
            bL.ForEach(b =>
            {
                b.LineStyle = XlLineStyle.xlContinuous;
                b.ColorIndex = 0;
                b.TintAndShade = 0;
                b.Weight = XlBorderWeight.xlThin;
            });
        }

        #endregion

        #region COMMENT

        public static void BasicShapeAutoSize(Range r)
        {
            if (r.Comment == null)
                return;
            Shape shape = r.Comment.Shape;
            TextFrame textFrame = shape.TextFrame;
            textFrame.AutoSize = true;
            if (shape.Width <= 175)
                return;
            float squre = shape.Width * shape.Height;
            shape.Width = 175;
            shape.Height = squre / 175;
        }

        public static void ShapeAutoSize(Range commentRange)
        {

        }

        public static void ShapeAutoSizeByAutoFit(Range commentRange)
        {
            AddIn_YuI.App.DisableUpdateAndAlerts();
            Worksheet sheet = null;
            Worksheet aws = ActSheet;
            Sheets sheets = ActWorkbook.Worksheets;
            if (ActWorkbook.IsSheetExisted("Temp"))
            {
                sheet = sheets["Temp"];
            }
            else
            {
                sheet = sheets.Add(After: sheets[sheets.Count]);
                AddIn_YuI.App.DisableUpdateAndAlerts();
                sheet.Name = "Temp";
            }
            sheet.Visible = XlSheetVisibility.xlSheetVeryHidden;
            Range tempRange = sheet.Range["A1"];
            tempRange.ColumnWidth = 35;
            tempRange.Font.Size = 10;
            tempRange.WrapText = true;
            foreach (Range sR in commentRange)
            {
                Comment comment = sR.Comment;
                if (comment == null) continue;
                Shape shape = comment.Shape;
                shape.TextFrame.AutoSize = true;
                float shapeWidth = shape.Width;
                if (shapeWidth <= 90)
                {
                    shape.TextFrame.AutoSize = false;
                    shape.Width = 90;
                }
                else if (shapeWidth <= 213.75)
                {
                    continue;
                }
                else
                {
                    shape.TextFrame.AutoSize = false;
                    tempRange.Value = sR.Comment.Text();
                    tempRange.Rows.AutoFit();
                    shape.Width = Convert.ToSingle(tempRange.Width);
                    shape.Height = Convert.ToSingle(tempRange.Height);
                }
            }
            AddIn_YuI.App.DisableUpdateAndAlerts();
            sheet.Visible = XlSheetVisibility.xlSheetHidden;
            sheet.Delete();
            aws.Activate();
            AddIn_YuI.App.EnableUpdateAndAlerts();
        }

        public void ShapeAutoSize_Worksheet(Worksheet sheet = null)
        {
            if (sheet is null) sheet = ActSheet;
            ShapeAutoSizeByAutoFit(sheet.Cells.SpecialCells(XlCellType.xlCellTypeComments));
        }

        public void ShapeAutoSize_Workbook(Workbook wb = null)
        {
            if (wb is null) wb = ActWorkbook;
            foreach(Worksheet ws in wb.Worksheets)
            {
                ShapeAutoSize_Worksheet(ws);
            }
        }

        public void ShapeAutoSize_ActiveCell()
        {
            ShapeAutoSizeByAutoFit(AddIn_YuI.App.ActiveCell);
        }

        #endregion

    }
}
