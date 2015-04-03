using System;
using System.Collections.Generic;
using System.Text;
using com.ftp.service.DAL;
using com.ftp.service.Model;

namespace com.ftp.service.BLL
{

    public partial class AdminUserBLL
    {
        /// <summary>
        /// 验证用户登录信息
        /// </summary>
        /// <param name="UserId">用户的登录名</param>
        /// <param name="UserPwd">用户的登录密码</param>
        /// <returns>用户是否存在</returns>
        public static bool CheckAdminUser(string UserId, string UserPwd)
        {
            return new AdminUserDAL().CheckAdminUser(UserId, UserPwd);
        }
        /// <summary>
        /// 获取数据库表中的最大ID值
        /// </summary>
        /// <returns></returns>
        public static int GetMaxId()
        {
            return new AdminUserDAL().GetMaxId();
        }

        /// <summary>
        /// 判断数据库中是否存在该用户ID
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <returns>存在返回true，不存在返回Flase</returns>
        public static bool CheckUserId(string UserId)
        {
            return new AdminUserDAL().CheckUserId(UserId);
        }
        public static AdminUser Add(AdminUser adminUser)
        {
            return new AdminUserDAL().Add(adminUser);
        }
        #region 保存用户更改后的密码
        /// <summary>
        /// 保存用户更改后的密码
        /// </summary>
        /// <param name="ID">编号</param>
        /// <param name="Pwd">新密码</param>
        /// <returns>所影响的行数</returns>
        public int SavaNewPwd(string ID, string Pwd)
        {
            return new AdminUserDAL().SavaNewPwd(ID, Pwd);
        }
        #endregion

        public int Update(AdminUser adminUser)
        {
            return new AdminUserDAL().Update(adminUser);
        }


        public int GetTotalCount()
        {
            return new AdminUserDAL().GetTotalCount();
        }

        public IEnumerable<AdminUser> GetPagedData(int pagesize, int pagenum)
        {
            return new AdminUserDAL().GetPagedData(pagesize, pagenum);
        }

        public IEnumerable<AdminUser> GetAll()
        {
            return new AdminUserDAL().GetAll();
        }
        public AdminUser GetByUserID(string userID)
        {
            return new AdminUserDAL().GetByUserID(userID);
        }
        public int DeleteByUserID(string userID)
        {
            return new AdminUserDAL().DeleteByUserID(userID);
        }
        public AdminUser GetByID(string ID)
        {
            return new AdminUserDAL().GetByID(ID);
        }
    }
}
