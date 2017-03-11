using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using QuickFrame.DbConnector.DbDriver;
using QuickFrame.Model;

namespace QuickFrame.DbConnector
{
	/// <summary>
	/// 数据访问帮助类
	/// </summary>
	public class QfDbConnector
	{
		#region 初始化

		/// <summary>
		///     构造数据库访问类
		/// </summary>
		public QfDbConnector()
		{
			switch (DbType)
			{
				case "postgresql":
					_db = new DbPostgreSql();
					break;
				case "sqlserver":
					_db = new DbSqlServer();
					break;
				default:
					_db = new DbMySql();
					break;
			}
		}

		/// <summary>
		///     构造数据库访问类
		/// </summary>
		public QfDbConnector(string binPath)
		{
			switch (DbType)
			{
				case "postgresql":
					_db = new DbPostgreSql(binPath);
					break;
				case "sqlserver":
					_db = new DbSqlServer(binPath);
					break;
				default:
					_db = new DbMySql(binPath);
					break;
			}
		}

		#endregion

		#region 属性/字段

		/// <summary>
		///     数据库类型
		/// </summary>
		private static readonly string DbType = ConfigurationManager.AppSettings["DbType"].ToLower();

		private readonly DbBase _db;

		#endregion

		#region 内部方法

		#endregion

		#region 公用方法

		/// <summary>
		///     判断是否存在某表的某个字段
		/// </summary>
		/// <param name="tableName">表名称</param>
		/// <param name="columnName">列名称</param>
		/// <returns>是否存在</returns>
		public bool ColumnExists(string tableName, string columnName)
		{
			return _db.ColumnExists(tableName, columnName);
		}

		/// <summary>
		///     获取最大ID
		/// </summary>
		/// <param name="tableName"></param>
		/// <param name="fieldName"></param>
		/// <returns></returns>
		public int GetMaxID(string tableName, string fieldName)
		{
			return _db.GetMaxID(tableName, fieldName);
		}

		/// <summary>
		///     表是否存在
		/// </summary>
		/// <param name="tableName"></param>
		/// <returns></returns>
		public bool TabExists(string tableName)
		{
			return _db.TabExists(tableName);
		}

		/// <summary>
		///     根据SQL判断是否存在
		/// </summary>
		/// <param name="strSql"></param>
		/// <returns></returns>
		public bool Exists(string strSql)
		{
			return _db.Exists(strSql);
		}

		/// <summary>
		///     根据SQL判断是否存在
		/// </summary>
		/// <param name="strSql"></param>
		/// <param name="cmdParms"></param>
		/// <returns></returns>
		public bool Exists(string strSql, params QfParameter[] cmdParms)
		{
			return _db.Exists(strSql, cmdParms);
		}

		#endregion 公用方法

		#region 执行简单SQL语句

		/// <summary>
		///     执行SQL语句，返回影响的记录数
		/// </summary>
		/// <param name="strSql">SQL语句</param>
		/// <returns>影响的记录数</returns>
		public int ExecuteSql(string strSql)
		{
			return _db.ExecuteSql(strSql);
		}

		/// <summary>
		///     在超时时间内执行SQL
		/// </summary>
		/// <param name="strSql"></param>
		/// <returns></returns>
		public int ExecuteSqlByTime(string strSql)
		{
			return ExecuteSqlByTime(strSql, 0);
		}

		/// <summary>
		///     在超时时间内执行SQL
		/// </summary>
		/// <param name="strSql"></param>
		/// <param name="timeout"></param>
		/// <returns></returns>
		public int ExecuteSqlByTime(string strSql, int timeout)
		{
			return _db.ExecuteSqlByTime(strSql, timeout);
		}

		/// <summary>
		///     执行多条SQL语句，实现数据库事务。
		/// </summary>
		/// <param name="strSqlList">多条SQL语句</param>
		public int ExecuteSqlTran(List<String> strSqlList)
		{
			return _db.ExecuteSqlTran(strSqlList);
		}

		/// <summary>
		///     执行带一个存储过程参数的的SQL语句。
		/// </summary>
		/// <param name="strSql">SQL语句</param>
		/// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
		/// <returns>影响的记录数</returns>
		public int ExecuteSql(string strSql, string content)
		{
			return _db.ExecuteSql(strSql, content);
		}

		/// <summary>
		///     执行带一个存储过程参数的的SQL语句。
		/// </summary>
		/// <param name="strSql">SQL语句</param>
		/// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
		/// <returns>影响的记录数</returns>
		public object ExecuteSqlGet(string strSql, string content)
		{
			return _db.ExecuteSqlGet(strSql, content);
		}

		/// <summary>
		///     向数据库里插入图像格式的字段(和上面情况类似的另一种实例)
		/// </summary>
		/// <param name="strSql">SQL语句</param>
		/// <param name="fs">图像字节,数据库的字段类型为image的情况</param>
		/// <returns>影响的记录数</returns>
		public int ExecuteSqlInsertImg(string strSql, byte[] fs)
		{
			return _db.ExecuteSqlInsertImg(strSql, fs);
		}

		/// <summary>
		///     执行一条计算查询结果语句，返回查询结果（object）。
		/// </summary>
		/// <param name="strSql">计算查询结果语句</param>
		/// <returns>查询结果（object）</returns>
		public object GetSingle(string strSql)
		{
			return _db.GetSingle(strSql);
		}

		/// <summary>
		///     执行SQL，返回单一结果
		/// </summary>
		/// <param name="strSql"></param>
		/// <param name="timeout"></param>
		/// <returns></returns>
		public object GetSingle(string strSql, int timeout)
		{
			return _db.GetSingle(strSql, timeout);
		}

		/// <summary>
		///     执行查询语句，返回DataSet
		/// </summary>
		/// <param name="strSql">查询语句</param>
		/// <returns>DataSet</returns>
		public DataSet Query(string strSql)
		{
			return _db.Query(strSql);
		}

		/// <summary>
		///     执行SQL，返回数据集
		/// </summary>
		/// <param name="strSql"></param>
		/// <param name="timeout"></param>
		/// <returns></returns>
		public DataSet Query(string strSql, int timeout)
		{
			return _db.Query(strSql, timeout);
		}

		#endregion 执行简单SQL语句

		#region 执行带参数的SQL语句

		/// <summary>
		///     执行SQL语句，返回影响的记录数
		/// </summary>
		/// <param name="strSql">SQL语句</param>
		/// <param name="cmdParms"></param>
		/// <returns>影响的记录数</returns>
		public int ExecuteSql(string strSql, params QfParameter[] cmdParms)
		{
			return _db.ExecuteSql(strSql, cmdParms);
		}

		/// <summary>
		///     执行多条SQL语句，实现数据库事务。
		/// </summary>
		/// <param name="strSqlList">SQL语句的哈希表（key为sql语句，value是该语句的QfParameter[]）</param>
		public void ExecuteSqlTran(Hashtable strSqlList)
		{
			_db.ExecuteSqlTran(strSqlList);
		}

		/// <summary>
		///     执行多条SQL语句，实现数据库事务。
		/// </summary>
		/// <param name="cmdList"></param>
		public int ExecuteSqlTran(List<QfCommandInfo> cmdList)
		{
			return _db.ExecuteSqlTran(cmdList);
		}

		/// <summary>
		///     执行多条SQL语句，实现数据库事务。
		/// </summary>
		/// <param name="strSqlList">SQL语句的哈希表（key为sql语句，value是该语句的QfParameter[]）</param>
		public void ExecuteSqlTranWithIndentity(List<QfCommandInfo> strSqlList)
		{
			_db.ExecuteSqlTranWithIndentity(strSqlList);
		}

		/// <summary>
		///     执行多条SQL语句，实现数据库事务。
		/// </summary>
		/// <param name="strSqlList">SQL语句的哈希表（key为sql语句，value是该语句的QfParameter[]）</param>
		public void ExecuteSqlTranWithIndentity(Hashtable strSqlList)
		{
			_db.ExecuteSqlTranWithIndentity(strSqlList);
		}

		/// <summary>
		///     执行一条计算查询结果语句，返回查询结果（object）。
		/// </summary>
		/// <param name="strSql">计算查询结果语句</param>
		/// <param name="cmdParms">参数列表</param>
		/// <returns>查询结果（object）</returns>
		public object GetSingle(string strSql, params QfParameter[] cmdParms)
		{
			return _db.GetSingle(strSql, cmdParms);
		}

		/// <summary>
		///     执行查询语句，返回DataSet
		/// </summary>
		/// <param name="strSql">查询语句</param>
		/// <param name="cmdParms"></param>
		/// <returns>DataSet</returns>
		public DataSet Query(string strSql, params QfParameter[] cmdParms)
		{
			return _db.Query(strSql, cmdParms);
		}

		#endregion 执行带参数的SQL语句

		#region 存储过程操作

		/// <summary>
		///     执行存储过程，返回DataSet
		/// </summary>
		/// <param name="storedProcName">存储过程名</param>
		/// <param name="parameters">存储过程参数</param>
		/// <returns>MySqlDataReader</returns>
		public DataSet RunProcedure(string storedProcName, Dictionary<string, QfParameter> parameters)
		{
			return _db.RunProcedure(storedProcName, parameters);
		}

		/// <summary>
		///     执行存储过程
		/// </summary>
		/// <param name="storedProcName">存储过程名</param>
		/// <param name="parameters">存储过程参数</param>
		/// <param name="tableName">DataSet结果中的表名</param>
		/// <returns>DataSet</returns>
		public DataSet RunProcedure(string storedProcName, QfParameter[] parameters, string tableName)
		{
			return _db.RunProcedure(storedProcName, parameters, tableName);
		}

		public DataSet RunProcedure(string storedProcName, QfParameter[] parameters, string tableName, int timeout)
		{
			return _db.RunProcedure(storedProcName, parameters, tableName, timeout);
		}

		/// <summary>
		///     执行存储过程
		/// </summary>
		/// <param name="storedProcName">存储过程名</param>
		/// <param name="parameters">存储过程参数</param>
		/// <returns>DataSet</returns>
		public DataSet RunProcedureDataSet(string storedProcName, QfParameter[] parameters)
		{
			return _db.RunProcedureDataSet(storedProcName, parameters);
		}

		/// <summary>
		///     执行存储过程，返回影响的行数
		/// </summary>
		/// <param name="storedProcName">存储过程名</param>
		/// <param name="parameters">存储过程参数</param>
		/// <param name="rowsAffected">影响的行数</param>
		/// <returns></returns>
		public int RunProcedure(string storedProcName, QfParameter[] parameters, out int rowsAffected)
		{
			return _db.RunProcedure(storedProcName, parameters, out rowsAffected);
		}

		/// <summary>
		///     执行存储过程
		/// </summary>
		/// <param name="storedProcName">存储过程名</param>
		/// <param name="parameters">存储过程参数</param>
		/// <returns></returns>
		public bool RunProcedure_(string storedProcName, Dictionary<string, QfParameter> parameters)
		{
			return _db.RunProcedure_(storedProcName, parameters);
		}

		/// <summary>
		///     执行存储过程
		/// </summary>
		/// <param name="storedProcName">存储过程名</param>
		/// <param name="parameters">存储过程参数</param>
		/// <returns></returns>
		public bool RunProcedure_(string storedProcName, params QfParameter[] parameters)
		{
			return _db.RunProcedure_(storedProcName, parameters);
		}

		#endregion 存储过程操作
	}
}
