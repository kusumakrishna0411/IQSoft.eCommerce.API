using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IQSoft.eCommerce.Entities.Core
{
    [Table(name: "dmnLanguage", Schema = "dbo")]
    public class AppLanguage
    {
        [Key]
        public byte LanguageId { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
    }
}
