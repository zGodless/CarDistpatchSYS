using System;
using System.Configuration;

namespace QuickFrame.DbConnector
{
	/// <summary>
	/// 数据库连接字符串生成器
	/// </summary>
    static class DbConnStrGenerator
	{
		public static string DbType = ConfigurationManager.AppSettings["DbType"];
		public static string DbHost = ConfigurationManager.AppSettings["DbHost"];
		public static string DbPort = ConfigurationManager.AppSettings["DbPort"];
		public static string DbName = ConfigurationManager.AppSettings["DbName"];
		public static string DbUser = ConfigurationManager.AppSettings["DbUser"];
		public static string DbPass = ConfigurationManager.AppSettings["DbPass"];
		public static string DbCharSet = ConfigurationManager.AppSettings["DbCharSet"];
        /// <summary>
        /// 获取本地连接字符串
        /// </summary>
        public static string ConnectionString
        {
            get
			{
				switch (DbType.ToLower())
				{
					case "postgresql":
						return string.Format(
							"Host={0};Port={1};Database={2};User ID={3};Password={4};Pooling=true;Min Pool Size=10;Max Pool Size=5000;",
							DbHost, DbPort, DbName, DbUser, DbPass);
					case "sqlserver":
						return string.Format(
							"Data Source={0},{1};Initial Catalog={2};User Id={3};Password={4};",
							DbHost, DbPort, DbName, DbUser, DbPass);
					default:
						return string.Format(
							"Server={0};Port={1};Database={2};Uid={3};Pwd={4};CharSet={5};Pooling=true;MinimumPoolSize=10;Allow User Variables=True;MaximumPoolSize=5000;",
							DbHost, DbPort, DbName, DbUser, DbPass, DbCharSet);
				}
            }
        }
    }
}
