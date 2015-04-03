using System;
using System.Collections.Generic;
using System.Web;

namespace WebServiceForFtp
{
    public class FtpUserAndPwd
    {
        //FTP登录用户类
        private string _FtpUser = string.Empty;//FTP登录用户名
        private string _FtpPWD = string.Empty;//FTP登录用户密码
        public string FtpUser
        {
            get { return _FtpUser; }
            set { _FtpUser = value; }
        }
        public string FtpPwd
        {
            get { return _FtpPWD; }
            set { _FtpPWD = value; }
        }
    }
}