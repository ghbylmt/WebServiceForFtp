using System;
using System.Collections.Generic;
using System.Text;
using com.ftp.service.DAL;
using com.ftp.service.Model;

namespace com.ftp.service.BLL
{

    public partial class UpdateRoleBLL
    {
        public UpdateRole Add(UpdateRole updateRole)
        {
            return new UpdateRoleDAL().Add(updateRole);
        }

        public int DeleteByID(int iD)
        {
            return new UpdateRoleDAL().DeleteByID(iD);
        }

		public int Update(UpdateRole updateRole)
        {
            return new UpdateRoleDAL().Update(updateRole);
        }
        

        public UpdateRole GetByID(int iD)
        {
            return new UpdateRoleDAL().GetByID(iD);
        }
		public int GetTotalCount()
		{
			return new UpdateRoleDAL().GetTotalCount();
		}
		
		public IEnumerable<UpdateRole> GetPagedData(int minrownum,int maxrownum)
		{
			return new UpdateRoleDAL().GetPagedData(minrownum,maxrownum);
		}
		
		public IEnumerable<UpdateRole> GetAll()
		{
			return new UpdateRoleDAL().GetAll();
		}
    }
}
