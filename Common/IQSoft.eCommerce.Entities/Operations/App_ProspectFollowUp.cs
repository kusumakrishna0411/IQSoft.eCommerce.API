using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IQSoft.eCommerce.Entities.Operations
{
    [Table(name: "App_ProspectFollowUp", Schema = "dbo")]
    public class App_ProspectFollowUp
    {
        [Key]
        public int RowID { get; set; }
        public string AppProspectID { get; set; }
        public int? ProspectID { get; set; }
        public DateTime ActivityDate { get; set; }
        public string Activity { get; set; }

        public int? CreateUserID { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? ModifyUserID { get; set; }
        public DateTime? ModifyDate { get; set; }
    }

    public class App_ProspectTransfer
    {        
        public int? ProspectID { get; set; }
        public int AgentId { get; set; }
        public string Remarks { get; set; }

    }
}
