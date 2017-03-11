using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace QuickFrame.Common.Crypt
{
	/// <summary>
	/// MD5 加密
	/// </summary>
	public static class Md5
	{
		/// <summary>
		///     MD5 加密
		/// </summary>
		/// <param name="strMd5In">待加密的字符串</param>
		/// <returns>返回加密结果</returns>
		public static string Encrypt(string strMd5In)
		{
			MD5 md5 = new MD5CryptoServiceProvider();
			var bytesMd5In = Encoding.UTF8.GetBytes(strMd5In);
			var bytesMd5Out = md5.ComputeHash(bytesMd5In);
			var strMd5Out = BitConverter.ToString(bytesMd5Out);
			return strMd5Out;
		}
	}
}
