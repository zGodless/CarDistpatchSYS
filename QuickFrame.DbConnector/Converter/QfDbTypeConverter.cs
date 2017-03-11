using System.Data;
using MySql.Data.MySqlClient;
using NpgsqlTypes;
using QuickFrame.Common;
using QuickFrame.Common.Exception;
using QuickFrame.Model;

namespace QuickFrame.DbConnector.Converter
{
	/// <summary>
	/// 将 QuickFrame 数据类型转换为数据库数据类型
	/// </summary>
	static class QfDbTypeConverter
	{
		/// <summary>
		/// 转换为 MySql 数据类型
		/// </summary>
		/// <param name="dbType"></param>
		/// <returns></returns>
		public static MySqlDbType ToMySql(QfDbType dbType)
		{
			switch (dbType)
			{
				case QfDbType.Byte:
				case QfDbType.Int8:
					return MySqlDbType.Byte;
				case QfDbType.Int16:
					return MySqlDbType.Int16;
				case QfDbType.Int24:
					return MySqlDbType.Int24;
				case QfDbType.Int32:
					return MySqlDbType.Int32;
				case QfDbType.Int64:
					return MySqlDbType.Int64;
				case QfDbType.Float:
					return MySqlDbType.Float;
				case QfDbType.Double:
					return MySqlDbType.Double;
				case QfDbType.Decimal:
					return MySqlDbType.Decimal;
				case QfDbType.Numeric:
					return MySqlDbType.Decimal;
				case QfDbType.Real:
					return MySqlDbType.Decimal;
				case QfDbType.Char:
					return MySqlDbType.Byte;
				case QfDbType.NChar:
					return MySqlDbType.Binary;
				case QfDbType.VarChar:
					return MySqlDbType.VarChar;
				case QfDbType.NVarChar:
					return MySqlDbType.VarBinary;
				case QfDbType.Date:
					return MySqlDbType.Date;
				case QfDbType.Time:
					return MySqlDbType.Time;
				case QfDbType.DateTime:
					return MySqlDbType.DateTime;
				case QfDbType.Blob:
					return MySqlDbType.Blob;
				case QfDbType.TinyBlob:
					return MySqlDbType.TinyBlob;
				case QfDbType.MediumBlob:
					return MySqlDbType.MediumBlob;
				case QfDbType.LongBlob:
					return MySqlDbType.LongBlob;
				case QfDbType.String:
					return MySqlDbType.String;
				case QfDbType.VarString:
					return MySqlDbType.VarString;
				case QfDbType.Binary:
					return MySqlDbType.Binary;
				case QfDbType.VarBinary:
					return MySqlDbType.VarBinary;
				case QfDbType.Text:
					return MySqlDbType.Text;
				case QfDbType.TinyText:
					return MySqlDbType.TinyText;
				case QfDbType.MediumText:
					return MySqlDbType.MediumText;
				case QfDbType.LongText:
					return MySqlDbType.LongText;
				case QfDbType.UByte:
					return MySqlDbType.UByte;
				case QfDbType.UInt16:
					return MySqlDbType.UInt16;
				case QfDbType.UInt24:
					return MySqlDbType.UInt24;
				case QfDbType.UInt32:
					return MySqlDbType.UInt32;
				case QfDbType.UInt64:
					return MySqlDbType.UInt64;
				case QfDbType.Guid:
					return MySqlDbType.Guid;
				default:
					throw new QfException("QuickFrame 数据类型超出范围");
			}
		}

		/// <summary>
		/// 转换为 PostgreSql 数据类型
		/// </summary>
		/// <param name="dbType"></param>
		/// <returns></returns>
		public static NpgsqlDbType ToPostgreSql(QfDbType dbType)
		{
			switch (dbType)
			{
				case QfDbType.Int8:
				case QfDbType.Int16:
					return NpgsqlDbType.Smallint;
				case QfDbType.Int24:
				case QfDbType.Int32:
					return NpgsqlDbType.Integer;
				case QfDbType.Int64:
					return NpgsqlDbType.Bigint;
				case QfDbType.Float:
					return NpgsqlDbType.Real;
				case QfDbType.Double:
					return NpgsqlDbType.Double;
				case QfDbType.Decimal:
				case QfDbType.Numeric:
					return NpgsqlDbType.Numeric;
				case QfDbType.Real:
					return NpgsqlDbType.Real;
				case QfDbType.Char:
				case QfDbType.NChar:
					return NpgsqlDbType.Char;
				case QfDbType.VarChar:
				case QfDbType.NVarChar:
					return NpgsqlDbType.Varchar;
				case QfDbType.Date:
					return NpgsqlDbType.Date;
				case QfDbType.Time:
					return NpgsqlDbType.Time;
				case QfDbType.DateTime:
					return NpgsqlDbType.Timestamp;
				case QfDbType.Blob:
				case QfDbType.TinyBlob:
				case QfDbType.MediumBlob:
				case QfDbType.LongBlob:
					return NpgsqlDbType.Bytea;
				case QfDbType.String:
				case QfDbType.VarString:
				case QfDbType.Text:
				case QfDbType.TinyText:
				case QfDbType.MediumText:
				case QfDbType.LongText:
					return NpgsqlDbType.Text;
				case QfDbType.Binary:
				case QfDbType.VarBinary:
					return NpgsqlDbType.Bytea;
				case QfDbType.Byte:
				case QfDbType.UByte:
					return NpgsqlDbType.Bytea;
				case QfDbType.UInt16:
					return NpgsqlDbType.Smallint;
				case QfDbType.UInt24:
					return NpgsqlDbType.Integer;
				case QfDbType.UInt32:
					return NpgsqlDbType.Integer;
				case QfDbType.UInt64:
					return NpgsqlDbType.Bigint;
				case QfDbType.Guid:
					return NpgsqlDbType.Uuid;
				default:
					throw new QfException("QuickFrame 数据类型超出范围");
			}
		}

		/// <summary>
		/// 转换为 SqlServer 数据类型
		/// </summary>
		/// <param name="dbType"></param>
		/// <returns></returns>
		public static SqlDbType ToSqlServer(QfDbType dbType)
		{
			switch (dbType)
			{
				case QfDbType.Byte:
				case QfDbType.Int8:
					return SqlDbType.TinyInt;
				case QfDbType.Int16:
					return SqlDbType.SmallInt;
				case QfDbType.Int24:
				case QfDbType.Int32:
					return SqlDbType.Int;
				case QfDbType.Int64:
					return SqlDbType.BigInt;
				case QfDbType.Float:
					return SqlDbType.Float;
				case QfDbType.Double:
					return SqlDbType.Float;
				case QfDbType.Decimal:
					return SqlDbType.Decimal;
				case QfDbType.Numeric:
					return SqlDbType.Decimal;
				case QfDbType.Real:
					return SqlDbType.Real;
				case QfDbType.Char:
					return SqlDbType.Char;
				case QfDbType.NChar:
					return SqlDbType.NChar;
				case QfDbType.VarChar:
					return SqlDbType.VarChar;
				case QfDbType.NVarChar:
					return SqlDbType.NVarChar;
				case QfDbType.Date:
					return SqlDbType.Date;
				case QfDbType.Time:
					return SqlDbType.Time;
				case QfDbType.DateTime:
					return SqlDbType.DateTime;
				case QfDbType.Blob:
				case QfDbType.TinyBlob:
				case QfDbType.MediumBlob:
				case QfDbType.LongBlob:
					return SqlDbType.VarBinary;
				case QfDbType.String:
					return SqlDbType.NChar;
				case QfDbType.VarString:
					return SqlDbType.NVarChar;
				case QfDbType.Binary:
					return SqlDbType.Binary;
				case QfDbType.VarBinary:
					return SqlDbType.VarBinary;
				case QfDbType.Text:
				case QfDbType.TinyText:
				case QfDbType.MediumText:
				case QfDbType.LongText:
					return SqlDbType.NText;
				case QfDbType.UByte:
					return SqlDbType.Binary;
				case QfDbType.UInt16:
					return SqlDbType.SmallInt;
				case QfDbType.UInt24:
					return SqlDbType.Int;
				case QfDbType.UInt32:
					return SqlDbType.Int;
				case QfDbType.UInt64:
					return SqlDbType.BigInt;
				case QfDbType.Guid:
					return SqlDbType.UniqueIdentifier;
				default:
					throw new QfException("QuickFrame 数据类型超出范围");
			}
		}
	}
}
