using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace com.ftp.service.util
{
    /// <summary>
    /// 日志服务类
    /// </summary>
    public class Log
    {
        /// <summary>
        /// 写日志的方法
        /// </summary>
        /// <param name="logContent"></param>
        public static void WriteLog(string logContent)
        {
            string sFilePath = "d:\\Log\\WebServiceForFtp\\" + DateTime.Now.ToString("yyyyMM");
            string sFileName = "rizhi" + DateTime.Now.ToString("dd") + ".log";
            sFileName = sFilePath + "\\" + sFileName; //文件的绝对路径
            if (!Directory.Exists(sFilePath))//验证路径是否存在
            {
                Directory.CreateDirectory(sFilePath);//不存在则创建
            }
            FileStream fs;
            StreamWriter sw;
            if (File.Exists(sFileName))//验证文件是否存在，有则追加，无则创建
            {
                fs = new FileStream(sFileName, FileMode.Append, FileAccess.Write);
            }
            else
            {
                fs = new FileStream(sFileName, FileMode.Create, FileAccess.Write);
            }
            sw = new StreamWriter(fs);
            sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + "     ---     " + logContent);
            sw.Close();
            fs.Close();
        }
    }
}
