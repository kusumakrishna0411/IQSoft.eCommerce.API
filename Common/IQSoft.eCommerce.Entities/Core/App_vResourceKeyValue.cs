using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IQSoft.eCommerce.Entities.Core
{
    [Table(name: "App_vResourceKeyValue", Schema = "MobileApp")]
    public class App_vResourceKeyValue
    {
        [Key]
        public int ResourceKeyId { get; set; }
        public byte LanguageId { get; set; }
        public string LanguageCode { get; set; }
        public string LanguageTitle { get; set; }
        public string ResourceName { get; set; }
        public string ResourceValue { get; set; }
    }
}

