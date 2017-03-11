using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Threading;
using QuickFrame.Common.Exception;
using QuickFrame.Common.Serialization;
using QuickFrame.Model;
using QuickFrame.Model.Token;
using QuickFrame.Token.Client;
using QuickFrame.Common;

namespace QuickFrame.ClientConnector
{
	/// <summary>
	/// 数据代理连接
	/// </summary>
	public class QfClientConnector
	{
		private readonly QfDataService.QfDataService _service = new QfDataService.QfDataService();

		/// <summary>
		/// 令牌功能类
		/// </summary>
		private readonly TokenClient _tokenUtil = new TokenClient();

		private readonly QfClientInfo _clientInfo;

		public QfClientConnector(QfClientInfo clientInfo = null)
		{
			_clientInfo = clientInfo;
			var serverUrl = ConfigurationManager.AppSettings["ServerUrl"];
			_service.Url = _service.Url.Replace("http://localhost:8069", serverUrl);
			InitToken();
		}

		private void InitToken(Exception exception = null)
		{
			var tokenSign = _tokenUtil.GetTokenSign();
			string tokenKey;
			try
			{
				tokenKey =
					(string) Serializer.Deserialize(_service.GetToken(Serializer.Serialize(tokenSign.Signature),
						Serializer.Serialize(tokenSign.Timestamp), Serializer.Serialize(tokenSign.Nonce)));
			}
			catch(Exception ex)
			{
				throw new QfException("无法获取令牌公钥，可能是服务端已更新造成的连接问题，请重启客户端稍后登录！", ex);
			}
			if (!_tokenUtil.InitToken(tokenKey))
			{
				throw new QfException("无法初始化连接令牌，可能是服务端已更新造成的连接问题，请重启客户端稍后登录！", exception);
			}
			UpdateClientInfo();
		}

		/// <summary>
		/// 更新Token
		/// </summary>
		/// <returns></returns>
		public void UpdateToken(Exception exception = null)
		{
			if (_service.QueryToken(GetToken())) return;
			InitToken();
			var t = 0;
			var ret = false;
			while (t < 30)
			{
				t++;
				ret = _service.QueryToken(GetToken());
				if (ret) break;
				Thread.Sleep(100);
			}
			if (!ret)
			{
				throw new QfException("令牌失效，可能是服务端已更新造成的连接问题，请重启客户端稍后登录！", exception);
			}
		}

		private void CloseToken()
		{
			try
			{
				_service.CloseToken(GetToken(false));
			}
			catch
			{
				// ignored
			}
		}

		~QfClientConnector()
		{
			CloseToken();
		}

		/// <summary>
		/// 获取一个Token
		/// </summary>
		/// <returns></returns>
		private byte[] GetToken(bool checkExpire = true)
		{
			if (checkExpire && _tokenUtil.IsTokenExipre())
			{
				CloseToken();
				InitToken();
			}
			return Serializer.Serialize(_tokenUtil.GetToken());
		}

		/// <summary>
		/// 更新客户端信息
		/// </summary>
		/// <param name="clientInfo">客户端信息</param>
		public void UpdateClientInfo(QfClientInfo clientInfo = null)
		{
			if (clientInfo != null)
			{
				_service.UpdateClientInfo(Serializer.Serialize(clientInfo), GetToken(false));
			}
			else if (_clientInfo != null)
			{
				_service.UpdateClientInfo(Serializer.Serialize(_clientInfo), GetToken(false));
			}
		}

		/// <summary>
		/// 根据用户ID获取客户端信息
		/// </summary>
		/// <param name="clientType">客户端类型</param>
		/// <param name="userId">用户ID</param>
		public QfClientInfo GetClientInfoByUserID(string clientType, int userId)
		{
			return (QfClientInfo)Serializer.Deserialize(_service.GetClientInfoByUserID(clientType, userId, GetToken()));
		}

		/// <summary>
		/// 获取当前服务器日期时间
		/// </summary>
		/// <returns>日期时间</returns>
		public DateTime GetServerDateTime()
		{
			return (DateTime) Serializer.Deserialize(_service.GetServerDateTime());
		}

		/// <summary>
		/// 判断是否存在某表的某个字段
		/// </summary>
		/// <param name="tableName">表名称</param>
		/// <param name="columnName">列名称</param>
		/// <returns>是否存在</returns>
		public bool ColumnExists(string tableName, string columnName)
		{
			try
			{
				return _service.ColumnExists(Serializer.Serialize(tableName), Serializer.Serialize(columnName),
					GetToken());
			}
			catch (Exception ex)
			{
				UpdateToken(ex);
				return _service.ColumnExists(Serializer.Serialize(tableName), Serializer.Serialize(columnName),
					GetToken());
			}
		}

		/// <summary>
		/// 获取最大ID值
		/// </summary>
		/// <param name="fieldName">字段名称</param>
		/// <param name="tableName">表名称</param>
		/// <returns>最大ID值</returns>
		public int GetMaxID(string fieldName, string tableName)
		{
			try
			{
				return _service.GetMaxID(Serializer.Serialize(fieldName), Serializer.Serialize(tableName), GetToken());
			}
			catch (Exception ex)
			{
				UpdateToken(ex);
				return _service.GetMaxID(Serializer.Serialize(fieldName), Serializer.Serialize(tableName), GetToken());
			}
		}

		/// <summary>
		/// 判断SQL语句是否有非0结果
		/// </summary>
		/// <param name="strSql">SQL语句</param>
		/// <returns>是否有非0结果</returns>
		public bool Exists(string strSql)
		{
			try
			{
				return _service.Exists(Serializer.Serialize(strSql), GetToken());
			}
			catch (Exception ex)
			{
				UpdateToken(ex);
				return _service.Exists(Serializer.Serialize(strSql), GetToken());
			}
		}

		/// <summary>
		/// 判断SQL语句是否有非0结果，带SQL参数
		/// </summary>
		/// <param name="strSql">SQL语句</param>
		/// <param name="cmdParms">参数表</param>
		/// <returns>是否有非0结果</returns>
		public bool Exists(string strSql, params QfParameter[] cmdParms)
		{
			try
			{
				return _service.ExistsByParams(Serializer.Serialize(strSql), Serializer.Serialize(cmdParms), GetToken());
			}
			catch (Exception ex)
			{
				UpdateToken(ex);
				return _service.ExistsByParams(Serializer.Serialize(strSql), Serializer.Serialize(cmdParms), GetToken());
			}
		}

		/// <summary>
		/// 表是否存在
		/// </summary>
		/// <param name="tableName">表名</param>
		/// <returns>是否存在</returns>
		public bool TabExists(string tableName)
		{
			try
			{
				return _service.TabExists(Serializer.Serialize(tableName), GetToken());
			}
			catch (Exception ex)
			{
				UpdateToken(ex);
				return _service.TabExists(Serializer.Serialize(tableName), GetToken());
			}
		}

		/// <summary>
		/// 执行SQL语句
		/// </summary>
		/// <param name="strSql">SQL语句</param>
		/// <returns>影响的记录数</returns>
		public int ExecuteSql(string strSql)
		{
			try
			{
				return _service.ExecuteSql(Serializer.Serialize(strSql), GetToken());
			}
			catch (Exception ex)
			{
				UpdateToken(ex);
				return _service.ExecuteSql(Serializer.Serialize(strSql), GetToken());
			}
		}

		/// <summary>
		/// 执行SQL语句，不超时无限等待
		/// </summary>
		/// <param name="strSql">SQL语句</param>
		/// <returns>影响的记录数</returns>
		public int ExecuteSqlByTime(string strSql)
		{
			try
			{
				return _service.ExcuteSqlByNoTimeOut(Serializer.Serialize(strSql), GetToken());
			}
			catch (Exception ex)
			{
				UpdateToken(ex);
				return _service.ExcuteSqlByNoTimeOut(Serializer.Serialize(strSql), GetToken());
			}
		}

		/// <summary>
		/// 执行SQL语句，指定超时时间
		/// </summary>
		/// <param name="strSql">SQL语句</param>
		/// <param name="timeout">超时时间</param>
		/// <returns>影响的记录数</returns>
		public int ExecuteSqlByTime(string strSql, int timeout)
		{
			try
			{
				return _service.ExecuteSqlByTime(Serializer.Serialize(strSql), timeout, GetToken());
			}
			catch (Exception ex)
			{
				UpdateToken(ex);
				return _service.ExecuteSqlByTime(Serializer.Serialize(strSql), timeout, GetToken());
			}
		}

		/// <summary>
		/// 执行多条SQL语句，实现数据库事务。
		/// </summary>
		/// <param name="listStrSql">多条SQL语句</param>
		/// <returns>影响的记录数</returns>
		public int ExecuteSqlTran(List<String> listStrSql)
		{
			try
			{
				return _service.ExecuteSqlTran(Serializer.Serialize(listStrSql), GetToken());
			}
			catch (Exception ex)
			{
				UpdateToken(ex);
				return _service.ExecuteSqlTran(Serializer.Serialize(listStrSql), GetToken());
			}
		}

		/// <summary>
		/// 执行带一个存储过程参数的的SQL语句。
		/// </summary>
		/// <param name="strSql">SQL语句</param>
		/// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
		/// <returns>影响的记录数</returns>
		public int ExecuteSql(string strSql, string content)
		{
			try
			{
				return _service.ExecuteSqlByContent(Serializer.Serialize(strSql), Serializer.Serialize(content), GetToken());
			}
			catch (Exception ex)
			{
				UpdateToken(ex);
				return _service.ExecuteSqlByContent(Serializer.Serialize(strSql), Serializer.Serialize(content), GetToken());
			}
		}

		/// <summary>
		/// 执行带一个存储过程参数的的SQL语句。
		/// </summary>
		/// <param name="strSql">SQL语句</param>
		/// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
		/// <returns>结果对象</returns>
		public object ExecuteSqlGet(string strSql, string content)
		{
			try
			{
				return Serializer.Deserialize(_service.ExecuteSqlGetByContent(Serializer.Serialize(strSql), Serializer.Serialize(content), GetToken()));
			}
			catch (Exception ex)
			{
				UpdateToken(ex);
				return Serializer.Deserialize(_service.ExecuteSqlGetByContent(Serializer.Serialize(strSql), Serializer.Serialize(content), GetToken()));
			}
		}

		/// <summary>
		/// 向数据库里插入图像格式的字段(和上面情况类似的另一种实例)
		/// </summary>
		/// <param name="strSql">SQL语句</param>
		/// <param name="imageBytes">图像字节,数据库的字段类型为image的情况</param>
		/// <returns>影响的记录数</returns>
		public int ExecuteSqlInsertImg(string strSql, byte[] imageBytes)
		{
			try
			{
				return _service.ExecuteSqlInsertImg(Serializer.Serialize(strSql), Serializer.Serialize(imageBytes), GetToken());
			}
			catch (Exception ex)
			{
				UpdateToken(ex);
				return _service.ExecuteSqlInsertImg(Serializer.Serialize(strSql), Serializer.Serialize(imageBytes), GetToken());
			}
		}

		/// <summary>
		/// 执行一条计算查询结果语句。
		/// </summary>
		/// <param name="strSql">SQL语句</param>
		/// <returns>结果对象</returns>
		public object GetSingle(string strSql)
		{
			try
			{
				return Serializer.Deserialize(_service.GetSingle(Serializer.Serialize(strSql), GetToken()));
			}
			catch (Exception ex)
			{
				UpdateToken(ex);
				return Serializer.Deserialize(_service.GetSingle(Serializer.Serialize(strSql), GetToken()));
			}
		}

		/// <summary>
		/// 执行一条计算查询结果语句，指定超时时间。
		/// </summary>
		/// <param name="strSql">SQL语句</param>
		/// <param name="timeout">超时时间</param>
		/// <returns>结果对象</returns>
		public object GetSingle(string strSql, int timeout)
		{
			try
			{
				return Serializer.Deserialize(_service.GetSingleByTimeOut(Serializer.Serialize(strSql), timeout, GetToken()));
			}
			catch (Exception ex)
			{
				UpdateToken(ex);
				return Serializer.Deserialize(_service.GetSingleByTimeOut(Serializer.Serialize(strSql), timeout, GetToken()));
			}
		}

		/// <summary>
		/// 执行查询语句
		/// </summary>
		/// <param name="strSql">SQL语句</param>
		/// <returns>数据集</returns>
		public DataSet Query(string strSql)
		{
			try
			{
				return (DataSet)Serializer.Deserialize(_service.Query(Serializer.Serialize(strSql), GetToken()));
			}
			catch (Exception ex)
			{
				UpdateToken(ex);
				return (DataSet)Serializer.Deserialize(_service.Query(Serializer.Serialize(strSql), GetToken()));
			}
		}

		/// <summary>
		/// 执行查询语句，指定超时时间。
		/// </summary>
		/// <param name="strSql">SQL语句</param>
		/// <param name="timeout">超时时间</param>
		/// <returns>数据集</returns>
		public DataSet Query(string strSql, int timeout)
		{
			try
			{
				return (DataSet)Serializer.Deserialize(_service.QueryByTimeOut(Serializer.Serialize(strSql), timeout, GetToken()));
			}
			catch (Exception ex)
			{
				UpdateToken(ex);
				return (DataSet)Serializer.Deserialize(_service.QueryByTimeOut(Serializer.Serialize(strSql), timeout, GetToken()));
			}
		}

		/// <summary>
		/// 执行SQL语句
		/// </summary>
		/// <param name="strSql">SQL语句</param>
		/// <param name="cmdParms">参数列表</param>
		/// <returns>影响的记录数</returns>
		public int ExecuteSql(string strSql, params QfParameter[] cmdParms)
		{
			try
			{
				return _service.ExecuteSqlByParams(Serializer.Serialize(strSql), Serializer.Serialize(cmdParms), GetToken());
			}
			catch (Exception ex)
			{
				UpdateToken(ex);
				return _service.ExecuteSqlByParams(Serializer.Serialize(strSql), Serializer.Serialize(cmdParms), GetToken());
			}
		}

		/// <summary>
		/// 执行多条SQL语句，实现数据库事务。
		/// </summary>
		/// <param name="htSql">SQL语句哈希表（key为sql语句，value是该语句的QfParameter[]）</param>
		public void ExecuteSqlTran(Hashtable htSql)
		{
			try
			{
				_service.ExecuteSqlTranByHashtable(Serializer.Serialize(htSql), GetToken());
			}
			catch (Exception ex)
			{
				UpdateToken(ex);
				_service.ExecuteSqlTranByHashtable(Serializer.Serialize(htSql), GetToken());
			}
		}

		/// <summary>
		/// 执行多条SQL语句，实现数据库事务。
		/// </summary>
		/// <param name="cmdList">命令列表</param>
		/// <returns>影响的记录数</returns>
		public int ExecuteSqlTran(List<QfCommandInfo> cmdList)
		{
			try
			{
				return _service.ExecuteSqlTranByCmdList(Serializer.Serialize(cmdList), GetToken());
			}
			catch (Exception ex)
			{
				UpdateToken(ex);
				return _service.ExecuteSqlTranByCmdList(Serializer.Serialize(cmdList), GetToken());
			}
		}

		/// <summary>
		/// 执行多条SQL语句，实现数据库事务。
		/// </summary>
		/// <param name="cmdList">命令列表</param>
		public void ExecuteSqlTranWithIndentity(List<QfCommandInfo> cmdList)
		{
			try
			{
				_service.ExecuteSqlTranWithIndentity(Serializer.Serialize(cmdList), GetToken());
			}
			catch (Exception ex)
			{
				UpdateToken(ex);
				_service.ExecuteSqlTranWithIndentity(Serializer.Serialize(cmdList), GetToken());
			}
		}

		/// <summary>
		/// 执行多条SQL语句，实现数据库事务。
		/// </summary>
		/// <param name="htSql">SQL语句的哈希表（key为sql语句，value是该语句的QfParameter[]）</param>
		public void ExecuteSqlTranWithIndentity(Hashtable htSql)
		{
			try
			{
				_service.ExecuteSqlTranWithIndentityByHashtable(Serializer.Serialize(htSql), GetToken());
			}
			catch (Exception ex)
			{
				UpdateToken(ex);
				_service.ExecuteSqlTranWithIndentityByHashtable(Serializer.Serialize(htSql), GetToken());
			}
		}

		/// <summary>
		/// 执行一条计算查询结果语句。
		/// </summary>
		/// <param name="strSql">SQL语句</param>
		/// <param name="cmdParms">参数列表</param>
		/// <returns>查询结果对象</returns>
		public object GetSingle(string strSql, params QfParameter[] cmdParms)
		{
			try
			{
				return Serializer.Deserialize(_service.GetSingleByParams(Serializer.Serialize(strSql), Serializer.Serialize(cmdParms), GetToken()));
			}
			catch (Exception ex)
			{
				UpdateToken(ex);
				return Serializer.Deserialize(_service.GetSingleByParams(Serializer.Serialize(strSql), Serializer.Serialize(cmdParms), GetToken()));
			}
		}

		/// <summary>
		/// 执行查询语句
		/// </summary>
		/// <param name="strSql">SQL语句</param>
		/// <param name="cmdParms">参数列表</param>
		/// <returns>数据集</returns>
		public DataSet Query(string strSql, params QfParameter[] cmdParms)
		{
			try
			{
				return (DataSet)Serializer.Deserialize(_service.QueryByParams(Serializer.Serialize(strSql), Serializer.Serialize(cmdParms), GetToken()));
			}
			catch (Exception ex)
			{
				UpdateToken(ex);
				return (DataSet)Serializer.Deserialize(_service.QueryByParams(Serializer.Serialize(strSql), Serializer.Serialize(cmdParms), GetToken()));
			}
		}

		/// <summary>
		/// 执行存储过程
		/// </summary>
		/// <param name="storedProcName">存储过程名</param>
		/// <param name="parameters">存储过程参数</param>
		/// <returns>数据集</returns>
		public DataSet RunProcedure(string storedProcName, ref Dictionary<string, QfParameter> parameters)
		{
			var byteParameters = Serializer.Serialize(parameters);
			try
			{
				var result = (DataSet)Serializer.Deserialize(_service.RunProcedureByDicParams(Serializer.Serialize(storedProcName), GetToken(), ref byteParameters));
				parameters = (Dictionary<string, QfParameter>)Serializer.Deserialize(byteParameters);
				return result;
			}
			catch (Exception ex)
			{
				UpdateToken(ex);
				var result = (DataSet)Serializer.Deserialize(_service.RunProcedureByDicParams(Serializer.Serialize(storedProcName), GetToken(), ref byteParameters));
				parameters = (Dictionary<string, QfParameter>)Serializer.Deserialize(byteParameters);
				return result;
			}
		}

		/// <summary>
		/// 执行存储过程
		/// </summary>
		/// <param name="storedProcName">存储过程名</param>
		/// <param name="parameters">存储过程参数</param>
		/// <param name="tableName">表名</param>
		/// <returns>数据集</returns>
		public DataSet RunProcedure(string storedProcName, ref QfParameter[] parameters, string tableName)
		{
			var byteParameters = Serializer.Serialize(parameters);
			try
			{
				var result = (DataSet)Serializer.Deserialize(_service.RunProcedure(Serializer.Serialize(storedProcName), Serializer.Serialize(tableName), GetToken(), ref byteParameters));
				parameters = (QfParameter[])Serializer.Deserialize(byteParameters);
				return result;
			}
			catch (Exception ex)
			{
				UpdateToken(ex);
				var result = (DataSet)Serializer.Deserialize(_service.RunProcedure(Serializer.Serialize(storedProcName), Serializer.Serialize(tableName), GetToken(), ref byteParameters));
				parameters = (QfParameter[])Serializer.Deserialize(byteParameters);
				return result;
			}
		}

		/// <summary>
		/// 执行存储过程，指定超时时间
		/// </summary>
		/// <param name="storedProcName">存储过程名</param>
		/// <param name="parameters">存储过程参数</param>
		/// <param name="tableName">表名</param>
		/// <param name="timeout">超时时间</param>
		/// <returns>数据集</returns>
		public DataSet RunProcedure(string storedProcName, ref QfParameter[] parameters, string tableName, int timeout)
		{
			var byteParameters = Serializer.Serialize(parameters);
			try
			{
				var result = (DataSet)Serializer.Deserialize(_service.RunProcedureByTimeOut(Serializer.Serialize(storedProcName), Serializer.Serialize(tableName), timeout, GetToken(), ref byteParameters));
				parameters = (QfParameter[])Serializer.Deserialize(byteParameters);
				return result;
			}
			catch (Exception ex)
			{
				UpdateToken(ex);
				var result = (DataSet)Serializer.Deserialize(_service.RunProcedureByTimeOut(Serializer.Serialize(storedProcName), Serializer.Serialize(tableName), timeout, GetToken(), ref byteParameters));
				parameters = (QfParameter[])Serializer.Deserialize(byteParameters);
				return result;
			}
		}

		/// <summary>
		/// 执行存储过程
		/// </summary>
		/// <param name="storedProcName">存储过程名</param>
		/// <param name="parameters">存储过程参数</param>
		/// <returns>数据集</returns>
		public DataSet RunProcedureDataSet(string storedProcName, ref QfParameter[] parameters)
		{
			var byteParameters = Serializer.Serialize(parameters);
			try
			{
				var result = (DataSet)Serializer.Deserialize(_service.RunProcedureDataSet(Serializer.Serialize(storedProcName), GetToken(), ref byteParameters));
				parameters = (QfParameter[])Serializer.Deserialize(byteParameters);
				return result;
			}
			catch (Exception ex)
			{
				UpdateToken(ex);
				var result = (DataSet)Serializer.Deserialize(_service.RunProcedureDataSet(Serializer.Serialize(storedProcName), GetToken(), ref byteParameters));
				parameters = (QfParameter[])Serializer.Deserialize(byteParameters);
				return result;
			}
		}

		/// <summary>
		/// 执行存储过程，返回影响的行数
		/// </summary>
		/// <param name="storedProcName">存储过程名</param>
		/// <param name="parameters">存储过程参数</param>
		/// <param name="rowsAffected">影响的行数</param>
		/// <returns>存储过程返回值</returns>
		public int RunProcedure(string storedProcName, ref QfParameter[] parameters, out int rowsAffected)
		{
			var byteParameters = Serializer.Serialize(parameters);
			try
			{
				var result = _service.RunProcedureRetRowsAffected(Serializer.Serialize(storedProcName), GetToken(), ref byteParameters, out rowsAffected);
				parameters = (QfParameter[])Serializer.Deserialize(byteParameters);
				return result;
			}
			catch (Exception ex)
			{
				UpdateToken(ex);
				var result = _service.RunProcedureRetRowsAffected(Serializer.Serialize(storedProcName), GetToken(), ref byteParameters, out rowsAffected);
				parameters = (QfParameter[])Serializer.Deserialize(byteParameters);
				return result;
			}
		}

		/// <summary>
		/// 执行存储过程
		/// </summary>
		/// <param name="storedProcName">存储过程名</param>
		/// <param name="parameters">存储过程参数</param>
		/// <returns>是否成功执行</returns>
		public bool RunProcedure_(string storedProcName, ref Dictionary<string, QfParameter> parameters)
		{
			var byteParameters = Serializer.Serialize(parameters);
			try
			{
				var result = _service.RunProcedureByDicParams_(Serializer.Serialize(storedProcName), GetToken(), ref byteParameters);
				parameters = (Dictionary<string, QfParameter>)Serializer.Deserialize(byteParameters);
				return result;
			}
			catch (Exception ex)
			{
				UpdateToken(ex);
				var result = _service.RunProcedureByDicParams_(Serializer.Serialize(storedProcName), GetToken(), ref byteParameters);
				parameters = (Dictionary<string, QfParameter>)Serializer.Deserialize(byteParameters);
				return result;
			}
		}

		/// <summary>
		/// 执行存储过程
		/// </summary>
		/// <param name="storedProcName">存储过程名</param>
		/// <param name="parameters">存储过程参数</param>
		/// <returns></returns>
		public bool RunProcedure_(string storedProcName, ref QfParameter[] parameters)
		{
			var byteParameters = Serializer.Serialize(parameters);
			try
			{
				var result = _service.RunProcedure_(Serializer.Serialize(storedProcName), GetToken(), ref byteParameters);
				parameters = (QfParameter[])Serializer.Deserialize(byteParameters);
				return result;
			}
			catch (Exception ex)
			{
				UpdateToken(ex);
				var result = _service.RunProcedure_(Serializer.Serialize(storedProcName), GetToken(), ref byteParameters);
				parameters = (QfParameter[])Serializer.Deserialize(byteParameters);
				return result;
			}
		}
        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public bool GenerateThumbnail(string filePath, string fileName, int width, int height)
        {
            return _service.GenerateThumbnail(filePath, fileName, width, height);
        }

        /// <summary>
        /// 创建目录
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        public bool CreateDirectory(string directory)
        {
            return _service.CreateDirectory(directory);
        }

        /// <summary>
        /// 创建上传实例
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        public UploadInstance CreateUploadInstance(string path, string fileName)
        {
            return (UploadInstance)ManagerCommon.DeserializeEntity(_service.CreateUploadInstance(path, fileName));
        }

        /// <summary>
        /// 上传文件数据
        /// </summary>
        /// <param name="instance">实例</param>
        /// <param name="data">数据</param>
        /// <param name="offset">偏移量</param>
        /// <param name="dataLength">数据长度</param>
        /// <returns></returns>
        public bool UploadFileData(UploadInstance instance, byte[] data, long offset, int dataLength)
        {
            return _service.UploadFileData(ManagerCommon.SerializeEntity(instance), data, offset, dataLength);
        }

        /// <summary>
        /// 中止上传
        /// </summary>
        /// <param name="instance">实例</param>
        public void AbortUpload(UploadInstance instance)
        {
            _service.AbortUpload(ManagerCommon.SerializeEntity(instance));
        }

        /// <summary>
        /// 文件是否存在
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool FileExists(string path)
        {
            return _service.FileExists(path);
        }

        /// <summary>
        /// 获取文件大小
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public long GetFileLength(string path)
        {
            return _service.GetFileLength(path);
        }

        /// <summary>
        /// 下载文件数据
        /// </summary>
        /// <param name="path"></param>
        /// <param name="offset"></param>
        /// <param name="dataLength"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int DownloadFileData(string path, long offset, int dataLength, out byte[] data)
        {
            return _service.DownloadFileData(path, offset, dataLength, out data);
        }
        /// <summary>
        /// 获取学员微信UnionID
        /// </summary>
        /// <param name="WechatOpenID"></param>
        /// <returns></returns>
        public string GetWechatUserInfo(string WechatOpenID)
        {
            return _service.GetWechatUserInfo(WechatOpenID);
        }
	}
}
