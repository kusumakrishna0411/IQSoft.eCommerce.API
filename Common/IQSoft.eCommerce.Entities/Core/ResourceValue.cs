using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IQSoft.eCommerce.Entities.Core
{
    [Table(name: "dmnResourceValue", Schema = "dbo")]
    public class ResourceValue
    {
        [Key]
        public int ResourceValueId { get; set; }
        public byte LanguageId { get; set; }
        public int ResourceId { get; set; }
        public string Value { get; set; }
    }
}
