using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Caching;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Architect.Utilities
{
    public static class Cache
    {

        /// <summary>
        /// Determina si una clave existe en el cache
        /// </summary>
        /// <param name="key"></param>
        public static bool Exist(string key)
        {
            ObjectCache cache = MemoryCache.Default;
            return cache.Contains(key);
        }

        /// <summary>
        /// Determina si una clave no existe en el cache
        /// </summary>
        /// <param name="key"></param>
        public static bool NotExist(string key)
        {
            ObjectCache cache = MemoryCache.Default;
            return !cache.Contains(key);
        }

        /// <summary>
        /// Retorna el objeto asociado a la clave.
        /// </summary>
        /// <param name="key"></param>
        public static object GetItem(string key)
        {
            ObjectCache cache = MemoryCache.Default;
            return cache[key];
        }

        public static void SetItem(string key, object item)
        {
            SetItem(key, item, string.Empty, string.Empty, 0.0);
        }

        public static void SetItem(string key, object item, double timeout)
        {
            SetItem(key, item, string.Empty, string.Empty, timeout);
        }

        public static void SetItem(string key, object item, string serviceName, string entityName)
        {
            SetItem(key, item, string.Empty, string.Empty, 0.0);
        }

        public static void SetItem(string key, object item, string serviceName, string entityName, double timeout)
        {
            ObjectCache cache = MemoryCache.Default;
            double TotalMinutes = timeout;
            if (TotalMinutes == 0.0)
            {
                TotalMinutes = 20.0;
            }

            if (timeout == -1)
            {
                cache.Set(key, item, new CacheItemPolicy());
            }
            else
            {
                cache.Set(key, item, new CacheItemPolicy() { AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(TotalMinutes) });
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="item"></param>
        /// <param name="expiration"></param>
        /// <example>Helpers.Caching.SetItem(token, object, DateTimeOffset.Now.AddMinutes(2))</example>
        public static void SetItem(string key, object item, DateTimeOffset expiration)
        {
            ObjectCache cache = MemoryCache.Default;
            cache.Set(key, item, new CacheItemPolicy() { AbsoluteExpiration = expiration });
        }


        /// <summary>
        /// Elimina el objeto asociado a la clave.
        /// </summary>
        /// <param name="key"></param>
        public static void Remove(string key)
        {
            ObjectCache cache = MemoryCache.Default;
            cache.Remove(key);
        }

        public static List<Contracts.LookUpValue> CacheCatalog()
        {
            List<Contracts.LookUpValue> result = new List<Contracts.LookUpValue>();
            ObjectCache cache = MemoryCache.Default;
            foreach (KeyValuePair<string, object> item in cache)
            {
                result.Add(new Contracts.LookUpValue() { Code = item.Key, Description = item.Value.GetType().FullName });
            }
            return result;
        }

        public static void Clean()
        {
            var cacheKeys = MemoryCache.Default.Select(kvp => kvp.Key).ToList();
            foreach (string cacheKey in cacheKeys)
                MemoryCache.Default.Remove(cacheKey);
        }

        public static void RemoveStartWith(string value)
        {
            var cacheKeys = MemoryCache.Default.Select(kvp => kvp.Key).ToList();
            foreach (string cacheKey in cacheKeys)
            {
                if (cacheKey.StartsWith(value, StringComparison.CurrentCultureIgnoreCase))
                {
                    MemoryCache.Default.Remove(cacheKey);
                }
            }
        }
    }
}
