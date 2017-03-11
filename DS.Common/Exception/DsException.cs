using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DS.Common.Exception
{
	/// <summary>
	/// 驾校系统异常
	/// </summary>
	public class DsException : System.Exception
	{
		public DsException()
			: this("QuickFrame 发生异常") { }

		public DsException(string message)
			: base(message)
		{
		}

		public DsException(string message, System.Exception innerException)
			: base(message, innerException)
		{

		}
	}
}
