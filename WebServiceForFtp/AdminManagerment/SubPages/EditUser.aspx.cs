using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.ftp.service.util;
using com.ftp.service.BLL;
using com.ftp.service.Model;

namespace WebServiceForFtp.AdminManagerment.SubPages
{
    public partial class EditUser : System.Web.UI.Page
    {
        private static string Id = string.Empty;//编号
        private static string userPwd = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
            string itemId = Request.QueryString["id"];
            if (!string.IsNullOrEmpty(itemId))
            {
                //加载用户的基本信息
                LoadInfo(itemId);
                Id = itemId;
            }
        }
        public void LoadInfo(string itemId)
        {
            AdminUser user = new AdminUser();
            user = new AdminUserBLL().GetByUserID(itemId);
            if (user != null)
            {
                if (!string.IsNullOrEmpty(user.Gender))
                {
                    input_gender.Value = user.Gender.Trim();
                }
                if (!string.IsNullOrEmpty(user.Address))
                {
                    input_homeAddress.Value = user.Address.Trim();
                }
                if (!string.IsNullOrEmpty(user.UserID))
                {
                    input_loginName.Value = user.UserID.Trim();
                }
                if (!string.IsNullOrEmpty(user.Email))
                {
                    input_mailAddress.Value = user.Email.Trim();
                }
                if (!string.IsNullOrEmpty(user.UserName))
                {
                    input_name.Value = user.UserName.Trim();
                }
                if (!string.IsNullOrEmpty(user.PhoneNum))
                {
                    input_phoneNum.Value = user.PhoneNum.Trim();
                }
                if (!string.IsNullOrEmpty(user.EmployeeId.ToString()))
                {
                    input_employeeId.Value = user.EmployeeId.ToString().Trim();
                }
                if (!string.IsNullOrEmpty(userPwd))
                {
                    userPwd = user.UserPwd.Trim();
                }
            }
        }
        #region 保存被修改的管理员信息

        protected void btnSave_Click(object sender, EventArgs e)
        {
            AdminUser user = new AdminUser();

            try
            {
                if (!string.IsNullOrEmpty(Id))
                {
                    user.ID = Convert.ToInt32(Id); user.Email = input_mailAddress.Value;
                    try
                    {
                        if (!string.IsNullOrEmpty(input_employeeId.Value))
                        {
                            user.EmployeeId = Convert.ToInt32(input_employeeId.Value);
                        }
                    }
                    catch (Exception)
                    {
                        JqHelper.ResponseScript("alert(\"输入的员工编号无效请重新输入!\")");
                        input_employeeId.Value = "";
                        input_employeeId.Focus();
                        // throw;
                    }
                    user.UserPwd = userPwd;
                    user.Gender = input_gender.Value;
                    user.Address = input_homeAddress.Value;
                    user.PhoneNum = input_phoneNum.Value;
                    user.UserName = input_name.Value;
                    user.UserID = input_loginName.Value;
                    if (new AdminUserBLL().Update(user) > 0)
                    {
                        JqHelper.ResponseScript("alert(\"保存成功！\");window.close()");
                    }
                }
                else
                {
                    JqHelper.ResponseScript("alert(\"保存失败！\")");
                }
            }
            catch (Exception)
            {

            }
        }
        #endregion

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            JqHelper.ResponseScript("window.close();");
        }
    }
}