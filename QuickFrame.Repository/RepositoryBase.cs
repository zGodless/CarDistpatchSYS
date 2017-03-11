namespace QuickFrame.Repository
{
	/// <summary>
	/// SQL 仓库基类
	/// </summary>
	public abstract class RepositoryBase
	{
		/// <summary>
		/// 获取SQL
		/// </summary>
		/// <param name="dbType">数据库类型</param>
		/// <param name="path">路径</param>
		/// <returns></returns>
		public abstract string GetSql(string dbType, string path);
	}
}
