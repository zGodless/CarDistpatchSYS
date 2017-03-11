using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DS.Common;
using DS.Data;
using DS.Model;
using DS.MSClient.UICommon;
using QuickFrame.Common.Configuration;
using QuickFrame.Common.Crypt;

namespace DS.MSClient.UIGeneric
{
	public partial class Formlogin : FormBase
	{
		public bool SetLocalTime(DateTime dt)
		{
			var flag = false;

			try
			{
				var st = new SystemTime();
				st.wYear = Convert.ToUInt16(dt.Year);
				st.wMonth = Convert.ToUInt16(dt.Month);
				st.wDay = Convert.ToUInt16(dt.Day);
				st.wHour = Convert.ToUInt16(dt.Hour);
				st.wMinute = Convert.ToUInt16(dt.Minute);
				st.wSecond = Convert.ToUInt16(dt.Second);
				st.wMiliseconds = Convert.ToUInt16(dt.Millisecond);
				st.wDayOfWeek = Convert.ToUInt16(dt.DayOfWeek);
				flag = Win32.SetLocalTime(ref st);
			}
				//由于不是C#本身的函数，很多异常无法捕获
				//函数执行成功则返回true，函数执行失败返回false
				//经常不返回异常，不提示错误，但是函数返回false，给查找错误带来了一定的困难
			catch (Exception)
			{
				// Console.WriteLine("SetLocalTime函数执行异常" + ex1.Message);
			}

			return flag;
		}

		//----------------------------------
		//--------------检测是否管理员身份-----------------\
		/// <summary>
		///     检测是否管理员身份
		/// </summary>
		/// <returns></returns>
		private bool IsAdmin()
		{
			var id = WindowsIdentity.GetCurrent();
			var p = new WindowsPrincipal(id);
			return p.IsInRole(WindowsBuiltInRole.Administrator);
		}

		/// <summary>
		///     以管理员身份重新启动程序
		/// </summary>
		private void RestartElevated()
		{
			var startInfo = new ProcessStartInfo();
			startInfo.UseShellExecute = true;
			startInfo.WorkingDirectory = Environment.CurrentDirectory;
			startInfo.FileName = Application.ExecutablePath;
			startInfo.Verb = "runas";
			try
			{
				var p = Process.Start(startInfo);
			}
			catch (Win32Exception)
			{
				return; //If cancelled, do nothing
			}

			GC.Collect();
			//强制退出，终止当前进程并为基础操作系统提供指定的退出代码。
			Environment.Exit(Environment.ExitCode);
		}

		//-----------修改系统时间为服务器时间---------
		[StructLayout(LayoutKind.Sequential)]
		public struct SystemTime
		{
			public ushort wYear;
			public ushort wMonth;
			public ushort wDayOfWeek;
			public ushort wDay;
			public ushort wHour;
			public ushort wMinute;
			public ushort wSecond;
			public ushort wMiliseconds;
		}

		public class Win32
		{
			[DllImport("Kernel32.dll")]
			public static extern bool SetSystemTime(ref SystemTime sysTime);

			[DllImport("Kernel32.dll")]
			public static extern bool SetLocalTime(ref SystemTime sysTime);

			[DllImport("Kernel32.dll")]
			public static extern void GetSystemTime(ref SystemTime sysTime);

			[DllImport("Kernel32.dll")]
			public static extern void GetLocalTime(ref SystemTime sysTime);
		}

		#region 初始化

		public Formlogin()
		{
			InitializeComponent();
			InitEvent();
		}

		/// <summary>
		///     初始化事件
		/// </summary>
		private void InitEvent()
		{
			Load += Formlogin_Load;
			MouseDown += Login_MouseDown;
			//登陆
			btnLogin.Click += btnLogin_Click;
			//取消，关闭窗体
			btnClose.Click += btnClose_Click;
			//登录、取消标签字体颜色
			btnLogin.MouseEnter += btn_MouseEnter;
			btnLogin.MouseLeave += btn_MouseLeave;
			btnClose.MouseEnter += btn_MouseEnter;
			btnClose.MouseLeave += btn_MouseLeave;
			//回车
			txtPassword.KeyPress += txtPassword_KeyPress;
		}

		#endregion

		#region 属性

		//private WaitDialogForm _waitForm;
		private Employee _checkLoginEmployee;

		#endregion

		#region 无标题窗体拖动

		//窗体移动属性
		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		//发送消息
		[DllImport("user32.dll")]
		public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

		//属性
		public const int WM_SYSCOMMAND = 0x0112;
		public const int SC_MOVE = 0xF010;
		public const int HTCAPTION = 0x0002;

		/// <summary>
		///     窗体移动事件
		/// </summary>
		private void Login_MouseDown(object sender, MouseEventArgs e)
		{
			try
			{
				if (e.Button == MouseButtons.Left) //只有左键才能移动
				{
					ReleaseCapture(); //捕获鼠标
					//发送消息
					SendMessage(Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
				}
			}
			catch
			{
				// ignored
			}
		}

		#endregion

		#region 方法

		/// <summary>
		///     锁定控件
		/// </summary>
		/// <param name="enabled"></param>
		private void LockControl(bool enabled)
		{
			txtUserName.Properties.ReadOnly = enabled;
			txtPassword.Properties.ReadOnly = enabled;
			btnLogin.Enabled = !enabled;
			btnLogin.Enabled = !enabled;
		}

		private void ShowTip(string content, string title = null, bool show = true)
		{
			lblTipTitle.Visible = lblTipContent.Visible = show;
			if (title != null) lblTipTitle.Text = title;
			lblTipContent.Text = content;
		}

		private void ShowTip(bool show = false)
		{
			ShowTip("", null, show);
		}

		/// <summary>
		///     预加载大数据
		/// </summary>
		private void PreDownloadLargeData()
        {
            ClientCache.AddAuto("TrainPlace", () => new TrainPlaceDAO().GetList());
            ClientCache.AddAuto("ApplyWay", () => new ApplyWayDAO().GetList());
            ClientCache.AddAuto("Employee", () => new EmployeeDao().GetList());
            ClientCache.AddAuto("Group", () => new GroupDao().GetList());
            ClientCache.AddAuto("School", () => new SchoolDao().GetAllList());
		}

		/// <summary>
		///     获取程序集文件版本号
		/// </summary>
		/// <returns></returns>
		private string GetAssemblyFileVersion()
		{
			var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyFileVersionAttribute), false);
			if (attributes.Length == 0)
			{
				return "1.0.0.0";
			}
			return ((AssemblyFileVersionAttribute) attributes[0]).Version;
		}

		#endregion

		#region 事件

		/// <summary>
		///     窗体加载
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Formlogin_Load(object sender, EventArgs e)
		{
			try
			{
				txtUserName.Text = Ini.ReadItem("Login", "UserName");
				Program.CurrentAssemblyFileVersion = GetAssemblyFileVersion();
				lblVersion.Text = Program.CurrentAssemblyFileVersion;
				Program.FilesWebServiceUrl = ConfigHelper.GetValue("ServerUrl");
			}
			catch
			{
				// ignored
			}
		}

		/// <summary>
		///     取消，关闭窗体
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnClose_Click(object sender, EventArgs e)
		{
			
			if (!Program.IsReStart)
			{
				Application.Exit();
			}
			else
			{
				DialogResult = DialogResult.Cancel;
			}
		}

		/// <summary>
		///     登陆
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnLogin_Click(object sender, EventArgs e)
		{
			try
			{
                if (new CommonDAO().GetServerTime().ToString("yy-MM-dd") != DateTime.Now.ToString("yy-MM-dd"))
			    {
			        MsgBox.ShowWarn("请设置本地电脑时间！");
                    return;
			    }
				var userName = txtUserName.Text = txtUserName.Text.Trim();
				var password = txtPassword.Text = txtPassword.Text.Trim();
				if (userName == "" || password == "")
				{
					MsgBox.ShowInfo("用户名、密码不能为空!");
					return;
				}
				LockControl(true);
				//_waitForm = new WaitDialogForm("请稍后......", "系统加载中");
				ShowTip("系统正在加载，请稍后……", "系统加载中");
				var i = 5;
				for (var j = 1; j < i - 1; j++)
				{
					Thread.Sleep(10);
					//_waitForm.SetCaption("执行进度（" + j + "/" + i + "）");
					ShowTip("加载进度（" + j + "/" + i + "）");
				}
				if (!ThreadExcuteNoShade(() =>
				{
					var user = new Employee
					{
						EmployeeCode = userName,
						Password = Salt.Encrypt(password)
					};
					_checkLoginEmployee = new EmployeeDao().Exist(user);
					Program.CurrentEmployee = _checkLoginEmployee;
				})) return;

				if (_checkLoginEmployee == null)
				{
					MsgBox.ShowInfo("用户名或密码不正确\r\n\r\n或该账户禁止登陆系统！\r\n\r\n如有疑问请联系系统管理员！");
					//_waitForm.Close();
					ShowTip();
					return;
				}
				Program._employeeRight = new EmployeeRightDao().GetList(_checkLoginEmployee.EmployeeID );
				Program._employeeroleRight = new RoleRightDao().GetRightIDByEmployeeID(_checkLoginEmployee.EmployeeID);
				if (Program._employeeRight == null)
				{
					Program._employeeRight = new List<EmployeeRight>();
				}
				if (Program._employeeroleRight == null)
				{
					Program._employeeroleRight = new List<Right>();
				}
				PreDownloadLargeData();
				Thread.Sleep(10);
				//_waitForm.SetCaption("初始化主界面（5" + "/" + i + "）");
				ShowTip("初始化主界面（5" + "/" + i + "）");
				Program.MFormMain.Init();

				Hide();
				Ini.WriteItem("Login", "UserName", txtUserName.Text.Trim());
				Program.MFormMain.Show();
			}
			catch (Exception ex)
			{
				//_waitForm.Close();
			}
			finally
			{
				ShowTip();
				LockControl(false);
			}
		}

		/// <summary>
		///     鼠标进入改变颜色
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_MouseEnter(object sender, EventArgs e)
		{
			var btn = sender as SimpleButton;
			if (btn == null) return;
			btn.Appearance.ForeColor = Color.Olive;
		}

		/// <summary>
		///     鼠标退出改变颜色
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_MouseLeave(object sender, EventArgs e)
		{
			var btn = sender as SimpleButton;
			if (btn == null) return;
			btn.Appearance.ForeColor = Color.Black;
		}

		/// <summary>
		///     回车
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				btnLogin_Click(sender, e);
			}
		}

		#endregion
	}
}