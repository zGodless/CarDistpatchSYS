using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DS.MSClient.UICommon
{
	/// <summary>
	/// 新建事件参数
	/// </summary>
	public class NewEventArgs : EventArgs
	{
		/// <summary>
		/// 新增数据
		/// </summary>
		public object Data { get; set; }
	}

	/// <summary>
	/// 新建事件处理器
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	public delegate void NewEventHandler(object sender, NewEventArgs e);
}
