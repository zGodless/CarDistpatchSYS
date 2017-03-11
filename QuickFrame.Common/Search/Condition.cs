using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickFrame.Common.Search
{
	public class Condition
	{
		private string _fieldName = string.Empty;
		private string _fieldCaption = string.Empty;

		/// <summary>
		/// 可查询的列名
		/// </summary>
		public string FieldName
		{
			get
			{
				return _fieldName;
			}
			set
			{
				_fieldName = value;
			}
		}

		/// <summary>
		/// 可查询的列的中文名字描述
		/// </summary>
		public string FieldCaption
		{
			get
			{
				return _fieldCaption;
			}
			set
			{
				_fieldCaption = value;
			}
		}

		/// <summary>
		/// 所有操作符列表
		/// </summary>
		public string[] OperatorArray { get; set; }

		/// <summary>
		/// 缺省操作符
		/// 1.缺省操作符为操作符列表的第一个.如果有第一个的话.
		/// </summary>
		public string Operator { get; set; }

		/// <summary>
		/// 原值(例如:BranchCompany,DateTime等类型)
		/// </summary>
		public object SourceValue { get; set; }

		/// <summary>
		/// 原值的类型
		/// </summary>
		public Type SourceValueType { get; set; }

		/// <summary>
		/// 显示属性名
		/// </summary>
		public string DisplayField { get; set; }

		/// <summary>
		/// 显示属性类型("Property","Method")
		/// </summary>
		public string DisplayFieldType { get; set; }

		/// <summary>
		/// 显示的值
		/// </summary>
		public object DisplayValue { get; set; }

		/// <summary>
		/// 值属性名
		/// </summary>
		public string ValueField { get; set; }

		/// <summary>
		/// 值属性类型("Property","Method")
		/// </summary>
		public string ValueFieldType { get; set; }

		/// <summary>
		/// 值
		/// </summary>
		public object Value { get; set; }

		/// <summary>
		/// 值类型
		/// </summary>
		public SearchValueType ValueType { get; set; }

		/// <summary>
		/// 是否选中
		/// </summary>
		public bool IsChoose { get; set; }

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="pFieldName">列名</param>
		/// <param name="pFieldCaption">列名描述(中文)</param>
		/// <param name="pOperatorArray"></param>
		/// <param name="pOperator">运算符</param>
		/// <param name="pSourceValue"></param>
		/// <param name="pSourceValueType"></param>
		/// <param name="pDisplayField"></param>
		/// <param name="pDisplayFieldType"></param>
		/// <param name="pDisplayValue"></param>
		/// <param name="pValueField"></param>
		/// <param name="pValueFieldType"></param>
		/// <param name="pValue">查询值</param>
		/// <param name="pValueType">查询值类型</param>
		public Condition(
			string pFieldName,
			string pFieldCaption,
			string[] pOperatorArray,
			string pOperator,
			object pSourceValue,
			Type pSourceValueType,
			string pDisplayField,
			string pDisplayFieldType,
			object pDisplayValue,
			string pValueField,
			string pValueFieldType,
			object pValue,
			SearchValueType pValueType)
		{
			IsChoose = false;
			FieldName = pFieldName;
			FieldCaption = pFieldCaption;
			ValueType = pValueType;
			OperatorArray = pOperatorArray ?? UsualOperatorType(ValueType);
			if (pValue == null) throw new ArgumentNullException("pValue");
			Operator = pOperator;
			SourceValue = pSourceValue;
			SourceValueType = pSourceValueType;
			DisplayField = pDisplayField;
			DisplayFieldType = pDisplayFieldType;
			DisplayValue = pDisplayValue;
			ValueField = pValueField;
			ValueFieldType = pValueFieldType;
			Value = pValue;
		}

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="pFieldName">列名</param>
		/// <param name="pFieldCaption">列名描述(中文)</param>
		/// <param name="pValue">查询值的初始值</param>
		/// <param name="pValueType">查询值的类型</param>
		public Condition(string pFieldName, string pFieldCaption, object pValue, SearchValueType pValueType)
		{
			IsChoose = false;
			FieldName = pFieldName;
			FieldCaption = pFieldCaption;
			ValueType = pValueType;
			Value = pValue;
			OperatorArray = UsualOperatorType(ValueType);
			Operator = OperatorArray[0];
		}

		/// <summary>
		/// 根据值类型获取常用的操作符
		/// 1.数字和日期的常用操作符:"=", "&gt;", "&lt;", "&gt;=", "&lt;=", "&lt;&gt;"
		/// <param name="valueType">查询值类型</param>
		/// </summary>
		private string[] UsualOperatorType(SearchValueType valueType)
		{
			switch (valueType)
			{
				case SearchValueType.Number:
				case SearchValueType.Date:
					var usual = new string[] { "=", ">", "<", ">=", "<=", "<>" };
					return usual;
				case SearchValueType.String:
					var strusual = new string[] { "=", ">", "<", ">=", "<=", "<>", "Like" };
					return strusual;
			}
			return null;
		}

		/// <summary>
		/// 刷新
		/// </summary>
		public void Refresh()
		{
			if (SourceValue != null && SourceValueType != null)
			{
				switch (DisplayFieldType)
				{
					case "Property":
						var p = SourceValueType.GetProperty(DisplayField);
						DisplayValue = p.GetValue(SourceValue, null);
						break;
					case "Method":
						var m = SourceValueType.GetMethod(DisplayField);
						DisplayValue = m.Invoke(SourceValue, null);
						break;
				}
				switch (ValueFieldType)
				{
					case "Property":
						var p = SourceValueType.GetProperty(ValueField);
						Value = p.GetValue(SourceValue, null);
						break;
					case "Method":
						var m = SourceValueType.GetMethod(ValueField);
						Value = m.Invoke(SourceValue, null);
						break;
				}
			}
		}
	}
}
