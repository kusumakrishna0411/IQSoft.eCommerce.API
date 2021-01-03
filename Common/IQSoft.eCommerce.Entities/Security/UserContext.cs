namespace IQSoft.eCommerce.Entities.Security
{
    public class UserContext
    {
        public int ClientId { get; set; }
        public short TimeZoneOffset { get; set; }
        public string Language { get; set; }
        public int LoggedInUserId { get; set; }
        public int SaleAgentId { get; set; }
        public string IPAddress { get; set; }
    }
}
