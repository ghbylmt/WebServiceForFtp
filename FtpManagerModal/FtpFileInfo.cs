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
	public class FtpFileInfo
	{	
			public int ID
			{
				get;
				set;
			}
			public string FileName
			{
				get;
				set;
			}
			public string FileAddress
			{
				get;
				set;
			}
			public string FileMd5
			{
				get;
				set;
			}
			public string FileLength
			{
				get;
				set;
			}
			public DateTime? CreateDate
			{
				get;
				set;
			}
			public string Description
			{
				get;
				set;
			}
			public int? DownloadTimes
			{
				get;
				set;
			}
	}
}
