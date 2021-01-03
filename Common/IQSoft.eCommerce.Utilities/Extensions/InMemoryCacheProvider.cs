using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;

namespace IQSoft.eCommerce.Utilities.Extensions
{
    public class InMemoryCacheProvider : ICacheManager
    {
        private readonly MemoryCache cacheClient;
        private object _syncObject = new object();

        public InMemoryCacheProvider()
        {
            this.cacheClient = new MemoryCache(new MemoryCacheOptions()
            {
                SizeLimit = 1024
            });
        }

        private string GetKey(int clientId, string key)
        {
            return string.Format("{0}_{1}", key, clientId);
        }

        public void Set<T>(string key, T value, int clientId = 0, int absoluteExpirationInSeconds = 120)
        {
            lock (_syncObject)
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSize(1)//Size amount
                               //Priority on removing when reaching size limit (memory pressure)
                    .SetPriority(CacheItemPriority.Normal)
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(60))
                    // Remove from cache after this time, regardless of sliding expiration
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(absoluteExpirationInSeconds));

                cacheClient.Set<T>(GetKey(clientId, key), value, cacheEntryOptions);
            }
        }

        public T Get<T>(string key, int clientId = 0)
        {
            if (cacheClient.TryGetValue(GetKey(clientId, key), out T result))
            {
                return result;
            }
            else
            {
                return default(T);
            }
        }

        public void Remove(string key, int clientId = 0)
        {
            cacheClient.Remove(GetKey(clientId, key));
        }

        public void RemoveAll(IEnumerable<string> keys, int clientId = 0)
        {
            foreach (var key in keys)
            {
                cacheClient.Remove(GetKey(clientId, key));
            }
        }

        public void SetAll<T>(IDictionary<string, T> values, int clientId = 0)
        {
            foreach (var keyValue in values)
            {
                this.Set<T>(keyValue.Key, keyValue.Value, clientId);
            }
        }

    }
}
