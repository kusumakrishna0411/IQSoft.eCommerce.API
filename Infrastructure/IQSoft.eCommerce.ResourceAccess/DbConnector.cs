using IQSoft.eCommerce.Entities.Core;
using System.Collections.Generic;
using System.Linq;

namespace IQSoft.eCommerce.ResourceAccess
{
    public class DbConnector : BaseDbContext
    {
        public DbConnector() : base(ConfigSettings.Instance.Data.CommonConnectionString)
        {

        }

        // public List<Client> Clients
        // {
        //     get { return this.GetTable<Client>(CommonDbTableNames.Client, isCache: true); }
        // }


        public string GetClientConnectionString()
        {            
            return ConfigSettings.Instance.Data.CommonConnectionString;
        }

        private static object _syncObject = new object();
        private static DbConnector _DbConnector = default(DbConnector);

        public static DbConnector Instance
        {
            get
            {
                lock (_syncObject)
                {
                    if (_DbConnector == null) _DbConnector = new DbConnector();
                }
                return _DbConnector;
            }
        }

    }
}
