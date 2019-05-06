using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kalista
{
    public enum RoomStatus { New, Extended, Empty }
    public enum RoomState { EMPTY, RESERVED, CHECKED_IN, CHECKED_OUT, NOSHOW, UNKNOWN }
    public enum PaymentState { UNPAID, PAID, FRONT, UNKNOWN }
    public enum Channel { NULL, BK, 交青, Agoda, 携程, HW, 青芒果, 美团, 到店, 微信, UNKNOWN }
    public enum RCellType { NormalRange, BasicCell, ResCell, RoomNumCell }
    
    public class SheetRoomStatusCellItem
    {
        public int RoomNum { get; }
        public int BedNum { get; }
        public int TRoomNum { get; set; }
        public bool IsEmpty { get; }
        public string Name { get; }
        public RoomStatus Status { get; set; }

        public SheetRoomStatusCellItem(int roomNum, int bedNum, string name, bool isEmpty = true)
        {
            this.RoomNum = roomNum;
            this.BedNum = bedNum;
            this.Name = name;
            this.IsEmpty = isEmpty;
            this.Status = RoomStatus.Empty;
        }

    }
    

    public class RoomCell
    {
        public string Name { get; }
        public long Color { get; }

        public RoomCell(Range r) : base()
        {
            this.Name = GetGuestName(r);
            this.Color = r.Interior.Color;
        }

        public static string GetGuestName(Range r)
        {
            string value = null;
            try
            {
                value = r.Value.TrimEnd("\r\n ".ToCharArray());
            }
            catch
            {
                return null;
            }
            if (string.IsNullOrEmpty(value)) return null;
            //若单元格内容带换行符，则返回最后一行；否则返回完整内容。返回前清除首尾空格
            int index = Math.Max(value.LastIndexOf("\n"), value.LastIndexOf("\r"));
            if (index < 0) index = value.LastIndexOf(" ");
            return index > -1 ? value.Substring(index + 1).Trim() : value.Trim();
        }

        public static (string, bool) GetRoomCellStatus(Range r) => (GetGuestName(r),
            r.Interior.Color != (long)ResCellColor.Blue && 
            r.Interior.Color != (long)ResCellColor.Red);

    }

    public class RoomNumCell
    {
        public int RoomNum { get; }
        public int BedNum { get; }

        public RoomNumCell(Range r)
        {
            (this.RoomNum, this.BedNum) = GetRoomNumberPair(r);
        }

        public static (int, int) GetRoomNumberPair(Range r)
        {
            string value = r.Formula;
            if (string.IsNullOrEmpty(value))
                return GetRoomNumberPair(r.TopCell());
            return (Int32.Parse(value.Substring(0, 3)),
                (value.Length > 3 && value[3] == '-') ? Int32.Parse(value[4].ToString()) : 0);
        }
        
    }
    
}
