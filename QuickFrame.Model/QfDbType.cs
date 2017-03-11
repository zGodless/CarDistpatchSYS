using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickFrame.Model
{
	// 指定QuickFrame连接层参数数据类型
	public enum QfDbType
	{
		/// <summary>
		/// System.Byte.8 位整数。
		/// </summary>
		Int8 = 0,
		/// <summary>
		/// System.Byte.8 位整数。
		/// </summary>
		TinyInt = 0,
		/// <summary>
		/// System.Int16.16 位整数。
		/// </summary>
		Int16 = 1,
		/// <summary>
		/// System.Int16.16 位整数。
		/// </summary>
		SmallInt = 1,
		/// <summary>
		/// 24 位整数。
		/// </summary>
		Int24 = 2,
		/// <summary>
		/// 24 位整数。
		/// </summary>
		MediumInt = 2,
		/// <summary>
		/// System.Int32.32 位整数。
		/// </summary>
		Int32 = 3,
		/// <summary>
		/// System.Int32.32 位整数。
		/// </summary>
		Int = 3,
		/// <summary>
		/// System.Int32.32 位整数。
		/// </summary>
		Integer = 3,
		/// <summary>
		/// System.Int64.64 位整数。
		/// </summary>
		Int64 = 4,
		/// <summary>
		/// System.Int64.64 位整数。
		/// </summary>
		BigInt = 4,

		/// <summary>
		/// System.Double.带有浮动小数点的小数字。
		/// </summary>
		Float = 5,
		/// <summary>
		/// System.Double.带有浮动小数点的小数字。
		/// </summary>
		Double = 6,
		/// <summary>
		/// System.Decimal.固定精度和小数位数数值。
		/// </summary>
		Decimal = 7,
		/// <summary>
		/// System.Decimal.固定精度和小数位数数值。
		/// </summary>
		Numeric = 8,
		/// <summary>
		/// 
		/// </summary>
		Real = 9,

		/// <summary>
		/// System.Boolean.无符号数值，可以是 0、1 或 null。
		/// </summary>
		Bit = 9,
		/// <summary>
		/// System.Boolean.无符号数值，可以是 0、1 或 null。
		/// </summary>
		Bool = 9,
		/// <summary>
		/// System.Boolean.无符号数值，可以是 0、1 或 null。
		/// </summary>
		Boolean = 9,

		Byte = 10,

		Char = 20,
		NChar = 21,
		VarChar = 22,
		NVarChar = 23,

		Date = 40,
		Time = 41,
		DateTime = 42,

		Blob = 60,
		TinyBlob = 61,
		MediumBlob = 62,
		LongBlob = 63,

		String = 80,
		VarString = 81,

		Binary = 100,
		VarBinary = 101,

		Text = 120,
		TinyText = 121,
		MediumText = 122,
		LongText = 123,

		UByte = 140,
		UInt16 = 141,
		UInt24 = 142,
		UInt32 = 143,
		UInt64 = 144,

		Guid = 200
	}
}
