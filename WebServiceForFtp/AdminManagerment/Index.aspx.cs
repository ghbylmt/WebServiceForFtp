using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.ftp.service.Model;
using com.ftp.service.util;


namespace WebServiceForFtp.AdminManagerMent
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
            AdminUser user = Session["Users"] as AdminUser;
            if (user == null)
            {
                //用户未登录，或者登录信息过期
                JqHelper.ResponseScript("alert(\"未能获取到您的登录信息，请重新登录！\")");
                Response.Redirect("../Login/Login.aspx");
            }
            else
            {
                //用户 登录成功
                aUser.InnerText = user.UserID;
                aUser.HRef = "";//连接到登出页面
            }
        }
        #region 安全退出的操作
        protected void btn_logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();//取消当前会话   
            Session.Clear();//清除当前浏览器进程所有session 
            // this.Response.Write(@"<script>window.opener=null;window.close();</script>");//关闭当前的窗口
            Response.Redirect("../Login/Login.aspx");//调试时使用
        }
        #endregion
    }
}