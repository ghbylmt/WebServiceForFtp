using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Configuration;


namespace WebServiceForFtp
{
    /// <summary>
    /// 升级文件
    /// </summary>
    public class UpdateFileInfo
    {
        private string _FileName = string.Empty;//文件名称
        private long _FileLength = 0;//文件的长度
        private long _OffSet = 0;//断点下载的偏移量
        private string _FileMd5 = string.Empty;//文件的MD5
        private string _FileDir = string.Empty;//文件的服务器端路径（FTP路径）

        /// <summary>
        /// 文件名称
        /// </summary> 
        public string FileName
        {
            get { return _FileName; }
            set { _FileName = value; }
        }
        /// <summary>
        /// 文件的大小
        /// </summary>
        public long FileLength
        {
            get { return _FileLength; }
            set { _FileLength = value; }
        }
        /// <summary>
        /// 断点下载的文件偏移量
        /// </summary>
        public long OffSet
        {
            get { return _OffSet; }
            set { _OffSet = value; }
        }
        /// <summary>
        /// 文件的MD5值
        /// </summary>
        public string FileMd5
        {
            get { return _FileMd5; }
            set { _FileMd5 = value; }
        }
        /// <summary>
        /// 文件的路径
        /// </summary>
        public string FileDir
        {
            get { return _FileDir; }
            set { _FileDir = value; }
        }
        /// <summary>
        /// 获取本地升级文件列表
        /// </summary>
        /// <returns></returns>
        public static List<UpdateFileInfo> GetUpdateFileInfo()
        {
            List<UpdateFileInfo> listUpdateFileInfo = new List<UpdateFileInfo>();
            string fileDir = System.Configuration.ConfigurationManager.AppSettings["UpdateFilesDir"];
            string[] fileNames = Directory.GetFiles(fileDir);
            if (fileNames.Length > 0)
            {
                for (int i = 0; i < fileNames.Length; i++)
                {
                    UpdateFileInfo updateFileInfoBuff = new UpdateFileInfo();
                    FileInfo fileInfo = new FileInfo(fileNames[i]);
                    if (File.Exists(fileInfo.FullName))
                    {
                        updateFileInfoBuff.FileName = fileInfo.Name;
                        updateFileInfoBuff.FileLength = fileInfo.Length;
                        updateFileInfoBuff.OffSet = 0;
                        updateFileInfoBuff.FileMd5 = FileOpteration.GetFileMD5(fileInfo.FullName);
                        updateFileInfoBuff.FileDir = fileInfo.FullName;
                        listUpdateFileInfo.Add(updateFileInfoBuff);
                    }
                }
            }
            return listUpdateFileInfo;
        }

    }
}