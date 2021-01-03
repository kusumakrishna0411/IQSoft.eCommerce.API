using System;

namespace IQSoft.eCommerce.API.Security
{
    public class JsonWebToken
    {
        public string access_token { get; set; }
        public string token_type { get; set; } = "bearer";
        public int expires_in { get; set; }
        public string refresh_token { get; set; }
        
        public int UserId { get; set; }

        public int ClientId { get; set; }

        // public string Roles { get; set; }

        public bool IsSuccess { get; set; } = true;
        public string ErrorMessage { get; set; } = "";
        public DateTime expires_on { get; set; }

        // public string UserLanguage { get; set; }

    }
}
