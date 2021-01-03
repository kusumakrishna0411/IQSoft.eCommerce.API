using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IQSoft.eCommerce.Entities.Dts
{
    [Table(name: "PS_DefectItemFollowUp", Schema = "dbo")]
    public class PS_DefectItemFollowUp
    {
        [Key]
        public int DefectItemFollowUpId { get; set; }
        public int DefectItemID { get; set; }
        public DateTime? FollowUpDate { get; set; }
        public string IsCompleted { get; set; }
        public string Description { get; set; }
        public int CreateUserID { get; set; }
        public DateTime CreateDate { get; set; }
        public int ModifyUserID { get; set; }
        public DateTime ModifyDate { get; set; }
        public string RecordStatus { get; set; }
        public string FollowUpType { get; set; }
        public int FollowUpBy { get; set; }
    }

    public class DefectStatus
    {
        public string Title { get; set; }
    }

    public class DefectItem
    {
        public int DefectHeaderID { get; set; }
        public int DefectItemID { get; set; }
        public int DefectTypeID { get; set; }

        public string Remark { get; set; }
        public DateTime? AssignDate { get; set; }
        public bool IsCompleted { get; set; }
        public int CreatedBy { get; set; }
        public int Contractor1ID { get; set; }
        public int Contractor2ID { get; set; }
        public int LocationID { get; set; }

        public string DocumentName { get; set; }        
        public string Keyword { get; set; }
        public string Status { get; set; }
        
        public int InternalUserID { get; set; }
        public int FeedbackRateId { get; set; }
        public string ImageData { get; set; }

    }
}
