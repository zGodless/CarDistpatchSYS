using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using MySql.Data.MySqlClient;
using Npgsql;
using QuickFrame.Model;

namespace QuickFrame.DbConnector.Converter
{
	/// <summary>
	/// 将 QuickFrame 参数转换为数据库参数
	/// </summary>
	static class QfParameterConverter
	{
		/// <summary>
		/// 转换为 MySql 参数
		/// </summary>
		/// <param name="paras"></param>
		/// <returns></returns>
		public static MySqlParameter[] ToMySql(IEnumerable<QfParameter> paras)
		{
			return paras.Select(m =>
			{
				var targetDbType = QfDbTypeConverter.ToMySql(m.QfDbType);
				return new MySqlParameter(m.ParameterName, targetDbType, m.Size, m.Direction, m.IsNullable, m.Precision, m.Scale,
					m.SourceColumn, m.SourceVersion, m.Value);
			}).ToArray();
		}
		/// <summary>
		/// 转换为 MySql 参数
		/// </summary>
		/// <param name="paras"></param>
		/// <returns></returns>
		public static MySqlParameter[] ToMySql(params QfParameter[] paras)
		{
			return ToMySql((IEnumerable<QfParameter>)paras);
		}
		/// <summary>
		/// 转换为 PostgreSql 参数
		/// </summary>
		/// <param name="paras"></param>
		/// <returns></returns>
		public static NpgsqlParameter[] ToPostgreSql(IEnumerable<QfParameter> paras)
		{
			return paras.Select(m =>
			{
				var targetDbType = QfDbTypeConverter.ToPostgreSql(m.QfDbType);
				return new NpgsqlParameter(m.ParameterName, targetDbType, m.Size, m.SourceColumn, m.Direction, m.IsNullable,
					m.Precision, m.Scale, m.SourceVersion, m.Value);
			}).ToArray();
		}
		/// <summary>
		/// 转换为 PostgreSql 参数
		/// </summary>
		/// <param name="paras"></param>
		/// <returns></returns>
		public static NpgsqlParameter[] ToPostgreSql(params QfParameter[] paras)
		{
			return ToPostgreSql((IEnumerable<QfParameter>)paras);
		}
		/// <summary>
		/// 转换为 SqlServer 参数
		/// </summary>
		/// <param name="paras"></param>
		/// <returns></returns>
		public static SqlParameter[] ToSqlServer(IEnumerable<QfParameter> paras)
		{
			return paras.Select(m =>
			{
				var targetDbType = QfDbTypeConverter.ToSqlServer(m.QfDbType);
				return new SqlParameter(m.ParameterName, targetDbType, m.Size, m.Direction, m.IsNullable, m.Precision, m.Scale,
					m.SourceColumn, m.SourceVersion, m.Value);
			}).ToArray();
		}
		/// <summary>
		/// 转换为 SqlServer 参数
		/// </summary>
		/// <param name="paras"></param>
		/// <returns></returns>
		public static SqlParameter[] ToSqlServer(params QfParameter[] paras)
		{
			return ToSqlServer((IEnumerable<QfParameter>)paras);
		}
	}
}
