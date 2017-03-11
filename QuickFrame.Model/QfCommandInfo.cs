using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickFrame.Model
{
	/// <summary>
	/// QuickFrame SQL命令信息
	/// </summary>
	[Serializable]
	public class QfCommandInfo
	{
		#region 初始化

		/// <summary>
		/// 初始化命令信息
		/// </summary>
		public QfCommandInfo()
		{
			EffectNextType = EffectNextType.None;
		}

		/// <summary>
		/// 初始化命令信息
		/// </summary>
		/// <param name="sqlText">SQL文本</param>
		public QfCommandInfo(string sqlText)
			: this()
		{
			CommandText = sqlText;
			Parameters = new QfParameter[0];
		}

		/// <summary>
		/// 初始化命令信息
		/// </summary>
		/// <param name="sqlText">SQL文本</param>
		/// <param name="paras">参数表</param>
		public QfCommandInfo(string sqlText, params QfParameter[] paras)
			: this()
		{
			CommandText = sqlText;
			Parameters = paras;
		}

		/// <summary>
		/// 初始化命令信息
		/// </summary>
		/// <param name="sqlText">SQL文本</param>
		/// <param name="paras">参数表</param>
		public QfCommandInfo(string sqlText, IEnumerable<QfParameter> paras)
			: this()
		{
			CommandText = sqlText;
			Parameters = paras.ToArray();
		}

		/// <summary>
		/// 初始化命令信息
		/// </summary>
		/// <param name="sqlText">SQL文本</param>
		/// <param name="paras">参数表</param>
		/// <param name="type">影响操作类型</param>
		public QfCommandInfo(string sqlText, QfParameter[] paras, EffectNextType type)
		{
			CommandText = sqlText;
			Parameters = paras;
			EffectNextType = type;
		}

		/// <summary>
		/// 初始化命令信息
		/// </summary>
		/// <param name="sqlText">SQL文本</param>
		/// <param name="paras">参数表</param>
		/// <param name="type">影响操作类型</param>
		public QfCommandInfo(string sqlText, IEnumerable<QfParameter> paras, EffectNextType type)
		{
			CommandText = sqlText;
			Parameters = paras.ToArray();
			EffectNextType = type;
		}

		#endregion

		#region 属性

		/// <summary>
		/// 共享对象
		/// </summary>
		public object ShareObject { get; set; }

		/// <summary>
		/// 原始数据
		/// </summary>
		public object OriginalData { get; set; }

		/// <summary>
		/// 请求事件
		/// </summary>
		public event EventHandler RequestEvent;

		/// <summary>
		/// 命令文本
		/// </summary>
		public string CommandText { get; set; }

		/// <summary>
		/// 参数
		/// </summary>
		public QfParameter[] Parameters { get; set; }

		/// <summary>
		/// 影响操作类型
		/// </summary>
		public EffectNextType EffectNextType { get; set; }

		#endregion

		#region 方法

		/// <summary>
		/// 在请求事件发生时执行
		/// </summary>
		protected virtual void OnRequestEvent()
		{
			var handler = RequestEvent;
			if (handler != null) handler(this, EventArgs.Empty);
		}

		#endregion

	}

	/// <summary>
	/// 影响操作枚举
	/// </summary>
	public enum EffectNextType
	{
		/// <summary>
		/// 当前语句影响到的行数必须大于0，否则回滚事务
		/// </summary>
		ExcuteEffectRows,
		/// <summary>
		/// 对其他语句无任何影响 
		/// </summary>
		None,
		/// <summary>
		/// 引发事件-当前语句必须为"select count(1) from .."格式，如果不存在则继续执行，存在回滚事务
		/// </summary>
		RequestEvent,
		/// <summary>
		/// 当前语句必须为"select count(1) from .."格式，如果存在则继续执行，不存在回滚事务
		/// </summary>
		WhenHaveContine,
		/// <summary>
		/// 当前语句必须为"select count(1) from .."格式，如果不存在则继续执行，存在回滚事务
		/// </summary>
		WhenNoHaveContine
	}
}
