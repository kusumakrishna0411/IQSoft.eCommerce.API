using IQSoft.eCommerce.Entities.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IQSoft.eCommerce.API.Controllers
{
    public abstract class IQSoftController : Controller
    {
        protected UserContext userContext = default(UserContext);

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {            
            
        }

    }
}
