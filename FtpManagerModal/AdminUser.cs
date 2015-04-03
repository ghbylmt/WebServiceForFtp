//============================================================
//http://net.itcast.cn author:yangzhongke
//============================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace com.ftp.service.Model
{
    [Serializable()]
    public class AdminUser
    {
        public int ID
        {
            get;
            set;
        }
        public string UserID
        {
            get;
            set;
        }
        public string UserPwd
        {
            get;
            set;
        }
        public DateTime? UserCreatedDate
        {
            get;
            set;
        }
        public string UserName
        {
            get;
            set;
        }
        public int? UserStatus
        {
            get;
            set;
        }
        public string Gender
        {
            get;
            set;
        }
        public int? EmployeeId
        {
            get;
            set;
        }
        public string Address
        {
            get;
            set;
        }
        public string PhoneNum
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }
    }
}
