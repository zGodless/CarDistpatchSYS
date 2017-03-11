using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using QuickFrame.Common.Compression;

namespace QuickFrame.Common
{
    public class ManagerCommon
    {
        private static readonly BinaryFormatter Transfer = new BinaryFormatter();

        /// <summary>
        /// 将对象转换成byte[]
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="isCompression">是否压缩</param>
        /// <returns></returns>
        public static byte[] SerializeEntity(object obj, bool isCompression)
        {
            if (obj == null) return null;
            var ms = new MemoryStream();
            Transfer.Serialize(ms, obj);
            var buffer = ms.GetBuffer();
            return isCompression ? GZip.Compress(buffer) : buffer;
        }

        /// <summary>
        /// 将对象转换成byte[]，不压缩
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public static byte[] SerializeEntity(object obj)
        {
            return SerializeEntity(obj, false);
        }

        /// <summary>
        /// 将字节数组反序列化为对象
        /// </summary>
        /// <param name="buffer">缓冲区</param>
        /// <param name="isCompression">是否已压缩</param>
        /// <returns></returns>
        public static object DeserializeEntity(byte[] buffer, bool isCompression)
        {
            if (buffer == null || buffer.Length == 0) return null;
            var data = isCompression ? GZip.Decompress(buffer) : buffer;
            var ms = new MemoryStream(data, 0, data.Length, true, true);
            var obj = Transfer.Deserialize(ms);
            return obj;
        }

        /// <summary>
        /// 将byte[]转换成对象，不压缩
        /// </summary>
        /// <param name="buffer">byte[]</param>
        /// <returns></returns>
        public static object DeserializeEntity(byte[] buffer)
        {
            return DeserializeEntity(buffer, false);
        }
    }
}
