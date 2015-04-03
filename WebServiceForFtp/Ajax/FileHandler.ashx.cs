using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Web.UI;
using com.ftp.service.BLL;

namespace WebServiceForFtp.Ajax
{
    /// <summary>
    /// FileHandler 的摘要说明
    /// </summary>
    public class FileHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string ajaxMethod = context.Request.QueryString["ajaxMethod"];
            switch (ajaxMethod)
            {
                case "DeleteFile"://删除文件
                    context.Response.Write(DeleteLocalFile(context));
                    context.Response.Flush();
                    context.Response.End();
                    break;
                default:
                    break;
            }
        }
        #region 删除本地的文件
        /// <summary>
        /// 删除本地文件的操作
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string DeleteLocalFile(HttpContext context)
        {
            string result = string.Empty;
            //string fileName = HttpUtility.UrlDecode(context.Request.QueryString["filename"]);
            //if (File.Exists(fileName))
            //{
            //    FileInfo file = new FileInfo(fileName);
            //    try
            //    {
            //        file.Delete();
            //        result = "Success";
            //    }
            //    catch (Exception)
            //    {
            //        result = "Failed";
            //        // throw;
            //    }
            //}
            //else
            //{
            //    result = "FileNotExists";
            //}
            string id = context.Request.QueryString["ID"];
            if (new FtpFileInfoBLL().DeleteByID(Convert.ToInt32(id)) > 0)
            {
                result = "Success";
            }
            else
            {
                result = "Failed";
            }
            return result;
        }
        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}