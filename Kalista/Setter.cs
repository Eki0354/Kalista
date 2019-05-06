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

        public static int Day0ColumnIndex => int.Parse(Items["ColumnIndex_Day0"]);
        public static int RoomState_MinRowIndex => int.Parse(Items["RowIndex_Min"]);
        public static int RoomState_MaxRowIndex => int.Parse(Items["RowIndex_Max"]);
        public static int RoomNumberColumnIndex => int.Parse(Items["ColumnIndex_RoomNumber"]);
        public static bool IsAutoBackup
        {
            get { return bool.Parse(Items["IsAutoBackup"]); }
            set { Items["IsAutoBackup"] = value.ToString(); }
        }

        public static void Initialize()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                + "\\Kalista\\settings.ini";
            if (!File.Exists(path))
            {
                System.Windows.Forms.MessageBox.Show("配置文件不存在！目标路径：" + path);
                return;
            }
            string[] pair;
            FileStream fs = new FileStream(path,FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            while(!sr.EndOfStream)
            {
                pair = sr.ReadLine().Split(Convert.ToChar("="));
                Items.Add(pair[0], pair[1]);
            }
            sr.Close();
            fs.Close();
        }
    }
}
