using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace QuickFrame.Model
{
    /// <summary>
    /// 上传实例
    /// </summary>
    [Serializable]
    public class UploadInstance
    {

        #region 初始化

        public UploadInstance()
            : this("", null)
        {
        }

        /// <summary>
        /// 初始化上传实例
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="fileName">文件名</param>
        public UploadInstance(string path = "", string fileName = null)
        {
            _guid = System.Guid.NewGuid().ToString();
            if (fileName == null)
            {
                _fileName = _guid;
                _subfix = ".bin";
            }
            else
            {
                _fileName = Path.GetFileNameWithoutExtension(fileName);
                _subfix = Path.GetExtension(fileName);
            }
            _uploadTime = DateTime.Now;
            _fileLength = 0;
            _offset = 0;
            _serverPath = path;
        }

        /// <summary>
        /// 初始化继续上传实例
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="fileName">文件名</param>
        /// <param name="fileLength">文件大小</param>
        public UploadInstance(string path, string fileName, long fileLength)
        {
            var fullPath = Path.Combine(path, fileName);
            if (!File.Exists(fullPath)) return;
            _fileName = Path.GetFileNameWithoutExtension(_fileName);
            _subfix = Path.GetExtension(_fileName);
            _uploadTime = DateTime.Now;
            _fileLength = fileLength;
            var fileInfo = new FileInfo(fullPath);
            _offset = fileInfo.Length;
            _serverPath = path;

        }

        #endregion 初始化


        #region 字段

        private string _guid;
        private string _fileName;
        private string _subfix;
        private readonly DateTime _uploadTime;
        private long _fileLength;
        private long _offset;
        private string _serverPath;
        private long _userId;

        #endregion 字段


        #region 属性

        /// <summary>
        /// GUID
        /// </summary>
        public string Guid
        {
            get { return _guid; }
        }

        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        /// <summary>
        /// 后缀
        /// </summary>
        public string Subfix
        {
            get { return _subfix; }
            set { _subfix = value; }
        }

        /// <summary>
        /// 上传时间
        /// </summary>
        public DateTime UploadTime
        {
            get { return _uploadTime; }
        }

        /// <summary>
        /// 文件大小
        /// </summary>
        public long FileLength
        {
            get { return _fileLength; }
            set { _fileLength = value; }
        }

        /// <summary>
        /// 偏移量
        /// </summary>
        public long Offset
        {
            get { return _offset; }
            set { _offset = value; }
        }

        /// <summary>
        /// 服务器路径
        /// </summary>
        public string ServerPath
        {
            get { return _serverPath; }
            set { _serverPath = value; }
        }

        /// <summary>
        /// 用户ID
        /// </summary>
        public long UserID
        {
            get { return _userId; }
            set { _userId = value; }
        }

        /// <summary>
        /// 完整服务器路径
        /// </summary>
        public string FullServerPath
        {
            get
            {
                if (_fileName != string.Empty && _serverPath != string.Empty)
                {
                    return Path.Combine(_serverPath, _fileName + _subfix);
                }
                return string.Empty;
            }
        }

        /// <summary>
        /// 完整文件名(包括后缀)
        /// </summary>
        public string FullFileName
        {
            get
            {
                if (_fileName != string.Empty)
                {
                    return _fileName + _subfix;
                }
                return string.Empty;
            }
        }

        #endregion 属性


        #region 方法

        /// <summary>
        /// 创建文件
        /// </summary>
        public void CreateFile()
        {
            var fullPath = FullServerPath;
            if (File.Exists(fullPath))
            {
                try
                {
                    File.Delete(fullPath);
                }
                catch { }
            }
            File.Create(fullPath).Close();
        }

        /// <summary>
        /// 上传数据
        /// </summary>
        /// <param name="data">数据包</param>
        /// <param name="offset">偏移量</param>
        /// <param name="dataSize">数据大小</param>
        /// <returns></returns>
        public bool UploadData(byte[] data, long offset, int dataSize)
        {
            var fullPath = FullServerPath;
            if (!File.Exists(fullPath)) return false;
            var fileOffset = new FileInfo(fullPath).Length;
            if (fileOffset != offset) return false;
            var fileStream = new FileStream(fullPath, FileMode.Append);
            fileStream.Write(data, 0, dataSize);
            fileStream.Close();
            return true;
        }

        /// <summary>
        /// 中止上传
        /// </summary>
        public void AbortUpload()
        {
            try
            {
                File.Delete(FullServerPath);
            }
            catch { }
        }

        #endregion 方法
    }
}
