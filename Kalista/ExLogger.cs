using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kalista
{
    public class ExLogger
    {
        public static void SaveEx(Exception ex)
        {
            SaveEx(string.Join("\r\n", new string[]
            {
                Convert.ToString(ex.HResult, 16),
                ex.Data.ToString(),
                ex.Message,
                ex.Source,
                ex.TargetSite.Name,
                ex.StackTrace
            }));
        }

        public static void SaveEx(string msg)
        {
            string exDirectory = string.Format("{0}\\{1}\\Logs",
                Updater.GetOneDrivePath(),
                Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location));
            if (!Directory.Exists(exDirectory))
                Directory.CreateDirectory(exDirectory);
            string exPath = string.Format("{0}\\{1}.txt",
                exDirectory,
                DateTime.Now.Ticks.ToString());
            using (FileStream fs = new FileStream(exPath, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(msg);
                }
            }
        }
    }
}
