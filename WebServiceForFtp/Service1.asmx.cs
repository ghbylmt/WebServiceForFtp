using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Xml;
using com.ftp.service.util;
using Newtonsoft;

namespace WebServiceForFtp
{
    /// <summary>
    /// Service1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://localhost:808")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Service1 : System.Web.Services.WebService
    {

        [WebMethod(Description = "")]
        public string HelloWorld()
        {
            return "Hello World";
        }
        //[WebMethod(Description = "获取升级文件的MD5的值")]
        //public string GetFileMD5()
        //{
        //    //获取文件的MD5值
        //    //该值通过计算得到
        //    XmlDocument doc = new XmlDocument();
        //    doc.Load(Server.MapPath("UpdateInfo.xml"));
        //    XmlElement root = doc.DocumentElement;
        //    string filePath = root.SelectSingleNode("filePath").InnerText;
        //    return FileOpteration.GetFileMD5(Server.MapPath(filePath));
        //}
        //[WebMethod(Description = "获取升级的最新软件的版本")]
        //public string GetSoftVersion()
        //{
        //    XmlDocument doc = new XmlDocument();
        //    doc.Load(Server.MapPath("UpdateInfo.xml"));
        //    XmlElement root = doc.DocumentElement;
        //    return root.SelectSingleNode("softVersion").InnerText;
        //}
        //[WebMethod(Description = "获取升级软件的名字")]
        //public string GetFileName()
        //{
        //    //返回文件名称
        //    XmlDocument doc = new XmlDocument();
        //    doc.Load(Server.MapPath("UpdateInfo.xml"));
        //    XmlElement root = doc.DocumentElement;
        //    return root.SelectSingleNode("fileName").InnerText;
        //}
        //[WebMethod(Description = "获取升级的创建日期")]
        //public string GetCreateDate()
        //{
        //    //返回升级包的创建时间
        //    XmlDocument doc = new XmlDocument();
        //    doc.Load(Server.MapPath("UpdateInfo.xml"));
        //    XmlElement root = doc.DocumentElement;
        //    return root.SelectSingleNode("createDate").InnerText;
        //}
        //[WebMethod(Description = "获取升级文件的Ftp下载地址")]
        //public string GetFtpServer()
        //{
        //    //返回FTP服务器的地址
        //    XmlDocument doc = new XmlDocument();
        //    doc.Load(Server.MapPath("UpdateInfo.xml"));
        //    XmlElement root = doc.DocumentElement;
        //    return root.SelectSingleNode("ftpAddress").InnerText;
        //}
        //[WebMethod(Description = "判断用户是否有权限下载本次升级")]
        //public bool Author(string UserId, string UserPwd)
        //{
        //    //需要对用户是否有权限升级此次软件做出判断 
        //    return true;
        //}
        ///// <summary>
        ///// 获取FTP文件的下载地址
        ///// </summary>
        ///// <param name="updateFileName">文件的名称</param>
        ///// <returns>FTP的下载地址</returns>
        //[WebMethod(Description = "获取升级文件的FTP下载地址")]
        //public string GetFtpAddress(string updateFileName)
        //{
        //    string result = "ftp://127.0.0.1//" + updateFileName;
        //    return "";
        //}
        ///// <summary>
        ///// 获取FTP的登录名和密码
        ///// </summary>
        ///// <param name="dogNum">加密狗编号</param> 
        ///// <returns>Json格式的用户名和密码</returns>
        //[WebMethod(Description = "获取FTP的登录名和密码")]
        //public string GetFtpUserAndPwd(string dogNum)
        //{
        //    return "";
        //}

        [WebMethod(Description = "信息交互的接口")]
        public string InfoExchangeAPI(string strMessageToWeService)
        {
            Log.WriteLog(strMessageToWeService);
            MessageToWebService messageToWebService = new MessageToWebService();
            string result = string.Empty;
            try
            {
                messageToWebService = Newtonsoft.Json.JsonConvert.DeserializeObject<MessageToWebService>(strMessageToWeService);
                result = FileOpteration.InformationExchange(messageToWebService);
                Log.WriteLog(result);
            }
            catch (Exception)
            {
                //throw;
                //return "";

            }
            return result;
        }


    }
}