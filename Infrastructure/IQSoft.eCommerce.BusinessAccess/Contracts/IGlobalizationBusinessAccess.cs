using IQSoft.eCommerce.Entities.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace IQSoft.eCommerce.BusinessAccess.Contracts
{
    public interface IGlobalizationBusinessAccess
    {
        List<AppLanguage> GetAllLanguages();
        List<vw_ResourceValue> GetResourceValuesByLanguage(string languageCode);
    }
}
