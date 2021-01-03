using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IQSoft.eCommerce.Entities.Core
{    
    [Table(name: "dmnClient", Schema = "dbo")]
    public class Client : Entity
    {
        [Key]
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientCode { get; set; }
        public string DomainName { get; set; }
        public string DbConnectionString { get; set; }
        public bool IsActive { get; set; }
    }
}
