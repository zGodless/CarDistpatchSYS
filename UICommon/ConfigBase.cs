using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DS.MSClient.UICommon
{
    public class ConfigBase
    {

        /// <summary>
        /// 将对象序列化成XML文件
        /// </summary>
        /// <param name="path">文件路径</param>
        public void Serialize(string p_Path)
        {
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(p_Path)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(p_Path));
                }
                var xls = new XmlSerializer(GetType());
                var fs = new FileStream(p_Path, FileMode.Create);
                xls.Serialize(fs, this);
                fs.Close();
                fs = null;
                xls = null;
            }
            catch
            {
                var e = new Exception("ERROR-C00001 无法将对象写入文件");
                throw e;
            }
        }

        /// <summary>
        /// 将XML文件反序列化成对象
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns>返回工程对象</returns>
        public ConfigBase Deserialize(string p_Path)
        {
            try
            {
                var xls = new XmlSerializer(GetType());
                var fs = new FileStream(p_Path, FileMode.Open);
                var pb = (ConfigBase)xls.Deserialize(fs);
                fs.Close();
                fs = null;
                xls = null;
                return pb;
            }
            catch
            {
                var e = new Exception("ERROR-C00002 无法从文件中读取对象");
                throw e;
            }
        }

        /// <summary>
        /// 生成深副本
        /// </summary>
        /// <returns>返回深副本</returns>
        public ConfigBase Copy()
        {
            var xs = new XmlSerializer(GetType());
            var ms = new MemoryStream();
            xs.Serialize(ms, this);
            ms.Position = 0;
            var tep = (ConfigBase)xs.Deserialize(ms);
            return tep;
        }
    }
}
