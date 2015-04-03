using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using com.ftp.service.util;
using com.ftp.service.Model;
using com.ftp.service.BLL;

namespace WebServiceForFtp.AdminManagerment.SubPages
{
    public partial class UpdateRoles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
            GetFileNames();//获取文件信息
        }

        #region 获取文件的列表，加到下拉选项中
        public void GetFileNames()
        {
            string filePath = Server.MapPath("~/UpdataFile");
            string[] fn = Directory.GetFiles(filePath);
            if (fn.Length > 0)
            {
                foreach (string fileDir in fn)
                {
                    FileInfo file = new FileInfo(fileDir);
                    if (File.Exists(file.FullName))
                    {
                        dropFileNames.Items.Add(new ListItem(file.Name, HttpUtility.UrlEncode(file.FullName)));

                    }
                }
                //加载默认数据
                FileInfo filefirst = new FileInfo(fn[0]);
                labFileLength.Text = Math.Round((Convert.ToDouble(filefirst.Length) / 1024 / 1024), 2).ToString() + "MB";
                labFileName.Text = filefirst.Name;
                labFileMd5.Text = FileHelper.GetFileMD5(filefirst.FullName);
            }
        }
        #endregion

        #region 下拉框事件
        protected void dropFileNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fileDir = HttpUtility.UrlDecode(dropFileNames.SelectedItem.Value);
            if (File.Exists(fileDir))
            {
                FileInfo file = new FileInfo(fileDir);
                labFileLength.Text = Math.Round((Convert.ToDouble(file.Length) / 1024 / 1024), 2).ToString() + "MB";
                labFileName.Text = file.Name;
                labFileMd5.Text = FileHelper.GetFileMD5(file.FullName);
            }
        }
        #endregion
        #region 确定按钮
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //将升级规则信息保存到数据库中
            AdminUser user = Session["users"] as AdminUser;
            if (user != null)
            {
                UpdateRole updateRole = new UpdateRole();
                updateRole.CreateDate = DateTime.Now;
                updateRole.CreateUserID = Convert.ToInt32(user.UserID);
                updateRole.Description = textDescription.Text;
                updateRole.OldVersion = textAllowVersion.Text;
                updateRole.NewVersion = textNewToVersion.Text;
                updateRole.UpdateFileID = 0;//在上传更新文件的时候需要将文件的相关信息存储到数据库中
                updateRole.UpdateType = 0;//

            }
            else
            {
                JqHelper.ResponseScript("alert(\"登录超时，请重新登陆！\");window.close();");//未获取到用户信息，则关闭当前的窗口
            }
        }
        #endregion
        #region 取消按钮
        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #region 单选按钮事件
        protected void radioSpecial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioSpecial.SelectedItem.Value == "yes")
            {
                //显示
                JqHelper.ResponseScript("show();");
            }
            else
            {
                //隐藏
                JqHelper.ResponseScript("hide();");
            }
        }
        #endregion
    }
}