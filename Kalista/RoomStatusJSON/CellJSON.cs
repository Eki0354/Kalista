using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalista.RoomStatusJSON
{
    class CellJSON
    {
        public Dictionary<string, string> CellRows=new Dictionary<string, string>();
        public CellJSON(Range range)
        {
            var comments = range.Value;
            if (comments is null) return;
            comments = comments.ToString();
            if (comments.Length < 1) return;
            string[] kvs = comments.Split("\r\n\t".ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries);
            if (kvs.Length < 1) return;
            if (kvs.Length < 2)
            {
                this.CellRows.Add(kvs[0], "");
            }
            else
            {
                this.CellRows.Add(kvs[0], string.Join(" ", kvs.Skip(1)));
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            var pairs = this.CellRows.Select(pair => ToJSON(pair));
            if (pairs.Count() < 1)
            {
                return "{}";
            }
            else
            {
                sb.Append("{");
                sb.Append(string.Join(",", pairs));
                sb.Append("}");
                return sb.ToString();
            }
        }

        private static string ToJSON(KeyValuePair<string,string> kv)
        {
            return string.Format("\"{0}\":\"{1}\"",
                kv.Key.Replace("\\", "\\\\").Replace("'", "&apos;").Replace("\"", "\\\"").Trim(),
                kv.Value.Replace("'", "&apos;").Replace("\\", "\\\\").Replace("\"", "\\\"").Trim());
        }
    }
}
