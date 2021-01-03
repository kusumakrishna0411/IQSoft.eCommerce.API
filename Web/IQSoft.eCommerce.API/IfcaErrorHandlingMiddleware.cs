using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace IQSoft.eCommerce.API
{
    public class IQSoftErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private static ILogger<IQSoftErrorHandlingMiddleware> log;

        public IQSoftErrorHandlingMiddleware(RequestDelegate next)
        {
            log = IQSoft.eCommerce.DIContainer.ServiceLocator.Instance.Get<ILogger<IQSoftErrorHandlingMiddleware>>();
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private static Task HandleException(HttpContext context, Exception ex)
        {
            HttpStatusCode code = HttpStatusCode.InternalServerError; // 500 if unexpected

            string result = JsonConvert.SerializeObject(new { error = ex.Message });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            log.LogError(ex, result);

            return context.Response.WriteAsync(result);
        }
    }

}
