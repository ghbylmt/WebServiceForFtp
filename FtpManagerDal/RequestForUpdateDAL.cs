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
	public partial class RequestForUpdateDAL
	{
        public RequestForUpdate Add
			(RequestForUpdate requestForUpdate)
		{
				string sql ="INSERT INTO RequestForUpdate (ID, CustomerID, CustomerName, RequestUpdateRoleID, RequestUpdateFileID, RequestResult, CreateDate)  VALUES (@ID, @CustomerID, @CustomerName, @RequestUpdateRoleID, @RequestUpdateFileID, @RequestResult, @CreateDate)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@ID", ToDBValue(requestForUpdate.ID)),
						new SqlParameter("@CustomerID", ToDBValue(requestForUpdate.CustomerID)),
						new SqlParameter("@CustomerName", ToDBValue(requestForUpdate.CustomerName)),
						new SqlParameter("@RequestUpdateRoleID", ToDBValue(requestForUpdate.RequestUpdateRoleID)),
						new SqlParameter("@RequestUpdateFileID", ToDBValue(requestForUpdate.RequestUpdateFileID)),
						new SqlParameter("@RequestResult", ToDBValue(requestForUpdate.RequestResult)),
						new SqlParameter("@CreateDate", ToDBValue(requestForUpdate.CreateDate)),
					};
				SqlHelper.ExecuteNonQuery(sql, para);
				return requestForUpdate;				
		}

        public int DeleteByID(int iD)
		{
            string sql = "DELETE RequestForUpdate WHERE ID = @ID";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@ID", iD)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
		
				
        public int Update(RequestForUpdate requestForUpdate)
        {
            string sql =
                "UPDATE RequestForUpdate " +
                "SET " +
			" CustomerID = @CustomerID" 
                +", CustomerName = @CustomerName" 
                +", RequestUpdateRoleID = @RequestUpdateRoleID" 
                +", RequestUpdateFileID = @RequestUpdateFileID" 
                +", RequestResult = @RequestResult" 
                +", CreateDate = @CreateDate" 
               
            +" WHERE ID = @ID";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@ID", requestForUpdate.ID)
					,new SqlParameter("@CustomerID", ToDBValue(requestForUpdate.CustomerID))
					,new SqlParameter("@CustomerName", ToDBValue(requestForUpdate.CustomerName))
					,new SqlParameter("@RequestUpdateRoleID", ToDBValue(requestForUpdate.RequestUpdateRoleID))
					,new SqlParameter("@RequestUpdateFileID", ToDBValue(requestForUpdate.RequestUpdateFileID))
					,new SqlParameter("@RequestResult", ToDBValue(requestForUpdate.RequestResult))
					,new SqlParameter("@CreateDate", ToDBValue(requestForUpdate.CreateDate))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public RequestForUpdate GetByID(int iD)
        {
            string sql = "SELECT * FROM RequestForUpdate WHERE ID = @ID";
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
		
		public RequestForUpdate ToModel(SqlDataReader reader)
		{
			RequestForUpdate requestForUpdate = new RequestForUpdate();

			requestForUpdate.ID = (int)ToModelValue(reader,"ID");
			requestForUpdate.CustomerID = (string)ToModelValue(reader,"CustomerID");
			requestForUpdate.CustomerName = (string)ToModelValue(reader,"CustomerName");
			requestForUpdate.RequestUpdateRoleID = (int?)ToModelValue(reader,"RequestUpdateRoleID");
			requestForUpdate.RequestUpdateFileID = (int?)ToModelValue(reader,"RequestUpdateFileID");
			requestForUpdate.RequestResult = (int?)ToModelValue(reader,"RequestResult");
			requestForUpdate.CreateDate = (DateTime?)ToModelValue(reader,"CreateDate");
			return requestForUpdate;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM RequestForUpdate";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public IEnumerable<RequestForUpdate> GetPagedData(int minrownum,int maxrownum)
		{
			 string sql = "SELECT * FROM RequestForUpdate where id>=@minrownum and id<=@maxrownum";
             SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@minrownum",  minrownum),
                new SqlParameter("@maxrownum",  maxrownum) 
			};
            SqlDataReader reader = SqlHelper.ExecuteDataReader(sql, para);
            return ToModels(reader); 
		}
		
		public IEnumerable<RequestForUpdate> GetAll()
		{
			string sql = "SELECT * FROM RequestForUpdate";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
			{
				return ToModels(reader);			
			}
		}
		
		protected IEnumerable<RequestForUpdate> ToModels(SqlDataReader reader)
		{
			var list = new List<RequestForUpdate>();
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
