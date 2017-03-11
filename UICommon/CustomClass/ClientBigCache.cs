using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraBars.ViewInfo;


namespace DS.MSClient.UICommon
{
    /// <summary>
    /// 缓存(大数据部分)
    /// </summary>
    static class ClientBigCache
    {
        private static readonly Hashtable BigCache = new Hashtable();//大缓存，放商品信息、客户信息等
        private static readonly Hashtable BigCacheLastUpdateTime = new Hashtable();//大缓存最后更新时间
        private static readonly Hashtable BigCacheUpdateTime = new Hashtable();//大缓存更新时间
        internal delegate object GetDataByTimeMethods(DateTime lastModifiedTime);
        /// <summary>
        /// 是否包含指定名称
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns></returns>
        public static bool BigContains(string name)
        {
            return BigCache.Contains(name);
        }


        /// <summary>
        /// 添加一个缓存，只用于大数据的增量更新缓存，商品信息、客户信息等
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="value">值</param>
        public static void AddBig<T>(object value)
        {
            string name = typeof(T).Name;
            if (BigContains(name))
            {
                BigCache[name] = value;
            }
            else
            {
                BigCache.Add(name, value); 
            }
            if (!BigCacheLastUpdateTime.Contains(name)) BigCacheLastUpdateTime.Add(name, BigCacheUpdateTime[name]); 
        }

        public static void Test<T>(GetDataByTimeMethods k)
        {

        }
 
        /// <summary>
        /// 添加一个缓存，自动从服务器获取，只用于大数据的增量更新缓存，商品信息、客户信息等
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="method">从服务器获取对象的方法</param>
        /// <returns>存在则返回缓存，不存在则返回服务器对象</returns>
        public static void AddBigAuto<T>( GetDataByTimeMethods method)
        {
            string name = typeof(T).Name;
            if (!BigCacheUpdateTime.Contains(name)) BigCacheUpdateTime.Add(name, DateTime.Now);//加入更新时间 

            var obj = method(GetLastUpdateTime(name));
            AddBig<T>(obj);
        }

        /// <summary>
        /// 获取一个对象，自动从缓存服务器获取，只用于大数据的增量更新缓存，商品信息、客户信息等
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="method">从服务器获取对象的方法</param>
        /// <returns>存在则返回缓存，不存在则返回服务器对象</returns>
        public static IList<T> GetBigAuto<T>(GetDataByTimeMethods method)
        {
            string name = typeof(T).Name;
            if (!BigCacheUpdateTime.Contains(name)) BigCacheUpdateTime.Add(name, DateTime.Now);//加入更新时间 
            if (BigContains(name))
            {
                return BigCache[name] as IList<T>;
            }
            var obj = method(GetLastUpdateTime(name));
            AddBig<T>(obj);
            return obj as IList<T>;
        }

        /// <summary>
        /// 获取增量更新，自动从服务器获取并更新到缓存,只用于大数据的增量更新缓存，商品信息、客户信息等
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="method">从服务器获取对象的方法</param>
        /// <returns>存在则返回缓存，不存在则返回服务器对象</returns>
        public static IList<T> GetBigIncrementUpdate<T>( GetDataByTimeMethods method)
        {
            string name = typeof(T).Name;
            if (!BigCacheUpdateTime.Contains(name)) BigCacheUpdateTime.Add(name, DateTime.Now);//加入更新时间
            else BigCacheUpdateTime[name] = DateTime.Now;

            var obj = method(GetLastUpdateTime(name));
            BigCacheLastUpdateTime[name] = BigCacheUpdateTime[name];//更新最后更新时间
            return obj as IList<T>;
        }
        /// <summary>
        /// 更新缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        public static void UpdateBigCache<T>(object value)
        {
            string name = typeof(T).Name;
            if (BigContains(name))
            {
                BigCache[name] = value;
            }
            else
            {
                BigCache.Add(name, value);
            }
        }

        public static DateTime GetLastUpdateTime(string name)
        {
            if (!BigCacheLastUpdateTime.Contains(name)) BigCacheLastUpdateTime.Add(name, new DateTime(1900, 1, 1)); 
            return Convert.ToDateTime(BigCacheLastUpdateTime[name]);
        }
    }
}
