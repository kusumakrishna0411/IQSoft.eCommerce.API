using IQSoft.eCommerce.BusinessAccess.Contracts;
using IQSoft.eCommerce.Entities.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IQSoft.eCommerce.API.Controllers
{
    [Route("[controller]")]
    public class GlobalizationController : IQSoftController
    {
        private IGlobalizationBusinessAccess globalizationBusinessAccess = default(IGlobalizationBusinessAccess);

        public GlobalizationController(UserContext userContext, IGlobalizationBusinessAccess globalizationBusinessAccess)
        {
            this.userContext = userContext;
            this.globalizationBusinessAccess = globalizationBusinessAccess;
        }

        [Route("[action]")]
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAllLanguages()
        {
            return Ok(globalizationBusinessAccess.GetAllLanguages());
        }

        [Route("[action]")]
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetResourceValuesByLanguage(string languageCode)
        {
            return Ok(globalizationBusinessAccess.GetResourceValuesByLanguage(languageCode));
        }

    }
}
