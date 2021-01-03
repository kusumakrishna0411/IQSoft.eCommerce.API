using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IQSoft.eCommerce.Entities.Operations
{
    [Table(name: "App_Gender", Schema = "dbo")]
    public class App_Gender
    {
        [Key]
        public int SexID { get; set; }
        public string Descs { get; set; }
    }
}
