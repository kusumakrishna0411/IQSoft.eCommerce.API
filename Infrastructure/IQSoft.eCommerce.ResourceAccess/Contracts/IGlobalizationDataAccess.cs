using IQSoft.eCommerce.Entities.Core;
using IQSoft.eCommerce.Entities.Operations;
using System.Collections.Generic;

namespace IQSoft.eCommerce.ResourceAccess.Contracts
{
    public interface IGlobalizationDataAccess
    {
        List<AppLanguage> GetAllLanguages();
        List<vw_ResourceValue> GetResourceValuesByLanguage(string languageCode);
    }
}
