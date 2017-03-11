using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickFrame.Model
{
	[Serializable]
	public class QfJsonResultList<T>
	{
		/// <summary>
		/// 状态
		/// </summary>
		public string return_code { get; set; }

		/// <summary>
		/// 消息
		/// </summary>
		public string return_msg { get; set; }

		/// <summary>
		/// 列表
		/// </summary>
		public List<T> List { get; set; } 
	}
}
