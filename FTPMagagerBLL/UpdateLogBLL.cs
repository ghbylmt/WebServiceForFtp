using System;
using System.Collections.Generic;
using System.Text;
using com.ftp.service.DAL;
using com.ftp.service.Model;

namespace com.ftp.service.BLL
{

    public partial class UpdateLogBLL
    {
        public UpdateLog Add(UpdateLog updateLog)
        {
            return new UpdateLogDAL().Add(updateLog);
        }

        public int DeleteByID(int iD)
        {
            return new UpdateLogDAL().DeleteByID(iD);
        }

		public int Update(UpdateLog updateLog)
        {
            return new UpdateLogDAL().Update(updateLog);
        }
        

        public UpdateLog GetByID(int iD)
        {
            return new UpdateLogDAL().GetByID(iD);
        }
		public int GetTotalCount()
		{
			return new UpdateLogDAL().GetTotalCount();
		}
		
		public IEnumerable<UpdateLog> GetPagedData(int minrownum,int maxrownum)
		{
			return new UpdateLogDAL().GetPagedData(minrownum,maxrownum);
		}
		
		public IEnumerable<UpdateLog> GetAll()
		{
			return new UpdateLogDAL().GetAll();
		}
    }
}
