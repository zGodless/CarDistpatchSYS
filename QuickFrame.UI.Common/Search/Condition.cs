using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickFrame.UI.Common.Search
{
    public class Condition
    {
        private string _FieldName = string.Empty;
        private string _FieldCaption = string.Empty;
        private bool _IsChoose = false;

        /// <summary>
        /// 可查询的列名
        /// </summary>
        public string FieldName
        {
            get
            {
                return _FieldName;
            }
            set
            {
                _FieldName = value;
            }
        }

        /// <summary>
        /// 可查询的列的中文名字描述
        /// </summary>
        public string FieldCaption
        {
            get
            {
                return _FieldCaption;
            }
            set
            {
                _FieldCaption = value;
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
        public bool IsChoose
        {
            get
            {
                return _IsChoose;
            }
            set
            {
                _IsChoose = value;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="p_FieldName">列名</param>
        /// <param name="p_FieldNameNote">列名描述(中文)</param>
        /// <param name="p_OperatorType">运算符</param>
        /// <param name="p_DefaultOperatorIndex">缺省运算符的索引</param>
        /// <param name="p_Value">查询值</param>
        /// <param name="p_ValueType">查询值类型</param>
        public Condition(
            string p_FieldName,
            string p_FieldCaption,
            string[] p_OperatorArray,
            string p_Operator,
            object p_SourceValue,
            Type p_SourceValueType,
            string p_DisplayField,
            string p_DisplayFieldType,
            object p_DisplayValue,
            string p_ValueField,
            string p_ValueFieldType,
            object p_Value,
            SearchValueType p_ValueType)
        {
            FieldName = p_FieldName;
            FieldCaption = p_FieldCaption;
            ValueType = p_ValueType;
            if (p_OperatorArray != null)
            {
                OperatorArray = p_OperatorArray;
            }
            else
            {
                OperatorArray = UsualOperatorType(ValueType);
            }
            Operator = p_Operator;
            SourceValue = p_SourceValue;
            SourceValueType = p_SourceValueType;
            DisplayField = p_DisplayField;
            DisplayFieldType = p_DisplayFieldType;
            DisplayValue = p_DisplayValue;
            ValueField = p_ValueField;
            ValueFieldType = p_ValueFieldType;
            Value = p_Value;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="p_FieldName">列名</param>
        /// <param name="p_FieldNameNote">列名描述(中文)</param>
        /// <param name="p_Value">查询值的初始值</param>
        /// <param name="p_ValueType">查询值的类型</param>
        public Condition(string p_FieldName, string p_FieldCaption, object p_Value, SearchValueType p_ValueType)
        {
            FieldName = p_FieldName;
            FieldCaption = p_FieldCaption;
            ValueType = p_ValueType;
            Value = p_Value;
            OperatorArray = UsualOperatorType(ValueType);
            Operator = OperatorArray[0];
        }

        /// <summary>
        /// 根据值类型获取常用的操作符
        /// 1.数字和日期的常用操作符:"=", ">", "<<><<></<><<></<>
        /// </<></summary>
        private string[] UsualOperatorType(SearchValueType ValueType)
        {
            switch (ValueType)
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
