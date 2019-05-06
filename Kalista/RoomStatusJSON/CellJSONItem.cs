using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalista.RoomStatusJSON
{
    class CellJSONItem
    {
        public string RoomTag { get; set; }
        public CellJSON Cell { get; set; }
        public CommentJSON Comment { get; set; }
        public CellJSONItem(Worksheet ws, Range range)
        {
            RoomTag = Ribbon_Excel.GetRoomTag(ws, range.Row);
            Cell = new CellJSON(range);
            Comment = new CommentJSON(range);
        }
        public override string ToString()
        {
            return string.Join("", new string[]{"{" ,

                string.Format(
                "\"tag\":\"{0}\",\"cell\":{1},\"comment\":{2}",
                this.RoomTag,
                this.Cell.ToString(),
                this.Comment.ToString()) ,"}" });
        }
    }
}
