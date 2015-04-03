using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.IO;
using System.Text;
using com.ftp.service.util;

namespace WebServiceForFtp
{
    public class FileOpteration
    {
        #region 获取文件的MD5的值
        /// <summary>
        /// 获取文件的MD5的值
        /// </summary>
        /// <param name="fileInfo">文件的本地路径例如：D:\\FTPFiles\\好食好客升级包5.2.17.zip</param>
        /// <returns>当前文件的MD5的值</returns>
        public static string GetFileMD5(string fileInfo)
        {
            try
            {
                FileStream file = new FileStream(fileInfo, FileMode.Open);
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
            // return "";
        }
        #endregion

        #region 数据交换的后台处理程序
        public static string InformationExchange(MessageToWebService messageToWebService)
        {
            //进行升级的验证操作

            FeedBackFromWebService feedBack = new FeedBackFromWebService();
            feedBack.AllowUpdate = "allow";
            feedBack.FtpPwd = "";
            feedBack.FtpUser = "";
            feedBack.UpdateFileMd5 = "";
            feedBack.UpdateFileName = "";
            feedBack.UpdatePubDate = DateTime.Now;
            feedBack.UpdateSoftVersion = "";
            return Newtonsoft.Json.JsonConvert.SerializeObject(feedBack);//返回json格式的数据
        }
        #endregion


        #region 判断用户是否可以获取更新
        /// <summary>
        /// 判断用户是否可以获取更新
        /// </summary>
        /// <param name="dogNum">加密狗编号</param>
        /// <param name="customerId">用户的ID</param>
        /// <param name="customerName">用户的名称</param>
        /// <returns>是否允许更新，允许更新“Allow”，不允许更新“Deny”</returns>
        public string CheckAccessRight(string dogNum, string customerId, string customerName)
        {
            string result = string.Empty;

            return result;
        }
        #endregion
        #region 获取更新的相关信息
        /// <summary>
        /// 获取升级包的相关信息
        /// </summary>
        /// <param name="updateFileID">升级包的ID</param>
        /// <returns></returns>
        public string GetUpdateFileInfo(int updateFileID)
        {
            string result = string.Empty;
            return result;
        }
        #endregion


    }

}