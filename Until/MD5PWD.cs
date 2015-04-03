using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace com.ftp.service.util
{
    public class MD5PWD
    {
        public static string EnCode(string sourcePwd)
        {
            //return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(text, "MD5");
            MD5 md = new MD5CryptoServiceProvider();
            byte[] bytes = Encoding.Default.GetBytes(sourcePwd);
            byte[] buffer2 = md.ComputeHash(bytes);
            md.Clear();
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < (buffer2.Length - 1); i++)
            {
                builder.Append(buffer2[i].ToString("x").PadLeft(2, '0'));
            }
            return builder.ToString();
        }
    }
}
