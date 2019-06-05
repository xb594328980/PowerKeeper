using System;

namespace PowerKeeper.Infra.Tool.Cache
{
    public interface ICache:IDisposable
    {
        T Get<T>(string key, Func<T> nullDo, DateTime exp);
        T Get<T>(string key);
        bool Set(string key, object obj, DateTime exp);
        bool Replace(string key, object obj);
        bool Remove(string key);
    }
}