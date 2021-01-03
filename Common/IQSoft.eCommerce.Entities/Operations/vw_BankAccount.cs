using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IQSoft.eCommerce.Entities.Operations
{
    [Table(name: "vw_BankAccount", Schema = "MobileApp")]
    public class vw_BankAccount
    {
        [Key]
        public int BankAccountID { get; set; }
        public string Name { get; set; }
        public int? UnitID { get; set; }
        public int? CurrencyID { get; set; }       
    }
}
