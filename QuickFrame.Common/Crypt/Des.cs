using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace QuickFrame.Common.Crypt
{
	/// <summary>
	/// DES 加解密
	/// </summary>
	public static class Des
	{
		/// <summary>
		///     DES加密字符串
		/// </summary>
		/// <param name="encryptString">待加密的字符串</param>
		/// <param name="encryptKey">加密密钥,要求为8位</param>
		/// <returns>加密成功返回加密后的字符串，失败返回源串 </returns>
		public static string Encrypt(string encryptString, string encryptKey)
		{
			try
			{
				var rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
				var rgbIv = CryptKeys.DesKeys;
				var inputByteArray = Encoding.UTF8.GetBytes(encryptString);
				var dcsp = new DESCryptoServiceProvider();
				var mStream = new MemoryStream();
				var cStream = new CryptoStream(mStream, dcsp.CreateEncryptor(rgbKey, rgbIv), CryptoStreamMode.Write);
				cStream.Write(inputByteArray, 0, inputByteArray.Length);
				cStream.FlushFinalBlock();
				return Convert.ToBase64String(mStream.ToArray());
			}
			catch
			{
				return encryptString;
			}
		}

		/// <summary>
		///     DES解密字符串
		/// </summary>
		/// <param name="decryptString">待解密的字符串</param>
		/// <param name="decryptKey">解密密钥,要求为8位,和加密密钥相同</param>
		/// <returns>解密成功返回解密后的字符串，失败返源串</returns>
		public static string Decrypt(string decryptString, string decryptKey)
		{
			try
			{
				var rgbKey = Encoding.UTF8.GetBytes(decryptKey);
				var rgbIv = CryptKeys.DesKeys;
				var inputByteArray = Convert.FromBase64String(decryptString);
				var dcsp = new DESCryptoServiceProvider();
				var mStream = new MemoryStream();
				var cStream = new CryptoStream(mStream, dcsp.CreateDecryptor(rgbKey, rgbIv), CryptoStreamMode.Write);
				cStream.Write(inputByteArray, 0, inputByteArray.Length);
				cStream.FlushFinalBlock();
				return Encoding.UTF8.GetString(mStream.ToArray());
			}
			catch
			{
				return decryptString;
			}
		}
	}
}
