using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using QuickFrame.Common.Exception;
using QuickFrame.DbConnector.Converter;
using QuickFrame.Model;
using QuickFrame.Repository;

namespace QuickFrame.DbConnector.DbDriver
{
	/// <summary>
	/// 数据库驱动基类
	/// </summary>
	abstract class DbBase
	{
		#region 初始化

		/// <summary>
		///     初始化数据基类
		/// </summary>
		protected DbBase()
		{
			ConStr = DbConnStrGenerator.ConnectionString;
			_repository = new QfRepository();
		}

		/// <summary>
		///     初始化数据基类
		/// </summary>
		protected DbBase(string binPath)
			: this()
		{
			ConStr = DbConnStrGenerator.ConnectionString;

			//动态加载仓库
			try
			{
				var repoAssembly = ConfigurationManager.AppSettings["RepositoryAssembly"];
				var repoType = ConfigurationManager.AppSettings["RepositoryType"];
				if (string.IsNullOrEmpty(repoAssembly)) repoAssembly = "Repository";
				if (string.IsNullOrEmpty(repoType)) repoType = "MainRepository";
				var repoPath = Path.Combine(binPath, repoAssembly + ".dll");
				var ass = Assembly.LoadFile(repoPath);
				if (ass == null) throw new QfException("无法加载 SQL 仓库程序集");
				var type = ass.GetType(repoAssembly + "." + repoType);
				_repository = (RepositoryBase) ass.CreateInstance(type.FullName);
			}
			catch (FileLoadException fle)
			{
				throw new QfException("无法加载 SQL 仓库", fle);
			}
			catch (FileNotFoundException fnfe)
			{
				throw new QfException("未找到 SQL 仓库程序集", fnfe);
			}
			catch (BadImageFormatException bife)
			{
				throw new QfException("SQL 仓库程序集文件格式错误", bife);
			}
		}

		static DbBase()
		{
			var appSets = ConfigurationManager.AppSettings;
			AllowAnySql = appSets["AllowAnySql"] == null || ConfigurationManager.AppSettings["AllowAnySql"].Equals("On", StringComparison.OrdinalIgnoreCase);
			SqlCache = appSets["SqlCache"] == null || ConfigurationManager.AppSettings["SqlCache"].Equals("On", StringComparison.OrdinalIgnoreCase);
		}

		#endregion

		#region 属性/字段

		protected string DatabaseType = "";

		/// <summary>
		///     超时时间
		/// </summary>
		protected const int Timeout = 180; //超时默认3分钟

		/// <summary>
		///     是否允许任意SQL
		/// </summary>
		protected static readonly bool AllowAnySql;

		protected static readonly bool SqlCache;

		/// <summary>
		///     SQL缓存
		/// </summary>
		protected static readonly Hashtable HtSql = new Hashtable();

		/// <summary>
		///     数据库连接字符串
		/// </summary>
		protected readonly string ConStr;

		/// <summary>
		/// QuickFrame 仓库
		/// </summary>
		private readonly QfRepository _qfRepository = new QfRepository();

		/// <summary>
		/// 主仓库
		/// </summary>
		private readonly RepositoryBase _repository;

		#endregion

		#region SQL仓库方法

		/// <summary>
		///     获取SQL
		/// </summary>
		/// <param name="sqlStr"></param>
		/// <returns></returns>
		protected string GetSql(string sqlStr)
		{
			var sqlStrTrim = sqlStr.TrimStart();
			string sql;
			if (sqlStrTrim.StartsWith("REPOS:", true, CultureInfo.CurrentCulture))
			{
				var sqlName = sqlStrTrim.Substring(6).TrimEnd();
				if (SqlCache && HtSql.Contains(sqlName))
					return (string) HtSql[sqlName];
				sql = _repository.GetSql("General", sqlName);
				if (SqlCache) HtSql.Add(sqlName, sql);
			}
			else if (sqlStrTrim.StartsWith("REPOS-SPC:", true, CultureInfo.CurrentCulture))
			{
				var sqlName = sqlStrTrim.Substring(10).TrimEnd();
				if (SqlCache && HtSql.Contains(sqlName))
					return (string) HtSql[sqlName];
				sql = _repository.GetSql(DatabaseType, sqlName);
				if (SqlCache) HtSql.Add(sqlName, sql);
			}
			else if (sqlStrTrim.StartsWith("QFREPOS:", true, CultureInfo.CurrentCulture))
			{
				var sqlName = sqlStrTrim.Substring(8).TrimEnd();
				if (SqlCache && HtSql.Contains(sqlName))
					return (string)HtSql[sqlName];
				sql = _qfRepository.GetSql("General", sqlName);
				if (SqlCache) HtSql.Add(sqlName, sql);
			}
			else if (sqlStrTrim.StartsWith("QFREPOS-SPC:", true, CultureInfo.CurrentCulture))
			{
				var sqlName = sqlStrTrim.Substring(12).TrimEnd();
				if (SqlCache && HtSql.Contains(sqlName))
					return (string) HtSql[sqlName];
				sql = _qfRepository.GetSql(DatabaseType, sqlName);
				if (SqlCache) HtSql.Add(sqlName, sql);
			}
			else
			{
				if (!AllowAnySql)
				{
					throw new QfException("配置文件不允许使用任意SQL语句");
				}
				return sqlStrTrim;
			}
			if (sql == null)
			{
				throw new QfException("无法从Repository中找到对应的SQL语句");
			}
			return sql;
		}

		/// <summary>
		///     获取SQL列表
		/// </summary>
		/// <param name="sqlStr"></param>
		/// <returns></returns>
		protected List<string> GetSqlList(string sqlStr)
		{
			var sqlStrTrim = sqlStr.TrimStart();
			List<string> list;
			if (sqlStrTrim.StartsWith("REPOS:", true, CultureInfo.CurrentCulture))
			{
				if (SqlCache && HtSql.Contains(sqlStrTrim)) return (List<string>)HtSql[sqlStrTrim];
				var sqlNameList = sqlStrTrim.Substring(6).Trim().Split(';');
				list = sqlNameList.Select(m => _repository.GetSql("General", m)).ToList();
				if (SqlCache) HtSql.Add(sqlStrTrim, list);
			}
			else if (sqlStrTrim.StartsWith("REPOS-SPC:", true, CultureInfo.CurrentCulture))
			{
				if (SqlCache && HtSql.Contains(sqlStrTrim)) return (List<string>)HtSql[sqlStrTrim];
				var sqlNameList = sqlStrTrim.Substring(10).Trim().Split(';');
				list = sqlNameList.Select(m => _repository.GetSql(DatabaseType, m)).ToList();
				if (SqlCache) HtSql.Add(sqlStrTrim, list);
			}
			else if (sqlStrTrim.StartsWith("QFREPOS:", true, CultureInfo.CurrentCulture))
			{
				if (SqlCache && HtSql.Contains(sqlStrTrim)) return (List<string>)HtSql[sqlStrTrim];
				var sqlNameList = sqlStrTrim.Substring(8).Trim().Split(';');
				list = sqlNameList.Select(m => _qfRepository.GetSql("General", m)).ToList();
				if (SqlCache) HtSql.Add(sqlStrTrim, list);
			}
			else if (sqlStrTrim.StartsWith("QFREPOS-SPC:", true, CultureInfo.CurrentCulture))
			{
				if (SqlCache && HtSql.Contains(sqlStrTrim)) return (List<string>) HtSql[sqlStrTrim];
				var sqlNameList = sqlStrTrim.Substring(12).Trim().Split(';');
				list = sqlNameList.Select(m => _qfRepository.GetSql(DatabaseType, m)).ToList();
				if (SqlCache) HtSql.Add(sqlStrTrim, list);
			}
			else
			{
				if (!AllowAnySql)
				{
					throw new Exception("配置文件不允许使用任意SQL语句");
				}
				return new List<string> { sqlStr };
			}
			if (list.Exists(m => m == null))
			{
				throw new QfException("无法从Repository中找到对应的SQL语句");
			}
			return list;
		}

		/// <summary>
		///     获取SQL列表
		/// </summary>
		/// <param name="sqlStrList"></param>
		/// <returns></returns>
		protected List<string> GetSqlList(IEnumerable<string> sqlStrList)
		{
			return sqlStrList.Select(GetSql).ToList();
		}

		#endregion

		#region 内部方法

		/// <summary>
		/// 获取数据参数
		/// </summary>
		/// <param name="qfParameters"></param>
		/// <returns></returns>
		private DbParameter[] GetDbParameters(IEnumerable<QfParameter> qfParameters)
		{
			switch (DatabaseType)
			{
				case "PostgreSql":
					return QfParameterConverter.ToPostgreSql(qfParameters).Cast<DbParameter>().ToArray();
				case "SqlServer":
					return QfParameterConverter.ToSqlServer(qfParameters).Cast<DbParameter>().ToArray();
				default:
					return QfParameterConverter.ToMySql(qfParameters).Cast<DbParameter>().ToArray();
			}
		}

		/// <summary>
		/// 生成数据命令
		/// </summary>
		/// <returns></returns>
		protected abstract DbCommand GenerateDbCommand();

		/// <summary>
		/// 准备命令
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="trans"></param>
		/// <param name="cmdText"></param>
		/// <param name="cmdParms"></param>
		/// <param name="timeOut"></param>
		protected DbCommand PrepareCommand(DbConnection conn, DbTransaction trans, string cmdText,
			IEnumerable<QfParameter> cmdParms, int timeOut = Timeout)
		{
			var cmd = GenerateDbCommand();
			if (conn.State != ConnectionState.Open)
				conn.Open();
			cmd.Connection = conn;
			cmd.CommandTimeout = timeOut;
			cmdText = GetSql(cmdText);
			cmd.CommandText = cmdText;
			cmd.CommandType = CommandType.Text;
			if (trans != null) cmd.Transaction = trans;
			if (cmdParms == null) return cmd;
			var parms = GetDbParameters(cmdParms);
			foreach (var parameter in parms)
			{
				if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input)
				    && (parameter.Value == null))
				{
					parameter.Value = DBNull.Value;
				}
				cmd.Parameters.Add(parameter);
			}
			return cmd;
		}

		/// <summary>
		///     构建 DbCommand 对象(用来返回一个结果集，而不是一个整数值)
		/// </summary>
		/// <param name="connection">数据库连接</param>
		/// <param name="storedProcName">存储过程名</param>
		/// <param name="parameters">存储过程参数</param>
		/// <returns>DbCommand</returns>
		protected DbCommand BuildQueryCommand(DbConnection connection, string storedProcName,
			Dictionary<string, QfParameter> parameters)
		{
			var command = GenerateDbCommand();
			command.Connection = connection;
			command.CommandText = storedProcName;
			command.CommandType = CommandType.StoredProcedure;
			var parms = GetDbParameters(parameters.Select(kv => kv.Value).Where(parameter => parameter != null));
			foreach (var parameter in parms)
			{
				// 检查未分配值的输出参数,将其分配以DBNull.Value.
				if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
					(parameter.Value == null))
				{
					parameter.Value = DBNull.Value;
				}
				command.Parameters.Add(parameter);
			}

			return command;
		}

		/// <summary>
		///     构建 DbCommand 对象(用来返回一个结果集，而不是一个整数值)
		/// </summary>
		/// <param name="connection">数据库连接</param>
		/// <param name="storedProcName">存储过程名</param>
		/// <param name="parameters">存储过程参数</param>
		/// <returns>DbCommand</returns>
		protected DbCommand BuildQueryCommand(DbConnection connection, string storedProcName,
			IEnumerable<QfParameter> parameters)
		{
			var command = GenerateDbCommand();
			command.Connection = connection;
			command.CommandText = storedProcName;
			command.CommandType = CommandType.StoredProcedure;
			var parms = GetDbParameters(parameters.Where(parameter => parameter != null));
			foreach (var parameter in parms)
			{
				// 检查未分配值的输出参数,将其分配以DBNull.Value.
				if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
					(parameter.Value == null))
				{
					parameter.Value = DBNull.Value;
				}
				command.Parameters.Add(parameter);
			}

			return command;
		}

		/// <summary>
		/// 绑定输出参数值
		/// </summary>
		/// <param name="srcPrams">源参数</param>
		/// <param name="tgtParams">目标参数</param>
		protected void BindOutputParams(IEnumerable<DbParameter> srcPrams, IEnumerable<QfParameter> tgtParams)
		{
			var tpList = tgtParams.ToList();
			foreach (DbParameter sp in srcPrams.Where(sp => sp.Direction != ParameterDirection.Input))
			{
				var tp = tpList.Find(m => m.ParameterName == sp.ParameterName);
				if (tp == null) continue;
				tp.Value = sp.Value;
			}
		}

		/// <summary>
		/// 绑定输出参数值
		/// </summary>
		/// <param name="srcPrams">源参数</param>
		/// <param name="tgtParams">目标参数</param>
		protected void BindOutputParams(IEnumerable<DbParameter> srcPrams, Dictionary<string, QfParameter> tgtParams)
		{
			BindOutputParams(srcPrams, tgtParams.Values.ToList());
		}

		#endregion

		#region 公用方法

		/// <summary>
		///     判断是否存在某表的某个字段
		/// </summary>
		/// <param name="tableName">表名称</param>
		/// <param name="columnName">列名称</param>
		/// <returns>是否存在</returns>
		public abstract bool ColumnExists(string tableName, string columnName);

		/// <summary>
		///     获取最大ID
		/// </summary>
		/// <param name="tableName"></param>
		/// <param name="fieldName"></param>
		/// <returns></returns>
		public abstract int GetMaxID(string tableName, string fieldName);

		/// <summary>
		///     表是否存在
		/// </summary>
		/// <param name="tableName"></param>
		/// <returns></returns>
		public abstract bool TabExists(string tableName);

		/// <summary>
		///     根据SQL判断是否存在
		/// </summary>
		/// <param name="strSql"></param>
		/// <returns></returns>
		public abstract bool Exists(string strSql);

		/// <summary>
		///     根据SQL判断是否存在
		/// </summary>
		/// <param name="strSql"></param>
		/// <param name="cmdParms"></param>
		/// <returns></returns>
		public abstract bool Exists(string strSql, params QfParameter[] cmdParms);

		#endregion 公用方法

		#region 执行简单SQL语句

		/// <summary>
		///     执行SQL语句，返回影响的记录数
		/// </summary>
		/// <param name="strSql">SQL语句</param>
		/// <returns>影响的记录数</returns>
		public abstract int ExecuteSql(string strSql);

		/// <summary>
		///     在超时时间内执行SQL
		/// </summary>
		/// <param name="strSql"></param>
		/// <returns></returns>
		public abstract int ExecuteSqlByTime(string strSql);

		/// <summary>
		///     在超时时间内执行SQL
		/// </summary>
		/// <param name="strSql"></param>
		/// <param name="timeout"></param>
		/// <returns></returns>
		public abstract int ExecuteSqlByTime(string strSql, int timeout);

		/// <summary>
		///     执行多条SQL语句，实现数据库事务。
		/// </summary>
		/// <param name="strSqlList">多条SQL语句</param>
		public abstract int ExecuteSqlTran(List<String> strSqlList);

		/// <summary>
		///     执行带一个存储过程参数的的SQL语句。
		/// </summary>
		/// <param name="strSql">SQL语句</param>
		/// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
		/// <returns>影响的记录数</returns>
		public abstract int ExecuteSql(string strSql, string content);

		/// <summary>
		///     执行带一个存储过程参数的的SQL语句。
		/// </summary>
		/// <param name="strSql">SQL语句</param>
		/// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
		/// <returns>影响的记录数</returns>
		public abstract object ExecuteSqlGet(string strSql, string content);

		/// <summary>
		///     向数据库里插入图像格式的字段(和上面情况类似的另一种实例)
		/// </summary>
		/// <param name="strSql">SQL语句</param>
		/// <param name="fs">图像字节,数据库的字段类型为image的情况</param>
		/// <returns>影响的记录数</returns>
		public abstract int ExecuteSqlInsertImg(string strSql, byte[] fs);

		/// <summary>
		///     执行一条计算查询结果语句，返回查询结果（object）。
		/// </summary>
		/// <param name="strSql">计算查询结果语句</param>
		/// <returns>查询结果（object）</returns>
		public abstract object GetSingle(string strSql);

		/// <summary>
		///     执行SQL，返回单一结果
		/// </summary>
		/// <param name="strSql"></param>
		/// <param name="timeout"></param>
		/// <returns></returns>
		public abstract object GetSingle(string strSql, int timeout);

		/// <summary>
		///     执行查询语句，返回DataSet
		/// </summary>
		/// <param name="strSql">查询语句</param>
		/// <returns>DataSet</returns>
		public abstract DataSet Query(string strSql);

		/// <summary>
		///     执行SQL，返回数据集
		/// </summary>
		/// <param name="strSql"></param>
		/// <param name="timeout"></param>
		/// <returns></returns>
		public abstract DataSet Query(string strSql, int timeout);

		#endregion 执行简单SQL语句

		#region 执行带参数的SQL语句

		/// <summary>
		///     执行SQL语句，返回影响的记录数
		/// </summary>
		/// <param name="strSql">SQL语句</param>
		/// <param name="cmdParms"></param>
		/// <returns>影响的记录数</returns>
		public abstract int ExecuteSql(string strSql, params QfParameter[] cmdParms);

		/// <summary>
		///     执行多条SQL语句，实现数据库事务。
		/// </summary>
		/// <param name="strSqlList">SQL语句的哈希表（key为sql语句，value是该语句的QfParameter[]）</param>
		public abstract void ExecuteSqlTran(Hashtable strSqlList);

		/// <summary>
		///     执行多条SQL语句，实现数据库事务。
		/// </summary>
		/// <param name="cmdList"></param>
		public abstract int ExecuteSqlTran(List<QfCommandInfo> cmdList);

		/// <summary>
		///     执行多条SQL语句，实现数据库事务。
		/// </summary>
		/// <param name="strSqlList">SQL语句的哈希表（key为sql语句，value是该语句的QfParameter[]）</param>
		public abstract void ExecuteSqlTranWithIndentity(List<QfCommandInfo> strSqlList);

		/// <summary>
		///     执行多条SQL语句，实现数据库事务。
		/// </summary>
		/// <param name="strSqlList">SQL语句的哈希表（key为sql语句，value是该语句的QfParameter[]）</param>
		public abstract void ExecuteSqlTranWithIndentity(Hashtable strSqlList);

		/// <summary>
		///     执行一条计算查询结果语句，返回查询结果（object）。
		/// </summary>
		/// <param name="strSql">计算查询结果语句</param>
		/// <param name="cmdParms">参数列表</param>
		/// <returns>查询结果（object）</returns>
		public abstract object GetSingle(string strSql, params QfParameter[] cmdParms);

		/// <summary>
		///     执行查询语句，返回DataSet
		/// </summary>
		/// <param name="strSql">查询语句</param>
		/// <param name="cmdParms"></param>
		/// <returns>DataSet</returns>
		public abstract DataSet Query(string strSql, params QfParameter[] cmdParms);

		#endregion 执行带参数的SQL语句

		#region 存储过程操作

		/// <summary>
		///     执行存储过程，返回DataSet
		/// </summary>
		/// <param name="storedProcName">存储过程名</param>
		/// <param name="parameters">存储过程参数</param>
		/// <returns>MySqlDataReader</returns>
		public abstract DataSet RunProcedure(string storedProcName, Dictionary<string, QfParameter> parameters);

		/// <summary>
		///     执行存储过程
		/// </summary>
		/// <param name="storedProcName">存储过程名</param>
		/// <param name="parameters">存储过程参数</param>
		/// <param name="tableName">DataSet结果中的表名</param>
		/// <returns>DataSet</returns>
		public abstract DataSet RunProcedure(string storedProcName, QfParameter[] parameters, string tableName);

		public abstract DataSet RunProcedure(string storedProcName, QfParameter[] parameters, string tableName, int timeout);

		/// <summary>
		///     执行存储过程
		/// </summary>
		/// <param name="storedProcName">存储过程名</param>
		/// <param name="parameters">存储过程参数</param>
		/// <returns>DataSet</returns>
		public abstract DataSet RunProcedureDataSet(string storedProcName, QfParameter[] parameters);

		/// <summary>
		///     执行存储过程，返回影响的行数
		/// </summary>
		/// <param name="storedProcName">存储过程名</param>
		/// <param name="parameters">存储过程参数</param>
		/// <param name="rowsAffected">影响的行数</param>
		/// <returns></returns>
		public abstract int RunProcedure(string storedProcName, QfParameter[] parameters, out int rowsAffected);

		/// <summary>
		///     执行存储过程
		/// </summary>
		/// <param name="storedProcName">存储过程名</param>
		/// <param name="parameters">存储过程参数</param>
		/// <returns></returns>
		public abstract bool RunProcedure_(string storedProcName, Dictionary<string, QfParameter> parameters);

		/// <summary>
		///     执行存储过程
		/// </summary>
		/// <param name="storedProcName">存储过程名</param>
		/// <param name="parameters">存储过程参数</param>
		/// <returns></returns>
		public abstract bool RunProcedure_(string storedProcName, params QfParameter[] parameters);

		#endregion 存储过程操作
	}
}
