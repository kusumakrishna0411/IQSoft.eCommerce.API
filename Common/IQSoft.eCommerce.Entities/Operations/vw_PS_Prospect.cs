using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IQSoft.eCommerce.Entities.Operations
{
    [Table(name: "vw_PS_Prospect", Schema = "MobileApp")]
    public class vw_PS_Prospect
    {
        [Key]
        public int RNo { get; set; }
        public int? RowID { get; set; }
        public int? AccountID { get; set; }
        public string AppProspectID { get; set; }
        public string AccountNo { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public int? SexID { get; set; }
        public DateTime? Birthday { get; set; }
        public int? NationalityID { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public int? IdentityTypeID { get; set; }
        public string IdentityNo { get; set; }
        public int? SaleAgentID { get; set; }
        public int? ProjectID { get; set; }
        public int? PhaseID { get; set; }

        public int? CreateUserID { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? ModifyUserID { get; set; }
        public DateTime? ModifyDate { get; set; }

        public string RecordStatus { get; set; }
        public string Remark { get; set; }
        public int? ProbabilityID { get; set; }
        public string OpportunityType { get; set; }
        public string UserName { get; set; }

        [NotMapped]
        public bool IsActive
        {
            get
            {
                return (string.Equals(RecordStatus, "Active", StringComparison.OrdinalIgnoreCase));
            }
        }
    }
}
