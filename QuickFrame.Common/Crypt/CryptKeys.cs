using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickFrame.Common.Crypt
{
	/// <summary>
	/// 加密密钥
	/// </summary>
	static class CryptKeys
	{
		/// <summary>
		/// DES加密向量
		/// </summary>
		public static readonly byte[] DesKeys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

		/// <summary>
		/// 加盐加密密钥
		/// </summary>
		public static readonly string SaltKeys = "kdfjelkreroogk;,1kdfj,wj,,,mk23j23kj23fgoihgfpslk;jf";
	}
}
