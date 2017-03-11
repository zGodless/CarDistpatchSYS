using System;
using System.Linq;
using System.Windows.Forms;
using DS.MSClient.Properties;
using DS.MSClient.UICommon.MessageBox;
using DevExpress.XtraEditors;
using DS.Common.Exception;
using QuickFrame.Common.Exception;

namespace DS.MSClient.UICommon
{
	static class MsgBox
	{
		#region  初始化

		static MsgBox()
		{
			DefaultInfoTitle = "系统提示";
			DefaultErrorTitle = "系统错误";
			DefaultWarnTitle = "系统警告";
			DefaultQuestTitle = "系统选择提示";
		}

		#endregion

		#region 属性

		/// <summary>
		///     默认信息标题
		/// </summary>
		public static string DefaultInfoTitle { get; set; }

		/// <summary>
		///     默认错误标题
		/// </summary>
		public static string DefaultErrorTitle { get; set; }

		/// <summary>
		///     默认警告标题
		/// </summary>
		public static string DefaultWarnTitle { get; set; }

		/// <summary>
		///     默认选择提示标题
		/// </summary>
		public static string DefaultQuestTitle { get; set; }

		#endregion

		#region 方法

		/// <summary>
		///     消息框，错误提示信息
		/// </summary>
		/// <param name="e">异常信息</param>
		/// <param name="title">标题</param>
		public static void ShowError(Exception e, string title = null)
		{
			try
			{
                Cursor.Current = Cursors.WaitCursor;
				var msg = e.Message;
				if (title == null) title = DefaultErrorTitle;
				if (msg.Contains("检索COM类工厂中CLSID为"))
				{
					msg = "组件未注册!";
				}
				else if (msg.Contains("Server did not recognize the value of HTTP Header SOAPAction"))
				{
					msg = "客户端代理与服务器端服务版本不一致!\r\n请联系技术人员!";
				}
				else if (msg.Contains("There is an error in XML document") || (msg.Contains("XML文档") && msg.Contains("中有错误")))
				{
					msg = "读取XML文档出错!\r\n网络错误，请检查网络或防火墙配置!";
				}
				else if (msg.Contains("Object reference not set to an instance of an object")
					        || msg.Contains("未将对象引用设置到对象的实例"))
				{
					msg = "操作数据出现不允许的空值!";
				}
				else if (msg.Contains("系统找不到指定的文件"))
				{
					msg = "未能加载文件或程序集!";
				}
				else if (msg.Contains("未能找到文件") || msg.Contains("Could not find a part of the path"))
				{
					msg = "未能找到指定的文件!";
				}
				else if (msg.Contains("正由另一进程使用，因此该进程无法访问该文件") ||
					        (msg.Contains("The process cannot access the file") &&
					        msg.Contains("because it is being used by another process")))
				{
					msg = "所访问的文件正由另一个进程使用，\r\n请关闭该文件后再重新尝试";
				}
				else if (msg.Contains("DS.MSClient found response content type of") ||
					        msg.Contains("客户端发现响应内容类型为"))
				{
					msg = "系统服务器可能正在更新，服务暂时中断! 请稍候重试!";
				}
				else if (msg.Contains("The underlying connection was closed"))
				{
					msg = "网络错误，数据库连接中断。";
				}
				else if (msg.Contains("Unable to connection to the remote server"))
				{
					msg = "无法连接到远程服务器";
				}
				else if (msg.Contains("HTTP") && msg.Contains("503"))
				{
					msg = "远程服务器不可用.";
				}
				else if (msg.Contains("The operation has timed out"))
				{
					msg = "网速过慢，网络超时。\r\n请检查网络情况!";
				}
				else if (msg.Contains("Value does not fall within the expected range") || msg.Contains("值不在预期的范围内"))
				{
					msg = "值不在预期的范围内!";
				}
				else if (msg.Contains("StartIndex不能小于0"))
				{
					msg = "字符串处理错误!";
				}
				else if (msg.Contains("上传图片失败"))
				{
					msg = "上传图片失败!";
				}
				else if (msg.Contains("CS1567"))
				{
					msg = "磁盘空间不足或其他某些错误而无法创建文件.";
				}
				else if (msg.Contains("可为空的对象必须具有一个值"))
				{
					msg = "可为空的对象必须具有一个值";
				}
				else if (msg.Contains("尝试读取或写入受保护的内存") || msg.Contains("Attempted to read or write protected memory"))
				{
					msg = "尝试读取或写入受保护的内存失败!";
				}
				else if (msg.Contains("索引超出范围") ||
					        (msg.Contains("was out of range.") && msg.Contains("less than the size of the collection")))
				{
					msg = "索引超出范围.";
				}
				else if (msg.Contains("找不到方法"))
				{
					msg = "系统程序尚有文件未更新到最新版本，导致程序引用指定的方法不存在，请联系技术人员更新！";
				}
                else if (msg.Contains("Cannot delete or update a parent row"))
                {
                    msg = "该数据已有关联，禁止删除";
                }
				else if (e.GetType() == typeof(QfException) || e.GetType() == typeof(DsException))
				{
					msg = e.Message;
					if (e.InnerException != null)
						e = e.InnerException;
				}
				else //如果是系统未定义错误，则原样输出
				{
					using (var mForm = new XtraMessageBoxForm())
					{
						var xe = new XtraMessageBoxArgs(null, msg.Replace("<br/>", "\r\n"), title, new[] {DialogResult.OK},
							Resources.error, 0);
						mForm.ShowMessageBoxDialog(xe);
					}
					return;
				}
				//输出经过处理的，包含详细信息的错误消息
				using (var form = new CustomMsgBox())
				{
					form.msg = msg;
					form.currentException = e;
					form.Text = title;
					form.StartPosition = FormStartPosition.CenterScreen;
					form.ShowDialog();
				}
			}
			catch
			{
				// ignored
			}
            
		}

		/// <summary>
		///     消息框，错误提示信息
		/// </summary>
		/// <param name="txt">文本</param>
		/// <param name="title">标题</param>
		public static void ShowError(string txt, string title = null)
		{
			try
			{
				if (title == null) title = DefaultErrorTitle;
				var mForm = new XtraMessageBoxForm();
				var xe = new XtraMessageBoxArgs(null, txt.Replace("<br/>", "\r\n"), title, new[] {DialogResult.OK},
                    Resources.error, 0);
				mForm.ShowMessageBoxDialog(xe);
			}
			catch
			{
				// ignored
			}
		}

		/// <summary>
		///     提示框，提示信息
		/// </summary>
		/// <param name="txt">文本</param>
		/// <param name="title">标题</param>
		public static void ShowInfo(string txt, string title = null)
		{
			try
			{
				if (title == null) title = DefaultInfoTitle;
				var mForm = new XtraMessageBoxForm();
				var xe = new XtraMessageBoxArgs(null, txt.Replace("<br/>", "\r\n"), title, new[] {DialogResult.OK},
					Resources.InfoIcon, 0);
				mForm.ShowMessageBoxDialog(xe);
			}
			catch
			{
				// ignored
			}
		}

		/// <summary>
		///     提示框(是Yes，否No，取消Cancel)
		/// </summary>
		/// <param name="txt">文本</param>
		/// <param name="title">标题</param>
		public static DialogResult ShowYesNoCancel(string txt, string title = null)
		{
			try
			{
				if (title == null) title = DefaultInfoTitle;
				var mForm = new XtraMessageBoxForm();
				var xe = new XtraMessageBoxArgs(null, txt.Replace("<br/>", "\r\n"), title,
                    new[] { DialogResult.Yes, DialogResult.No, DialogResult.Cancel }, Resources.question, 0);
				return mForm.ShowMessageBoxDialog(xe);
			}
			catch
			{
				return DialogResult.Cancel;
			}
		}

		/// <summary>
		///     提示框(是Yes,否No)
		/// </summary>
		/// <param name="txt">文本</param>
		/// <param name="defaultButton">默认按钮索引</param>
		/// <param name="title">标题</param>
		public static DialogResult ShowYesNo(string txt, int defaultButton = 0, string title = null)
		{
			try
			{
				if (title == null) title = DefaultQuestTitle;
				var mForm = new XtraMessageBoxForm();
				var xe = new XtraMessageBoxArgs(null, txt.Replace("<br/>", "\r\n"), title, new[] {DialogResult.Yes, DialogResult.No},
					Resources.question, defaultButton);
				return mForm.ShowMessageBoxDialog(xe);
			}
			catch
			{
				return DialogResult.No;
			}
		}

		/// <summary>
		///     提示框(确定OK,取消Cancel)
		/// </summary>
		/// <param name="txt">文本</param>
		/// <param name="defaultButton">默认按钮索引</param>
		/// <param name="title">标题</param>
		public static DialogResult ShowOKCancel(string txt, int defaultButton = 0, string title = null)
		{
			try
			{
				if (title == null) title = DefaultQuestTitle;
				var mForm = new XtraMessageBoxForm();
				var xe = new XtraMessageBoxArgs(null, txt.Replace("<br/>", "\r\n"), title,
					new[] {DialogResult.OK, DialogResult.Cancel}, Resources.question, defaultButton);
				return mForm.ShowMessageBoxDialog(xe);
			}
			catch
			{
				return DialogResult.No;
			}
		}

		/// <summary>
		///     提示框，警告信息
		/// </summary>
		/// <param name="txt">文本</param>
		/// <param name="title">标题</param>
		public static void ShowWarn(string txt, string title = null)
		{
			try
			{
				if (title == null) title = DefaultWarnTitle;
				var mForm = new XtraMessageBoxForm();
				var xe = new XtraMessageBoxArgs(null, txt.Replace("<br/>", "\r\n"), title, new[] {DialogResult.OK},
					Resources.warning, 0);
				mForm.ShowMessageBoxDialog(xe);
			}
			catch
			{
				// ignored
			}
		}

		/// <summary>
		///     提示没有权限
		/// </summary>
		/// <param name="title">标题</param>
		public static void ShowNoRight(string title = null)
		{
			try
			{
				if (title == null) title = DefaultWarnTitle;
				var mForm = new XtraMessageBoxForm();
				var xe = new XtraMessageBoxArgs(null, "您没有该权限，请与系统管理员联系！", title, new[] {DialogResult.OK}, Resources.warning, 0);
				mForm.ShowMessageBoxDialog(xe);
			}
			catch
			{
				// ignored
			}
		}

		#endregion
	}
}