using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IQSoft.eCommerce.Entities.Operations
{
    [Table(name: "vw_App_UserToken", Schema = "MobileApp")]
    public class App_UserToken
    {
        [Key]
        public long UserTokenId { get; set; }
        public string DeviceToken { get; set; }
        public string Platform { get; set; }
        public int UserId { get; set; }
        public string RecordStatus { get; set; }
        public string RedirectionLink { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
