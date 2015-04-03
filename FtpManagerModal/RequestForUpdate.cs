//============================================================
//Code By LMT, Source From CodeSmith
// 2015年03月30日
//代码由系统自动生成，非必要请勿更改
//============================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace com.ftp.service.Model
{	
	[Serializable()]
	public class RequestForUpdate
	{	
			public int ID
			{
				get;
				set;
			}
			public string CustomerID
			{
				get;
				set;
			}
			public string CustomerName
			{
				get;
				set;
			}
			public int? RequestUpdateRoleID
			{
				get;
				set;
			}
			public int? RequestUpdateFileID
			{
				get;
				set;
			}
			public int? RequestResult
			{
				get;
				set;
			}
			public DateTime? CreateDate
			{
				get;
				set;
			}
	}
}
