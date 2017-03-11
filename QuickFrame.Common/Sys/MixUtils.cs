using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace QuickFrame.Common.Sys
{
	public class MixUtils
	{
		/// <summary>
		/// 蜂鸣
		/// </summary>
		/// <param name="dwFreq">频率高低</param>
		/// <param name="dwDuration">时长（毫秒）</param>
		/// <returns></returns>
		[DllImport("kernel32.dll", EntryPoint = "Beep")]
		public static extern int Beep(int dwFreq, int dwDuration);
	}
}
