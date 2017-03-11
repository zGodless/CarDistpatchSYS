using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraBars.ViewInfo;

namespace DS.MSClient.UICommon
{
	static class ClientCache
	{
		private static readonly Hashtable Cache = new Hashtable();

		internal delegate object GetDataMethod();

		/// <summary>
		/// 是否包含指定名称
		/// </summary>
		/// <param name="name">名称</param>
		/// <returns></returns>
		public static bool Contains(string name)
		{
			return Cache.Contains(name);
		}

		/// <summary>
		/// 添加一个缓存
		/// </summary>
		/// <param name="name">名称</param>
		/// <param name="value">值</param>
		public static void Add(string name, object value)
		{
			if (Contains(name))
			{
				Cache[name] = value;
			}
			else
			{
				Cache.Add(name, value);
			}
		}

		/// <summary>
		/// 获取一个缓存
		/// </summary>
		/// <param name="name">名称</param>
		/// <returns>存在则返回值，否则返回空</returns>
		public static object Get(string name)
		{
			return Contains(name) ? Cache[name] : null;
		}

		/// <summary>
		/// 添加一个缓存，自动从服务器获取
		/// </summary>
		/// <param name="name">名称</param>
		/// <param name="method">从服务器获取对象的方法</param>
		/// <returns>存在则返回缓存，不存在则返回服务器对象</returns>
		public static void AddAuto(string name, GetDataMethod method)
		{
			var obj = method();
			Add(name, obj);
		}

		/// <summary>
		/// 获取一个对象，自动从缓存服务器获取
		/// </summary>
		/// <param name="name">名称</param>
		/// <param name="method">从服务器获取对象的方法</param>
		/// <returns>存在则返回缓存，不存在则返回服务器对象</returns>
		public static object GetAuto(string name, GetDataMethod method)
		{
			if (Contains(name))
			{
				return Cache[name];
			}
			var obj = method();
			Add(name, obj);
			return obj;
		}

		/// <summary>
		/// 获取一个对象，自动从服务器获取并更新到缓存
		/// </summary>
		/// <param name="name">名称</param>
		/// <param name="method">从服务器获取对象的方法</param>
		/// <returns>存在则返回缓存，不存在则返回服务器对象</returns>
		public static object GetUpdate(string name, GetDataMethod method)
		{
			var obj = method();
			Add(name, obj);
			return obj;
		}
	}
}
