using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickFrame.Common.Converter
{
	/// <summary>
	/// 值类转换
	/// </summary>
	public class ValueConvert
	{
		#region 字符串

		/// <summary>
		/// 转换为字符串
		/// </summary>
		/// <param name="obj">待转换对象</param>
		/// <returns></returns>
		public static string ToString(object obj)
		{
			if (obj == null || obj == DBNull.Value)
			{
				return null;
			}
			return obj.ToString();
		}

        /// <summary>
        /// 转换为字符串
        /// </summary>
        /// <param name="obj">待转换对象</param>
        /// <returns></returns>
        public static string ToForceString(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return "";
            }
            return obj.ToString();
        }

		/// <summary>
		/// 转换为默认空字符串
		/// </summary>
		/// <param name="obj">待转换对象</param>
		/// <returns></returns>
		public static string ToEmptyNullString(object obj)
		{
			if (obj == null || obj == DBNull.Value)
			{
				return null;
			}
			var result = obj.ToString();
			if (result == string.Empty) return null;
			return result;
		}

		#endregion

		#region 定点数

		/// <summary>
		/// 转换为定点数
		/// </summary>
		/// <param name="obj">待转换对象</param>
		/// <returns></returns>
		public static decimal ToDecimal(object obj)
		{
			try
			{
				return Convert.ToDecimal(obj);
			}
			catch
			{
				return 0m;
			}
		}

		/// <summary>
		/// 转换为定点数
		/// </summary>
		/// <param name="str">待转换字符串</param>
		/// <returns></returns>
		public static decimal ToDecimal(string str)
		{
			if (string.IsNullOrEmpty(str) || str.Trim() == string.Empty) return 0m;
			return ToDecimal((object)str.Trim());
		}

		/// <summary>
		/// 转换为可空定点数
		/// </summary>
		/// <param name="obj">待转换对象</param>
		/// <returns></returns>
		public static decimal? ToNullableDecimal(object obj)
		{
			try
			{
				if (obj == null) return null;
				return Convert.ToDecimal(obj);
			}
			catch
			{
				return null;
			}
		}

		/// <summary>
		/// 转换为可空定点数
		/// </summary>
		/// <param name="str">待转换字符串</param>
		/// <returns></returns>
		public static decimal? ToNullableDecimal(string str)
		{
			if (string.IsNullOrEmpty(str) || str.Trim() == string.Empty) return null;
			return ToNullableDecimal((object)str.Trim());
		}

		#endregion

		#region 浮点数

		/// <summary>
		/// 转换为单精度浮点数
		/// </summary>
		/// <param name="obj">待转换对象</param>
		/// <returns></returns>
		public static float ToSingle(object obj)
		{
			try
			{
				return Convert.ToSingle(obj);
			}
			catch
			{
				return 0f;
			}
		}

		/// <summary>
		/// 转换为单精度浮点数
		/// </summary>
		/// <param name="str">待转换字符串</param>
		/// <returns></returns>
		public static float ToSingle(string str)
		{
			if (string.IsNullOrEmpty(str) || str.Trim() == string.Empty) return 0f;
			return ToSingle((object)str.Trim());
		}

		/// <summary>
		/// 转换为可空单精度浮点数
		/// </summary>
		/// <param name="obj">待转换对象</param>
		/// <returns></returns>
		public static float? ToNullableSingle(object obj)
		{
			try
			{
				return Convert.ToSingle(obj);
			}
			catch
			{
				return null;
			}
		}

		/// <summary>
		/// 转换为可空单精度浮点数
		/// </summary>
		/// <param name="str">待转换字符串</param>
		/// <returns></returns>
		public static float? ToNullableSingle(string str)
		{
			if (string.IsNullOrEmpty(str) || str.Trim() == string.Empty) return null;
			return ToNullableSingle((object)str.Trim());
		}

		/// <summary>
		/// 转换为双精度浮点数
		/// </summary>
		/// <param name="obj">待转换对象</param>
		/// <returns></returns>
		public static double ToDouble(object obj)
		{
			try
			{
				return Convert.ToDouble(obj);
			}
			catch
			{
				return 0d;
			}
		}

		/// <summary>
		/// 转换为双精度浮点数
		/// </summary>
		/// <param name="str">待转换字符串</param>
		/// <returns></returns>
		public static double ToDouble(string str)
		{
			if (string.IsNullOrEmpty(str) || str.Trim() == string.Empty) return 0d;
			return ToDouble((object)str.Trim());
		}

		/// <summary>
		/// 转换为可空双精度浮点数
		/// </summary>
		/// <param name="obj">待转换对象</param>
		/// <returns></returns>
		public static double? ToNullableDouble(object obj)
		{
			try
			{
				if (obj == null) return null;
				return Convert.ToDouble(obj);
			}
			catch
			{
				return null;
			}
		}

		/// <summary>
		/// 转换为可空双精度浮点数
		/// </summary>
		/// <param name="str">待转换字符串</param>
		/// <returns></returns>
		public static double? ToNullableDouble(string str)
		{
			if (string.IsNullOrEmpty(str) || str.Trim() == string.Empty) return null;
			return ToNullableDouble((object)str.Trim());
		}

		#endregion

		#region 有符号整数

		/// <summary>
		/// 转换为 32 位有符号整数
		/// </summary>
		/// <param name="obj">待转换对象</param>
		/// <returns></returns>
		public static int ToInt32(object obj)
		{
			try
			{
				return Convert.ToInt32(obj);
			}
			catch
			{
				return 0;
			}
		}

		/// <summary>
		/// 转换为 32 位有符号整数
		/// </summary>
		/// <param name="str">待转换字符串</param>
		/// <returns></returns>
		public static int ToInt32(string str)
		{
			if (string.IsNullOrEmpty(str) || str.Trim() == string.Empty) return 0;
			return ToInt32((object)str.Trim());
		}

		/// <summary>
		/// 转换为可空 32 位有符号整数
		/// </summary>
		/// <param name="obj">待转换对象</param>
		/// <returns></returns>
		public static int? ToNullableInt32(object obj)
		{
			try
			{
				if (obj == null) return null;
				return Convert.ToInt32(obj);
			}
			catch
			{
				return null;
			}
		}

		/// <summary>
		/// 转换为可空 32 位有符号整数
		/// </summary>
		/// <param name="str">待转换字符串</param>
		/// <returns></returns>
		public static int? ToNullableInt32(string str)
		{
			if (string.IsNullOrEmpty(str) || str.Trim() == string.Empty) return null;
			return ToNullableInt32((object)str.Trim());
		}

		#endregion

		#region 布尔值

		/// <summary>
		/// 转换为布尔值
		/// </summary>
		/// <param name="obj">待转换对象</param>
		/// <returns></returns>
		public static bool ToBoolean(object obj)
		{
			try
			{
				return Convert.ToBoolean(obj);
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// 转换为布尔值
		/// </summary>
		/// <param name="str">待转换字符串</param>
		/// <returns></returns>
		public static bool ToBoolean(string str)
		{
			if (string.IsNullOrEmpty(str) || str.Trim() == string.Empty) return false;
			return ToBoolean((object)str.Trim());
		}

		/// <summary>
		/// 转换为可空布尔值
		/// </summary>
		/// <param name="obj">待转换对象</param>
		/// <returns></returns>
		public static bool? ToNullableBoolean(object obj)
		{
			try
			{
				if (obj == null) return null;
				return Convert.ToBoolean(obj);
			}
			catch
			{
				return null;
			}
		}

		/// <summary>
		/// 转换为可空布尔值
		/// </summary>
		/// <param name="str">待转换字符串</param>
		/// <returns></returns>
		public static bool? ToNullableBoolean(string str)
		{
			if (string.IsNullOrEmpty(str) || str.Trim() == string.Empty) return null;
			return ToNullableBoolean((object)str.Trim());
		}

		#endregion

		#region 日期时间

		/// <summary>
		/// 转换为日期时间
		/// </summary>
		/// <param name="obj">待转换对象</param>
		/// <returns></returns>
		public static DateTime ToDateTime(object obj)
		{
			try
			{
				return Convert.ToDateTime(obj);
			}
			catch
			{
				return new DateTime();
			}
		}

		/// <summary>
		/// 转换为日期时间
		/// </summary>
		/// <param name="str">待转换字符串</param>
		/// <returns></returns>
		public static DateTime ToDateTime(string str)
		{
			if (string.IsNullOrEmpty(str) || str.Trim() == string.Empty) return new DateTime();
			return ToDateTime((object)str.Trim());
		}

		/// <summary>
		/// 转换为日期时间
		/// </summary>
		/// <param name="nullableDateTime">可空的日期时间</param>
		/// <returns></returns>
		public static DateTime ToDateTime(DateTime? nullableDateTime)
		{
			return nullableDateTime ?? new DateTime();
		}

		/// <summary>
		/// 转换为可空日期时间
		/// </summary>
		/// <param name="obj">待转换对象</param>
		/// <returns></returns>
		public static DateTime? ToNullableDateTime(object obj)
		{
			try
			{
				if (obj == null) return null;
				return Convert.ToDateTime(obj);
			}
			catch
			{
				return null;
			}
		}

		/// <summary>
		/// 转换为可空日期时间
		/// </summary>
		/// <param name="str">待转换字符串</param>
		/// <returns></returns>
		public static DateTime? ToNullableDateTime(string str)
		{
			if (string.IsNullOrEmpty(str) || str.Trim() == string.Empty) return null;
			return ToNullableDateTime((object)str.Trim());
		}

		/// <summary>
		/// 转换为可空日期时间
		/// </summary>
		/// <param name="dateTime">日期时间</param>
		/// <returns></returns>
		public static DateTime? ToNullableDateTime(DateTime dateTime)
		{
			if (dateTime == new DateTime()) return null;
			return dateTime;
		}

		#endregion
	}
}
