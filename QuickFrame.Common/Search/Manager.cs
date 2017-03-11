using System;
using System.Collections.Generic;

namespace QuickFrame.Common.Search
{
	public class Manager
	{
		/// <summary>
		///     解析查询条件中使用的变量
		/// </summary>
		/// <param name="pVariable"></param>
		/// <returns></returns>
		public static object AnalysisVariable(object pVariable)
		{
			switch (pVariable.ToString())
			{
				case "[#DateTime.Now#]":
					return DateTime.Now;
			}
			return null;
		}

		/// <summary>
		///     将条件列表转换成表达式
		/// </summary>
		/// <param name="conditionList">条件列表</param>
		/// <param name="preflag">前缀标记</param>
		/// <returns></returns>
		public static string GetQueryExpress(List<Condition> conditionList, string preflag)
		{
			var querExpress = "";
			foreach (var c in conditionList)
			{
				querExpress += " " + preflag + "." + c.FieldName + " ";
				querExpress += " " + c.Operator + " ";
				querExpress += " " + CheckValue(c.Value, c.ValueType, c.Operator) + "";
				querExpress += " and";
			}
			if (conditionList.Count > 0)
			{
				querExpress = querExpress.Substring(0, querExpress.Length - 4);
			}
			return querExpress;
		}

		/// <summary>
		///     将条件列表转换成表达式
		/// </summary>
		/// <param name="conditionList">条件列表</param>
		/// <returns></returns>
		public static string GetQueryExpress(List<Condition> conditionList)
		{
			var QuerExpress = string.Empty;
			foreach (var c in conditionList)
			{
				QuerExpress += " " + c.FieldName + " ";
				QuerExpress += " " + c.Operator + " ";
				QuerExpress += " " + CheckValue(c.Value, c.ValueType, c.Operator) + string.Empty;
				QuerExpress += " and";
			}
			if (conditionList.Count > 0)
			{
				QuerExpress = QuerExpress.Substring(0, QuerExpress.Length - 4);
			}
			return QuerExpress;
		}

		/// <summary>
		///     将值转换成合适的值字符串
		///     1.Number:  无需转换
		///     2.String:  '值'
		///     3.Date:    TO_DATE('值','YYYY-MM-DD')
		/// </summary>
		/// <param name="value"></param>
		/// <param name="type"></param>
		/// <param name="op"></param>
		/// <returns></returns>
		private static string CheckValue(object value, SearchValueType type, string op)
		{
			var result = string.Empty;
			switch (type)
			{
				case SearchValueType.Number:
					result = value.ToString();
					break;
				case SearchValueType.String:
					if (op == "Like")
					{
						result = "'%" + value + "%'";
					}
					else
					{
						result = "'" + value + "'";
					}
					break;
				case SearchValueType.Date:
					result = "TO_DATE('" + value + "','YYYY-MM-DD HH24:MI:SS')";
					break;
			}
			return result;
		}
	}
}