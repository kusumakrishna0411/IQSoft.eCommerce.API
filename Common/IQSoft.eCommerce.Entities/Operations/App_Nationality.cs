using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IQSoft.eCommerce.Entities.Operations
{
    [Table(name: "App_Nationality", Schema = "dbo")]
    public class App_Nationality
    {
        [Key]
        public int NationalityID { get; set; }
        public string Descs { get; set; }
    }
}
