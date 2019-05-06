using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using System.Reflection;
using System.Diagnostics;

namespace Kalista
{
    public class Updater
    {
        public static string GetOneDrivePath()
        {
            RegistryKey rKey = Registry.CurrentUser.OpenSubKey("Environment");
            return rKey.GetValue("OneDrive") as string;
        }

        public static void CheckUpdate()
        {
            string odPath = GetOneDrivePath();
            string updatePath = odPath + "\\发布_Kalista";
            string setupPath = odPath + "\\Kalista";
            string vstoName = Assembly.GetExecutingAssembly().GetName().Name;
            string updateVSTOPath = string.Format("{0}\\{1}.vsto", updatePath, vstoName);
            if (!File.Exists(updateVSTOPath))
            {
                System.Windows.Forms.MessageBox.Show("Kalista无法检测自动更新！\r\n更新启动文件不存在！");
                return;
            }
            Version lastVersion = GetVSTOVersion(updateVSTOPath);
            if (lastVersion == null)
            {
                System.Windows.Forms.MessageBox.Show("Kalista无法检测自动更新！\r\n启动文件版本号错误！");
                return;
            }
            Version currentVersion = GetVSTOVersion(string.Format("{0}\\{1}.vsto", setupPath, vstoName));
            if (lastVersion > currentVersion)
            {
                if (System.Windows.Forms.MessageBox.Show(
                    "Kalista有更新版本！\r\n是否立即更新？",
                    "复仇",
                    System.Windows.Forms.MessageBoxButtons.YesNo) ==
                    System.Windows.Forms.DialogResult.Yes)
                {
                    CopyDirectory(updatePath, setupPath);
                    Process p = new Process();
                    p.StartInfo.FileName = setupPath + "\\setup.exe";
                    p.Start();
                }
            }
        }

        static Version GetVSTOVersion(string path)
        {
            #region LINQ
            /*XNamespace aw = "asmv1";
            int x = doc.Elements(aw + "assemblyIdentity").Count();
            var versionElements = from e in doc.Elements(aw + "assemblyIdentity")
                                  where e.Attribute("name").Value == vstoName
                                  select e.Value;
            if (versionElements.Count() < 1)
            {
                System.Windows.Forms.MessageBox.Show("Kalista无法检测自动更新！\r\n启动文件版本号错误！");
                return;
            }
            Version lastVersion = Version.Parse(versionElements.First());*/
            #endregion
            XElement doc = XElement.Load(path);
            foreach (XElement xe in doc.Elements())
            {
                if (xe.Name.LocalName == "assemblyIdentity" && xe.Attribute("name") is XAttribute xa &&
                    xa.Value == "Kalista.vsto")
                {
                    return Version.Parse(xe.Attribute("version").Value);
                }
            }
            return null;
        }

        public static void CopyDirectory(string srcPath, string destPath)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(srcPath);
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //获取目录下（不包含子目录）的文件和子目录
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)     //判断是否文件夹
                    {
                        if (!Directory.Exists(destPath + "\\" + i.Name))
                            Directory.CreateDirectory(destPath + "\\" + i.Name);   //目标目录下不存在此文件夹即创建子文件夹
                        CopyDirectory(i.FullName, destPath + "\\" + i.Name);    //递归调用复制子文件夹
                    }
                    else
                    {
                        File.Copy(i.FullName, destPath + "\\" + i.Name, true);      //不是文件夹即复制文件，true表示可以覆盖同名文件
                    }
                }
            }
            catch (Exception e)
            {
                ExLogger.SaveEx(e);
            }
        }
    }
}
