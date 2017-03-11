using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using QuickFrame.ClientConnector;
using QuickFrame.Common;
using QuickFrame.Common.Converter;
using QuickFrame.Model;

namespace DS.Data
{
	/// <summary>
	///     数据访问基类
	///     Copyright (C) csit
	/// </summary>
	public class DaoBase
	{
		/// <summary>
		///     数据库帮助类
		/// </summary>
		public static QfClientConnector Connector;

		public DaoBase()
		{
			if (Connector == null)
			{
				Connector = new QfClientConnector();
			}
		}

		/// <summary>
		///     判断是否存在某表的某个字段
		/// </summary>
		/// <param name="tableName">表名称</param>
		/// <param name="columnName">列名称</param>
		/// <returns>是否存在</returns>
		protected bool ColumnExists(string tableName, string columnName)
		{
			return Connector.ColumnExists(tableName, columnName);
		}

		/// <summary>
		///     是否存在
		/// </summary>
		/// <param name="fieldName"></param>
		/// <param name="tableName"></param>
		/// <returns></returns>
		protected int GetMaxID(string fieldName, string tableName)
		{
			return Connector.GetMaxID(fieldName, tableName);
		}

		/// <summary>
		///     是否存在
		/// </summary>
		/// <param name="strSql"></param>
		/// <returns></returns>
		protected bool Exists(string strSql)
		{
			return Connector.Exists(strSql);
		}

		/// <summary>
		///     是否存在
		/// </summary>
		/// <param name="strSql"></param>
		/// <param name="cmdParms"></param>
		/// <returns></returns>
		protected bool Exists(string strSql, params QfParameter[] cmdParms)
		{
			return Connector.Exists(strSql, cmdParms);
		}

		/// <summary>
		///     表是否存在
		/// </summary>
		/// <param name="tableName"></param>
		/// <returns></returns>
		protected bool TabExists(string tableName)
		{
			return Connector.TabExists(tableName);
		}

		/// <summary>
		///     执行SQL语句，返回影响的记录数
		/// </summary>
		/// <param name="strSql">SQL语句</param>
		/// <returns>影响的记录数</returns>
		protected int ExecuteSql(string strSql)
		{
			return Connector.ExecuteSql(strSql);
		}

		protected int ExecuteSqlByTime(string strSql)
		{
			return Connector.ExecuteSqlByTime(strSql);
		}

		protected int ExecuteSqlByTime(string strSql, int timeout)
		{
			return Connector.ExecuteSqlByTime(strSql, timeout);
		}

		/// <summary>
		///     执行多条SQL语句，实现数据库事务。
		/// </summary>
		/// <param name="strSqlList">多条SQL语句</param>
		protected int ExecuteSqlTran(List<String> strSqlList)
		{
			return Connector.ExecuteSqlTran(strSqlList);
		}

		/// <summary>
		///     执行带一个存储过程参数的的SQL语句。
		/// </summary>
		/// <param name="strSql">SQL语句</param>
		/// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
		/// <returns>影响的记录数</returns>
		protected int ExecuteSql(string strSql, string content)
		{
			return Connector.ExecuteSql(strSql, content);
		}

		/// <summary>
		///     执行带一个存储过程参数的的SQL语句。
		/// </summary>
		/// <param name="strSql">SQL语句</param>
		/// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
		/// <returns>影响的记录数</returns>
		protected object ExecuteSqlGet(string strSql, string content)
		{
			return Connector.ExecuteSqlGet(strSql, content);
		}

		/// <summary>
		///     向数据库里插入图像格式的字段(和上面情况类似的另一种实例)
		/// </summary>
		/// <param name="strSql">SQL语句</param>
		/// <param name="fs">图像字节,数据库的字段类型为image的情况</param>
		/// <returns>影响的记录数</returns>
		protected int ExecuteSqlInsertImg(string strSql, byte[] fs)
		{
			return Connector.ExecuteSqlInsertImg(strSql, fs);
		}

		/// <summary>
		///     执行一条计算查询结果语句，返回查询结果（object）。
		/// </summary>
		/// <param name="strSql">计算查询结果语句</param>
		/// <returns>查询结果（object）</returns>
		protected object GetSingle(string strSql)
		{
			return Connector.GetSingle(strSql);
		}

		protected object GetSingle(string strSql, int timeout)
		{
			return Connector.GetSingle(strSql, timeout);
		}

		/// <summary>
		///     执行查询语句，返回DataSet
		/// </summary>
		/// <param name="strSql">查询语句</param>
		/// <returns>DataSet</returns>
		protected DataSet Query(string strSql)
		{
			return Connector.Query(strSql);
		}

		protected DataSet Query(string strSql, int timeout)
		{
			return Connector.Query(strSql, timeout);
		}

		/// <summary>
		///     执行SQL语句，返回影响的记录数
		/// </summary>
		/// <param name="strSql">SQL语句</param>
		/// <param name="cmdParms"></param>
		/// <returns>影响的记录数</returns>
		protected int ExecuteSql(string strSql, params QfParameter[] cmdParms)
		{
			return Connector.ExecuteSql(strSql, cmdParms);
		}

		/// <summary>
		///     执行多条SQL语句，实现数据库事务。
		/// </summary>
		/// <param name="strSqlList">SQL语句的哈希表（key为sql语句，value是该语句的MyQfParameter[]）</param>
		protected void ExecuteSqlTran(Hashtable strSqlList)
		{
			Connector.ExecuteSqlTran(strSqlList);
		}

		/// <summary>
		///     执行多条SQL语句，实现数据库事务。
		/// </summary>
		/// <param name="cmdList"></param>
		protected int ExecuteSqlTran(List<QfCommandInfo> cmdList)
		{
			return Connector.ExecuteSqlTran(cmdList);
		}

		/// <summary>
		///     执行多条SQL语句，实现数据库事务。
		/// </summary>
		/// <param name="strSqlList">SQL语句的哈希表（key为sql语句，value是该语句的MyQfParameter[]）</param>
		protected void ExecuteSqlTranWithIndentity(List<QfCommandInfo> strSqlList)
		{
			Connector.ExecuteSqlTranWithIndentity(strSqlList);
		}

		/// <summary>
		///     执行多条SQL语句，实现数据库事务。
		/// </summary>
		/// <param name="strSqlList">SQL语句的哈希表（key为sql语句，value是该语句的MyQfParameter[]）</param>
		protected void ExecuteSqlTranWithIndentity(Hashtable strSqlList)
		{
			Connector.ExecuteSqlTranWithIndentity(strSqlList);
		}

		/// <summary>
		///     执行一条计算查询结果语句，返回查询结果（object）。
		/// </summary>
		/// <param name="strSql">计算查询结果语句</param>
		/// <param name="cmdParms"></param>
		/// <returns>查询结果（object）</returns>
		protected object GetSingle(string strSql, params QfParameter[] cmdParms)
		{
			return Connector.GetSingle(strSql, cmdParms);
		}

		/// <summary>
		///     执行查询语句，返回List
		/// </summary>
		/// <param name="strSql">查询语句</param>
		/// <returns>MySqlDataReader</returns>
		protected List<T> QueryGetList<T>(string strSql)
		{
			var ds = Connector.Query(strSql);
			return ModelConvert.ToList<T>(ds);
		}

		/// <summary>
		///     执行查询语句，返回List
		/// </summary>
		/// <param name="strSql">查询语句</param>
		/// <param name="cmdParms"></param>
		/// <returns>MySqlDataReader</returns>
		protected List<T> QueryGetList<T>(string strSql, params QfParameter[] cmdParms)
		{
			var ds = Connector.Query(strSql, cmdParms);
			return ModelConvert.ToList<T>(ds);
		}

		/// <summary>
		///     执行查询语句，返回DataSet
		/// </summary>
		/// <param name="strSql">查询语句</param>
		/// <param name="cmdParms"></param>
		/// <returns>DataSet</returns>
		protected DataSet Query(string strSql, params QfParameter[] cmdParms)
		{
			return Connector.Query(strSql, cmdParms);
		}

		/// <summary>
		///     执行存储过程，返回MySqlDataReader  ( 注意：调用该方法后，一定要对MySqlDataReader进行Close )
		/// </summary>
		/// <param name="storedProcName">存储过程名</param>
		/// <param name="parameters">存储过程参数</param>
		/// <returns>MySqlDataReader</returns>
		protected List<T> RunProcedureGetList<T>(string storedProcName, ref Dictionary<string, QfParameter> parameters)
		{
			var ds = Connector.RunProcedure(storedProcName, ref parameters);
			return ModelConvert.ToList<T>(ds);
		}

		/// <summary>
		///     执行存储过程，返回MySqlDataReader  ( 注意：调用该方法后，一定要对MySqlDataReader进行Close )
		/// </summary>
		/// <param name="storedProcName">存储过程名</param>
		/// <param name="parameters">存储过程参数</param>
		/// <returns>MySqlDataReader</returns>
		protected List<T> RunProcedureGetList<T>(string storedProcName, ref QfParameter[] parameters)
		{
			var ds = Connector.RunProcedureDataSet(storedProcName, ref parameters);
			return ModelConvert.ToList<T>(ds);
		}

		/// <summary>
		///     执行存储过程
		/// </summary>
		/// <param name="storedProcName">存储过程名</param>
		/// <param name="parameters">存储过程参数</param>
		/// <param name="tableName">DataSet结果中的表名</param>
		/// <returns>DataSet</returns>
		protected DataSet RunProcedure(string storedProcName, ref QfParameter[] parameters, string tableName)
		{
			return Connector.RunProcedure(storedProcName, ref parameters, tableName);
		}

		protected DataSet RunProcedure(string storedProcName, ref QfParameter[] parameters, string tableName, int timeout)
		{
			return Connector.RunProcedure(storedProcName, ref parameters, tableName, timeout);
		}

		/// <summary>
		///     执行存储过程
		/// </summary>
		/// <param name="storedProcName">存储过程名</param>
		/// <param name="parameters">存储过程参数</param>
		/// <returns>DataSet</returns>
		protected DataSet RunProcedureDataSet(string storedProcName, ref QfParameter[] parameters)
		{
			return Connector.RunProcedureDataSet(storedProcName, ref parameters);
		}

		/// <summary>
		///     执行存储过程，返回影响的行数
		/// </summary>
		/// <param name="storedProcName">存储过程名</param>
		/// <param name="parameters">存储过程参数</param>
		/// <param name="rowsAffected">影响的行数</param>
		/// <returns></returns>
		protected int RunProcedure(string storedProcName, ref QfParameter[] parameters, out int rowsAffected)
		{
			return Connector.RunProcedure(storedProcName, ref parameters, out rowsAffected);
		}

		/// <summary>
		///     执行存储过程
		/// </summary>
		/// <param name="storedProcName">存储过程名</param>
		/// <param name="parameters">存储过程参数</param>
		/// <returns></returns>
		protected bool RunProcedure_(string storedProcName, ref Dictionary<string, QfParameter> parameters)
		{
			return Connector.RunProcedure_(storedProcName, ref parameters);
		}

		/// <summary>
		///     执行存储过程
		/// </summary>
		/// <param name="storedProcName">存储过程名</param>
		/// <param name="parameters">存储过程参数</param>
		/// <returns></returns>
		protected bool RunProcedure_(string storedProcName, ref QfParameter[] parameters)
		{
			return Connector.RunProcedure_(storedProcName, ref parameters);
		}
        public DateTime GetServerDateTime()
        {
            return Connector.GetServerDateTime();
        }
	}
}