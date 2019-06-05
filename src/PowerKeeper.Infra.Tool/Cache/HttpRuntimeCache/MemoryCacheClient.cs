using System;
using System.Collections;
using Microsoft.Extensions.Caching.Memory;

namespace PowerKeeper.Infra.Tool.Cache.HttpRuntimeCache
{
    /// <summary>
    /// HttpRuntime Cache读取设置缓存信息封装
    /// <auther>
    ///     <name>Kencery</name>
    ///     <date>2015-8-11</date>
    /// </auther>
    /// 使用描述：给缓存赋值使用HttpRuntimeCache.Set(key,value....)等参数(第三个参数可以传递文件的路径(HttpContext.Current.Server.MapPath()))
    /// 读取缓存中的值使用JObject jObject=HttpRuntimeCache.Get(key) as JObject，读取到值之后就可以进行一系列判断
    /// </summary>
    public class MemoryCacheClient : ICache
    {
        private IMemoryCache _memoryCache;

        public MemoryCacheClient(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public T Get<T>(string key, Func<T> nullDo, DateTime exp)
        {
            object obj;

            if (_memoryCache.TryGetValue(key, out obj))
            {
                try
                {
                    return (T)obj;
                }
                catch
                {
                    if (nullDo != null)
                    {
                        var result = nullDo();
                        _memoryCache.Set(key, result, exp);
                        return result;
                    }
                    else
                    {
                        return default(T);
                    }
                }
            }
            else
            {
                if (nullDo != null)
                {
                    var result = nullDo();
                    _memoryCache.Set(key, result, exp);
                    return result;
                }
                else
                {
                    return default(T);
                }
            }
        }
        public T Get<T>(string key)
        {
            object obj;
            if (_memoryCache.TryGetValue(key, out obj))
            {
                try
                {
                    return (T)obj;
                }
                catch
                {
                    return default(T);
                }
            }
            return default(T);
        }
        public bool Set(string key, object obj, DateTime exp)
        {
            _memoryCache.Set(key, obj, exp);
            return true;
        }

        public bool Replace(string key, object obj)
        {
            _memoryCache.Set(key, obj);
            return true;
        }

        public bool Remove(string key)
        {
            _memoryCache.Remove(key);
            return true;
        }

        public bool ReplaceFromNewest<T>(string key, Func<T, T> updateFunc)
        {

            throw new NotImplementedException();
        }

        public void Dispose()
        {
          

        }
    }
}