using IQSoft.eCommerce.Entities.Core;
using System.Collections.Generic;

namespace IQSoft.eCommerce.ResourceAccess
{
    public class CommonDbContext : BaseDbContext
    {
        public CommonDbContext() : base(ConfigSettings.Instance.Data.CommonConnectionString)
        {

        }

        public List<Client> Clients(string whereCondition = "", string orderBy = "", bool isCache = true)
        {
            return this.GetTable<Client>(CommonDbTableNames.Client, whereCondition, orderBy, isCache);
        }

        public List<AppLanguage> AppLanguages(string whereCondition = "", string orderBy = "", bool isCache = true)
        {
            return this.GetTable<AppLanguage>(CommonDbTableNames.Language, whereCondition, orderBy, isCache);
        }

        public List<Resource> Resources(string whereCondition = "", string orderBy = "", bool isCache = true)
        {
            return this.GetTable<Resource>(CommonDbTableNames.Resource, whereCondition, orderBy, isCache);
        }

        public List<ResourceValue> ResourceValues(string whereCondition = "", string orderBy = "", bool isCache = true)
        {
            return this.GetTable<ResourceValue>(CommonDbTableNames.ResourceValue, whereCondition, orderBy, isCache);
        }

        public List<vw_ResourceValue> vw_ResourceValues(string whereCondition = "", string orderBy = "", bool isCache = true)
        {
            return this.GetTable<vw_ResourceValue>(CommonDbTableNames.vw_ResourceValue, whereCondition, orderBy, isCache);
        }

    }

    public class CommonDbTableNames
    {
        public const string Client = "dbo.dmnClient";
        public const string Language = "dbo.dmnLanguage";
        public const string Resource = "dbo.dmnResource";
        public const string ResourceValue = "dbo.dmnResourceValue";
        public const string vw_ResourceValue = "dbo.vw_ResourceValue";
    }

}
