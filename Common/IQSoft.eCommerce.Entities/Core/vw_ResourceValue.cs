using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IQSoft.eCommerce.Entities.Core
{
    [Table(name: "vw_ResourceValue", Schema = "dbo")]
    public class vw_ResourceValue
    {
        [Key]
        public int ResourceId { get; set; }
        public byte LanguageId { get; set; }
        public string LanguageCode { get; set; }
        public string LanguageTitle { get; set; }
        public string ResourceTitle { get; set; }
        public string Value { get; set; }
    }
}
