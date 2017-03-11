using System;
using System.Security.Cryptography;
using System.Text;

namespace QuickFrame.Common.Crypt
{
	/// <summary>
	/// SHA1 加密
	/// </summary>
	public static class Sha1
	{
		/// <summary>
		///     SHA1加密
		/// </summary>
		/// <param name="strSha1In">待加密的字符串</param>
		/// <returns>返回加密结果</returns>
		public static string Encrypt(string strSha1In)
		{
			SHA1 sha1 = new SHA1CryptoServiceProvider();
			var bytesSha1In = Encoding.UTF8.GetBytes(strSha1In);
			var bytesSha1Out = sha1.ComputeHash(bytesSha1In);
			var strSha1Out = BitConverter.ToString(bytesSha1Out);
			return strSha1Out;
		}
	}
}
