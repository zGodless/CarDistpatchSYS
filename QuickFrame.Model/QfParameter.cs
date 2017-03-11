using System;
using System.Collections;
using System.Data;

namespace QuickFrame.Model
{
	/// <summary>
	/// QuickFrame 连接层参数
	/// </summary>
	[Serializable]
	public class QfParameter
	{
		#region 初始化

		public QfParameter()
		{
			_inferType = true;
			Init();
		}

		public QfParameter(string parameterName, QfDbType dbType)
			:this(parameterName, null)
		{
			QfDbType = dbType;
		}

		public QfParameter(string parameterName, object value)
			:this()
		{
			ParameterName = parameterName;
			Value = value;
		}

		public QfParameter(string parameterName, QfDbType dbType, int size)
			: this(parameterName, dbType)
		{
			Size = size;
		}

		public QfParameter(string parameterName, QfDbType dbType, int size, string sourceColumn)
			: this(parameterName, dbType)
		{
			Size = size;
			Direction = ParameterDirection.Input;
			SourceColumn = sourceColumn;
			SourceVersion = DataRowVersion.Current;
		}

		internal QfParameter(string name, QfDbType type, ParameterDirection dir, string col, DataRowVersion ver,
			object val)
			: this(name, type)
		{
			Direction = dir;
			SourceColumn = col;
			SourceVersion = ver;
			Value = val;
		}

		public QfParameter(string parameterName, QfDbType dbType, int size, ParameterDirection direction,
			bool isNullable, byte precision, byte scale, string sourceColumn, DataRowVersion sourceVersion, object value)
			: this(parameterName, dbType, size, sourceColumn)
		{
			Direction = direction;
			SourceVersion = sourceVersion;
			IsNullable = isNullable;
			Precision = precision;
			Scale = scale;
			Value = value;
		}
		private void Init()
		{
			SourceVersion = DataRowVersion.Current;
			Direction = ParameterDirection.Input;
		}
 
		#endregion

		#region 属性
		public DbType DbType { get; set; }
		public ParameterDirection Direction { get; set; }
		public bool IsNullable { get; set; }

		public QfDbType QfDbType { get; set; }
		public string ParameterName { get; set; }
		public IList PossibleValues { get; internal set; }
		public byte Precision { get; set; }
		public byte Scale { get; set; }
		public int Size { get; set; }
		public string SourceColumn { get; set; }
		public bool SourceColumnNullMapping { get; set; }
		public DataRowVersion SourceVersion { get; set; }

		private bool _inferType;

		private object _value;

		public object Value
		{
			get { return _value; }
			set
			{
				//修正不同平台下日期不对应问题
				if (value != null && value.GetType().Name == "DateTime")
				{
					var dt = (DateTime) value;
					if (dt.Millisecond != 0)
					{
						dt = new DateTime(dt.Ticks - (dt.Ticks % TimeSpan.TicksPerSecond), DateTimeKind.Unspecified);
					}
					if (dt.Kind != DateTimeKind.Unspecified)
					{
						var newdt = DateTime.SpecifyKind(dt, DateTimeKind.Unspecified);
						_value = newdt;
					}
					else
					{
						_value = dt;
					}
				}
				else
				{
					_value = value;
				}
				var buffer = value as byte[];
				var str = value as string;
				if (buffer != null)
				{
					Size = buffer.Length;
				}
				else if (str != null)
				{
					Size = str.Length;
				}
				if (_inferType)
				{
					SetTypeFromValue();
				}
			}
		}

		#endregion

		#region 方法

		private void SetTypeFromValue()
		{
			if ((_value != null) && (_value != DBNull.Value))
			{
				if (_value is Guid)
				{
					QfDbType = QfDbType.Guid;
				}
				else if (_value is TimeSpan)
				{
					QfDbType = QfDbType.Time;
				}
				else if (_value is bool)
				{
					QfDbType = QfDbType.Bool;
				}
				else
				{
					var type = _value.GetType();
					switch (type.Name)
					{
						case "SByte":
							QfDbType = QfDbType.Byte;
							return;

						case "Byte":
							QfDbType = QfDbType.UByte;
							return;

						case "Int16":
							QfDbType = QfDbType.Int16;
							return;

						case "UInt16":
							QfDbType = QfDbType.UInt16;
							return;

						case "Int32":
							QfDbType = QfDbType.Int32;
							return;

						case "UInt32":
							QfDbType = QfDbType.UInt32;
							return;

						case "Int64":
							QfDbType = QfDbType.Int64;
							return;

						case "UInt64":
							QfDbType = QfDbType.UInt64;
							return;

						case "DateTime":
							QfDbType = QfDbType.DateTime;
							return;

						case "String":
							QfDbType = QfDbType.VarChar;
							return;

						case "Single":
							QfDbType = QfDbType.Float;
							return;

						case "Double":
							QfDbType = QfDbType.Double;
							return;

						case "Decimal":
							QfDbType = QfDbType.Decimal;
							return;
					}
					QfDbType = type.BaseType == typeof(Enum) ? QfDbType.Int32 : QfDbType.Blob;
				}
			}
		}

		public QfParameter Clone()
		{
			return new QfParameter(ParameterName, QfDbType, Direction, SourceColumn, SourceVersion, Value) { _inferType = _inferType};
		}

		#endregion
	}
}
