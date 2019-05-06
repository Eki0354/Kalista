using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kalista.RoomStatusJSON
{
    class RoomStatusJSONHelper
    {
        public List<DateJSONItem> Items = new List<DateJSONItem>();
        private Workbook _wb;
        public RoomStatusJSONHelper(Workbook wb)
        {
            this._wb = wb;
        }

        private string getYear()
        {
            string name = _wb.Name;
            return name.Substring(0, 4);
        }
        
        public void ToJSON()
        {
            StringBuilder jsonSB = new StringBuilder();
            DateTime startDate = new DateTime(int.Parse(getYear()), 1, 1);
            for (int i = 0; i < 365; i++)
            {
                DateTime date = startDate.AddDays(i);
                Worksheet sheet = _wb.Sheets[date.ToString("MM月")];
                if (sheet is null) continue;
                this.Items.Add(new DateJSONItem(sheet, date));
            }
            jsonSB.Append("[");
            jsonSB.Append(string.Join(",", this.Items));
            jsonSB.Append("]");
            string path = string.Format("rs{0}.txt", DateTime.Now.Ticks);
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                using(var sw =new StreamWriter(fs))
                {
                    sw.Write(jsonSB.ToString());
                }
            }
            Console.WriteLine(path);
        }
    }
}
