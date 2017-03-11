using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using QuickFrame.Common.Exception;

namespace QuickFrame.Common.Crypt
{
	/// <summary>
	/// 加盐加密
	/// </summary>
	public static class Salt
	{
		/// <summary>
		///     获取加盐的散列值
		/// </summary>
		/// <param name="paraTohash">要HASH的字符</param>
		/// <returns></returns>
		public static string Encrypt(string paraTohash)
		{
			if (string.IsNullOrEmpty(paraTohash))
			{
				throw new QfException(@"参数不能为NULL或""");
			}
			var strToHash = CryptKeys.SaltKeys + paraTohash;
			var strBytes = Encoding.Default.GetBytes(strToHash);
			var shaHash = new SHA1CryptoServiceProvider();
			var hash = shaHash.ComputeHash(strBytes);
			return Convert.ToBase64String(hash);
		}
	}
}
