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
	public class UpdateRole
	{	
			public int ID
			{
				get;
				set;
			}
			public string OldVersion
			{
				get;
				set;
			}
			public string NewVersion
			{
				get;
				set;
			}
			public DateTime? CreateDate
			{
				get;
				set;
			}
			public int? UpdateType
			{
				get;
				set;
			}
			public int? UpdateFileID
			{
				get;
				set;
			}
			public string Description
			{
				get;
				set;
			}
			public int? CreateUserID
			{
				get;
				set;
			}
	}
}
