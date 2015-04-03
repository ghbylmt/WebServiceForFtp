using System;
using System.Collections.Generic;
using System.Text;
using com.ftp.service.DAL;
using com.ftp.service.Model;

namespace com.ftp.service.BLL
{

    public partial class RequestForUpdateBLL
    {
        public RequestForUpdate Add(RequestForUpdate requestForUpdate)
        {
            return new RequestForUpdateDAL().Add(requestForUpdate);
        }

        public int DeleteByID(int iD)
        {
            return new RequestForUpdateDAL().DeleteByID(iD);
        }

		public int Update(RequestForUpdate requestForUpdate)
        {
            return new RequestForUpdateDAL().Update(requestForUpdate);
        }
        

        public RequestForUpdate GetByID(int iD)
        {
            return new RequestForUpdateDAL().GetByID(iD);
        }
		public int GetTotalCount()
		{
			return new RequestForUpdateDAL().GetTotalCount();
		}
		
		public IEnumerable<RequestForUpdate> GetPagedData(int minrownum,int maxrownum)
		{
			return new RequestForUpdateDAL().GetPagedData(minrownum,maxrownum);
		}
		
		public IEnumerable<RequestForUpdate> GetAll()
		{
			return new RequestForUpdateDAL().GetAll();
		}
    }
}
