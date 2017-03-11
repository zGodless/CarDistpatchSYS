using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using Newtonsoft.Json;
using QuickFrame.ClientConnector.Properties;
using QuickFrame.Common.Converter;
using QuickFrame.Common.Crypt;
using QuickFrame.Model;

namespace QuickFrame.ClientConnector
{
	/// <summary>
	/// Web API 连接器
	/// Author: Noly Oh
	/// Create Date: 2015-06-07
	/// </summary>
	public class WebApiConnector
	{
		/// <summary>
		/// API 接口基本 URL 地址
		/// </summary>
		private readonly string _apiUrl = ConfigurationManager.AppSettings["ApiServerUrl"];

		/// <summary>
		/// API Token 密钥
		/// </summary>
		private readonly string _apiToken = ConfigurationManager.AppSettings["ApiToken"];

		/// <summary>
		/// HTTP Client 对象
		/// </summary>
		private readonly HttpClient _httpClient;

		public bool UseToken { get; set; }

		/// <summary>
		/// 构造 WebAPI 连接器
		/// </summary>
		public WebApiConnector(bool useToken = false)
		{
			_httpClient = new HttpClient {BaseAddress = new Uri(_apiUrl)};
			_httpClient.DefaultRequestHeaders.Add("user-agent", Resources.UserAgent);
			UseToken = useToken;
		}

		/// <summary>
		/// 析构 WebAPI 连接器
		/// </summary>
		~WebApiConnector()
		{
			_httpClient.Dispose();
		}

		/// <summary>
		/// 生成 API Token 信息
		/// </summary>
		/// <returns></returns>
		public List<KeyValuePair<string, string>> GenToken()
		{
			var timestamp = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0)).Ticks.ToString();
			var nonce = (new Random((int)(DateTime.Now.Ticks))).Next(0, 999999999).ToString("D9");
			var data = new List<string> {timestamp, nonce, _apiToken};
			data.Sort();
			var sign = Sha1.Encrypt(string.Join("", data.ToArray())).Replace("-", "").ToLower();
			var resultList = new List<KeyValuePair<string, string>>();
			resultList.Add(new KeyValuePair<string, string>("signature", sign));
			resultList.Add(new KeyValuePair<string, string>("timestamp", timestamp));
			resultList.Add(new KeyValuePair<string, string>("nonce", nonce));
			return resultList;
		}

		private List<KeyValuePair<string, string>> GenStrKvList(IQfApiParameter paramElement)
		{
			if (paramElement == null) return null;
			var paramList = new List<KeyValuePair<string, string>>();
			var type = paramElement.GetType();
			foreach (PropertyInfo prop in type.GetProperties())
			{
				var value = prop.GetValue(paramElement, null);
				paramList.Add(new KeyValuePair<string, string>(prop.Name, ValueConvert.ToString(value)));
			}
			return paramList;
		} 

		/// <summary>
		/// 生成 GET 参数字符串
		/// </summary>
		/// <param name="paramElement">参数元素</param>
		/// <returns></returns>
		private string GenGetParamString(IQfApiParameter paramElement)
		{
			var paramList = GenStrKvList(paramElement);
			if (paramList == null) return "";
			var strList = paramList.Select(pair => string.Format("{0}={1}", pair.Key, pair.Value)).ToList();
			return string.Join("&", strList);
		}

		/// <summary>
		/// 生成 GET 参数字符串
		/// </summary>
		/// <param name="paramList">参数列表</param>
		/// <returns></returns>
		private string GenGetParamString(IEnumerable<KeyValuePair<string, string>> paramList)
		{
			if (paramList == null) return "";
			var strList = paramList.Select(pair => string.Format("{0}={1}", pair.Key, pair.Value)).ToList();
			return string.Join("&", strList);
		}

		/// <summary>
		/// 生成 URI 字符串
		/// </summary>
		/// <param name="module">模块</param>
		/// <param name="controller">控制器</param>
		/// <param name="method">方法</param>
		/// <param name="paramString">参数字符串</param>
		/// <returns></returns>
		private string GenUri(string module, string controller, string method, string paramString = null)
		{
			if (!UseToken)
				return !string.IsNullOrEmpty(paramString)
					? string.Format("/{0}/{1}/{2}?{3}", module, controller, method, paramString)
					: string.Format("/{0}/{1}/{2}", module, controller, method);
			var tokenParamString = GenGetParamString(GenToken());
			return !string.IsNullOrEmpty(paramString)
				? string.Format("/{0}/{1}/{2}?{3}&{4}", module, controller, method, tokenParamString, paramString)
				: string.Format("/{0}/{1}/{2}?{3}", module, controller, method, tokenParamString);
		}

		/// <summary>
		/// 生成 URI 字符串
		/// </summary>
		/// <param name="module">模块</param>
		/// <param name="controller">控制器</param>
		/// <param name="method">方法</param>
		/// <param name="paramList">参数列表</param>
		/// <returns></returns>
		private string GenUri(string module, string controller, string method, IEnumerable<KeyValuePair<string, string>> paramList)
		{
			return GenUri(module, controller, method, GenGetParamString(paramList));
		}

		/// <summary>
		/// 执行 GET 请求
		/// </summary>
		/// <param name="module">模块</param>
		/// <param name="controller">控制器</param>
		/// <param name="method">方法</param>
		/// <param name="paramString">参数字符串</param>
		/// <returns></returns>
		public string Get(string module, string controller, string method, string paramString = null)
		{
			var uri = GenUri(module, controller, method, paramString);
			var asyncTask = _httpClient.GetStringAsync(uri);
			asyncTask.Wait();
			var content = asyncTask.Result;
			return content;
		}

		/// <summary>
		/// 执行 GET 请求
		/// </summary>
		/// <param name="module">模块</param>
		/// <param name="controller">控制器</param>
		/// <param name="method">方法</param>
		/// <param name="paramList">参数列表</param>
		/// <returns></returns>
		public string Get(string module, string controller, string method, IEnumerable<KeyValuePair<string, string>> paramList)
		{
			return Get(module, controller, method, GenGetParamString(paramList));
		}

		/// <summary>
		/// 执行 GET 请求
		/// </summary>
		/// <param name="module">模块</param>
		/// <param name="controller">控制器</param>
		/// <param name="method">方法</param>
		/// <param name="paramElement">参数元素</param>
		/// <returns></returns>
		public string Get(string module, string controller, string method, IQfApiParameter paramElement)
		{
			return Get(module, controller, method, GenGetParamString(paramElement));
		}

		/// <summary>
		/// 执行 GET 请求
		/// </summary>
		/// <typeparam name="T">转换类型</typeparam>
		/// <param name="module">模块</param>
		/// <param name="controller">控制器</param>
		/// <param name="method">方法</param>
		/// <param name="paramString">参数字符串</param>
		/// <returns></returns>
		public T Get<T>(string module, string controller, string method, string paramString = null)
		{
			var content = Get(module, controller, method, paramString);
			var result = JsonConvert.DeserializeObject<T>(content);
			return result;
		}

		/// <summary>
		/// 执行 GET 请求
		/// </summary>
		/// <typeparam name="T">转换类型</typeparam>
		/// <param name="module">模块</param>
		/// <param name="controller">控制器</param>
		/// <param name="method">方法</param>
		/// <param name="paramList">参数列表</param>
		/// <returns></returns>
		public T Get<T>(string module, string controller, string method, IEnumerable<KeyValuePair<string, string>> paramList)
		{
			return Get<T>(module, controller, method, GenGetParamString(paramList));
		}

		/// <summary>
		/// 执行 GET 请求
		/// </summary>
		/// <typeparam name="T">转换类型</typeparam>
		/// <param name="module">模块</param>
		/// <param name="controller">控制器</param>
		/// <param name="method">方法</param>
		/// <param name="paramElement">参数元素</param>
		/// <returns></returns>
		public T Get<T>(string module, string controller, string method, IQfApiParameter paramElement)
		{
			return Get<T>(module, controller, method, GenGetParamString(paramElement));
		}

		/// <summary>
		/// 执行 GET 请求
		/// </summary>
		/// <typeparam name="T">转换类型</typeparam>
		/// <param name="module">模块</param>
		/// <param name="controller">控制器</param>
		/// <param name="method">方法</param>
		/// <param name="paramString">参数字符串</param>
		/// <returns></returns> 
		public QfJsonResultList<T> GetList<T>(string module, string controller, string method, string paramString = null)
		{
			var content = Get(module, controller, method, paramString);
			var result = JsonConvert.DeserializeObject<QfJsonResultList<T>>(content);
			return result;
		}

		/// <summary>
		/// 执行 GET 请求
		/// </summary>
		/// <typeparam name="T">转换类型</typeparam>
		/// <param name="module">模块</param>
		/// <param name="controller">控制器</param>
		/// <param name="method">方法</param>
		/// <param name="paramList">参数列表</param>
		/// <returns></returns>
		public QfJsonResultList<T> GetList<T>(string module, string controller, string method, IEnumerable<KeyValuePair<string, string>> paramList)
		{
			return GetList<T>(module, controller, method, GenGetParamString(paramList));
		}

		/// <summary>
		/// 执行 GET 请求
		/// </summary>
		/// <typeparam name="T">转换类型</typeparam>
		/// <param name="module">模块</param>
		/// <param name="controller">控制器</param>
		/// <param name="method">方法</param>
		/// <param name="paramElement">参数元素</param>
		/// <returns></returns>
		public QfJsonResultList<T> GetList<T>(string module, string controller, string method, IQfApiParameter paramElement)
		{
			return GetList<T>(module, controller, method, GenGetParamString(paramElement));
		}

		/// <summary>
		/// 执行 POST 请求
		/// </summary>
		/// <param name="module">模块</param>
		/// <param name="controller">控制器</param>
		/// <param name="method">方法</param>
		/// <param name="paramString">参数字符串</param>
		/// <param name="postParamList">POST 参数列表</param>
		/// <returns></returns>
		public string Post(string module, string controller, string method, string paramString, IEnumerable<KeyValuePair<string, string>> postParamList)
		{
			string content;
			if (postParamList == null)
			{
				content = Get(module, controller, method, paramString);
			}
			else
			{
				var uri = GenUri(module, controller, method, paramString);
				var asyncTask = _httpClient.PostAsync(uri, new FormUrlEncodedContent(postParamList));
				asyncTask.Wait();
				content = asyncTask.Result.Content.ReadAsStringAsync().Result;
			}
			return content;
		}

		/// <summary>
		/// 执行 POST 请求
		/// </summary>
		/// <param name="module">模块</param>
		/// <param name="controller">控制器</param>
		/// <param name="method">方法</param>
		/// <param name="paramString">参数字符串</param>
		/// <param name="postParamElement">POST 参数元素</param>
		/// <returns></returns>
		public string Post(string module, string controller, string method, string paramString, IQfApiParameter postParamElement)
		{
			return Post(module, controller, method, paramString, GenStrKvList(postParamElement));
		}

		/// <summary>
		/// 执行 POST 请求
		/// </summary>
		/// <param name="module">模块</param>
		/// <param name="controller">控制器</param>
		/// <param name="method">方法</param>
		/// <param name="paramList">参数列表</param>
		/// <param name="postParamList">POST 参数列表</param>
		/// <returns></returns>
		public string Post(string module, string controller, string method, IEnumerable<KeyValuePair<string, string>> paramList, IEnumerable<KeyValuePair<string, string>> postParamList)
		{
			return Post(module, controller, method, GenGetParamString(paramList), postParamList);
		}

		/// <summary>
		/// 执行 POST 请求
		/// </summary>
		/// <param name="module">模块</param>
		/// <param name="controller">控制器</param>
		/// <param name="method">方法</param>
		/// <param name="paramList">参数列表</param>
		/// <param name="postParamElement">POST 参数元素</param>
		/// <returns></returns>
		public string Post(string module, string controller, string method, IEnumerable<KeyValuePair<string, string>> paramList, IQfApiParameter postParamElement)
		{
			return Post(module, controller, method, GenGetParamString(paramList), GenStrKvList(postParamElement));
		}

		/// <summary>
		/// 执行 POST 请求
		/// </summary>
		/// <param name="module">模块</param>
		/// <param name="controller">控制器</param>
		/// <param name="method">方法</param>
		/// <param name="paramElement">参数元素</param>
		/// <param name="postParamList">POST 参数列表</param>
		/// <returns></returns>
		public string Post(string module, string controller, string method, IQfApiParameter paramElement, IEnumerable<KeyValuePair<string, string>> postParamList)
		{
			return Post(module, controller, method, GenGetParamString(paramElement), postParamList);
		}

		/// <summary>
		/// 执行 POST 请求
		/// </summary>
		/// <param name="module">模块</param>
		/// <param name="controller">控制器</param>
		/// <param name="method">方法</param>
		/// <param name="paramElement">参数元素</param>
		/// <param name="postParamElement">POST 参数元素</param>
		/// <returns></returns>
		public string Post(string module, string controller, string method, IQfApiParameter paramElement, IQfApiParameter postParamElement)
		{
			return Post(module, controller, method, GenGetParamString(paramElement), GenStrKvList(postParamElement));
		}

		/// <summary>
		/// 执行 POST 请求
		/// </summary>
		/// <param name="module">模块</param>
		/// <param name="controller">控制器</param>
		/// <param name="method">方法</param>
		/// <param name="postParamList">POST 参数列表</param>
		/// <returns></returns>
		public string Post(string module, string controller, string method, List<KeyValuePair<string, string>> postParamList)
		{
			return Post(module, controller, method, "", postParamList);
		}

		/// <summary>
		/// 执行 POST 请求
		/// </summary>
		/// <typeparam name="T">转换类型</typeparam>
		/// <param name="module">模块</param>
		/// <param name="controller">控制器</param>
		/// <param name="method">方法</param>
		/// <param name="paramString">参数字符串</param>
		/// <param name="postParamList">POST 参数列表</param>
		/// <returns></returns>
		public T Post<T>(string module, string controller, string method, string paramString, IEnumerable<KeyValuePair<string, string>> postParamList)
		{
			var content = Post(module, controller, method, paramString, postParamList);
			var result = JsonConvert.DeserializeObject<T>(content);
			return result;
		}

		/// <summary>
		/// 执行 POST 请求
		/// </summary>
		/// <typeparam name="T">转换类型</typeparam>
		/// <param name="module">模块</param>
		/// <param name="controller">控制器</param>
		/// <param name="method">方法</param>
		/// <param name="paramString">参数字符串</param>
		/// <param name="postParamElement">POST 参数元素</param>
		/// <returns></returns>
		public T Post<T>(string module, string controller, string method, string paramString, IQfApiParameter postParamElement)
		{
			return Post<T>(module, controller, method, paramString, GenStrKvList(postParamElement));
		}

		/// <summary>
		/// 执行 POST 请求
		/// </summary>
		/// <typeparam name="T">转换类型</typeparam>
		/// <param name="module">模块</param>
		/// <param name="controller">控制器</param>
		/// <param name="method">方法</param>
		/// <param name="paramList">参数列表</param>
		/// <param name="postParamList">POST 参数列表</param>
		/// <returns></returns>
		public T Post<T>(string module, string controller, string method, IEnumerable<KeyValuePair<string, string>> paramList, IEnumerable<KeyValuePair<string, string>> postParamList)
		{
			return Post<T>(module, controller, method, GenGetParamString(paramList), postParamList);
		}

		/// <summary>
		/// 执行 POST 请求
		/// </summary>
		/// <typeparam name="T">转换类型</typeparam>
		/// <param name="module">模块</param>
		/// <param name="controller">控制器</param>
		/// <param name="method">方法</param>
		/// <param name="paramElement">参数元素</param>
		/// <param name="postParamList">POST 参数列表</param>
		/// <returns></returns>
		public T Post<T>(string module, string controller, string method, IQfApiParameter paramElement, IEnumerable<KeyValuePair<string, string>> postParamList)
		{
			return Post<T>(module, controller, method, GenGetParamString(paramElement), postParamList);
		}

		/// <summary>
		/// 执行 POST 请求
		/// </summary>
		/// <typeparam name="T">转换类型</typeparam>
		/// <param name="module">模块</param>
		/// <param name="controller">控制器</param>
		/// <param name="method">方法</param>
		/// <param name="paramList">参数列表</param>
		/// <param name="postParamElement">POST 参数元素</param>
		/// <returns></returns>
		public T Post<T>(string module, string controller, string method, IEnumerable<KeyValuePair<string, string>> paramList, IQfApiParameter postParamElement)
		{
			return Post<T>(module, controller, method, GenGetParamString(paramList), GenStrKvList(postParamElement));
		}

		/// <summary>
		/// 执行 POST 请求
		/// </summary>
		/// <typeparam name="T">转换类型</typeparam>
		/// <param name="module">模块</param>
		/// <param name="controller">控制器</param>
		/// <param name="method">方法</param>
		/// <param name="paramElement">参数元素</param>
		/// <param name="postParamElement">POST 参数元素</param>
		/// <returns></returns>
		public T Post<T>(string module, string controller, string method, IQfApiParameter paramElement, IQfApiParameter postParamElement)
		{
			return Post<T>(module, controller, method, GenGetParamString(paramElement), GenStrKvList(postParamElement));
		}

		/// <summary>
		/// 执行 POST 请求
		/// </summary>
		/// <param name="module">模块</param>
		/// <param name="controller">控制器</param>
		/// <param name="method">方法</param>
		/// <param name="postParamElement">POST 参数元素</param>
		/// <returns></returns>
		public string Post(string module, string controller, string method, IQfApiParameter postParamElement)
		{
			return Post(module, controller, method, "", GenStrKvList(postParamElement));
		}

		/// <summary>
		/// 执行 POST 请求
		/// </summary>
		/// <typeparam name="T">转换类型</typeparam>
		/// <param name="module">模块</param>
		/// <param name="controller">控制器</param>
		/// <param name="method">方法</param>
		/// <param name="postParamList">POST 参数列表</param>
		/// <returns></returns>
		public T Post<T>(string module, string controller, string method, List<KeyValuePair<string, string>> postParamList)
		{
			return Post<T>(module, controller, method, "", postParamList);
		}

		/// <summary>
		/// 执行 POST 请求
		/// </summary>
		/// <typeparam name="T">转换类型</typeparam>
		/// <param name="module">模块</param>
		/// <param name="controller">控制器</param>
		/// <param name="method">方法</param>
		/// <param name="postParamElement">POST 参数元素</param>
		/// <returns></returns>
		public T Post<T>(string module, string controller, string method, IQfApiParameter postParamElement)
		{
			return Post<T>(module, controller, method, "", GenStrKvList(postParamElement));
		}

		/// <summary>
		/// 执行 POST 请求
		/// </summary>
		/// <typeparam name="T">转换类型</typeparam>
		/// <param name="module">模块</param>
		/// <param name="controller">控制器</param>
		/// <param name="method">方法</param>
		/// <param name="paramString">参数字符串</param>
		/// <param name="postParamList">POST 参数列表</param>
		/// <returns></returns>
		public QfJsonResultList<T> PostList<T>(string module, string controller, string method, string paramString, IEnumerable<KeyValuePair<string, string>> postParamList)
		{
			var content = Post(module, controller, method, paramString, postParamList);
			var result = JsonConvert.DeserializeObject<QfJsonResultList<T>>(content);
			return result;
		}

		/// <summary>
		/// 执行 POST 请求
		/// </summary>
		/// <typeparam name="T">转换类型</typeparam>
		/// <param name="module">模块</param>
		/// <param name="controller">控制器</param>
		/// <param name="method">方法</param>
		/// <param name="paramString">参数字符串</param>
		/// <param name="postParamElement">POST 参数元素</param>
		/// <returns></returns>
		public QfJsonResultList<T> PostList<T>(string module, string controller, string method, string paramString, IQfApiParameter postParamElement)
		{
			return PostList<T>(module, controller, method, paramString, GenStrKvList(postParamElement));
		}

		/// <summary>
		/// 执行 POST 请求
		/// </summary>
		/// <typeparam name="T">转换类型</typeparam>
		/// <param name="module">模块</param>
		/// <param name="controller">控制器</param>
		/// <param name="method">方法</param>
		/// <param name="paramList">参数列表</param>
		/// <param name="postParamList">POST 参数列表</param>
		/// <returns></returns>
		public QfJsonResultList<T> PostList<T>(string module, string controller, string method, IEnumerable<KeyValuePair<string, string>> paramList, IEnumerable<KeyValuePair<string, string>> postParamList)
		{
			return PostList<T>(module, controller, method, GenGetParamString(paramList), postParamList);
		}

		/// <summary>
		/// 执行 POST 请求
		/// </summary>
		/// <typeparam name="T">转换类型</typeparam>
		/// <param name="module">模块</param>
		/// <param name="controller">控制器</param>
		/// <param name="method">方法</param>
		/// <param name="paramElement">参数元素</param>
		/// <param name="postParamList">POST 参数列表</param>
		/// <returns></returns>
		public QfJsonResultList<T> PostList<T>(string module, string controller, string method, IQfApiParameter paramElement, IEnumerable<KeyValuePair<string, string>> postParamList)
		{
			return PostList<T>(module, controller, method, GenGetParamString(paramElement), postParamList);
		}

		/// <summary>
		/// 执行 POST 请求
		/// </summary>
		/// <typeparam name="T">转换类型</typeparam>
		/// <param name="module">模块</param>
		/// <param name="controller">控制器</param>
		/// <param name="method">方法</param>
		/// <param name="paramList">参数列表</param>
		/// <param name="postParamElement">POST 参数元素</param>
		/// <returns></returns>
		public QfJsonResultList<T> PostList<T>(string module, string controller, string method, IEnumerable<KeyValuePair<string, string>> paramList, IQfApiParameter postParamElement)
		{
			return PostList<T>(module, controller, method, GenGetParamString(paramList), GenStrKvList(postParamElement));
		}

		/// <summary>
		/// 执行 POST 请求
		/// </summary>
		/// <typeparam name="T">转换类型</typeparam>
		/// <param name="module">模块</param>
		/// <param name="controller">控制器</param>
		/// <param name="method">方法</param>
		/// <param name="paramElement">参数元素</param>
		/// <param name="postParamElement">POST 参数元素</param>
		/// <returns></returns>
		public QfJsonResultList<T> PostList<T>(string module, string controller, string method, IQfApiParameter paramElement, IQfApiParameter postParamElement)
		{
			return PostList<T>(module, controller, method, GenGetParamString(paramElement), GenStrKvList(postParamElement));
		}

		/// <summary>
		/// 执行 POST 请求
		/// </summary>
		/// <typeparam name="T">转换类型</typeparam>
		/// <param name="module">模块</param>
		/// <param name="controller">控制器</param>
		/// <param name="method">方法</param>
		/// <param name="postParamList">POST 参数列表</param>
		/// <returns></returns>
		public QfJsonResultList<T> PostList<T>(string module, string controller, string method, List<KeyValuePair<string, string>> postParamList)
		{
			return PostList<T>(module, controller, method, "", postParamList);
		}

		/// <summary>
		/// 执行 POST 请求
		/// </summary>
		/// <typeparam name="T">转换类型</typeparam>
		/// <param name="module">模块</param>
		/// <param name="controller">控制器</param>
		/// <param name="method">方法</param>
		/// <param name="postParamElement">POST 参数元素</param>
		/// <returns></returns>
		public QfJsonResultList<T> PostList<T>(string module, string controller, string method, IQfApiParameter postParamElement)
		{
			return PostList<T>(module, controller, method, "", GenStrKvList(postParamElement));
		}
	}
}
