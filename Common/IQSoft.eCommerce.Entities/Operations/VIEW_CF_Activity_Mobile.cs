using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IQSoft.eCommerce.Entities.Operations
{
    [Table(name: "VIEW_CF_Activity_Mobile", Schema = "dbo")]
    public class VIEW_CF_Activity_Mobile
    {
        [Key]
        public int ActivityID { get; set; }
        public string RefTable { get; set; }
        public int? ProjectID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Remark { get; set; }

        public int? RefRecordID { get; set; }
        public string Source { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? Starttime { get; set; }
        public DateTime? PlannedDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? ActualDate { get; set; }
        public string RecordStatus { get; set; }
        public int? PriorityID { get; set; }
        public string PriorityDesc { get; set; }
        public int? ActivityTypeID { get; set; }
        public string ActivityType { get; set; }
        public int? CreateUserID { get; set; }
        public int? AssignedToID { get; set; }
    }
}
