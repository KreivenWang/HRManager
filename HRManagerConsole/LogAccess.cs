using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HRManagerDataAccess
{
    public static class LogAccess
    {
       static string LogPath;
         static LogAccess()
         {
             LogPath = ConfigHelper.GetAppConfig("LogPath");

         }

        private static string GetPath()
        {
             var month = DateTime.Now.Month;
            var year = DateTime.Now.Year;
            var day = DateTime.Now.Day;
            return LogPath + "/" + year + "/" + month + "/" + day + "/";
        }

        public static void Write(string logContent)
        {
            logContent = DateTime.Now + logContent + "\n";
            var filePath = GetPath();
            WriteFile(filePath, "log.txt", logContent);

        }

        public static void Write_Exp(string logContent)
        {
            logContent += DateTime.Now + "\n";
            var filePath = GetPath() ;
            WriteFile(filePath,"log_exp.txt", logContent);

        }

        private static void WriteFile(string path,string fileName, string content)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            FileStream fs = new FileStream(path+fileName, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            //开始写入
            sw.WriteLine("**************************************************");
            sw.WriteLine(content);
            sw.WriteLine("**************************************************");
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();
        }
    }
}
