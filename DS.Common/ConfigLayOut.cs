using System;
using System.IO;
using QuickFrame.Common.Exception;

namespace DS.Common
{
    public static class ConfigLayOut
    {
	    private const string StylePath = "Style";

	    static ConfigLayOut()
	    {
		    StrPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, StylePath);
	    }

        /// <summary>
        /// 风格文件存放路径
        /// </summary>
		public static string StrPath { get; set; }

        /// <summary>
        /// 判断对应风格文件是否存在
        /// </summary>
        /// <param name="layOutName"></param>
        public static bool LayOutIsAlive(string layOutName)
        {
			if (!Directory.Exists(StrPath))
            {
				Directory.CreateDirectory(StrPath);
            }

            try
            {
				var strPath = Path.Combine(StrPath, layOutName);
				if (File.Exists(strPath))
                {
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                throw new QfException(ex.Message);
            }
            return false;
        }
    }
}
