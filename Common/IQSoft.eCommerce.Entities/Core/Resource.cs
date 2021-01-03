using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IQSoft.eCommerce.Entities.Core
{
    [Table(name: "dmnResource", Schema = "dbo")]
    public class Resource : Entity
    {
        [Key]
        public int ResourceId { get; set; }
        public string Title { get; set; }
        public string DefaultValue { get; set; }        
    }
}
