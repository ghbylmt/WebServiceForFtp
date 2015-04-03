using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using com.ftp.service.util;
using com.ftp.service.BLL;
using com.ftp.service.Model;

namespace WebServiceForFtp.AdminManagerment
{
    public partial class UpdateFilesPub : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
            LoadFilesInfo();
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fileUpload.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(fileUpload.FileName);
                    fileUpload.SaveAs(Server.MapPath("~/UpdataFile/") + filename);
                    FileInfo fileInfo = new FileInfo(Server.MapPath("~/UpdataFile/") + filename);
                    if (File.Exists(fileInfo.FullName))
                    {
                        FtpFileInfo updatefile = new FtpFileInfo();
                        updatefile.FileAddress = "ftp://192.168.167.81/" + fileInfo.Name;//ftp的服务器的地址，需要重新进行拼接
                        updatefile.FileLength = fileInfo.Length.ToString();
                        updatefile.FileMd5 = FileHelper.GetFileMD5(fileInfo.FullName);
                        updatefile.FileName = fileInfo.Name;
                        updatefile.CreateDate = DateTime.Now;
                        updatefile.Description = textDecription.Text;//描述信息
                        updatefile.DownloadTimes = 0;
                        updatefile.ID = FtpFileInfoBLL.GetMaxID() + 1;
                        if (new FtpFileInfoBLL().Add(updatefile) > 0)
                        {
                            JqHelper.ResponseScript("alert(\"上传文件成功！\")");
                        }
                        else
                        {
                            JqHelper.ResponseScript("alert(\"保存到数据库失败，请重新尝试！\")");
                        }
                    }
                    LoadFilesInfo();
                    //上传成功之后需要将文件信息保存到数据库
                }
                catch (Exception ex)
                {
                    JqHelper.ResponseScript("alert(\"上传失败！\")");
                }
            }
            else
            {
                JqHelper.ResponseScript("alert(\"请选择需要上传的文件！\")");
                fileUpload.Focus();
            }
        }
        #region 加载升级包文件信息
        public void LoadFilesInfo()
        {
            string filePath = Server.MapPath("~/UpdataFile");
            //string[] fn = Directory.GetFiles(filePath);
            //if (fn.Length > 0)
            //{
            //    StringBuilder sb = new StringBuilder();
            //    foreach (string fileName in fn)
            //    {
            //        if (File.Exists(fileName))
            //        {
            //            FileInfo file = new FileInfo(fileName);
            //            sb.Append("<tr id=\"tr" + HttpUtility.UrlEncode(file.FullName) + "\"><th>");
            //            sb.Append(file.Name);
            //            sb.Append("</th><th>");
            //            sb.Append(Math.Round((Convert.ToDouble(file.Length) / 1024 / 1024), 2).ToString() + "MB");
            //            sb.Append("</th><th>");
            //            sb.Append(FileHelper.GetFileMD5(fileName));
            //            sb.Append("</th><th>");
            //            sb.Append(file.CreationTime);
            //            sb.Append("</th><th>");
            //            sb.Append("<a href=\"#\" onclick=deleteFile('" + HttpUtility.UrlEncode(file.FullName) + "')>删除</a>");
            //            sb.Append("</th><tr>");
            //        }

            //    }
            //    littablebody.Text = sb.ToString();

            // }
            IEnumerable<FtpFileInfo> ftpFiles = new FtpFileInfoBLL().GetPagedData(0, 100);
            if (ftpFiles != null)
            {
                StringBuilder sb = new StringBuilder();
                foreach (FtpFileInfo item in ftpFiles)
                {
                    sb.Append("<tr id=\"tr" + item.ID + "\"><th>");
                    sb.Append(item.FileName);
                    sb.Append("</th><th>");
                    sb.Append(Math.Round((Convert.ToDouble(item.FileLength) / 1024 / 1024), 2).ToString() + "MB");
                    sb.Append("</th><th>");
                    sb.Append(item.FileMd5);
                    sb.Append("</th><th>");
                    sb.Append(item.CreateDate.ToString());
                    sb.Append("</th><th>");
                    sb.Append("<a href=\"#\" onclick=deleteFile('" + item.ID + "')>删除</a>");
                    sb.Append("</th><tr>");
                }
                littablebody.Text = sb.ToString();
            }
        }
        #endregion
    }
}