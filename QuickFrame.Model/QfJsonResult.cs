using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickFrame.Model
{
	/// <summary>
	/// JSON返回值
	/// </summary>
	[Serializable]
	public class QfJsonResult
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
		/// 返回值
		/// </summary>
		public object result { get; set; }

        public string unionid { get; set; }

		/// <summary>
		/// 是否被选中，列表专用
		/// </summary>
		public bool Choose { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string return_id { get; set; }
	}
}
