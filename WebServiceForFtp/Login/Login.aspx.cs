using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.ftp.service.Model;
using com.ftp.service.BLL;
using com.ftp.service.util;

namespace WebServiceForFtp.Login
{
    public partial class Login : System.Web.UI.Page
    {
        private int LoginError = 0;//控制用户的登录错误次数
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
        }

        protected void button_login_Click(object sender, EventArgs e)
        {
            //添加必填验证
            if (CheckInput())
            {
                button_login.Enabled = false;
                if (AdminUserBLL.CheckAdminUser(textbox_userId.Text, MD5PWD.EnCode(textbox_pwd.Text)))
                {
                    AdminUser admin = new AdminUser();
                    admin.UserID = textbox_userId.Text;
                    admin.UserPwd = MD5PWD.EnCode(textbox_pwd.Text);
                    //登录按钮操作事件
                    //Session["pwd"] = textbox_pwd.Text; 
                    admin = new AdminUserBLL().GetByID(textbox_userId.Text);
                    Session["Users"] = admin;//将用户存入到Session中
                    Response.Redirect("../AdminManagerment/Index.aspx");
                }
                else
                {
                    JqHelper.ResponseScript("alert(\"登录密码或用户名错误！\")");
                    button_login.Enabled = true;
                }
            }
        }

        #region 必填验证
        public bool CheckInput()
        {
            bool result = false;
            if (string.IsNullOrEmpty(textbox_userId.Text))
            {
                JqHelper.ResponseScript("alert(\"请输入登录用户名\")");
                textbox_userId.Focus();
            }
            else
            {
                if (string.IsNullOrEmpty(textbox_pwd.Text))
                {
                    JqHelper.ResponseScript("alert(\"请输入登录密码\")");
                    textbox_pwd.Focus();
                }
                else
                {
                    result = true;
                }
            }
            return result;
        }
        #endregion
    }
}