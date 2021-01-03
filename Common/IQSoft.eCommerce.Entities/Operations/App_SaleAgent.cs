using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IQSoft.eCommerce.Entities.Operations
{
    [Table(name: "App_SaleAgent", Schema = "dbo")]
    public class App_SaleAgent
    {
        [Key]
        public int SaleAgentID { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public int? ParentAgentID { get; set; }
        public int? CompanyID { get; set; }
        public int? ProjectID { get; set; }        
    }
}
