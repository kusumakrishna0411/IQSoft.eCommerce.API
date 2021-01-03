using IQSoft.eCommerce.BusinessAccess.Contracts;
using IQSoft.eCommerce.Entities.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace IQSoft.eCommerce.API.Security
{
    public class RsaJwtTokenProvider : ITokenProvider
    {
        public RsaJwtTokenProvider()
        {

        }

        public JsonWebToken CreateToken(string userName, string password, int expiryInMinutes = 180)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            var httpContextAccessor = DIContainer.ServiceLocator.Instance.Get<IHttpContextAccessor>();
            var userBusinessAccess = DIContainer.ServiceLocator.Instance.Get<IUserBusinessAccess>();

            var url = httpContextAccessor.HttpContext.Request.Headers["HostName"].Any()
                ? httpContextAccessor.HttpContext.Request.Headers["HostName"].First()
                : (httpContextAccessor.HttpContext.Request.Host.HasValue ? httpContextAccessor.HttpContext.Request.Host.Host : string.Empty);

            var claims = userBusinessAccess.ValidateUser(userName, password);
            if (claims != null)
            {
                var identity = new ClaimsIdentity(new GenericIdentity("Login" + "::" + userName, "jwt"));
                // identity.AddClaims(claims);

                var expires_on = DateTime.Now.AddMinutes(expiryInMinutes);
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigSettings.Instance.JwtKeysSettings.IssuerSigningKey)); //Secret
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(ConfigSettings.Instance.JwtKeysSettings.ValidIssuer, ConfigSettings.Instance.JwtKeysSettings.ValidAudience,
                    identity.Claims,
                    expires: expires_on,
                    signingCredentials: creds);

                var jsonWebToken = new JsonWebToken
                {
                    access_token = tokenHandler.WriteToken(token),
                    expires_in = expiryInMinutes,
                    expires_on = expires_on,

                    UserId = claims.UserId,

                };

                return jsonWebToken;
            }
            else
            {
                if (claims != null)
                {
                    var errorMessage = "Invalid credentials - ";
                    return new JsonWebToken { IsSuccess = false, ErrorMessage = errorMessage };
                }
                else
                {
                    return new JsonWebToken { IsSuccess = false, ErrorMessage = "Invalid credentials" };
                }

            }

        }

    }
}
