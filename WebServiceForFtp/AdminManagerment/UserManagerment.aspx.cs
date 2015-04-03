using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.ftp.service.Model;
using com.ftp.service.util;
using com.ftp.service.BLL;
using System.Text;

namespace WebServiceForFtp.AdminManagerment
{
    /// <summary>
    /// 管理员用户管理页面
    /// 实现管理员密码的修改
    /// 添加用户
    /// </summary>
    public partial class UserManagerment : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            AdminUser user = Session["Users"] as AdminUser;
            if (user == null)
            {
                //用户未登录，或者登录信息过期
                JqHelper.ResponseScript("alert(\"未能获取到您的登录信息，请重新登录！\")");
                Response.Redirect("../Login/Login.aspx");
            }
            else
            {
                labuser.InnerText = user.UserID;
                if (user.UserID.Trim() != "admin")
                {
                    //如果不是管理员则不能进行管理员的创建操作
                    createuser1.Visible = false;
                    createuser2.Visible = false;
                    userlisttable.Visible = false;
                }
                else
                {
                    GetAdmins();//获取管理员列表
                }
            }
        }

        #region 加载个人信息
        public void LoadPersonInfo(AdminUser user)
        {

        }
        #endregion
        #region 创建用户的按钮
        protected void btncreateuser_Click(object sender, EventArgs e)
        {
            //创建用户的操作
            if (CheckInputForCreate())
            {
                AdminUser user = new AdminUser();
                user.ID = AdminUserBLL.GetMaxId() + 1;//注意获取最大ID后使用时要在ID基础上+1
                user.UserID = textboxUserId.Text;
                user.UserPwd = MD5PWD.EnCode(textboxPwd.Text);
                user.UserCreatedDate = DateTime.Now;
                if (AdminUserBLL.CheckUserId(textboxUserId.Text))
                {
                    if (AdminUserBLL.Add(user) != null)
                    {
                        JqHelper.ResponseScript("alert(\"创建用户成功!\")");
                        GetAdmins();
                    }
                    else
                    {
                        JqHelper.ResponseScript("alert(\"创建失败，请重新尝试！\")");
                    }
                }
                else
                {
                    JqHelper.ResponseScript("alert(\"该用户名已经被使用请更换一个！\")");
                    textboxUserId.Text = "";
                    textboxPwd.Text = "";
                    textboxUserId.Focus();
                }
            }
        }
        #endregion
        #region 创建用户的必填验证
        public bool CheckInputForCreate()
        {
            bool result = false;
            if (string.IsNullOrEmpty(textboxUserId.Text))
            {
                JqHelper.ResponseScript("alert(\"请输入登录用户名\")");
                textboxUserId.Focus();
            }
            else
            {
                if (string.IsNullOrEmpty(textboxPwd.Text))
                {
                    JqHelper.ResponseScript("alert(\"请输入登录密码\")");
                    textboxPwd.Focus();
                }
                else
                {
                    result = true;
                }
            }
            return result;
        }
        #endregion
        #region 获取管理员用户的列表
        public void GetAdmins()
        {
            StringBuilder sb = new StringBuilder();
            IEnumerable<AdminUser> userlist = new AdminUserBLL().GetPagedData(10, 0);
            if (userlist == null)
            {

            }
            else
            {
                foreach (AdminUser item in userlist)
                {
                    sb.Append("<tr id=\"tr" + item.ID + "\"><th>");
                    sb.Append(item.UserName);
                    sb.Append("</th><th>");
                    sb.Append(item.UserID);
                    sb.Append("</th><th>");
                    sb.Append(item.Gender);
                    sb.Append("</th><th>");
                    sb.Append(item.PhoneNum);
                    sb.Append("</th><th>");
                    sb.Append(item.Email);
                    sb.Append("</th><th>");
                    sb.Append(item.Address);
                    sb.Append("</th><th>");
                    sb.Append(item.UserCreatedDate);
                    sb.Append("</th><th>");
                    if (item.UserID.Trim() == "admin")
                    {
                        sb.Append("&nbsp;");
                    }
                    else
                    {
                        sb.Append("<a href=\"#\" onclick=\"opt('edit_" + item.ID + "')\">编辑</a>&nbsp;&nbsp;<a href=\"#\" onclick=\"opt('delete_" + item.ID + "')\">删除</a>");
                    }

                    sb.Append("</th><tr>");


                }
                littablebody.Text = sb.ToString();
            }
        }
        #endregion
        #region 更改密码
        protected void btnChangePwd_Click(object sender, EventArgs e)
        {
            btnChangePwd.Enabled = false;
            //更改密码首先验证原始密码，
            //然后在保存用户的新密码 
            AdminUser user = Session["Users"] as AdminUser;
            if (user != null && AdminUserBLL.CheckAdminUser(user.UserID, MD5PWD.EnCode(oldpwd.Text)))
            {
                //验证旧的密码成功

                if (new AdminUserBLL().SavaNewPwd(user.ID.ToString(), MD5PWD.EnCode(newpwd.Text)) > 0)
                {
                    JqHelper.ResponseScript("alert(\"修改密码成功！\")");
                }
                else
                {
                    JqHelper.ResponseScript("alert(\"修改密码失败！\")");
                }
            }
            btnChangePwd.Enabled = true;
        }
        #endregion
    }
}