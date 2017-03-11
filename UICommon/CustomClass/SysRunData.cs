using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Security.Principal;
using System.Text;

namespace DS.MSClient.UICommon
{
	/// <summary>
	/// 系统运行数据
	/// 用于存储程序正在运行的对象和数据
	/// </summary>
	static class SysRunData
	{
		static SysRunData()
		{
			if (!Directory.Exists(TopicRootPath)) Directory.CreateDirectory(TopicRootPath);
			if (!Directory.Exists(PaperRootPath)) Directory.CreateDirectory(PaperRootPath);
			if (!Directory.Exists(TemplateRootPath)) Directory.CreateDirectory(TemplateRootPath);
		}

		#region 属性

		/// <summary>
		/// 应用程序路径
		/// </summary>
		public static string AppPath = Directory.GetCurrentDirectory() + "\\";

		/// <summary>
		/// 文档根路径
		/// </summary>
		public static string TopicRootPath = Directory.GetCurrentDirectory() + "\\Topic\\";

		/// <summary>
		/// 试卷根路径
		/// </summary>
		public static string PaperRootPath = Directory.GetCurrentDirectory() + "\\Paper\\";

		/// <summary>
		/// 模板根路径
		/// </summary>
		public static string TemplateRootPath = Directory.GetCurrentDirectory() + "\\Template\\";

		private static readonly string[] PaperNumStrings = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };

		#endregion

		#region 方法(其他)

		/// <summary>
		/// 判断当前是否管理员权限
		/// </summary>
		/// <returns></returns>
		public static bool IsAdministrator()
		{
			var wi = WindowsIdentity.GetCurrent();
			if (wi == null) return false;
			var pricipal = new WindowsPrincipal(wi);
			return pricipal.IsInRole(WindowsBuiltInRole.Administrator);
		}

		/// <summary>
		/// 提权运行指定文件
		/// </summary>
		/// <param name="fileName"></param>
		public static void RunElevated(string fileName)
		{
			var processInfo = new ProcessStartInfo {Verb = "runas", FileName = fileName};
			try
			{
				Process.Start(processInfo);
			}
			catch (Win32Exception)
			{
				//Do nothing. Probably the user canceled the UAC window
			}
		}

		/// <summary>
		/// 获取系统地址宽度
		/// </summary>
		/// <returns></returns>
		public static string GetAddressWidth()
		{
			var oConn = new ConnectionOptions();
			var oMs = new ManagementScope("\\\\localhost", oConn);
			var oQuery = new ObjectQuery("select AddressWidth from Win32_Processor");
			var oSearcher = new ManagementObjectSearcher(oMs, oQuery);
			var oReturnCollection = oSearcher.Get();
			string addressWidth = null;
			foreach (var oReturn in oReturnCollection)
			{
				addressWidth = oReturn["AddressWidth"].ToString();
			}
			return addressWidth;
		}

		#endregion
	}
}
