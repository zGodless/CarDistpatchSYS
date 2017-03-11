using System;
using System.IO;
using System.IO.Compression;
using QuickFrame.Common.Exception;

namespace QuickFrame.Common.Compression
{
    /// <summary>
    /// GZip 压缩
    /// </summary>
    public static class GZip
    {
		/// <summary>
		/// 压缩
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
        public static byte[] Compress(byte[] data)
        {
            var stream = new MemoryStream();
            var gZipStream = new GZipStream(stream, CompressionMode.Compress);
            gZipStream.Write(data, 0, data.Length);
            gZipStream.Close();
            return stream.ToArray();
        }

		/// <summary>
		/// 解压
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
        public static byte[] Decompress(byte[] data)
        {
            var stream = new MemoryStream();
            var gZipStream = new GZipStream(new MemoryStream(data), CompressionMode.Decompress);
            var bytes = new byte[40960];
            int n;
            while ((n = gZipStream.Read(bytes, 0, bytes.Length)) != 0)
            {
                stream.Write(bytes, 0, n);
            }
            gZipStream.Close();
            return stream.ToArray();
        }

        /// <summary>
        /// 将指定的字节数组压缩,并写入到目标文件
        /// </summary>
        /// <param name="buffer">指定的源字节数组</param>
        /// <param name="destinationFile">指定的目标文件</param>
        public static void CompressData(byte[] buffer, string destinationFile)
        {
            FileStream destinationStream = null;
            GZipStream compressedStream = null;
            try
            {
                destinationStream = new FileStream(destinationFile, FileMode.OpenOrCreate, FileAccess.Write);

                compressedStream = new GZipStream(destinationStream, CompressionMode.Compress, true);

                compressedStream.Write(buffer, 0, buffer.Length);
            }
            catch (System.Exception ex)
            {
                throw new QfException(String.Format("ERROR-CC00006 缓存错误:压缩数据写入文件{0}时发生错误", destinationFile), ex);
            }
            finally
            {
                if (null != compressedStream)
                {
                    compressedStream.Close();
                    compressedStream.Dispose();
                }

                if (null != destinationStream)
                {
                    destinationStream.Close();
                }
            }
        }

        /// <summary>
        /// 将指定源文件压缩,并写入到目标文件
        /// </summary>
        /// <param name="sourceFile">指定的源文件</param>
        /// <param name="destinationFile">指定的目标文件</param>
        public static void CompressFile(string sourceFile, string destinationFile)
        {
            if (false == File.Exists(sourceFile))
            {
                throw new FileNotFoundException(String.Format("找不到指定的文件{0}", sourceFile));
            }
	        FileStream sourceStream = null;
            try
            {
                sourceStream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read, FileShare.Read);

                var buffer = new byte[sourceStream.Length];
                var checkCounter = sourceStream.Read(buffer, 0, buffer.Length);

                if (checkCounter != buffer.Length)
                {
                    throw new ApplicationException(String.Format("读取指定文件{0}出错", sourceFile));
                }

                CompressData(buffer, destinationFile);
            }
            catch (System.Exception ex)
            {
                throw new QfException(String.Format("ERROR-CC00006 缓存错误:压缩文件{0}时发生错误", sourceFile), ex);
            }
            finally
            {
                if (null != sourceStream)
                {
                    sourceStream.Close();
                }
            }
        }

        /// <summary>
        /// 将指定的文件解压,返回解压后的数据
        /// </summary>
        /// <param name="sourceFile">指定的源文件</param>
        /// <returns>解压后得到的数据</returns>
        public static byte[] DecompressData(string sourceFile)
        {
            if (false == File.Exists(sourceFile))
            {
                throw new FileNotFoundException(String.Format("找不到指定的文件{0}", sourceFile));
            }
            FileStream sourceStream = null;
            GZipStream decompressedStream = null;
	        try
            {
                sourceStream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read, FileShare.Read);
                decompressedStream = new GZipStream(sourceStream, CompressionMode.Decompress, true);
                var quartetBuffer = new byte[4];
                var position = sourceStream.Length - 4;
                sourceStream.Position = position;
                sourceStream.Read(quartetBuffer, 0, 4);
                var checkLength = BitConverter.ToInt32(quartetBuffer, 0);

	            var data = checkLength <= sourceStream.Length ? new byte[Int16.MaxValue] : new byte[checkLength + 100];

                var buffer = new byte[100];

                sourceStream.Position = 0;
                var offset = 0;
                var total = 0;

                while (true)
                {
                    var bytesRead = decompressedStream.Read(buffer, 0, 100);
                    if (bytesRead == 0)
                    {
                        break;
                    }
	                buffer.CopyTo(data, offset);

	                offset += bytesRead;
                    total += bytesRead;
                }

                var actualdata = new byte[total];
                for (var i = 0; i < total; i++)
                {
                    actualdata[i] = data[i];
                }
                return actualdata;
            }
            catch (System.Exception ex)
            {
                throw new QfException(String.Format("ERROR-CC00006 缓存错误:从文件{0}解压数据时发生错误", sourceFile), ex);
            }
            finally
            {
                if (sourceStream != null)
                {
                    sourceStream.Close();
                }
                if (decompressedStream != null)
                {
                    decompressedStream.Close();
                }
            }
        }

        /// <summary>
        /// 将指定的文件解压,并写入到目标文件
        /// </summary>
        /// <param name="sourceFile">指定的源文件</param>
        /// <param name="destinationFile">指定的目标文件</param>
        public static void DecompressFile(string sourceFile, string destinationFile)
        {
            var data = DecompressData(sourceFile);
            FileStream destinationStream = null;
            try
            {
                destinationStream = new FileStream(destinationFile, FileMode.Create);

                destinationStream.Write(data, 0, data.Length);

                destinationStream.Flush();
            }
            catch (System.Exception ex)
            {
                throw new QfException(String.Format("ERROR-CC00006 缓存错误:解压数据到文件{0}时发生错误", destinationFile), ex);
            }
            finally
            {
                if (destinationStream != null)
                {
                    destinationStream.Close();
                }
            }
        }
    }
}
