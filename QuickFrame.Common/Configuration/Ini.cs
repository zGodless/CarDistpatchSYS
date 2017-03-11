using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace QuickFrame.Common.Configuration
{
	/// <summary>
	/// INI 配置文件操作
	/// </summary>
	public class Ini
	{
		#region DLL引用

		/// <summary>
		/// 读配置字符串
		/// </summary>
		/// <param name="section"></param>
		/// <param name="key"></param>
		/// <param name="def"></param>
		/// <param name="retVal"></param>
		/// <param name="size"></param>
		/// <param name="filePath"></param>
		/// <returns></returns>
		[DllImport("kernel32")]
		private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
		
		/// <summary>
		/// 写配置字符串
		/// </summary>
		/// <param name="section"></param>
		/// <param name="key"></param>
		/// <param name="val"></param>
		/// <param name="filePath"></param>
		/// <returns></returns>
		[DllImport("kernel32")]
		private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

		#endregion

		#region 初始化

		static Ini()
		{
			DefaultIniPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.ini");
		}

		/// <summary>
		/// 初始化，配置文件为config.ini
		/// </summary>
		public Ini()
		{
			IniPath = DefaultIniPath;
		}

		/// <summary>
		/// 初始化，指定配置文件
		/// </summary>
		public Ini(string filename)
		{
			IniPath = filename.Contains(Path.DirectorySeparatorChar)
				? filename
				: Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);
		}

		#endregion

		#region 属性

		/// <summary>
		/// INI配置文件路径
		/// </summary>
		public string IniPath { get; private set; }

		/// <summary>
		/// 默认INI配置文件路径
		/// </summary>
		public static readonly string DefaultIniPath;

		#endregion

		#region 方法

		/// <summary>
		/// 获取INI项
		/// </summary>
		/// <param name="section">节</param>
		/// <param name="key">键</param>
		/// <returns>值</returns>
		public string GetItem(string section, string key)
		{
			try
			{
				if (File.Exists(IniPath) == false)
				{
					return string.Empty;
				}
				var sb = new StringBuilder(255);
				GetPrivateProfileString(section, key, string.Empty, sb, 255, IniPath);
				return sb.ToString();
			}
			catch
			{
				return string.Empty;
			}
		}

		/// <summary>
		/// 设置INI项
		/// </summary>
		/// <param name="section">节</param>
		/// <param name="key">键</param>
		/// <param name="value">值</param>
		public void SetItem(string section, string key, string value)
		{
			try
			{
				WritePrivateProfileString(section, key, value, IniPath);
			}
			catch
			{
				// ignored
			}
		}

		#endregion

		#region 方法(静态)

		/// <summary>
		/// 读取INI项
		/// </summary>
		/// <param name="section">节</param>
		/// <param name="key">键</param>
		/// <returns>值</returns>
		public static string ReadItem(string section, string key)
		{
			try
			{
				if (File.Exists(DefaultIniPath) == false)
				{
					return string.Empty;
				}
				var sb = new StringBuilder(255);
				GetPrivateProfileString(section, key, string.Empty, sb, 255, DefaultIniPath);
				return sb.ToString();
			}
			catch
			{
				return string.Empty;
			}
		}

		/// <summary>
		/// 设置INI项
		/// </summary>
		/// <param name="section">节</param>
		/// <param name="key">键</param>
		/// <param name="value">值</param>
		public static void WriteItem(string section, string key, string value)
		{
			try
			{
				WritePrivateProfileString(section, key, value, DefaultIniPath);
			}
			catch
			{
				// ignored
			}
		}

		#endregion
	}
}
