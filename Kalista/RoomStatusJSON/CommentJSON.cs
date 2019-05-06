using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalista.RoomStatusJSON
{
    class CommentJSON
    {
        public Dictionary<string, string> Comments=new Dictionary<string, string>();
        public CommentJSON(Range range)
        {
            string comments = range.CommentString();
            if (comments == null || comments.Length < 1) return;
            if(comments.StartsWith("Text Box: "))
            {
                comments = comments.Substring(10);
            }
            foreach(string row in comments.Split("\r\n".ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries))
            {
                string[] kvs=row.Split("：:\t".ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries);
                if (kvs.Length < 2)
                {
                    if (this.Comments.ContainsKey(kvs[0])) continue;
                    this.Comments.Add(kvs[0], "");
                }
                else
                {
                    if (this.Comments.ContainsKey(kvs[0])) continue;
                    this.Comments.Add(kvs[0], string.Join(" ", kvs.Skip(1)));
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            var pairs = this.Comments.Select(pair => ToJSON(pair));
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
                kv.Value.Replace("\\", "\\\\").Replace("'", "&apos;").Replace("\"", "\\\"").Trim());
        }
    }
}
