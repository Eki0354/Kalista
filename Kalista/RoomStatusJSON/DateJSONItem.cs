using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalista.RoomStatusJSON
{
    class DateJSONItem
    {
        public DateTime Date { get; set; }
        public List<CellJSONItem> Items = new List<CellJSONItem>();
        public DateJSONItem(Worksheet ws, DateTime date)
        {
            this.Date = date;
            int col = this.Date.Day + 4;
            for(int i = 3; i < 100; i++)
            {
                Items.Add(new CellJSONItem(ws, ws.Cells[i, col]));
            }
        }

        public override string ToString()
        {
            return "{" + string.Format("\"date\":\"{0}\",\"data\":[{1}]",
                this.Date.ToString("yyyy-MM-dd"),
                string.Join(",", this.Items)) + "}";
        }
    }
}
