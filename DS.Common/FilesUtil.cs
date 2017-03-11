using System;
using System.IO;
using System.Net;
using DS.Common.Exception;

namespace DS.Common
{
    /// <summary>
    /// 模块：
    /// 作用：文件上传、下载操作类
    /// 作者：phq
    /// 日期：2011-3-11
    /// 说明：
    /// </summary>
    public class FilesUtil
    {
        /// <summary>   
        /// WebClient上传文件至服务器，默认不自动改名   
        /// </summary>
        /// <param name="fileNamePath">文件名，全路径格式</param>
        /// <param name="urlString">服务器文件夹路径</param>
        /// <param name="newFileName">上传后的新文件名（不带扩展名）</param>
        public static bool UpLoadFile(string fileNamePath, string urlString, string newFileName)
        {
            var fileName = fileNamePath.Substring(fileNamePath.LastIndexOf("\\", StringComparison.Ordinal) + 1);
            var fileNameExt = fileName.Substring(fileName.LastIndexOf(".", StringComparison.Ordinal) + 1);
            if (urlString.EndsWith("/") == false)
            {
                urlString = urlString + "/";
            }
            var uploadFilePath = urlString + newFileName + "." + fileNameExt;
            var client = new WebClient();
            client.UseDefaultCredentials = true;
            client.Credentials = CredentialCache.DefaultCredentials;
            var fStream = new FileStream(fileNamePath, FileMode.Open, FileAccess.Read);
            var bReader = new BinaryReader(fStream);
            var uploadByte = bReader.ReadBytes(Convert.ToInt32(fStream.Length));
            var uploadStream = client.OpenWrite(uploadFilePath, "PUT");
            try
            {
                if (uploadStream.CanWrite)
                {
                    uploadStream.Write(uploadByte, 0, uploadByte.Length);
                }
            }
            catch (System.Exception ex)
            {
                throw new DsException("上传失败：" + ex.Message);
            }
            finally
            {
                fStream.Close();
                fStream.Dispose();
                uploadStream.Close();
                uploadStream.Dispose();
                client.Dispose();
            }
            return true;
        }
        /// <summary>
        /// 异步上传文件（带进度条）
        /// </summary>
        /// <param name="client"></param>
        /// <param name="fileNamePath">文件名，全路径格式</param>
        /// <param name="urlString">服务器文件夹路径</param>
        /// <param name="newFileName">上传后的新文件名（不带扩展名）</param>
        /// <returns></returns>
        public static bool UploadDataAsync(WebClient client, string fileNamePath, string urlString, string newFileName)
        {
            var fileNameExt = Path.GetExtension(fileNamePath);
            if (urlString.EndsWith("/") == false)
            {
                urlString = urlString + "/";
            }
            var uploadFilePath = urlString + newFileName + fileNameExt;
            client.UseDefaultCredentials = true;
            client.Credentials = CredentialCache.DefaultCredentials;
            var fStream = new FileStream(fileNamePath, FileMode.Open, FileAccess.Read);
            var dataByte = new byte[fStream.Length];
            fStream.Read(dataByte, 0, dataByte.Length);
            fStream.Close();
            var uri = new Uri(uploadFilePath);
            client.UploadDataAsync(uri, "PUT", dataByte, dataByte);
            return true;
        }

        /// <summary>
        /// 异步下载文件
        /// </summary>
        /// <param name="client"></param>
        /// <param name="fileServerUrl">远程服务器文件url</param>
        /// <param name="newFilePath">下载后的文件路径(包含文件名、扩展名)</param>
        /// <returns></returns>
        public static bool DownloadDataAsync(WebClient client, string fileServerUrl, string newFilePath)
        {
            client.UseDefaultCredentials = true;
            client.Credentials = CredentialCache.DefaultCredentials;
            var uri = new Uri (fileServerUrl);
            client.DownloadFileAsync(uri, newFilePath);
            return true;
        }
    }
}
