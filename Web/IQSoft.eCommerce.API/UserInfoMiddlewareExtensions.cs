using Microsoft.AspNetCore.Builder;

namespace IQSoft.eCommerce.API
{
    public static class UserInfoMiddlewareExtensions
    {
        public static IApplicationBuilder UseUserInfo(
           this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UserInfoMiddleware>();
        }
    }
}
