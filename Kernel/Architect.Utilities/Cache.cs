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
    /// <summary>
    /// Provides extension methods for caching operations using MemoryCache.
    /// Supports generic type-safe caching with configurable expiration policies.
    /// </summary>
    public static class Cache
    {
        /// <summary>
        /// Determines if a key exists in the cache.
        /// </summary>
        /// <param name="key">The cache key to check.</param>
        /// <returns><c>true</c> if the key exists in the cache; otherwise, <c>false</c>.</returns>
        public static bool Exist(this string key)
        {
            ObjectCache cache = MemoryCache.Default;
            return cache.Contains(key);
        }

        /// <summary>
        /// Determines if a key does not exist in the cache.
        /// </summary>
        /// <param name="key">The cache key to check.</param>
        /// <returns><c>true</c> if the key does not exist in the cache; otherwise, <c>false</c>.</returns>
        public static bool NotExist(this string key)
        {
            ObjectCache cache = MemoryCache.Default;
            return !cache.Contains(key);
        }

        /// <summary>
        /// Returns the object associated with the specified key.
        /// </summary>
        /// <param name="key">The cache key.</param>
        /// <returns>The cached object, or <c>null</c> if the key does not exist.</returns>
        public static object GetItem(this string key)
        {
            ObjectCache cache = MemoryCache.Default;
            return cache[key];
        }

        /// <summary>
        /// Returns the strongly-typed object associated with the specified key.
        /// </summary>
        /// <typeparam name="T">The type of the cached object.</typeparam>
        /// <param name="key">The cache key.</param>
        /// <returns>The cached object of type <typeparamref name="T"/>, or <c>null</c> if the key does not exist or type conversion fails.</returns>
        public static T GetItem<T>(this string key) where T : class
        {
            object value = key.GetItem();
            return value as T;
        }

        /// <summary>
        /// Sets an item in the cache with a default expiration of 20 minutes.
        /// </summary>
        /// <param name="key">The cache key.</param>
        /// <param name="item">The object to cache.</param>
        public static void SetItem(this string key, object item)
        {
            key.SetItem(item, string.Empty, string.Empty, 0.0);
        }

        /// <summary>
        /// Sets a strongly-typed item in the cache with a default expiration of 20 minutes.
        /// </summary>
        /// <typeparam name="T">The type of the object to cache.</typeparam>
        /// <param name="key">The cache key.</param>
        /// <param name="item">The object to cache.</param>
        public static void SetItem<T>(this string key, T item) where T : class
        {
            key.SetItem(item, string.Empty, string.Empty, 0.0);
        }

        /// <summary>
        /// Sets an item in the cache with the specified timeout in minutes.
        /// </summary>
        /// <param name="key">The cache key.</param>
        /// <param name="item">The object to cache.</param>
        /// <param name="timeout">The expiration timeout in minutes. Use -1 for no expiration, 0 for default (20 minutes).</param>
        public static void SetItem(this string key, object item, double timeout)
        {
            key.SetItem(item, string.Empty, string.Empty, timeout);
        }

        /// <summary>
        /// Sets a strongly-typed item in the cache with the specified timeout in minutes.
        /// </summary>
        /// <typeparam name="T">The type of the object to cache.</typeparam>
        /// <param name="key">The cache key.</param>
        /// <param name="item">The object to cache.</param>
        /// <param name="timeout">The expiration timeout in minutes. Use -1 for no expiration, 0 for default (20 minutes).</param>
        public static void SetItem<T>(this string key, T item, double timeout) where T : class
        {
            key.SetItem(item, string.Empty, string.Empty, timeout);
        }

        /// <summary>
        /// Sets an item in the cache with service and entity metadata.
        /// </summary>
        /// <param name="key">The cache key.</param>
        /// <param name="item">The object to cache.</param>
        /// <param name="serviceName">The service name (metadata, not used for caching logic).</param>
        /// <param name="entityName">The entity name (metadata, not used for caching logic).</param>
        public static void SetItem(this string key, object item, string serviceName, string entityName)
        {
            key.SetItem(item, string.Empty, string.Empty, 0.0);
        }

        /// <summary>
        /// Sets a strongly-typed item in the cache with service and entity metadata.
        /// </summary>
        /// <typeparam name="T">The type of the object to cache.</typeparam>
        /// <param name="key">The cache key.</param>
        /// <param name="item">The object to cache.</param>
        /// <param name="serviceName">The service name (metadata, not used for caching logic).</param>
        /// <param name="entityName">The entity name (metadata, not used for caching logic).</param>
        public static void SetItem<T>(this string key, T item, string serviceName, string entityName) where T : class
        {
            key.SetItem(item, string.Empty, string.Empty, 0.0);
        }

        /// <summary>
        /// Sets an item in the cache with service, entity metadata, and custom timeout.
        /// </summary>
        /// <param name="key">The cache key.</param>
        /// <param name="item">The object to cache.</param>
        /// <param name="serviceName">The service name (metadata, not used for caching logic).</param>
        /// <param name="entityName">The entity name (metadata, not used for caching logic).</param>
        /// <param name="timeout">The expiration timeout in minutes. Use -1 for no expiration, 0 for default (20 minutes).</param>
        public static void SetItem(this string key, object item, string serviceName, string entityName, double timeout)
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
        /// Sets a strongly-typed item in the cache with service, entity metadata, and custom timeout.
        /// </summary>
        /// <typeparam name="T">The type of the object to cache.</typeparam>
        /// <param name="key">The cache key.</param>
        /// <param name="item">The object to cache.</param>
        /// <param name="serviceName">The service name (metadata, not used for caching logic).</param>
        /// <param name="entityName">The entity name (metadata, not used for caching logic).</param>
        /// <param name="timeout">The expiration timeout in minutes. Use -1 for no expiration, 0 for default (20 minutes).</param>
        public static void SetItem<T>(this string key, T item, string serviceName, string entityName, double timeout) where T : class
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
        /// Sets an item in the cache with an absolute expiration time.
        /// </summary>
        /// <param name="key">The cache key.</param>
        /// <param name="item">The object to cache.</param>
        /// <param name="expiration">The absolute expiration date and time.</param>
        /// <example>
        /// <code>
        /// "myKey".SetItem(myObject, DateTimeOffset.Now.AddMinutes(2));
        /// </code>
        /// </example>
        public static void SetItem(this string key, object item, DateTimeOffset expiration)
        {
            ObjectCache cache = MemoryCache.Default;
            cache.Set(key, item, new CacheItemPolicy() { AbsoluteExpiration = expiration });
        }

        /// <summary>
        /// Sets a strongly-typed item in the cache with an absolute expiration time.
        /// </summary>
        /// <typeparam name="T">The type of the object to cache.</typeparam>
        /// <param name="key">The cache key.</param>
        /// <param name="item">The object to cache.</param>
        /// <param name="expiration">The absolute expiration date and time.</param>
        /// <example>
        /// <code>
        /// "myKey".SetItem&lt;MyClass&gt;(myObject, DateTimeOffset.Now.AddMinutes(2));
        /// </code>
        /// </example>
        public static void SetItem<T>(this string key, T item, DateTimeOffset expiration) where T : class
        {
            ObjectCache cache = MemoryCache.Default;
            cache.Set(key, item, new CacheItemPolicy() { AbsoluteExpiration = expiration });
        }

        /// <summary>
        /// Removes the object associated with the specified key from the cache.
        /// </summary>
        /// <param name="key">The cache key to remove.</param>
        public static void Remove(this string key)
        {
            ObjectCache cache = MemoryCache.Default;
            cache.Remove(key);
        }

        /// <summary>
        /// Returns a catalog of all cached items with their keys and type information.
        /// </summary>
        /// <returns>A list of <see cref="Contracts.LookUpValue"/> containing cache keys and type names.</returns>
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

        /// <summary>
        /// Removes all items from the cache.
        /// </summary>
        public static void Clean()
        {
            var cacheKeys = MemoryCache.Default.Select(kvp => kvp.Key).ToList();
            foreach (string cacheKey in cacheKeys)
                MemoryCache.Default.Remove(cacheKey);
        }

        /// <summary>
        /// Removes all cache items whose keys start with the specified value (case-insensitive).
        /// </summary>
        /// <param name="value">The prefix to match against cache keys.</param>
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
