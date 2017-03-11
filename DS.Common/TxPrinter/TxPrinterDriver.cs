using System;
using System.Runtime.InteropServices;
using System.Text;

namespace DS.Common.TxPrinter
{
	public class TxPrinterDriver
	{
		#region DLL调用

		[DllImport("TxPrnMod.dll", SetLastError = true,
			CharSet = CharSet.Ansi, ExactSpelling = false,
			CallingConvention = CallingConvention.StdCall)]
		private static extern bool TxOpenPrinter(uint Type, UIntPtr Idx);

		[DllImport("TxPrnMod.dll", SetLastError = true,
			CharSet = CharSet.Ansi, ExactSpelling = false,
			CallingConvention = CallingConvention.StdCall)]
		private static extern uint TxGetStatus();

		[DllImport("TxPrnMod.dll", SetLastError = true,
			CharSet = CharSet.Ansi, ExactSpelling = false,
			CallingConvention = CallingConvention.StdCall)]
		private static extern uint TxGetStatus2();

		[DllImport("TxPrnMod.dll", SetLastError = true,
			CharSet = CharSet.Ansi, ExactSpelling = false,
			CallingConvention = CallingConvention.StdCall)]
		private static extern void TxClosePrinter();

		[DllImport("TxPrnMod.dll", SetLastError = true,
			CharSet = CharSet.Ansi, ExactSpelling = false,
			CallingConvention = CallingConvention.StdCall)]
		private static extern void TxInit();

		[DllImport("TxPrnMod.dll", SetLastError = true,
			CharSet = CharSet.Ansi, ExactSpelling = false,
			CallingConvention = CallingConvention.StdCall)]
		private static extern void TxOutputString(string str);

		[DllImport("TxPrnMod.dll", SetLastError = true,
			CharSet = CharSet.Ansi, ExactSpelling = false,
			CallingConvention = CallingConvention.StdCall)]
		private static extern void TxNewline();

		[DllImport("TxPrnMod.dll", SetLastError = true,
			CharSet = CharSet.Ansi, ExactSpelling = false,
			CallingConvention = CallingConvention.StdCall)]
		private static extern void TxOutputStringLn(string str);

		[DllImport("TxPrnMod.dll", SetLastError = true,
			CharSet = CharSet.Ansi, ExactSpelling = false,
			CallingConvention = CallingConvention.StdCall)]
		private static extern void TxResetFont();

		[DllImport("TxPrnMod.dll", SetLastError = true,
			CharSet = CharSet.Ansi, ExactSpelling = false,
			CallingConvention = CallingConvention.StdCall)]
		private static extern bool TxPrintImage(string path);

		[DllImport("TxPrnMod.dll", SetLastError = true,
			CharSet = CharSet.Ansi, ExactSpelling = false,
			CallingConvention = CallingConvention.StdCall)]
		private static extern void TxSetupSerial(uint attr);

		[DllImport("TxPrnMod.dll", SetLastError = true,
			CharSet = CharSet.Ansi, ExactSpelling = false,
			CallingConvention = CallingConvention.StdCall)]
		private static extern bool TxPrintBarcode(uint type, string str);

		[DllImport("TxPrnMod.dll", SetLastError = true,
			CharSet = CharSet.Ansi, ExactSpelling = false,
			CallingConvention = CallingConvention.StdCall)]
		private static extern bool TxDoFunction(uint func, int param1, int param2);

		#endregion

		#region 方法

		/// <summary>
		///     打开端口
		/// </summary>
		/// <param name="type"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		public static bool OpenPrinter(TxTypeEnum type, int index)
		{
			return TxOpenPrinter((uint) type, (UIntPtr) index);
		}

		/// <summary>
		///     获取状态
		/// </summary>
		/// <returns></returns>
		public static TxStatEnum GetStatus()
		{
			return (TxStatEnum) TxGetStatus();
		}

		/// <summary>
		///     获取状态2
		/// </summary>
		/// <returns></returns>
		public static TxStatEnum GetStatus2()
		{
			return (TxStatEnum) TxGetStatus2();
		}

		/// <summary>
		///     关闭端口
		/// </summary>
		public static void ClosePrinter()
		{
			TxClosePrinter();
		}

		/// <summary>
		///     初始化
		/// </summary>
		public static void Init()
		{
			TxInit();
		}

		/// <summary>
		///     输出字符串
		/// </summary>
		/// <param name="str"></param>
		public static void OutputString(string str)
		{
			TxOutputString(str);
		}

		/// <summary>
		///     换行
		/// </summary>
		public static void Newline()
		{
			TxNewline();
		}

		/// <summary>
		///     输出字符串并换行
		/// </summary>
		/// <param name="str"></param>
		public static void OutputStringLn(string str)
		{
			TxOutputStringLn(str);
		}

		/// <summary>
		///     重置字体
		/// </summary>
		public static void ResetFont()
		{
			TxResetFont();
		}

		/// <summary>
		///     打印图像
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public static bool PrintImage(string path)
		{
			return TxPrintImage(path);
		}

		/// <summary>
		///     设置串口
		/// </summary>
		/// <param name="attr"></param>
		public static void SetupSerial(TxSerialEnum attr)
		{
			TxSetupSerial((uint) attr);
		}

		/// <summary>
		///     打印条码
		/// </summary>
		/// <param name="type"></param>
		/// <param name="str"></param>
		/// <returns></returns>
		public static bool PrintBarcode(TxBarEnum type, string str)
		{
			return TxPrintBarcode((uint) type, str);
		}

		/// <summary>
		///     执行功能
		/// </summary>
		/// <param name="func"></param>
		/// <param name="param1"></param>
		/// <param name="param2"></param>
		/// <returns></returns>
		public static bool DoFunction(TxFuncEnum func, int param1, int param2)
		{
			return TxDoFunction((uint) func, param1, param2);
		}

		/// <summary>
		///     执行功能
		/// </summary>
		/// <param name="func"></param>
		/// <param name="param1"></param>
		/// <param name="param2"></param>
		/// <returns></returns>
		public static bool DoFunction(TxFuncEnum func, TxFuncParamEnum param1, int param2)
		{
			return TxDoFunction((uint) func, (int) param1, param2);
		}

		/// <summary>
		///     执行功能
		/// </summary>
		/// <param name="func"></param>
		/// <param name="param1"></param>
		/// <param name="param2"></param>
		/// <returns></returns>
		public static bool DoFunction(TxFuncEnum func, int param1, TxFuncParamEnum param2)
		{
			return TxDoFunction((uint) func, param1, (int) param2);
		}

		/// <summary>
		///     执行功能
		/// </summary>
		/// <param name="func"></param>
		/// <param name="param1"></param>
		/// <param name="param2"></param>
		/// <returns></returns>
		public static bool DoFunction(TxFuncEnum func, TxFuncParamEnum param1, TxFuncParamEnum param2)
		{
			return TxDoFunction((uint) func, (int) param1, (int) param2);
		}

		#endregion
	}
}