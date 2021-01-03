using IQSoft.eCommerce.BusinessAccess.Contracts;
using IQSoft.eCommerce.Entities.Core;
using IQSoft.eCommerce.Entities.Security;
using IQSoft.eCommerce.ResourceAccess.Contracts;
using System.Collections.Generic;

namespace IQSoft.eCommerce.BusinessAccess.Implementation
{
    public class GlobalizationBusinessAccess : IGlobalizationBusinessAccess
    {
        private IGlobalizationDataAccess globalizationDataAccess;
        public GlobalizationBusinessAccess(UserContext userContext, IGlobalizationDataAccess globalizationDataAccess)
        {
            this.globalizationDataAccess = globalizationDataAccess;
        }

        public List<AppLanguage> GetAllLanguages()
        {
            return this.globalizationDataAccess.GetAllLanguages();
        }

        public List<vw_ResourceValue> GetResourceValuesByLanguage(string languageCode)
        {
            return this.globalizationDataAccess.GetResourceValuesByLanguage(languageCode);
        }
    }
}
