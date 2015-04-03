//============================================================
// 2015.04.01
// 修改查询分页的方法
// BY LMT
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using com.ftp.service.Model;
using com.ftp.service.util;
using System.Collections.ObjectModel;

namespace com.ftp.service.DAL
{
    public class AdminUserDAL
    {

        #region 验证用户的登录信息
        /// <summary>
        /// 验证用户的登录信息
        /// </summary>
        /// <param name="UserId">用户的登录名称</param>
        /// <param name="UserPwd">用户的登录密码</param>
        /// <returns>用户是否登录成功</returns>
        public bool CheckAdminUser(string UserId, string UserPwd)
        {
            string sql = "select count(*) from AdminUser where UserId=@UserId and UserPwd = @UserPwd";
            SqlParameter[] args = new SqlParameter[]
            {
                new SqlParameter("@UserID", ToDBValue(UserId)),
			    new SqlParameter("@UserPwd", ToDBValue( UserPwd))
            };
            object obj = SqlHelper.ExecuteScalar(sql, args);
            string count = obj == null ? "" : obj.ToString();
            if (count == "0" || count == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region 获取表中的最大ID
        public int GetMaxId()
        {
            try
            {
                string sql = "select max(id) from AdminUser";
                return (int)SqlHelper.ExecuteScalar(sql);
            }
            catch (Exception)
            {
                return 0;
                //throw;
            }
        }
        #endregion

        #region 判断数据库中是否存在该用户ID了？
        /// <summary>
        /// 判断数据库中是否存在该用户ID
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <returns>存在返回true，不存在返回Flase</returns>
        public bool CheckUserId(string UserId)
        {
            string sql = "select count(*) from AdminUser where UserId = @UserId";
            SqlParameter[] args = new SqlParameter[]
            {
                new SqlParameter("@UserID", ToDBValue(UserId))
            };
            object obj = SqlHelper.ExecuteScalar(sql, args);
            string count = obj == null ? "" : obj.ToString();
            if (count == "0" || count == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 保存新密码

        public int SavaNewPwd(string ID, string Pwd)
        {
            string sql = "UPDATE AdminUser SET  UserPwd = @UserPwd  where id = @ID";
            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@ID",ID),
                new SqlParameter("@UserPwd",Pwd)
            };
            return SqlHelper.ExecuteNonQuery(sql, para);
        }
        #endregion

        public AdminUser Add
            (AdminUser adminUser)
        {
            string sql = "INSERT INTO AdminUser (ID, UserID, UserPwd, UserCreatedDate, UserName, UserStatus, Gender, EmployeeId, Address, PhoneNum, Email)  VALUES (@ID, @UserID, @UserPwd, @UserCreatedDate, @UserName, @UserStatus, @Gender, @EmployeeId, @Address, @PhoneNum, @Email)";
            SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@ID", ToDBValue(adminUser.ID)),
						new SqlParameter("@UserID", ToDBValue(adminUser.UserID)),
						new SqlParameter("@UserPwd", ToDBValue(adminUser.UserPwd)),
						new SqlParameter("@UserCreatedDate", ToDBValue(adminUser.UserCreatedDate)),
						new SqlParameter("@UserName", ToDBValue(adminUser.UserName)),
						new SqlParameter("@UserStatus", ToDBValue(adminUser.UserStatus)),
						new SqlParameter("@Gender", ToDBValue(adminUser.Gender)),
						new SqlParameter("@EmployeeId", ToDBValue(adminUser.EmployeeId)),
						new SqlParameter("@Address", ToDBValue(adminUser.Address)),
						new SqlParameter("@PhoneNum", ToDBValue(adminUser.PhoneNum)),
						new SqlParameter("@Email", ToDBValue(adminUser.Email)),
					};
            SqlHelper.ExecuteNonQuery(sql, para);
            return adminUser;
        }

        public int DeleteByUserID(string userID)
        {
            string sql = "DELETE AdminUser WHERE ID = @ID";

            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@ID", userID)
			};

            return SqlHelper.ExecuteNonQuery(sql, para);
        }


        public int Update(AdminUser adminUser)
        {
            string sql =
                "UPDATE AdminUser " +
                "SET " +
            " ID = @ID"
                + ", UserPwd = @UserPwd"
                + ", UserCreatedDate = @UserCreatedDate"
                + ", UserName = @UserName"
                + ", UserStatus = @UserStatus"
                + ", Gender = @Gender"
                + ", EmployeeId = @EmployeeId"
                + ", Address = @Address"
                + ", PhoneNum = @PhoneNum"
                + ", Email = @Email"

            + " WHERE ID = @ID";


            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@UserID", adminUser.UserID)
					,new SqlParameter("@ID", ToDBValue(adminUser.ID))
					,new SqlParameter("@UserPwd", ToDBValue(adminUser.UserPwd))
					,new SqlParameter("@UserCreatedDate", ToDBValue(adminUser.UserCreatedDate))
					,new SqlParameter("@UserName", ToDBValue(adminUser.UserName))
					,new SqlParameter("@UserStatus", ToDBValue(adminUser.UserStatus))
					,new SqlParameter("@Gender", ToDBValue(adminUser.Gender))
					,new SqlParameter("@EmployeeId", ToDBValue(adminUser.EmployeeId))
					,new SqlParameter("@Address", ToDBValue(adminUser.Address))
					,new SqlParameter("@PhoneNum", ToDBValue(adminUser.PhoneNum))
					,new SqlParameter("@Email", ToDBValue(adminUser.Email))
			};

            return SqlHelper.ExecuteNonQuery(sql, para);
        }

        public AdminUser GetByUserID(string userID)
        {
            string sql = "SELECT * FROM AdminUser WHERE ID = @UserID";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql, new SqlParameter("@UserID", userID)))
            {
                if (reader.Read())
                {
                    return ToModel(reader);
                }
                else
                {
                    return null;
                }
            }
        }
        public AdminUser GetByID(string ID)
        {
            string sql = "SELECT * FROM AdminUser WHERE UserID = @ID";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql, new SqlParameter("@ID", ID)))
            {
                if (reader.Read())
                {
                    return ToModel(reader);
                }
                else
                {
                    return null;
                }
            }
        }

        public AdminUser ToModel(SqlDataReader reader)
        {
            AdminUser adminUser = new AdminUser();

            adminUser.ID = (int)ToModelValue(reader, "ID");
            adminUser.UserID = (string)ToModelValue(reader, "UserID");
            adminUser.UserPwd = (string)ToModelValue(reader, "UserPwd");
            adminUser.UserCreatedDate = (DateTime?)ToModelValue(reader, "UserCreatedDate");
            adminUser.UserName = (string)ToModelValue(reader, "UserName");
            adminUser.UserStatus = (int?)ToModelValue(reader, "UserStatus");
            adminUser.Gender = (string)ToModelValue(reader, "Gender");
            adminUser.EmployeeId = (int?)ToModelValue(reader, "EmployeeId");
            adminUser.Address = (string)ToModelValue(reader, "Address");
            adminUser.PhoneNum = (string)ToModelValue(reader, "PhoneNum");
            adminUser.Email = (string)ToModelValue(reader, "Email");
            return adminUser;
        }

        public int GetTotalCount()
        {
            string sql = "SELECT count(*) FROM AdminUser";
            return (int)SqlHelper.ExecuteScalar(sql);
        }

        public IEnumerable<AdminUser> GetPagedData(int pagesize, int pagenum)
        {
            int pagebottom = pagesize * pagenum;
            string sql = "SELECT TOP " + pagesize + " * FROM AdminUser WHERE (ID NOT IN  (SELECT TOP " + pagebottom + " id  FROM AdminUser  ORDER BY id)) ORDER BY ID";
            SqlDataReader reader = SqlHelper.ExecuteDataReader(sql);
            return ToModels(reader);
        }

        public IEnumerable<AdminUser> GetAll()
        {
            string sql = "SELECT * FROM AdminUser";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
            {
                return ToModels(reader);
            }
        }

        protected IEnumerable<AdminUser> ToModels(SqlDataReader reader)
        {
            var list = new List<AdminUser>();
            while (reader.Read())
            {
                list.Add(ToModel(reader));
            }
            return list;
        }

        protected object ToDBValue(object value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }
            else
            {
                return value;
            }
        }

        protected object ToModelValue(SqlDataReader reader, string columnName)
        {
            if (reader.IsDBNull(reader.GetOrdinal(columnName)))
            {
                return null;
            }
            else
            {
                return reader[columnName];
            }
        }
    }
}
