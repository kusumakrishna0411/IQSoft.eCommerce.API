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

                return BadRequest("Error getting information getHomeDataDetails " + ex.ToString());
            }
        }



        [Route("[action]")]
        [HttpGet]
        [Authorize]
        public object GetItemDetailsByCategoy(int categoryId)
        {
            try
            {
                return Ok(this.userBusinessAccess.GetItemDetailsByCategoy(categoryId));
            }
            catch (System.Exception ex)
            {

                return BadRequest("Error getting information GetItemDetailsByCategoy " + ex.ToString());
            }
        }

        [Route("[action]")]
        [HttpGet]
        [Authorize]
        public object GetItemDetailsByCategoyType2(int categoryId)
        {
            try
            {
                return Ok(this.userBusinessAccess.GetItemDetailsByCategoy2(categoryId));
            }
            catch (System.Exception ex)
            {

                return BadRequest("Error getting information GetItemDetailsByCategoy " + ex.ToString());
            }
        }

        [Route("[action]")]
        [HttpGet]
        [Authorize]
        public object GetProductResults(int categoryId)
        {
            try
            {
                return Ok(this.userBusinessAccess.GetProductResults(categoryId));
            }
            catch (System.Exception ex)
            {

                return BadRequest("Error getting information GetProductResults " + ex.ToString());
            }
        }

        [Route("[action]")]
        [HttpGet]
        [Authorize]
        public object GetProductDetails(int productId)
        {
            try
            {
                return Ok(this.userBusinessAccess.GetProductDetails(productId));
            }
            catch (System.Exception ex)
            {

                return BadRequest("Error getting information productId " + ex.ToString());
            }
        }

        [Route("[action]")]
        [HttpGet]
        [Authorize]
        public object GetAdditionalFiltersInfo(int categoryId)
        {
            try
            {
                return Ok(this.userBusinessAccess.GetAdditionalFiltersInfo(categoryId));
            }
            catch (System.Exception ex)
            {

                return BadRequest("Error getting information GetAdditionalFiltersInfo productId " + ex.ToString());
            }
        }

        [Route("[action]")]
        [HttpGet]
        [Authorize]
        public object GetFilterInfoByType(int categoryId)
        {
            try
            {
                return Ok(this.userBusinessAccess.GetFilterInfoByType(categoryId));
            }
            catch (System.Exception ex)
            {

                return BadRequest("Error getting information GetFilterInfoByType categoryId " + ex.ToString());
            }
        }
    }
}
