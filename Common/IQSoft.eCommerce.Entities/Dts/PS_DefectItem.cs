using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IQSoft.eCommerce.Entities.Dts
{
    [Table(name: "PS_DefectItem", Schema = "dbo")]
    public class PS_DefectItem
    {
        [Key]
        public int DefectItemID { get; set; }
        public int DefectHeaderID { get; set; }
        public int DefectTypeID { get; set; }

        public string DefectNo { get; set; }
        public string Remark { get; set; }
        public int? AssignType { get; set; }
        public int? AssignTo { get; set; }

        public DateTime? AssignDate { get; set; }
        public DateTime? TargetDate { get; set; }
        public DateTime? CompletionDate { get; set; }

        public int? Acceptance { get; set; }
        public string RecordStatus { get; set; }

        public int CreateUserID { get; set; }
        public DateTime CreateDate { get; set; }
        public int ModifyUserID { get; set; }
        public DateTime ModifyDate { get; set; }

        public int? Qty { get; set; }
        public int? LocationID { get; set; }
        public string Type { get; set; }
        public DateTime? CloseDate { get; set; }

        public int? Contractor1ID { get; set; }
        public int? Contractor2ID { get; set; }
        public int? InternalStaffID { get; set; }
        public int? SeverityID { get; set; }
        public int? ReasonID { get; set; }

        [NotMapped]
        public string DefectType { get; set; }
    }
}
