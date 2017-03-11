using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace QuickFrame.Common.Converter
{
	/// <summary>
	/// 模型转换
	/// </summary>
	public class ModelConvert
	{
		#region 方法(内部)

		/// <summary>
		/// 为对象的属性赋值
		/// </summary>
		/// <param name="prop">属性</param>
		/// <param name="destObj">目标对象</param>
		/// <param name="value">源值</param>
		private static void SetPropertyValue(PropertyInfo prop, object destObj, object value)
		{
			try
			{
				if (prop.GetSetMethod() == null) return;
				var temp = ChangeObjectType(prop.PropertyType, value);
				if (prop.PropertyType == typeof(DateTime?) && temp is DateTime)
				{
					prop.SetValue(destObj, new DateTime?((DateTime)temp), null);
				}
				else if (prop.PropertyType == typeof(DateTime) && temp is TimeSpan)
				{
					var time = DateTime.Now.Date + (TimeSpan)temp;
					prop.SetValue(destObj, time, null);
				}
				else if (prop.PropertyType == typeof(DateTime?) && temp is TimeSpan)
				{
					var time = DateTime.Now.Date + (TimeSpan)temp;
					prop.SetValue(destObj, new DateTime?(time), null);
				}
				else if (prop.PropertyType == typeof(String) && temp is Guid)
				{
					var guid = temp.ToString();
					prop.SetValue(destObj, guid, null);
				}
				else
				{
					prop.SetValue(destObj, temp, null);
				}
			}
			catch
			{
				// ignored;
			}
		}

		/// <summary>
		/// 用于类型数据的赋值
		/// </summary>
		/// <param name="type">目标类型</param>
		/// <param name="value">原值</param>
		/// <returns></returns>
		private static object ChangeObjectType(Type type, object value)
		{
			if ((value == null) && type.IsGenericType)
			{
				return Activator.CreateInstance(type);
			}
			if (value == null)
			{
				return null;
			}
			if (type == value.GetType())
			{
				return value;
			}
			if (type.IsEnum)
			{
				var s = value as string;
				return s != null ? Enum.Parse(type, s) : Enum.ToObject(type, value);
			}

			if (type == typeof(bool) && value is int)
			{
				var temp = int.Parse(value.ToString());
				return temp != 0;
			}
			if (!type.IsInterface && type.IsGenericType)
			{
				var type1 = type.GetGenericArguments()[0];
				var obj1 = ChangeObjectType(type1, value);
				if ((type == typeof(DateTime) || type == typeof(DateTime?)) && obj1 is TimeSpan)
				{
					return obj1;
				}
				return Activator.CreateInstance(type, obj1);
			}
			var strVal = value as string;
			if (strVal != null)
			{
				if (type == typeof(Guid))
				{
					return new Guid(strVal);
				}
				if (type == typeof(Version))
				{
					return new Version(strVal);
				}
			}
			if (!(value is IConvertible))
			{
				return value;
			}
			return Convert.ChangeType(value, type);
		}

		/// <summary>
		/// 判断DataSet默认表是否为空:true:不为空 false:为空。
		/// </summary>
		/// <param name="ds"></param>
		/// <returns></returns>
		private static bool CheckDataSet(DataSet ds)
		{
			var isNull = CheckDataSet(ds, 0);
			return isNull;
		}

		/// <summary>
		/// 判断DataSet指定索引表是否为空:true:不为空 false:为空。
		/// </summary>
		/// <param name="ds">DataSet</param>
		/// <param name="tableIndex">表的索引值</param>
		/// <returns></returns>
		private static bool CheckDataSet(DataSet ds, int tableIndex)
		{
			return ds != null && ds.Tables.Count > tableIndex && ds.Tables[tableIndex] != null &&
				   ds.Tables[tableIndex].Rows != null && ds.Tables[tableIndex].Rows.Count > 0;
		}

		#endregion

		#region 方法(公开)

		/// <summary>
		/// 将数据行转换成数据实体
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="row"></param>
		/// <param name="relation"></param>
		/// <returns></returns>
		public static T ToModel<T>(DataRow row, Hashtable relation = null)
		{
			var type = typeof(T);
			var destObj = Activator.CreateInstance<T>();
			foreach (PropertyInfo prop in type.GetProperties())
			{
				if (row.Table.Columns.Contains(prop.Name) &&
					row[prop.Name] != DBNull.Value)
				{
					SetPropertyValue(prop, destObj, row[prop.Name]);
				}
			}

			if (relation != null)
			{
				foreach (string name in relation.Keys)
				{
					var temp = type.GetProperty(relation[name].ToString());
					if (temp != null &&
						row[name] != DBNull.Value)
					{
						SetPropertyValue(temp, destObj, row[name]);
					}
				}
			}

			return destObj;
		}

		/// <summary>
		/// 将数据行转换成数据实体
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="dt"></param>
		/// <returns></returns>
		public static T ToModel<T>(DataTable dt)
		{
			var type = typeof(T);
			var destObj = Activator.CreateInstance<T>();

			if (dt.Rows.Count > 0)
			{
				var row = dt.Rows[0];
				foreach (PropertyInfo prop in type.GetProperties().Where(prop => row.Table.Columns.Contains(prop.Name) &&
																				 row[prop.Name] != DBNull.Value))
				{
					SetPropertyValue(prop, destObj, row[prop.Name]);
				}
			}
			else
			{
				destObj = default(T);
			}

			return destObj;
		}

		/// <summary>
		/// 将数据行转换成数据实体
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="ds"></param>
		/// <returns></returns>
		public static T ToModel<T>(DataSet ds)
		{
			return ds.Tables.Count > 0 ? ToModel<T>(ds.Tables[0]) : default(T);
		}

		/// <summary>
		/// 将多数据行转换成数据实体列表
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="rows"></param>
		/// <param name="relation"></param>
		/// <returns></returns>
		public static List<T> ToList<T>(IEnumerable<DataRow> rows, Hashtable relation = null)
		{
			var dataRows = rows as DataRow[] ?? rows.ToArray();
			if (rows == null) return null;
			if (!dataRows.Any()) return new List<T>();
			return dataRows.Select(row => ToModel<T>(row, relation)).ToList();
		}

		/// <summary>
		/// 根据数据表生成相应的实体对象列表
		/// </summary>
		/// <typeparam name="T">实体类型</typeparam>
		/// <param name="srcDt">数据</param>
		/// <param name="relation">数据库表列名与对象属性名对应关系；如果列名与实体对象属性名相同，该参数可为空</param>
		/// <returns>对象列表</returns>
		public static List<T> ToList<T>(DataTable srcDt, Hashtable relation = null)
		{
			if (srcDt == null) return null;
			if (srcDt.Rows.Count <= 0) return new List<T>();
			return (from DataRow row in srcDt.Rows select ToModel<T>(row, relation)).ToList();
		}

		/// <summary>
		/// 将数据集转换成数据实体列表
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="ds"></param>
		/// <param name="relation"></param>
		/// <returns></returns>
		public static List<T> ToList<T>(DataSet ds, Hashtable relation = null)
		{
			var drClec = ds.Tables[0].Rows;
			return ToList<T>(drClec.Cast<DataRow>().ToArray(), relation);
		}

		/// <summary>
		/// 将集合类转换成DataTable
		/// </summary>
		/// <param name="list">集合</param>
		/// <returns></returns>
		public static DataTable ToDataTable(IList list)
		{
			var result = new DataTable();
			if (list.Count <= 0) return result;
			var propertys = list[0].GetType().GetProperties();
			foreach (PropertyInfo pi in propertys)
			{
				result.Columns.Add(pi.Name, pi.PropertyType);
			}
			foreach (object t in list)
			{
				var tempList = new ArrayList();
				foreach (PropertyInfo pi in propertys)
				{
					var obj = pi.GetValue(t, null);
					tempList.Add(obj);
				}
				var array = tempList.ToArray();
				result.LoadDataRow(array, true);
			}
			return result;
		}

		/// <summary>
		/// 将泛型集合类转换成DataTable
		/// </summary>
		/// <typeparam name="T">集合项类型</typeparam>
		/// <param name="list">集合</param>
		/// <returns>数据集(表)</returns>
		public static DataTable ToDataTable<T>(IList<T> list)
		{
			return ToDataTable(list, null);
		}

		/// <summary>
		/// 将泛型集合类转换成DataTable
		/// </summary>
		/// <typeparam name="T">集合项类型</typeparam>
		/// <param name="list">集合</param>
		/// <param name="propertyName">需要返回的列的列名</param>
		/// <returns>数据集(表)</returns>
		public static DataTable ToDataTable<T>(IList<T> list, params string[] propertyName)
		{
			var propertyNameList = new List<string>();
			if (propertyName != null)
			{
				propertyNameList.AddRange(propertyName);
			}
			var result = new DataTable();
			if (list.Count <= 0) return result;
			var propertys = list[0].GetType().GetProperties();
			if (propertyNameList.Count == 0)
			{
				foreach (PropertyInfo pi in propertys)
				{
					var colType = pi.PropertyType;
					if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
					{
						colType = colType.GetGenericArguments()[0];
					}
					result.Columns.Add(pi.Name, colType);
				}
				foreach (T t in list)
				{
					var tempList = new ArrayList();
					foreach (PropertyInfo pi in propertys)
					{
						var obj = pi.GetValue(t, null) ?? DBNull.Value;
						tempList.Add(obj);
					}
					var array = tempList.ToArray();
					result.LoadDataRow(array, true);
				}
			}
			else
			{
				var propList = new List<PropertyInfo>();
				foreach (var pm in propertyNameList)
				{
					var pi = propertys.First(m => m.Name == pm);
					if (pi == null) continue;
					propList.Add(pi);
					var colType = pi.PropertyType;
					if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
					{
						colType = colType.GetGenericArguments()[0];
					}
					result.Columns.Add(pi.Name, colType);
				}
				foreach (T t in list)
				{
					var tempList = new ArrayList();
					foreach (PropertyInfo pi in propList)
					{
						var obj = pi.GetValue(t, null) ?? DBNull.Value;
						tempList.Add(obj);
					}
					var array = tempList.ToArray();
					result.LoadDataRow(array, true);
				}
			}
			return result;
		}

		/// <summary>
		/// 将泛型对象转化为属性对应的对象数组
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="t"></param>
		/// <returns></returns>
		public static object[] ToObjects<T>(T t)
		{
			var type = typeof(T);
			var length = type.GetProperties().Length;
			var objs = new object[length];
			var i = 0;
			foreach (PropertyInfo prop in type.GetProperties())
			{
				objs[i] = prop.GetValue(t, null);
				i++;
			}
			return objs;
		}

		/// <summary>
		/// 将ArrayList对象类型转化为泛型对象
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="objs"></param>
		/// <returns></returns>
		public static T ToModel<T>(IEnumerable<Object> objs)
		{
			var destObj = Activator.CreateInstance<T>();
			try
			{
				var arrObjs = objs.ToArray();
				var type = typeof(T);
				var i = 0;
				foreach (PropertyInfo prop in type.GetProperties())
				{
					prop.SetValue(destObj, arrObjs[i], null);
					i++;
				}
			}
			catch
			{
				// ignored
			}
			return destObj;
		}

		#endregion
	}
}
