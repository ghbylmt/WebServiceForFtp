//============================================================
//Code By LMT, Source From CodeSmith
// 2015年03月30日
//代码由系统自动生成，非必要请勿更改
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using com.ftp.service.Model;
using com.ftp.service.util;

namespace com.ftp.service.DAL
{
	public partial class UpdateRoleDAL
	{
        public UpdateRole Add
			(UpdateRole updateRole)
		{
				string sql ="INSERT INTO UpdateRoles (ID, OldVersion, NewVersion, CreateDate, UpdateType, UpdateFileID, Description, CreateUserID)  VALUES (@ID, @OldVersion, @NewVersion, @CreateDate, @UpdateType, @UpdateFileID, @Description, @CreateUserID)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@ID", ToDBValue(updateRole.ID)),
						new SqlParameter("@OldVersion", ToDBValue(updateRole.OldVersion)),
						new SqlParameter("@NewVersion", ToDBValue(updateRole.NewVersion)),
						new SqlParameter("@CreateDate", ToDBValue(updateRole.CreateDate)),
						new SqlParameter("@UpdateType", ToDBValue(updateRole.UpdateType)),
						new SqlParameter("@UpdateFileID", ToDBValue(updateRole.UpdateFileID)),
						new SqlParameter("@Description", ToDBValue(updateRole.Description)),
						new SqlParameter("@CreateUserID", ToDBValue(updateRole.CreateUserID)),
					};
				SqlHelper.ExecuteNonQuery(sql, para);
				return updateRole;				
		}

        public int DeleteByID(int iD)
		{
            string sql = "DELETE UpdateRoles WHERE ID = @ID";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@ID", iD)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
		
				
        public int Update(UpdateRole updateRole)
        {
            string sql =
                "UPDATE UpdateRoles " +
                "SET " +
			" OldVersion = @OldVersion" 
                +", NewVersion = @NewVersion" 
                +", CreateDate = @CreateDate" 
                +", UpdateType = @UpdateType" 
                +", UpdateFileID = @UpdateFileID" 
                +", Description = @Description" 
                +", CreateUserID = @CreateUserID" 
               
            +" WHERE ID = @ID";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@ID", updateRole.ID)
					,new SqlParameter("@OldVersion", ToDBValue(updateRole.OldVersion))
					,new SqlParameter("@NewVersion", ToDBValue(updateRole.NewVersion))
					,new SqlParameter("@CreateDate", ToDBValue(updateRole.CreateDate))
					,new SqlParameter("@UpdateType", ToDBValue(updateRole.UpdateType))
					,new SqlParameter("@UpdateFileID", ToDBValue(updateRole.UpdateFileID))
					,new SqlParameter("@Description", ToDBValue(updateRole.Description))
					,new SqlParameter("@CreateUserID", ToDBValue(updateRole.CreateUserID))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public UpdateRole GetByID(int iD)
        {
            string sql = "SELECT * FROM UpdateRoles WHERE ID = @ID";
            using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql, new SqlParameter("@ID", iD)))
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
		
		public UpdateRole ToModel(SqlDataReader reader)
		{
			UpdateRole updateRole = new UpdateRole();

			updateRole.ID = (int)ToModelValue(reader,"ID");
			updateRole.OldVersion = (string)ToModelValue(reader,"OldVersion");
			updateRole.NewVersion = (string)ToModelValue(reader,"NewVersion");
			updateRole.CreateDate = (DateTime?)ToModelValue(reader,"CreateDate");
			updateRole.UpdateType = (int?)ToModelValue(reader,"UpdateType");
			updateRole.UpdateFileID = (int?)ToModelValue(reader,"UpdateFileID");
			updateRole.Description = (string)ToModelValue(reader,"Description");
			updateRole.CreateUserID = (int?)ToModelValue(reader,"CreateUserID");
			return updateRole;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM UpdateRoles";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public IEnumerable<UpdateRole> GetPagedData(int minrownum,int maxrownum)
		{
			 string sql = "SELECT * FROM UpdateRoles where id>=@minrownum and id<=@maxrownum";
             SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@minrownum",  minrownum),
                new SqlParameter("@maxrownum",  maxrownum) 
			};
            SqlDataReader reader = SqlHelper.ExecuteDataReader(sql, para);
            return ToModels(reader); 
		}
		
		public IEnumerable<UpdateRole> GetAll()
		{
			string sql = "SELECT * FROM UpdateRoles";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
			{
				return ToModels(reader);			
			}
		}
		
		protected IEnumerable<UpdateRole> ToModels(SqlDataReader reader)
		{
			var list = new List<UpdateRole>();
			while(reader.Read())
			{
				list.Add(ToModel(reader));
			}	
			return list;
		}		
		
		protected object ToDBValue(object value)
		{
			if(value==null)
			{
				return DBNull.Value;
			}
			else
			{
				return value;
			}
		}
		
		protected object ToModelValue(SqlDataReader reader,string columnName)
		{
			if(reader.IsDBNull(reader.GetOrdinal(columnName)))
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
