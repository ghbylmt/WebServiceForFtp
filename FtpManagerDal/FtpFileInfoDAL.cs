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
    public partial class FtpFileInfoDAL
    {

        public int GetMaxID()
        {
            string sql = "select max(id) from FtpFileInfo";
            object obj = SqlHelper.ExecuteScalar(sql);
            try
            {
                string id = obj == null ? "" : obj.ToString();
                return Convert.ToInt32(id);
            }
            catch (Exception)
            {
                return 0;
                //throw;
            }

        }

        public int Add
            (FtpFileInfo ftpFileInfo)
        {
            string sql = "INSERT INTO FtpFileInfo (ID, FileName, FileAddress, FileMd5, FileLength, CreateDate, Description, DownloadTimes)  VALUES (@ID, @FileName, @FileAddress, @FileMd5, @FileLength, @CreateDate, @Description, @DownloadTimes)";
            SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@ID", ToDBValue(ftpFileInfo.ID)),
						new SqlParameter("@FileName", ToDBValue(ftpFileInfo.FileName)),
						new SqlParameter("@FileAddress", ToDBValue(ftpFileInfo.FileAddress)),
						new SqlParameter("@FileMd5", ToDBValue(ftpFileInfo.FileMd5)),
						new SqlParameter("@FileLength", ToDBValue(ftpFileInfo.FileLength)),
						new SqlParameter("@CreateDate", ToDBValue(ftpFileInfo.CreateDate)),
						new SqlParameter("@Description", ToDBValue(ftpFileInfo.Description)),
						new SqlParameter("@DownloadTimes", ToDBValue(ftpFileInfo.DownloadTimes)),
					};
            return SqlHelper.ExecuteNonQuery(sql, para);

        }

        public int DeleteByID(int iD)
        {
            string sql = "DELETE FtpFileInfo WHERE ID = @ID";

            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@ID", iD)
			};

            return SqlHelper.ExecuteNonQuery(sql, para);
        }


        public int Update(FtpFileInfo ftpFileInfo)
        {
            string sql =
                "UPDATE FtpFileInfo " +
                "SET " +
            " FileName = @FileName"
                + ", FileAddress = @FileAddress"
                + ", FileMd5 = @FileMd5"
                + ", FileLength = @FileLength"
                + ", CreateDate = @CreateDate"
                + ", Description = @Description"
                + ", DownloadTimes = @DownloadTimes"

            + " WHERE ID = @ID";


            SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@ID", ftpFileInfo.ID)
					,new SqlParameter("@FileName", ToDBValue(ftpFileInfo.FileName))
					,new SqlParameter("@FileAddress", ToDBValue(ftpFileInfo.FileAddress))
					,new SqlParameter("@FileMd5", ToDBValue(ftpFileInfo.FileMd5))
					,new SqlParameter("@FileLength", ToDBValue(ftpFileInfo.FileLength))
					,new SqlParameter("@CreateDate", ToDBValue(ftpFileInfo.CreateDate))
					,new SqlParameter("@Description", ToDBValue(ftpFileInfo.Description))
					,new SqlParameter("@DownloadTimes", ToDBValue(ftpFileInfo.DownloadTimes))
			};

            return SqlHelper.ExecuteNonQuery(sql, para);
        }

        public FtpFileInfo GetByID(int iD)
        {
            string sql = "SELECT * FROM FtpFileInfo WHERE ID = @ID";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql, new SqlParameter("@ID", iD)))
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

        public FtpFileInfo ToModel(SqlDataReader reader)
        {
            FtpFileInfo ftpFileInfo = new FtpFileInfo();

            ftpFileInfo.ID = (int)ToModelValue(reader, "ID");
            ftpFileInfo.FileName = (string)ToModelValue(reader, "FileName");
            ftpFileInfo.FileAddress = (string)ToModelValue(reader, "FileAddress");
            ftpFileInfo.FileMd5 = (string)ToModelValue(reader, "FileMd5");
            ftpFileInfo.FileLength = (string)ToModelValue(reader, "FileLength");
            ftpFileInfo.CreateDate = (DateTime?)ToModelValue(reader, "CreateDate");
            ftpFileInfo.Description = (string)ToModelValue(reader, "Description");
            ftpFileInfo.DownloadTimes = (int?)ToModelValue(reader, "DownloadTimes");
            return ftpFileInfo;
        }

        public int GetTotalCount()
        {
            string sql = "SELECT count(*) FROM FtpFileInfo";
            return (int)SqlHelper.ExecuteScalar(sql);
        }

        public IEnumerable<FtpFileInfo> GetPagedData(int minrownum, int maxrownum)
        {
            int pagesize = maxrownum - minrownum;
            string sql = "SELECT TOP " + pagesize + " * FROM FtpFileInfo WHERE (ID NOT IN  (SELECT TOP " + minrownum + " id  FROM AdminUser  ORDER BY id)) ORDER BY ID";
            SqlDataReader reader = SqlHelper.ExecuteDataReader(sql);
            return ToModels(reader);
        }

        public IEnumerable<FtpFileInfo> GetAll()
        {
            string sql = "SELECT * FROM FtpFileInfo";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
            {
                return ToModels(reader);
            }
        }

        protected IEnumerable<FtpFileInfo> ToModels(SqlDataReader reader)
        {
            var list = new List<FtpFileInfo>();
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
