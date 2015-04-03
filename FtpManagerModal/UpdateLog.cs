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
	public class UpdateLog
	{	
			public int ID
			{
				get;
				set;
			}
			public DateTime? UpdateTime
			{
				get;
				set;
			}
			public string CustomrName
			{
				get;
				set;
			}
			public string CustomID
			{
				get;
				set;
			}
			public int? UpdateResult
			{
				get;
				set;
			}
			public int? RequestFileID
			{
				get;
				set;
			}
			public int? RequestUpdateRoleID
			{
				get;
				set;
			}
	}
}
