using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickFrame.Model.Token
{
	/// <summary>
	/// 令牌
	/// </summary>
	[Serializable]
	public class QfToken
	{
		public string TokenID { get; set; }

		public string TokenCode { get; set; }

		public long Timestamp { get; set; }

		public string Nonce { get; set; }
	}
}
