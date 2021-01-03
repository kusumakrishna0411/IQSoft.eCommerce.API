using IQSoft.eCommerce.Utilities.Extensions;

namespace IQSoft.eCommerce.Utilities.Helpers
{
    public class CacheHelper
    {
        private static ICacheManager _cacheManager = default(ICacheManager);
        private static object _syncObject = new object();

        public static ICacheManager Instance
        {
            get
            {
                lock (_syncObject)
                {
                    if (_cacheManager == null) _cacheManager = new InMemoryCacheProvider();
                }
                return _cacheManager;
            }

        }
    }
}
