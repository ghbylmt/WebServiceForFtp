using System;
using System.Collections.Generic;
using System.Text;
using com.ftp.service.DAL;
using com.ftp.service.Model;

namespace com.ftp.service.BLL
{

    public partial class FtpFileInfoBLL
    {
        #region 获取数据库中的ID的最大值
        public static int GetMaxID()
        {
            return new FtpFileInfoDAL().GetMaxID();
        }
        #endregion

        public int Add(FtpFileInfo ftpFileInfo)
        {
            return new FtpFileInfoDAL().Add(ftpFileInfo);
        }

        public int DeleteByID(int iD)
        {
            return new FtpFileInfoDAL().DeleteByID(iD);
        }

        public int Update(FtpFileInfo ftpFileInfo)
        {
            return new FtpFileInfoDAL().Update(ftpFileInfo);
        }


        public FtpFileInfo GetByID(int iD)
        {
            return new FtpFileInfoDAL().GetByID(iD);
        }
        public int GetTotalCount()
        {
            return new FtpFileInfoDAL().GetTotalCount();
        }

        public IEnumerable<FtpFileInfo> GetPagedData(int minrownum, int maxrownum)
        {
            return new FtpFileInfoDAL().GetPagedData(minrownum, maxrownum);
        }

        public IEnumerable<FtpFileInfo> GetAll()
        {
            return new FtpFileInfoDAL().GetAll();
        }
    }
}
