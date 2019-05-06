using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Kalista
{
    public static class Setter
    {
        #region Regex

        public static Regex YearRegex => new Regex(@"\d{4}(?=年房态表)");
        public static Regex MonthRegex => new Regex(@"\d+(?=月)");

        #endregion

        public static Dictionary<string, string> Items { get; } = new Dictionary<string, string>();

        public static int Day0ColumnIndex => int.Parse(Properties.Resources.ColumnIndex_Day0);
        public static int RoomState_MinRowIndex => int.Parse(Properties.Resources.RowIndex_Min);
        public static int RoomState_MaxRowIndex => int.Parse(Properties.Resources.RowIndex_Max);
        public static int RoomNumberColumnIndex => int.Parse(Properties.Resources.ColumnIndex_RoomNumber);
        public static int DayRowIndex => int.Parse(Properties.Resources.DayRowIndex);
    }
}
