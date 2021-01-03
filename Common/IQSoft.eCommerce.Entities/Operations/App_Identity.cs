using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IQSoft.eCommerce.Entities.Operations
{
    [Table(name: "App_Identity", Schema = "dbo")]
    public class App_Identity
    {
        [Key]
        public int IdentityTypeID { get; set; }
        public string Descs { get; set; }
    }
}
