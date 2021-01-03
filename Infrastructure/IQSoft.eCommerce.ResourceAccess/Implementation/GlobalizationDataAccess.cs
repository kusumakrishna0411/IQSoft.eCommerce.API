using IQSoft.eCommerce.Entities.Core;
using IQSoft.eCommerce.Entities.Security;
using IQSoft.eCommerce.ResourceAccess.Contracts;
using System.Collections.Generic;

namespace IQSoft.eCommerce.ResourceAccess.Implementation
{
    public class GlobalizationDataAccess : DataAccess, IGlobalizationDataAccess
    {
        public GlobalizationDataAccess(UserContext userContext)
            : base(userContext)
        {

        }

        public List<AppLanguage> GetAllLanguages()
        {
            return this.commonDbContext.AppLanguages();
        }

        public List<vw_ResourceValue> GetResourceValuesByLanguage(string languageCode)
        {
            return this.commonDbContext.vw_ResourceValues($"LanguageCode = '{languageCode}'");
        }
    }
}
