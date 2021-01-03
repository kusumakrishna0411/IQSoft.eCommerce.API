using Microsoft.IdentityModel.Tokens;

namespace IQSoft.eCommerce.API.Security
{
    public interface ITokenProvider
    {
        JsonWebToken CreateToken(string userName, string password, int expiryInMinutes = 180);
    }
}
