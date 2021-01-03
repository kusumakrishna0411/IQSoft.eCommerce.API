using IQSoft.eCommerce.Entities.Security;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IQSoft.eCommerce.API
{
    public class UserInfoMiddleware
    {
        private readonly RequestDelegate _next;

        public UserInfoMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, UserContext userContext)
        {
            this.FillUserContext(context.Request, context, userContext);

            // Call the next delegate/middleware in the pipeline
            await _next(context);
        }

        protected void FillUserContext(HttpRequest request, HttpContext httpContext, UserContext userContext)
        {
            var timezoneOffset = default(short);
            var language = default(string);

            try
            {
                if (request.Headers["TimeZoneOffset"].Any())
                {
                    short.TryParse(request.Headers["TimeZoneOffset"].First(), out timezoneOffset);
                }
                else
                {
                    timezoneOffset = 420;
                }

                if (request.Headers["Language"].Any())
                {
                    language = request.Headers["Language"].First();
                }
                else
                {
                    language = "EN";
                }

                userContext.ClientId = this.ClientId(httpContext);
                userContext.TimeZoneOffset = timezoneOffset;
                userContext.Language = language;
                userContext.LoggedInUserId = default(int);
                userContext.SaleAgentId = default(int);

                if (httpContext.User != null && httpContext.User.Identity.IsAuthenticated)
                {
                    userContext.LoggedInUserId = this.LoggedInId(httpContext);
                    userContext.SaleAgentId = this.SaleAgentId(httpContext);
                }

            }
            catch (System.Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("Application", ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
                throw;
            }

            var ipAddress = httpContext.Connection.RemoteIpAddress;

            userContext.IPAddress = (ipAddress == null) ? "n/a" : ipAddress.ToString();

        }

        public IEnumerable<System.Security.Claims.Claim> Claims(HttpContext httpContext)
        {
            if (httpContext.User == null) return new List<System.Security.Claims.Claim>();
            else return httpContext.User.Claims;
        }

        public int ClientId(HttpContext httpContext)
        {
            return int.Parse(
                   this.Claims(httpContext).Any(c => c.Type == "ClientId") ?
                   this.Claims(httpContext).First(c => c.Type == "ClientId").Value : "0"
                   );
        }


        public int LoggedInId(HttpContext httpContext)
        {
            var userId = 0;

            userId = int.Parse(
                    this.Claims(httpContext).Any(c => c.Type == "LoggedInId") ?
                    this.Claims(httpContext).First(c => c.Type == "LoggedInId").Value : "0"
                    );

            if(userId == 0)
            {
                userId = int.Parse(
                    this.Claims(httpContext).Any(c => c.Type == "UserId") ?
                    this.Claims(httpContext).First(c => c.Type == "UserId").Value : "0"
                    );
            }

            return userId;
        }

        public int SaleAgentId(HttpContext httpContext)
        {
            return int.Parse(
                    this.Claims(httpContext).Any(c => c.Type == "SaleAgentId") ?
                    this.Claims(httpContext).First(c => c.Type == "SaleAgentId").Value : "0"
                    ); ;
        }
    }    
}
