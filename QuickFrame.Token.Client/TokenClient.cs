using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickFrame.Common.Crypt;
using QuickFrame.Model.Token;

namespace QuickFrame.Token.Client
{
	public class TokenClient
	{
		private readonly string _tokenSalt = ConfigurationManager.AppSettings["TokenSalt"];
		private readonly int _tokenTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["TokenTimeout"]);
		private const string EncryptKey = "h$AE8b-.";

		private string _tokenKey;
		private string _tokenId;
		private DateTime _expireDate;

		public TokenSign GetTokenSign()
		{
			var timestamp = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0)).Ticks;
			var nonce = (new Random((int)(DateTime.Now.Ticks))).Next(10000000, 99999999).ToString();
			var data = new List<string> { _tokenSalt, timestamp.ToString(), nonce };
			data.Sort();
			var sign = Md5.Encrypt(string.Join("", data.ToArray()));
			var tokenSign = new TokenSign() { Nonce = nonce, Signature = sign, Timestamp = timestamp };
			return tokenSign;
		}

		/// <summary>
		/// 初始化令牌
		/// </summary>
		/// <param name="tokenKey"></param>
		/// <returns></returns>
		public bool InitToken(string tokenKey)
		{
			try
			{
				_expireDate = DateTime.Now;
				_tokenKey = tokenKey;
				_tokenId = Des.Decrypt(_tokenKey, EncryptKey);
				return true;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// 令牌是否过期
		/// </summary>
		/// <returns></returns>
		public bool IsTokenExipre()
		{
			var tokenTimeout = _tokenTimeout - 2 <= 0 ? 0 : _tokenTimeout - 2;
			return _expireDate.AddMinutes(tokenTimeout) < DateTime.Now;
		}

		/// <summary>
		/// 获取一个Token
		/// </summary>
		/// <returns>Token</returns>
		public QfToken GetToken()
		{
			var timestamp = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0)).Ticks;
			var nonce = (new Random((int)(DateTime.Now.Ticks))).Next(10000000, 99999999).ToString();
			var data = new List<string> { _tokenKey, timestamp.ToString(), nonce };
			data.Sort();
			var tokenCode = Sha1.Encrypt(string.Join("", data.ToArray()));
			var token = new QfToken() { TokenID = _tokenId, TokenCode = tokenCode, Timestamp = timestamp, Nonce = nonce };
			return token;
		}
	}

	public class TokenSign
	{
		public string Signature { get; set; }

		public long Timestamp { get; set; }

		public string Nonce { get; set; }
	}
}
