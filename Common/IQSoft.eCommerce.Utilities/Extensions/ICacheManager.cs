using System.Collections.Generic;

namespace IQSoft.eCommerce.Utilities.Extensions
{
    public interface ICacheManager
    {
        void Set<T>(string key, T value, int clientId = 0, int absoluteExpirationInSeconds = 120);
        T Get<T>(string key, int clientId = 0);
        void Remove(string key, int clientId = 0);
        void RemoveAll(IEnumerable<string> keys, int clientId = 0);
        void SetAll<T>(IDictionary<string, T> values, int clientId = 0);
    }
}
