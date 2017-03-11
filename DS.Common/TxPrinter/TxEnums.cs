using System;

namespace DS.Common.TxPrinter
{
	/// <summary>
	///     接口类型枚举
	/// </summary>
	public enum TxTypeEnum : uint
	{
		/// <summary>
		///     无
		/// </summary>
		None = 0,

		/// <summary>
		///     USB接口
		/// </summary>
		Usb = 1,

		/// <summary>
		///     LPT接口
		/// </summary>
		Lpt = 2,

		/// <summary>
		///     COM接口
		/// </summary>
		Com = 3
	}

	/// <summary>
	///     状态枚举
	/// </summary>
	[Flags]
	public enum TxStatEnum : uint
	{
		/// <summary>
		///     无故障
		/// </summary>
		NoError = 0x0008,

		/// <summary>
		///     处于联机状态
		/// </summary>
		Select = 0x0010,

		/// <summary>
		///     缺纸
		/// </summary>
		PaperEnd = 0x0020,

		/// <summary>
		///     繁忙
		/// </summary>
		Busy = 0x0080,

		/// <summary>
		///     钱箱接口的电平（整机使用的，模块无用）
		/// </summary>
		DrawHigh = 0x0100,

		/// <summary>
		///     打印机机芯的盖子打开
		/// </summary>
		Cover = 0x0200,

		/// <summary>
		///     打印机错误
		/// </summary>
		Error = 0x0400,

		/// <summary>
		///     可恢复错误（需要人工干预）
		/// </summary>
		RcvErr = 0x0800,

		/// <summary>
		///     切刀错误
		/// </summary>
		CutErr = 0x1000,

		/// <summary>
		///     不可恢复错误
		/// </summary>
		URcvErr = 0x2000,

		/// <summary>
		///     可自动恢复的错误
		/// </summary>
		ARcvErr = 0x4000,

		/// <summary>
		///     快要没有纸了
		/// </summary>
		PaperNe = 0x8000
	}

	/// <summary>
	///     串口设置参数枚举
	/// </summary>
	[Flags]
	public enum TxSerialEnum : uint
	{
		/// <summary>
		///     波特率
		/// </summary>
		BaudMask = 0xff000000,

		/// <summary>
		///     9600 的波特率
		/// </summary>
		Baud9600 = 0x00000000,

		/// <summary>
		///     19200 的波特率
		/// </summary>
		Baud19200 = 0x01000000,

		/// <summary>
		///     38400 的波特率
		/// </summary>
		Baud38400 = 0x02000000,

		/// <summary>
		///     57600 的波特率
		/// </summary>
		Baud57600 = 0x03000000,

		/// <summary>
		///     115200 的波特率
		/// </summary>
		Baud115200 = 0x04000000,

		/// <summary>
		///     数据位
		/// </summary>
		DataMask = 0x00FF0000,

		/// <summary>
		///     8 位数据位
		/// </summary>
		Data8Bits = 0x00000000,

		/// <summary>
		///     7 位数据位
		/// </summary>
		Data7Bits = 0x00010000,

		/// <summary>
		///     校验
		/// </summary>
		ParityMask = 0x0000FF00,

		/// <summary>
		///     无校验
		/// </summary>
		ParityNone = 0x00000000,

		/// <summary>
		///     偶校验
		/// </summary>
		ParityEven = 0x00000100,

		/// <summary>
		///     奇校验
		/// </summary>
		ParityOdd = 0x00000200,

		/// <summary>
		///     停止位
		/// </summary>
		StopMask = 0x000000F0,

		/// <summary>
		///     1 位停止位
		/// </summary>
		Stop1Bits = 0x00000000,

		/// <summary>
		///     1.5 位停止位
		/// </summary>
		Stop15Bits = 0x00000010,

		/// <summary>
		///     2 位停止位
		/// </summary>
		Stop2Bits = 0x00000020,

		/// <summary>
		///     流控制
		/// </summary>
		FlowMask = 0x0000000F,

		/// <summary>
		///     无流控
		/// </summary>
		FlowNone = 0x00000000,

		/// <summary>
		///     硬件流控（DTR/DSR 方式）
		/// </summary>
		FlowHard = 0x00000001,

		/// <summary>
		///     软件流控（XON/XOFF 方式）
		/// </summary>
		FlowSoft = 0x00000002
	}

	/// <summary>
	///     条码类型枚举
	/// </summary>
	public enum TxBarEnum : uint
	{
		UPCA = 65,
		UPCE = 66,
		EAN13 = 67,
		EAN8 = 68,
		CODE39 = 69,
		ITF = 70,
		CODEBAR = 71,
		CODE93 = 72,
		CODE128 = 73
	}

	/// <summary>
	///     指令枚举
	/// </summary>
	public enum TxFuncEnum : uint
	{
		/// <summary>
		///     控制字体的放大倍数功能，后面的 2 个参数 0 为正常大小，递增 1 为增大 1 倍，如此类推；
		///     最大为 7；参数 1(param1)为字体宽的倍数，参数 2(param2)为字体高的倍数。
		///     下面的例子就是使用 4 倍宽 3 倍高的字体：
		///     TxDoFunction(TxFuncEnum.FontSize,TxFuncParamEnum.Size3X,TxFuncParamEnum.Size2X)
		/// </summary>
		FontSize = 1,

		/// <summary>
		///     控制是否有下划线功能，只需 1 个参数，param1=TxFuncParamEnum.On(有下划线)，=TxFuncParamEnum.Off(无下划
		///     线）,param2=0 就可以了。
		///     下面的例子就是使用下划线的调用：
		///     TxDoFunction(TxFuncEnum.FontULine,TxFuncParamEnum.On,0);
		/// </summary>
		FontULine = 2,

		/// <summary>
		///     控制是否粗体功能，只需 1 个参数，param1=TxFuncParamEnum.On(使用粗体 )，=TxFuncParamEnum.Off(不使用粗
		///     体),param2=0 就可以了。
		///     下面的例子就是使用粗体的调用
		///     TxDoFunction(TxFuncEnum.FontBold,TxFuncParamEnum.On,0);
		/// </summary>
		FontBold = 3,

		/// <summary>
		///     选 择 英 文 字 体 功 能 ， 也 是 只 需 要 1 个 参 数 ， TxFuncParamEnum.FontA(12X24) 或
		///     TxFuncParamEnum.FontB(9X17),param2=0 就可以了。
		///     下面的例子就是使用 9X17 的字体调用的
		///     TxDoFunction(TxFuncEnum.SelFont,TxFuncParamEnum.FontB,0);
		/// </summary>
		SelFont = 4,

		/// <summary>
		///     字体是否旋转 90 度功能，只需要 1 个参数。
		///     下面的例子就是使用 9X17 的字体调用的
		///     TxDoFunction(TxFuncEnum.FontRotate,TxFuncParamEnum.On,0);
		/// </summary>
		FontRotate = 5,

		/// <summary>
		///     控制对齐功能，参数为 TX_ALIGN_XXX，只需要 1 个参数。
		///     下面例子是对中打印的调用
		///     TxDoFunction(TxFuncEnum.Align,TxFuncParamEnum.AlignCenter,0);
		///     TxOutputStringLn("center")
		/// </summary>
		Align = 6,

		/// <summary>
		///     中文/英文模式切换功能，只需要 1 个参数。
		///     下面的例子是进入中文方式的调用
		///     TxDoFunction(TxFuncEnum.ChineseMode,TxFuncParamEnum.On,0);
		/// </summary>
		ChineseMode = 7,

		/// <summary>
		///     执行走纸功能，只需要 1 个参数，参数以毫米为单位。
		///     下面的例子是走纸 30 毫米的调用
		///     TxDoFunction(TxFuncEnum.Feed,30,0);
		/// </summary>
		Feed = 10,

		/// <summary>
		///     设置动作单位(无效)
		/// </summary>
		UnitType = 11,

		/// <summary>
		///     执行切纸功能，第一参数指明类型，第二参数指明切纸前的走纸距离
		///     切纸的类型有 2 种:
		///     下面的例子就是不走纸直接全切的调用。
		///     TxDoFunction(TxFuncEnum.Cut,TxFuncParamEnum.CutFull,0);
		/// </summary>
		Cut = 12,

		/// <summary>
		///     绝对水平定位功能，只需要 1 个参数，参数以毫米为单位。
		///     下面的例子就是定位在离左边 20mm 的地方开始处理字符数据（或着说打印也可以）
		///     TxDoFunction(TxFuncEnum.HorPos,20,0);
		/// </summary>
		HorPos = 13,

		/// <summary>
		///     设置行间距功能，只需要 1 个参数，参数是以点数为单位的。
		///     下面的例子就是设置行间距为 30 点（默认的参数）
		///     TxDoFunction(TxFuncEnum.LineSp,30,0);
		/// </summary>
		LineSp = 14,

		/// <summary>
		///     设置字体是否黑白翻转功能，只需要 1 个参数
		///     下面的例子是使用黑白翻转打印功能的调用。
		///     TxDoFunction(TxFuncEnum.BwReverse,TxFuncParamEnum.On,0);
		/// </summary>
		BwReverse = 15,

		/// <summary>
		///     设置是否倒置打印功能，只需要 1 个参数
		///     下面的例子是使用倒置打印功能的调用。
		///     TxDoFunction(TxFuncEnum.UpsideDown,TxFuncParamEnum.On,0);
		/// </summary>
		UpsideDown = 16,

		/// <summary>
		///     选择国际字符集功能，只需要 1 个参数,通常这个设置也是在英文方式下使用的，只是针对
		///     12 个特定的 ASCII 码不同国家的使用的字形不同，默认是 0，表示是使用美国的字符集。
		///     下面的例子是设置国际字符集为 1
		///     TxDoFunction(TxFuncEnum.InetChars,1,0);
		/// </summary>
		InetChars = 17,

		/// <summary>
		///     选择字符代码页功能，只需要 1 个参数，通常是 0~n,表示选择的代码页参数，祥见打印机说
		///     明书
		///     一般默认是 0，是表示 PC437 的代码页，这个功能要只在英文方式下有效。
		///     下面的例子是设置字符代码页为 3
		///     TxDoFunction(TxFuncEnum.CodePage,3,0);
		/// </summary>
		CodePage = 18,

		/// <summary>
		///     设定汉字旋转功能，只需要 1 个参数，可以表示 3 种选择，如下所示：
		///     下面的例子是设置汉字向左旋转的功能
		///     TxDoFunction(TxFuncEnum.ChRotate,TxFuncParamEnum.ChRotateLeft,0);
		/// </summary>
		ChRotate = 19,

		/// <summary>
		///     寻找黑标黑标
		///     TX_CHK_BMARK 是执行黑标检测，这个动作本身是不需要参数的，所以就是
		///     TxDoFunction(TxFuncEnum.ChkBmark,0,0)
		/// </summary>
		ChkBmark = 20,

		/// <summary>
		///     设置黑标相关偏移量功能
		///     这里有 2 个参数要设置，起始打印位置相对于黑标检测位置的偏移量和切/撕纸位置相对于
		///     黑标检测位置的偏移量。
		///     TxDoFunction(TxFuncEnum.SetBmark,TxFuncParamEnum.BmStart,参数)，这样是设置起始打印位置相对
		///     于黑标检测位置的偏移量。
		///     TxDoFunction(TxFuncEnum.SetBmark,TxFuncParamEnum.BmTear ,参数)，这样是切/撕纸位置相对于黑标
		///     检测位置的偏移量。
		/// </summary>
		SetBmark = 21,

		/// <summary>
		///     打印已下载好的 LOGO 的功能，只需 1 个参数，可以表示 4 种选择，如下所示：
		///     下面的例子就是正常打印下载的 LOGO
		///     TxDoFunction(TxFuncEnum.PrintLogo,TxFuncParamEnum.Logo1X1,0);
		/// </summary>
		PrintLogo = 22,

		/// <summary>
		///     设定条码高度功能,只需要 1 个参数,单位为点数
		///     下面的例子是设置的条码打印的高度为 15 点：
		///     TxDoFunction(TxFuncEnum.BarcodeHeight,15,0);
		/// </summary>
		BarcodeHeight = 23,

		/// <summary>
		///     设定条码宽度功能,只需要 1 个参数,单位为点数, 不能小于 2.
		///     下面的例子是设置的条码打印的宽度高度为 3 点：
		///     TxDoFunction(TxFuncEnum.BarcodeWidth,3,0);
		/// </summary>
		BarcodeWidth = 24,

		/// <summary>
		///     选择条码 HRI 字符的打印位置,只需要 1 个参数，可以表示 4 种选择，如下所示：
		///     下面的例子就是设置打印条码时条码的 HRI 字符打印在条码的下面
		///     TxDoFunction(TxFuncEnum.BarcodeFont,TxFuncParamEnum.BarFontDown,0);
		/// </summary>
		BarcodeFont = 25,

		/// <summary>
		///     执行反向走纸功能，只需要 1 个参数，参数以毫米为单位。
		///     下面的例子是反向走纸 30 毫米的调用
		///     TxDoFunction(TxFuncEnum.FeedRev,30,0);
		/// </summary>
		FeedRev = 26
	}

	/// <summary>
	///     指令参数枚举
	/// </summary>
	public enum TxFuncParamEnum
	{
		/// <summary>
		/// 功能设置有效
		/// </summary>
		On = 1,
		/// <summary>
		/// 功能设置无效
		/// </summary>
		Off = 0,

		/// <summary>
		/// 全切
		/// </summary>
		CutFull = 0,
		/// <summary>
		/// 半切
		/// </summary>
		CutPartial = 1,

		/// <summary>
		/// 12X24 点阵
		/// </summary>
		FontA = 0,
		/// <summary>
		/// 9X17 点阵
		/// </summary>
		FontB = 1,

		/// <summary>
		/// 左对齐
		/// </summary>
		AlignLeft = 0,
		/// <summary>
		/// 居中对齐
		/// </summary>
		AlignCenter = 1,
		/// <summary>
		/// 右对齐
		/// </summary>
		AlignRight = 2,

		/// <summary>
		/// 正常大小
		/// </summary>
		Size1X = 0,
		/// <summary>
		/// 2 倍大小
		/// </summary>
		Size2X = 1,
		/// <summary>
		/// 3 倍大小
		/// </summary>
		Size3X = 2,
		/// <summary>
		/// 4 倍大小
		/// </summary>
		Size4X = 3,
		/// <summary>
		/// 5 倍大小
		/// </summary>
		Size5X = 4,
		/// <summary>
		/// 6 倍大小
		/// </summary>
		Size6X = 5,
		/// <summary>
		/// 7 倍大小
		/// </summary>
		Size7X = 6,
		/// <summary>
		/// 8 倍大小
		/// </summary>
		Size8X = 7,

		/// <summary>
		/// 像素
		/// </summary>
		UnitPixel = 0,
		/// <summary>
		/// 毫米
		/// </summary>
		UnitMM = 1,

		/// <summary>
		/// 不旋转
		/// </summary>
		ChRotateNone = 0,
		/// <summary>
		/// 坐旋转
		/// </summary>
		ChRotateLeft = 1,
		/// <summary>
		/// 右旋转
		/// </summary>
		ChRotateRight = 2,

		/// <summary>
		/// 起始打印位置相对于黑标检测位置的偏移量
		/// </summary>
		BmStart = 1,
		/// <summary>
		/// 切/撕纸位置相对于黑标检测位置的偏移量
		/// </summary>
		BmTear = 2,

		/// <summary>
		/// 正常大小，203X203
		/// </summary>
		Logo1X1 = 0,
		/// <summary>
		/// 水平放大 2 倍，203x101
		/// </summary>
		Logo1X2 = 1,
		/// <summary>
		/// 垂直放大 2 倍，101x203
		/// </summary>
		Logo2X1 = 2,
		/// <summary>
		/// 水平和垂直放大 2 倍，101x101
		/// </summary>
		Logo2X2 = 3,

		/// <summary>
		/// 不打印
		/// </summary>
		BarFontNone = 0,
		/// <summary>
		/// 打印在条码的上面
		/// </summary>
		BarFontUp = 1,
		/// <summary>
		/// 打印在条码的下面
		/// </summary>
		BarFontDown = 2,
		/// <summary>
		/// 条码的上面下面都打印
		/// </summary>
		BarFontBoth = 3
	}
}