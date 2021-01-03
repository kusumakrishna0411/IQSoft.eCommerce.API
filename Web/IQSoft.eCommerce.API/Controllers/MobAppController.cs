using IQSoft.eCommerce.API.Security;
using IQSoft.eCommerce.BusinessAccess.Contracts;
using IQSoft.eCommerce.Entities.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace IQSoft.eCommerce.API.Controllers
{
    [Route("[controller]")]
    public class MobAppController : IQSoftController
    {
        private ITokenProvider _tokenProvider;
        private IUserBusinessAccess userBusinessAccess;
        private readonly ILogger _logger;

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public MobAppController(UserContext userContext, ITokenProvider tokenProvider, IUserBusinessAccess userBusinessAccess, ILogger<TokenController> logger)
        {
            this.userContext = userContext;
            _tokenProvider = tokenProvider;
            this._logger = logger;
            this.userBusinessAccess = userBusinessAccess;
        }

        [Route("[action]")]
        [HttpGet]
        [Authorize]
        public IActionResult Narasimha()
        {
            return Ok(this.userBusinessAccess.Narasimha());
        }

        [Route("[action]")]
        [HttpGet]
        [Authorize]
        public IActionResult getHomeDataDetails()
        {
            try
            {
                return Ok(this.userBusinessAccess.getHomeDataDetails());
            }
            catch (System.Exception ex)
            {
                return BadRequest("Error getting information getHomeDataDetails ");
            }
        }
    }
}
