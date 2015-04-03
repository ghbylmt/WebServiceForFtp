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
	public partial class UpdateLogDAL
	{
        public UpdateLog Add
			(UpdateLog updateLog)
		{
				string sql ="INSERT INTO UpdateLog (ID, UpdateTime, CustomrName, CustomID, UpdateResult, RequestFileID, RequestUpdateRoleID)  VALUES (@ID, @UpdateTime, @CustomrName, @CustomID, @UpdateResult, @RequestFileID, @RequestUpdateRoleID)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@ID", ToDBValue(updateLog.ID)),
						new SqlParameter("@UpdateTime", ToDBValue(updateLog.UpdateTime)),
						new SqlParameter("@CustomrName", ToDBValue(updateLog.CustomrName)),
						new SqlParameter("@CustomID", ToDBValue(updateLog.CustomID)),
						new SqlParameter("@UpdateResult", ToDBValue(updateLog.UpdateResult)),
						new SqlParameter("@RequestFileID", ToDBValue(updateLog.RequestFileID)),
						new SqlParameter("@RequestUpdateRoleID", ToDBValue(updateLog.RequestUpdateRoleID)),
					};
				SqlHelper.ExecuteNonQuery(sql, para);
				return updateLog;				
		}

        public int DeleteByID(int iD)
		{
            string sql = "DELETE UpdateLog WHERE ID = @ID";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@ID", iD)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
		
				
        public int Update(UpdateLog updateLog)
        {
            string sql =
                "UPDATE UpdateLog " +
                "SET " +
			" UpdateTime = @UpdateTime" 
                +", CustomrName = @CustomrName" 
                +", CustomID = @CustomID" 
                +", UpdateResult = @UpdateResult" 
                +", RequestFileID = @RequestFileID" 
                +", RequestUpdateRoleID = @RequestUpdateRoleID" 
               
            +" WHERE ID = @ID";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@ID", updateLog.ID)
					,new SqlParameter("@UpdateTime", ToDBValue(updateLog.UpdateTime))
					,new SqlParameter("@CustomrName", ToDBValue(updateLog.CustomrName))
					,new SqlParameter("@CustomID", ToDBValue(updateLog.CustomID))
					,new SqlParameter("@UpdateResult", ToDBValue(updateLog.UpdateResult))
					,new SqlParameter("@RequestFileID", ToDBValue(updateLog.RequestFileID))
					,new SqlParameter("@RequestUpdateRoleID", ToDBValue(updateLog.RequestUpdateRoleID))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public UpdateLog GetByID(int iD)
        {
            string sql = "SELECT * FROM UpdateLog WHERE ID = @ID";
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
		
		public UpdateLog ToModel(SqlDataReader reader)
		{
			UpdateLog updateLog = new UpdateLog();

			updateLog.ID = (int)ToModelValue(reader,"ID");
			updateLog.UpdateTime = (DateTime?)ToModelValue(reader,"UpdateTime");
			updateLog.CustomrName = (string)ToModelValue(reader,"CustomrName");
			updateLog.CustomID = (string)ToModelValue(reader,"CustomID");
			updateLog.UpdateResult = (int?)ToModelValue(reader,"UpdateResult");
			updateLog.RequestFileID = (int?)ToModelValue(reader,"RequestFileID");
			updateLog.RequestUpdateRoleID = (int?)ToModelValue(reader,"RequestUpdateRoleID");
			return updateLog;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM UpdateLog";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public IEnumerable<UpdateLog> GetPagedData(int minrownum,int maxrownum)
		{
			 string sql = "SELECT * FROM UpdateLog where id>=@minrownum and id<=@maxrownum";
             SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@minrownum",  minrownum),
                new SqlParameter("@maxrownum",  maxrownum) 
			};
            SqlDataReader reader = SqlHelper.ExecuteDataReader(sql, para);
            return ToModels(reader); 
		}
		
		public IEnumerable<UpdateLog> GetAll()
		{
			string sql = "SELECT * FROM UpdateLog";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
			{
				return ToModels(reader);			
			}
		}
		
		protected IEnumerable<UpdateLog> ToModels(SqlDataReader reader)
		{
			var list = new List<UpdateLog>();
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
