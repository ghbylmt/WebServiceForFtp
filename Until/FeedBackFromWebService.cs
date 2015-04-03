using System;
using System.Collections.Generic;
using System.Text;

namespace com.ftp.service.util
{
    public class FeedBackFromWebService
    {
        //  4、用户与WebService之间的通信交互的数据格式：
        //{
        //“allowupdate”:”true/false”,
        //”updatefilename”:”软件更新包的名称”,
        //”updatesoftversion”:”更新的软件版本”,
        //“updatefileMd5”:”更新包文件的MD5的值”
        //“FtpUser”:“FTP登录用户名（加密）”
        //“FtpPwd”：“登录用户的密码（加密）”
        // “updatePubDate”:“更新发布的时间”
        //}
        private string _AllowUpdate = string.Empty;
        private string _UpdateFileName = string.Empty;
        private string _UpdateSoftVersion = string.Empty;
        private string _UpdateFileMd5 = string.Empty;
        private string _FileFtpAddress = string.Empty;
        private string _FtpUser = string.Empty;
        private string _FtpPwd = string.Empty;
        private DateTime _UpdatePubDate = DateTime.MaxValue;
        /// <summary>
        /// 是否允许更新
        /// allow or deny
        /// </summary>
        public string AllowUpdate
        {
            get { return _AllowUpdate; }
            set { _AllowUpdate = value; }
        }
        /// <summary>
        /// 升级文件的名称
        /// </summary>
        public string UpdateFileName
        {
            get { return _UpdateFileName; }
            set { _UpdateFileName = value; }
        }
        /// <summary>
        /// 升级软件的版本
        /// </summary>
        public string UpdateSoftVersion
        {
            get { return _UpdateSoftVersion; }
            set { _UpdateSoftVersion = value; }
        }
        /// <summary>
        /// 升级包的MD5的值
        /// </summary>
        public string UpdateFileMd5
        {
            get { return _UpdateFileMd5; }
            set { _UpdateFileMd5 = value; }
        }
        /// <summary>
        /// FTP登录用户名
        /// </summary>
        public string FtpUser
        {
            get { return _FtpUser; }
            set { _FtpUser = value; }
        }
        /// <summary>
        /// FTP登录用户密码
        /// </summary>
        public string FtpPwd
        {
            get { return _FtpPwd; }
            set { _FtpPwd = value; }
        }
        /// <summary>
        /// 该版本发布的时间
        /// </summary>
        public DateTime UpdatePubDate
        {
            get { return _UpdatePubDate; }
            set { _UpdatePubDate = value; }
        }
    }
    /// <summary>
    /// 客户端向WebService发送的软件更新请求信息
    /// </summary>
    public class MessageToWebService
    {
        private string _CurrentSoftVersion = string.Empty;
        private string _RequestID = string.Empty;
        private string _RequestName = string.Empty;
        private string _DogNum = string.Empty;
        private DateTime _RequestDate = DateTime.MaxValue;
        /// <summary>
        /// 当前的软件版本
        /// </summary>
        public string CurrentSoftVersion
        {
            get { return _CurrentSoftVersion; }
            set { _CurrentSoftVersion = value; }
        }
        /// <summary>
        /// 请求用户的ID
        /// </summary>
        public string RequestID
        {
            get { return _RequestID; }
            set { _RequestID = value; }
        }
        /// <summary>
        /// 请求用户的名称
        /// </summary>
        public string RequestName
        {
            get { return _RequestName; }
            set { _RequestName = value; }
        }
        /// <summary>
        /// 请求用户的加密狗编号
        /// </summary>
        public string DogNum
        {
            get { return _DogNum; }
            set { _DogNum = value; }
        }
        /// <summary>
        /// 请求时间
        /// </summary>
        public DateTime RequestDate
        {
            get { return _RequestDate; }
            set { _RequestDate = value; }
        }
    }
}
