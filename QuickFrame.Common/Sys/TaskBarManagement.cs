using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace QuickFrame.Common.Sys
{
	/// <summary>
	/// 任务栏管理
	/// </summary>
	public class TaskBarManagement
	{
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		static extern IntPtr FindWindow(string strClassName, string strWindowName);

		[DllImport("shell32.dll")]
		static extern UInt32 SHAppBarMessage(UInt32 dwMessage, ref APPBARDATA pData);

		[DllImport("user32.dll")]
		static extern int ShowWindow(IntPtr hwnd, int nCmdShow);

		public enum AppBarMessages
		{
			New =
			0x00000000,
			Remove =
			0x00000001,
			QueryPos =
			0x00000002,
			SetPos =
			0x00000003,
			GetState =
			0x00000004,
			GetTaskBarPos =
			0x00000005,
			Activate =
			0x00000006,
			GetAutoHideBar =
			0x00000007,
			SetAutoHideBar =
			0x00000008,
			WindowPosChanged =
			0x00000009,
			SetState =
			0x0000000a
		}

		public enum ShowWindowCommands
		{
			Hide = 0,
			Show = 5,
			Restore = 9
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct APPBARDATA
		{
			public UInt32 cbSize;
			public IntPtr hWnd;
			public UInt32 uCallbackMessage;
			public UInt32 uEdge;
			public Rectangle rc;
			public Int32 lParam;
		}

		public enum AppBarStates
		{
			AutoHide =
			0x00000001,
			AlwaysOnTop =
			0x00000002
		}

		/// <summary>
		/// Set the Taskbar State option
		/// </summary>
		/// <param name="option">AppBarState to activate</param>
		public static void SetTaskbarState(AppBarStates option)
		{
			APPBARDATA msgData = new APPBARDATA();
			msgData.cbSize = (UInt32)Marshal.SizeOf(msgData);
			msgData.hWnd = FindWindow("System_TrayWnd", null);
			msgData.lParam = (Int32)(option);
			SHAppBarMessage((UInt32)AppBarMessages.SetState, ref msgData);
		}

		/// <summary>
		/// Gets the current Taskbar state
		/// </summary>
		/// <returns>current Taskbar state</returns>
		public static AppBarStates GetTaskbarState()
		{
			APPBARDATA msgData = new APPBARDATA();
			msgData.cbSize = (UInt32)Marshal.SizeOf(msgData);
			msgData.hWnd = FindWindow("System_TrayWnd", null);
			return (AppBarStates)SHAppBarMessage((UInt32)AppBarMessages.GetState, ref msgData);
		}

		public static void ShowTaskBar()
		{
			ShowWindow(FindWindow("Shell_TrayWnd", null), (Int32)ShowWindowCommands.Show);
		}

		public static void HideTaskBar()
		{
			ShowWindow(FindWindow("Shell_TrayWnd", null), (Int32)ShowWindowCommands.Hide);
		}
	}
}
