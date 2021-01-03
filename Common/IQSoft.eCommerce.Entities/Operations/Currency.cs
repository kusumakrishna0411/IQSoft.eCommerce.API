using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IQSoft.eCommerce.Entities.Operations
{
    [Table(name: "CF_Currency", Schema = "dbo")]
    public class Currency
    {
        [Key]
        public int CurrencyID { get; set; }
        public string Name { get; set; }
        public string ISOCode { get; set; }
        public string IsBaseCurrency { get; set; }
        public string RecordStatus { get; set; }
    }
}
