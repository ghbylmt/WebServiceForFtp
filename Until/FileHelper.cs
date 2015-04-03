using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace com.ftp.service.util
{
    /// <summary>
    /// 文件相关操作的帮助类
    /// </summary>
    public class FileHelper
    {
        #region 获取文件的MD5的值

        /// <summary>
        /// 获取文件的MD5的值
        /// </summary>
        /// <param name="FileDir">文件的路径名称</param>
        /// <returns>文件的MD5的值</returns>
        public static string GetFileMD5(string FileDir)
        {
            try
            {
                FileStream file = new FileStream(FileDir, FileMode.Open);
                System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(file);
                file.Close();

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    //数据每次两位的16进制数；
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("GetMD5HashFromFile() fail,error:" + ex.Message);
            }
        }
        #endregion
    }
}
