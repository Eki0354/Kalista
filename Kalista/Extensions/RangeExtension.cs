using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalista
{
    public enum ResCellColor : long
    {
        White = 16777215,
        Yellow = 65535,
        Blue = 16776960,
        Red = 255,
        Gray = 8421504,
        Purple = 10498160,
        Green = 52224
    }

    public static class RangeExtension
    {
        public static bool ValueContains(this Range r, string keyString)
        {
            string value = r.Value;
            return string.IsNullOrEmpty(value) ? false : value.Contains(keyString);
        }

        public static string CommentString(this Range r)
        {
            Comment comment = r.Comment;
            if (comment is null) return null;
            return comment.Shape.AlternativeText;
        }

        #region StepMoveCell

        public static Range LeftCell(this Range r, int step = 1) =>
            (r.Parent as Worksheet).Cells[r.Row, r.Column - step];

        public static Range RightCell(this Range r, int step = 1) =>
            (r.Parent as Worksheet).Cells[r.Row, r.Column + step];

        public static Range TopCell(this Range r, int step = 1) =>
            (r.Parent as Worksheet).Cells[r.Row - step, r.Column];

        public static Range BottomCell(this Range r, int step = 1) =>
            (r.Parent as Worksheet).Cells[r.Row + step, r.Column];

        public static Range StepCell(this Range r,
            int horizonStep = 1, int verticalStep = 0) =>
            (r.Parent as Worksheet).Cells[r.Row + horizonStep, r.Column + verticalStep];

        #endregion

        public static RoomCell ToResCell(this Range r) => new RoomCell(r);

        public static RoomNumCell ToRoomNumCell(this Range r) => new RoomNumCell(r);

        public static DateTime GetDateOfRoomRange(this Range r) => new DateTime(
                Int32.Parse(Setter.YearRegex.Match(r.Worksheet.Parent.Name).Value),
                Int32.Parse(Setter.MonthRegex.Match(r.Worksheet.Name).Value),
                r.Column - Setter.Day0ColumnIndex);

        public static Range LastRoomRange(this Range r) =>
            r.Application.GetRangeByDate(r.GetDateOfRoomRange().AddDays(-1), r.Row);

        public static Range NextRoomRange(this Range r) =>
            r.Application.GetRangeByDate(r.GetDateOfRoomRange().AddDays(1), r.Row);
    }
}
