namespace DSTS.Model.Base
{
	/// <summary>
	/// 查询参数基类
	/// </summary>
	public abstract class QueryParamBase
	{
		/// <summary>
		/// 方法标记
		/// </summary>
		public string Method { get; set; }

		/// <summary>
		/// 页面索引
		/// </summary>
		public int PageIndex { get; set; }

		/// <summary>
		/// 单页大小
		/// </summary>
		public int PageSize { get; set; }

		/// <summary>
		/// 记录总数
		/// </summary>
		public int PageCount { get; set; }

		/// <summary>
		/// 排序表别名
		/// </summary>
		public string SortTableAliasName { get; set; }

		/// <summary>
		/// 排序列名
		/// </summary>
		public string SortColumnName { get; set; }

		/// <summary>
		/// 排序顺序
		/// </summary>
		public string SortOrder { get; set; }

		/// <summary>
		/// 排序字符串，内嵌于SQL
		/// </summary>
		public string SortString
		{
			get
			{
				if (string.IsNullOrEmpty(SortColumnName)) return null;
				if (!string.IsNullOrEmpty(SortTableAliasName))
				{
					return SortTableAliasName + "." + SortColumnName + " " + SortOrder;
				}
				return SortColumnName + " " + SortOrder;
			}
		}
	}
}
