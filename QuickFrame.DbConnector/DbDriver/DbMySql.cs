using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using MySql.Data.MySqlClient;
using QuickFrame.Model;

namespace QuickFrame.DbConnector.DbDriver
{
	class DbMySql : DbBase
	{
		#region 初始化

		public DbMySql()
		{
			DatabaseType = "MySql";
		}

		public DbMySql(string binPath)
			: base(binPath)
		{
			DatabaseType = "MySql";
		}

		#endregion

		#region 内部方法

		protected override DbCommand GenerateDbCommand()
		{
			return new MySqlCommand();
		}

		#endregion

		#region 公用方法

		/// <summary>
		///     判断是否存在某表的某个字段
		/// </summary>
		/// <param name="tableName">表名称</param>
		/// <param name="columnName">列名称</param>
		/// <returns>是否存在</returns>
		public override bool ColumnExists(string tableName, string columnName)
		{
			using (var connection = new MySqlConnection(ConStr))
			{
				var strSql = @"select count(1) from ( " +
							 "	select column_name from information_schema.`COLUMNS` " +
							 "		where table_schema = '" + DbConnStrGenerator.DbName + "' " +
							 "			and table_name = '" + tableName + "' " +
							 "			and column_name = '" + columnName + "'" +
							 ") a;";
				using (var cmd = new MySqlCommand(strSql, connection))
				{
					connection.Open();
					var obj = cmd.ExecuteScalar();
					if ((Equals(obj, null)) || (Equals(obj, DBNull.Value)))
					{
						return false;
					}
					return Convert.ToInt32(obj) > 0;
				}
			}
		}

		/// <summary>
		///     获取最大ID
		/// </summary>
		/// <param name="tableName"></param>
		/// <param name="fieldName"></param>
		/// <returns></returns>
		public override int GetMaxID(string tableName, string fieldName)
		{
			using (var connection = new MySqlConnection(ConStr))
			{
				var strSql = "select max(" + fieldName + ")+1 from " + tableName;
				using (var cmd = new MySqlCommand(strSql, connection))
				{
					connection.Open();
					var obj = cmd.ExecuteScalar();
					return obj == null ? 1 : int.Parse(obj.ToString());
				}
			}
		}

		/// <summary>
		///     表是否存在
		/// </summary>
		/// <param name="tableName"></param>
		/// <returns></returns>
		public override bool TabExists(string tableName)
		{
			using (var connection = new MySqlConnection(ConStr))
			{
				var strSql = @"select count(1) from ( " +
							 "	select table_name from information_schema.`TABLES` " +
							 "		where table_schema = '" + DbConnStrGenerator.DbName + "' " +
							 "			and table_name = '" + tableName + "' " +
							 ") a;";
				using (var cmd = new MySqlCommand(strSql, connection))
				{
					connection.Open();
					var obj = cmd.ExecuteScalar();
					if ((Equals(obj, null)) || (Equals(obj, DBNull.Value)))
					{
						return false;
					}
					return Convert.ToInt32(obj) > 0;
				}
			}
		}

		/// <summary>
		///     根据SQL判断是否存在
		/// </summary>
		/// <param name="strSql"></param>
		/// <returns></returns>
		public override bool Exists(string strSql)
		{
			var obj = GetSingle(strSql);
			int cmdresult;
			if ((Equals(obj, null)) || (Equals(obj, DBNull.Value)))
			{
				cmdresult = 0;
			}
			else
			{
				cmdresult = int.Parse(obj.ToString());
			}
			return cmdresult != 0;
		}

		/// <summary>
		///     根据SQL判断是否存在
		/// </summary>
		/// <param name="strSql"></param>
		/// <param name="cmdParms"></param>
		/// <returns></returns>
		public override bool Exists(string strSql, params QfParameter[] cmdParms)
		{
			var obj = GetSingle(strSql, cmdParms);
			int cmdresult;
			if ((Equals(obj, null)) || (Equals(obj, DBNull.Value)))
			{
				cmdresult = 0;
			}
			else
			{
				cmdresult = int.Parse(obj.ToString());
			}
			return cmdresult != 0;
		}

		#endregion 公用方法

		#region 执行简单SQL语句

		/// <summary>
		///     执行SQL语句，返回影响的记录数
		/// </summary>
		/// <param name="strSql">SQL语句</param>
		/// <returns>影响的记录数</returns>
		public override int ExecuteSql(string strSql)
		{
			strSql = GetSql(strSql);
			using (var connection = new MySqlConnection(ConStr))
			{
				using (var cmd = new MySqlCommand(strSql, connection))
				{
					try
					{
						connection.Open();
						cmd.CommandTimeout = Timeout;
						var rows = cmd.ExecuteNonQuery();
						return rows;
					}
					finally
					{
						connection.Close();
					}
				}
			}
		}

		/// <summary>
		///     在超时时间内执行SQL
		/// </summary>
		/// <param name="strSql"></param>
		/// <returns></returns>
		public override int ExecuteSqlByTime(string strSql)
		{
			return ExecuteSqlByTime(strSql, 0);
		}

		/// <summary>
		///     在超时时间内执行SQL
		/// </summary>
		/// <param name="strSql"></param>
		/// <param name="timeout"></param>
		/// <returns></returns>
		public override int ExecuteSqlByTime(string strSql, int timeout)
		{
			using (var connection = new MySqlConnection(ConStr))
			{
				strSql = GetSql(strSql);
				using (var cmd = new MySqlCommand(strSql, connection))
				{
					try
					{
						connection.Open();
						cmd.CommandTimeout = timeout;
						var rows = cmd.ExecuteNonQuery();
						return rows;
					}
					finally
					{
						connection.Close();
					}
				}
			}
		}

		/// <summary>
		///     执行多条SQL语句，实现数据库事务。
		/// </summary>
		/// <param name="strSqlList">多条SQL语句</param>
		public override int ExecuteSqlTran(List<String> strSqlList)
		{
			strSqlList = GetSqlList(strSqlList);
			using (var conn = new MySqlConnection(ConStr))
			{
				conn.Open();
				var cmd = new MySqlCommand();
				cmd.CommandTimeout = Timeout;
				cmd.Connection = conn;
				var tx = conn.BeginTransaction();
				cmd.Transaction = tx;
				try
				{
					var count = 0;
					foreach (var strsql in strSqlList.Where(strsql => strsql.Trim().Length > 1))
					{
						cmd.CommandText = strsql;
						count += cmd.ExecuteNonQuery();
					}
					tx.Commit();
					return count;
				}
				catch
				{
					tx.Rollback();
					throw;
				}
			}
		}

		/// <summary>
		///     执行带一个存储过程参数的的SQL语句。
		/// </summary>
		/// <param name="strSql">SQL语句</param>
		/// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
		/// <returns>影响的记录数</returns>
		public override int ExecuteSql(string strSql, string content)
		{
			using (var connection = new MySqlConnection(ConStr))
			{
				strSql = GetSql(strSql);
				var cmd = new MySqlCommand(strSql, connection) {CommandTimeout = Timeout};
				var myParameter = new QfParameter("@content", MySqlDbType.Text) {Value = content};
				cmd.Parameters.Add(myParameter);
				try
				{
					connection.Open();
					var rows = cmd.ExecuteNonQuery();
					return rows;
				}
				finally
				{
					cmd.Dispose();
					connection.Close();
				}
			}
		}

		/// <summary>
		///     执行带一个存储过程参数的的SQL语句。
		/// </summary>
		/// <param name="strSql">SQL语句</param>
		/// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
		/// <returns>影响的记录数</returns>
		public override object ExecuteSqlGet(string strSql, string content)
		{
			using (var connection = new MySqlConnection(ConStr))
			{
				strSql = GetSql(strSql);
				var cmd = new MySqlCommand(strSql, connection);
				cmd.CommandTimeout = Timeout;
				var myParameter = new QfParameter("@content", MySqlDbType.Text);
				myParameter.Value = content;
				cmd.Parameters.Add(myParameter);
				try
				{
					connection.Open();
					var obj = cmd.ExecuteScalar();
					if ((Equals(obj, null)) || (Equals(obj, DBNull.Value)))
					{
						return null;
					}
					else
					{
						return obj;
					}
				}
				finally
				{
					cmd.Dispose();
					connection.Close();
				}
			}
		}

		/// <summary>
		///     向数据库里插入图像格式的字段(和上面情况类似的另一种实例)
		/// </summary>
		/// <param name="strSql">SQL语句</param>
		/// <param name="fs">图像字节,数据库的字段类型为image的情况</param>
		/// <returns>影响的记录数</returns>
		public override int ExecuteSqlInsertImg(string strSql, byte[] fs)
		{
			using (var connection = new MySqlConnection(ConStr))
			{
				strSql = GetSql(strSql);
				var cmd = new MySqlCommand(strSql, connection);
				cmd.CommandTimeout = Timeout;
				var myParameter = new QfParameter("@fs", MySqlDbType.Blob);
				myParameter.Value = fs;
				cmd.Parameters.Add(myParameter);
				try
				{
					connection.Open();
					var rows = cmd.ExecuteNonQuery();
					return rows;
				}
				finally
				{
					cmd.Dispose();
					connection.Close();
				}
			}
		}

		/// <summary>
		///     执行一条计算查询结果语句，返回查询结果（object）。
		/// </summary>
		/// <param name="strSql">计算查询结果语句</param>
		/// <returns>查询结果（object）</returns>
		public override object GetSingle(string strSql)
		{
			using (var connection = new MySqlConnection(ConStr))
			{
				strSql = GetSql(strSql);
				using (var cmd = new MySqlCommand(strSql, connection))
				{
					connection.Open();
					var obj = cmd.ExecuteScalar();
					if ((Equals(obj, null)) || (Equals(obj, DBNull.Value)))
					{
						return null;
					}
					return obj;
				}
			}
		}

		/// <summary>
		///     执行SQL，返回单一结果
		/// </summary>
		/// <param name="strSql"></param>
		/// <param name="timeout"></param>
		/// <returns></returns>
		public override object GetSingle(string strSql, int timeout)
		{
			using (var connection = new MySqlConnection(ConStr))
			{
				strSql = GetSql(strSql);
				using (var cmd = new MySqlCommand(strSql, connection))
				{
					connection.Open();
					cmd.CommandTimeout = timeout;
					var obj = cmd.ExecuteScalar();
					if ((Equals(obj, null)) || (Equals(obj, DBNull.Value)))
					{
						return null;
					}
					return obj;
				}
			}
		}

		/// <summary>
		///     执行查询语句，返回DataSet
		/// </summary>
		/// <param name="strSql">查询语句</param>
		/// <returns>DataSet</returns>
		public override DataSet Query(string strSql)
		{
			using (var connection = new MySqlConnection(ConStr))
			{
				var ds = new DataSet();
				connection.Open();
				strSql = GetSql(strSql);
				var command = new MySqlDataAdapter(strSql, connection);
				command.Fill(ds, "ds");
				return ds;
			}
		}

		/// <summary>
		///     执行SQL，返回数据集
		/// </summary>
		/// <param name="strSql"></param>
		/// <param name="timeout"></param>
		/// <returns></returns>
		public override DataSet Query(string strSql, int timeout)
		{
			using (var connection = new MySqlConnection(ConStr))
			{
				var ds = new DataSet();
				connection.Open();
				strSql = GetSql(strSql);
				var command = new MySqlDataAdapter(strSql, connection)
				{
					SelectCommand =
					{
						CommandTimeout = timeout
					}
				};
				command.Fill(ds, "ds");
				return ds;
			}
		}

		#endregion 执行简单SQL语句

		#region 执行带参数的SQL语句

		/// <summary>
		///     执行SQL语句，返回影响的记录数
		/// </summary>
		/// <param name="strSql">SQL语句</param>
		/// <param name="cmdParms"></param>
		/// <returns>影响的记录数</returns>
		public override int ExecuteSql(string strSql, params QfParameter[] cmdParms)
		{
			using (var connection = new MySqlConnection(ConStr))
			{
				var cmd = PrepareCommand(connection, null, strSql, cmdParms);
				var rows = cmd.ExecuteNonQuery();
				BindOutputParams(cmd.Parameters.Cast<MySqlParameter>(), cmdParms);
				return rows;
			}
		}

		/// <summary>
		///     执行多条SQL语句，实现数据库事务。
		/// </summary>
		/// <param name="strSqlList">SQL语句的哈希表（key为sql语句，value是该语句的QfParameter[]）</param>
		public override void ExecuteSqlTran(Hashtable strSqlList)
		{
			using (var conn = new MySqlConnection(ConStr))
			{
				conn.Open();
				using (var trans = conn.BeginTransaction())
				{
					try
					{
						//循环
						foreach (DictionaryEntry myDe in strSqlList)
						{
							var cmdText = myDe.Key.ToString();
							var cmdParms = (QfParameter[]) myDe.Value;
							var cmd = PrepareCommand(conn, trans, cmdText, cmdParms);
							var val = cmd.ExecuteNonQuery();
							BindOutputParams(cmd.Parameters.Cast<MySqlParameter>(), cmdParms);
						}
						trans.Commit();
					}
					catch
					{
						trans.Rollback();
						throw;
					}
				}
			}
		}

		/// <summary>
		///     执行多条SQL语句，实现数据库事务。
		/// </summary>
		/// <param name="cmdList"></param>
		public override int ExecuteSqlTran(List<QfCommandInfo> cmdList)
		{
			using (var conn = new MySqlConnection(ConStr))
			{
				conn.Open();
				using (var trans = conn.BeginTransaction())
				{
					try
					{
						var count = 0;
						//循环
						foreach (var myDe in cmdList)
						{
							var cmdText = myDe.CommandText;
							var cmdParms = myDe.Parameters;
							var cmd = PrepareCommand(conn, trans, cmdText, cmdParms);

							if (myDe.EffectNextType == EffectNextType.WhenHaveContine ||
							    myDe.EffectNextType == EffectNextType.WhenNoHaveContine)
							{
								if (myDe.CommandText.ToLower().IndexOf("count(", StringComparison.Ordinal) == -1)
								{
									trans.Rollback();
									return 0;
								}

								var obj = cmd.ExecuteScalar();
								var isHave = false;
								if (obj != null && obj != DBNull.Value)
								{
									isHave = Convert.ToInt32(obj) > 0;
								}

								if (myDe.EffectNextType == EffectNextType.WhenHaveContine && !isHave)
								{
									trans.Rollback();
									return 0;
								}
								if (myDe.EffectNextType == EffectNextType.WhenNoHaveContine && isHave)
								{
									trans.Rollback();
									return 0;
								}
								continue;
							}
							var val = cmd.ExecuteNonQuery();
							count += val;
							if (myDe.EffectNextType == EffectNextType.ExcuteEffectRows && val == 0)
							{
								trans.Rollback();
								return 0;
							}
							BindOutputParams(cmd.Parameters.Cast<MySqlParameter>(), cmdParms);
						}
						trans.Commit();
						return count;
					}
					catch
					{
						trans.Rollback();
						throw;
					}
				}
			}
		}

		/// <summary>
		///     执行多条SQL语句，实现数据库事务。
		/// </summary>
		/// <param name="strSqlList">SQL语句的哈希表（key为sql语句，value是该语句的QfParameter[]）</param>
		public override void ExecuteSqlTranWithIndentity(List<QfCommandInfo> strSqlList)
		{
			using (var conn = new MySqlConnection(ConStr))
			{
				conn.Open();
				using (var trans = conn.BeginTransaction())
				{
					var cmd = new MySqlCommand {CommandTimeout = Timeout};
					try
					{
						var indentity = 0;
						//循环
						foreach (var myDe in strSqlList)
						{
							var cmdText = myDe.CommandText;
							var cmdParms = myDe.Parameters;
							foreach (var q in cmdParms.Where(q => q.Direction == ParameterDirection.InputOutput))
							{
								q.Value = indentity;
							}
							PrepareCommand(conn, trans, cmdText, cmdParms);
							var val = cmd.ExecuteNonQuery();
							foreach (var q in cmdParms.Where(q => q.Direction == ParameterDirection.Output))
							{
								indentity = Convert.ToInt32(q.Value);
							}
							BindOutputParams(cmd.Parameters.Cast<MySqlParameter>(), cmdParms);
						}
						trans.Commit();
					}
					catch
					{
						trans.Rollback();
						throw;
					}
				}
			}
		}

		/// <summary>
		///     执行多条SQL语句，实现数据库事务。
		/// </summary>
		/// <param name="strSqlList">SQL语句的哈希表（key为sql语句，value是该语句的QfParameter[]）</param>
		public override void ExecuteSqlTranWithIndentity(Hashtable strSqlList)
		{
			using (var conn = new MySqlConnection(ConStr))
			{
				conn.Open();
				using (var trans = conn.BeginTransaction())
				{
					var cmd = new MySqlCommand();
					cmd.CommandTimeout = Timeout;
					try
					{
						var indentity = 0;
						//循环
						foreach (DictionaryEntry myDe in strSqlList)
						{
							var cmdText = myDe.Key.ToString();
							var cmdParms = (QfParameter[]) myDe.Value;
							foreach (var q in cmdParms.Where(q => q.Direction == ParameterDirection.InputOutput))
							{
								q.Value = indentity;
							}
							PrepareCommand(conn, trans, cmdText, cmdParms);
							var val = cmd.ExecuteNonQuery();
							foreach (var q in cmdParms.Where(q => q.Direction == ParameterDirection.Output))
							{
								indentity = Convert.ToInt32(q.Value);
							}
							BindOutputParams(cmd.Parameters.Cast<MySqlParameter>(), cmdParms);
						}
						trans.Commit();
					}
					catch
					{
						trans.Rollback();
						throw;
					}
				}
			}
		}

		/// <summary>
		///     执行一条计算查询结果语句，返回查询结果（object）。
		/// </summary>
		/// <param name="strSql">计算查询结果语句</param>
		/// <param name="cmdParms">参数列表</param>
		/// <returns>查询结果（object）</returns>
		public override object GetSingle(string strSql, params QfParameter[] cmdParms)
		{
			using (var connection = new MySqlConnection(ConStr))
			{
				var cmd = PrepareCommand(connection, null, strSql, cmdParms);
				var obj = cmd.ExecuteScalar();
				BindOutputParams(cmd.Parameters.Cast<MySqlParameter>(), cmdParms);
				if ((Equals(obj, null)) || (Equals(obj, DBNull.Value)))
				{
					return null;
				}
				return obj;
			}
		}

		/// <summary>
		///     执行查询语句，返回DataSet
		/// </summary>
		/// <param name="strSql">查询语句</param>
		/// <param name="cmdParms"></param>
		/// <returns>DataSet</returns>
		public override DataSet Query(string strSql, params QfParameter[] cmdParms)
		{
			using (var connection = new MySqlConnection(ConStr))
			{
				var cmd = PrepareCommand(connection, null, strSql, cmdParms);
				using (var da = new MySqlDataAdapter((MySqlCommand) cmd))
				{
					var ds = new DataSet();
					da.Fill(ds, "ds");
					BindOutputParams(cmd.Parameters.Cast<MySqlParameter>(), cmdParms);
					return ds;
				}
			}
		}

		#endregion 执行带参数的SQL语句

		#region 存储过程操作

		/// <summary>
		///     执行存储过程，返回DataSet
		/// </summary>
		/// <param name="storedProcName">存储过程名</param>
		/// <param name="parameters">存储过程参数</param>
		/// <returns>MySqlDataReader</returns>
		public override DataSet RunProcedure(string storedProcName, Dictionary<string, QfParameter> parameters)
		{
			using (var connection = new MySqlConnection(ConStr))
			{
				var dataSet = new DataSet();
				connection.Open();
				var sqlDa = new MySqlDataAdapter {SelectCommand = (MySqlCommand)BuildQueryCommand(connection, storedProcName, parameters)};
				sqlDa.SelectCommand.CommandTimeout = Timeout;
				sqlDa.Fill(dataSet);
				connection.Close();
				BindOutputParams(sqlDa.SelectCommand.Parameters.Cast<MySqlParameter>(), parameters);
				return dataSet;
			}
		}

		/// <summary>
		///     执行存储过程
		/// </summary>
		/// <param name="storedProcName">存储过程名</param>
		/// <param name="parameters">存储过程参数</param>
		/// <param name="tableName">DataSet结果中的表名</param>
		/// <returns>DataSet</returns>
		public override DataSet RunProcedure(string storedProcName, QfParameter[] parameters, string tableName)
		{
			using (var connection = new MySqlConnection(ConStr))
			{
				var dataSet = new DataSet();
				connection.Open();
				var sqlDa = new MySqlDataAdapter {SelectCommand = (MySqlCommand)BuildQueryCommand(connection, storedProcName, parameters)};
				sqlDa.SelectCommand.CommandTimeout = Timeout;
				sqlDa.Fill(dataSet, tableName);
				connection.Close();
				BindOutputParams(sqlDa.SelectCommand.Parameters.Cast<MySqlParameter>(), parameters);
				return dataSet;
			}
		}

		public override DataSet RunProcedure(string storedProcName, QfParameter[] parameters, string tableName, int timeout)
		{
			using (var connection = new MySqlConnection(ConStr))
			{
				var dataSet = new DataSet();
				connection.Open();
				var sqlDa = new MySqlDataAdapter {SelectCommand = (MySqlCommand)BuildQueryCommand(connection, storedProcName, parameters)};
				sqlDa.SelectCommand.CommandTimeout = timeout;
				sqlDa.Fill(dataSet, tableName);
				connection.Close();
				BindOutputParams(sqlDa.SelectCommand.Parameters.Cast<MySqlParameter>(), parameters);
				return dataSet;
			}
		}

		/// <summary>
		///     执行存储过程
		/// </summary>
		/// <param name="storedProcName">存储过程名</param>
		/// <param name="parameters">存储过程参数</param>
		/// <returns>DataSet</returns>
		public override DataSet RunProcedureDataSet(string storedProcName, QfParameter[] parameters)
		{
			using (var connection = new MySqlConnection(ConStr))
			{
				var dataSet = new DataSet();
				connection.Open();
				var sqlDa = new MySqlDataAdapter {SelectCommand = (MySqlCommand)BuildQueryCommand(connection, storedProcName, parameters)};
				sqlDa.SelectCommand.CommandTimeout = Timeout;
				sqlDa.Fill(dataSet);
				connection.Close();
				BindOutputParams(sqlDa.SelectCommand.Parameters.Cast<MySqlParameter>(), parameters);
				return dataSet;
			}
		}

		/// <summary>
		///     执行存储过程，返回影响的行数
		/// </summary>
		/// <param name="storedProcName">存储过程名</param>
		/// <param name="parameters">存储过程参数</param>
		/// <param name="rowsAffected">影响的行数</param>
		/// <returns></returns>
		public override int RunProcedure(string storedProcName, QfParameter[] parameters, out int rowsAffected)
		{
			using (var connection = new MySqlConnection(ConStr))
			{
				connection.Open();
				var command = BuildIntCommand(connection, storedProcName, parameters);
				command.CommandTimeout = Timeout; //设置超时时间
				rowsAffected = command.ExecuteNonQuery();
				var result = (int)command.Parameters["ReturnValue"].Value;
				BindOutputParams(command.Parameters.Cast<MySqlParameter>(), parameters);
				return result;
			}
		}

		/// <summary>
		///     执行存储过程
		/// </summary>
		/// <param name="storedProcName">存储过程名</param>
		/// <param name="parameters">存储过程参数</param>
		/// <returns></returns>
		public override bool RunProcedure_(string storedProcName, Dictionary<string, QfParameter> parameters)
		{
			using (var connection = new MySqlConnection(ConStr))
			{
				connection.Open();
				var command = BuildQueryCommand(connection, storedProcName, parameters);
				command.CommandTimeout = Timeout; //设置超时时间
				command.ExecuteNonQuery();
				BindOutputParams(command.Parameters.Cast<MySqlParameter>(), parameters);
				return true;
			}
		}

		/// <summary>
		///     执行存储过程
		/// </summary>
		/// <param name="storedProcName">存储过程名</param>
		/// <param name="parameters">存储过程参数</param>
		/// <returns></returns>
		public override bool RunProcedure_(string storedProcName, params QfParameter[] parameters)
		{
			using (var connection = new MySqlConnection(ConStr))
			{
				connection.Open();
				var command = BuildQueryCommand(connection, storedProcName, parameters);
				command.CommandTimeout = Timeout; //设置超时时间
				command.ExecuteNonQuery();
				BindOutputParams(command.Parameters.Cast<MySqlParameter>(), parameters);
				return true;
			}
		}

		/// <summary>
		///     创建 MySqlCommand 对象实例(用来返回一个整数值)
		/// </summary>
		/// <param name="connection">数据库连接</param>
		/// <param name="storedProcName">存储过程名</param>
		/// <param name="parameters">存储过程参数</param>
		/// <returns>MySqlCommand 对象实例</returns>
		private MySqlCommand BuildIntCommand(MySqlConnection connection, string storedProcName,
			QfParameter[] parameters)
		{
			var command = (MySqlCommand)BuildQueryCommand(connection, storedProcName, parameters);
			command.Parameters.Add(new MySqlParameter("ReturnValue",
				MySqlDbType.Int32, 4, ParameterDirection.ReturnValue,
				false, 0, 0, string.Empty, DataRowVersion.Default, null));
			return command;
		}

		#endregion 存储过程操作
	}
}
