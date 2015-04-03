using System;
using System.Collections.Generic;
using System.Web;
using com.ftp.service.BLL;

namespace WebServiceForFtp.Ajax
{
    /// <summary>
    /// UserManagerHandler 的摘要说明
    /// 用户管理的一般页面
    /// </summary>
    public class UserManagerHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            // context.Response.Write("success");
            string ajaxMethod = context.Request.QueryString["ajaxMethod"];
            switch (ajaxMethod)
            {
                case "deleteUser":
                    context.Response.Write(DeleteUser(context));
                    context.Response.Flush();
                    context.Response.End();
                    break;
                default:
                    break;
            }
        }
        #region 删除用户
        public string DeleteUser(HttpContext context)
        {
            string id = context.Request.QueryString["id"];
            if (!string.IsNullOrEmpty(id) && id != "1")
            {
                if (new AdminUserBLL().DeleteByUserID(id) > 0)
                {
                    return "success";
                }
                else
                {
                    return "failed";
                }
            }
            else
            {
                return "failed";
            }
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