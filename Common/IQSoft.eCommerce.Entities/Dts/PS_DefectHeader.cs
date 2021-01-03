using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IQSoft.eCommerce.Entities.Dts
{
    [Table(name: "PS_DefectHeader", Schema = "dbo")]
    public class PS_DefectHeader
    {
        [Key]
        public int DefectHeaderID { get; set; }
        public string ReportNo { get; set; }
        public DateTime? ReportDate { get; set; }

        public int? UnitId { get; set; }
        public int? ReportedBy { get; set; }
        public int? ReportVia { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public string Remark { get; set; }
        public DateTime? CompletionDate { get; set; }
        public int? Acceptance { get; set; }
        public string RecordStatus { get; set; }

        public int? CreateUserID { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? ModifyUserID { get; set; }
        public DateTime? ModifyDate { get; set; }

        public int? ReasonID { get; set; }
        public int? Appointment { get; set; }
        public int? Keys { get; set; }

        public DateTime? KeyDate { get; set; }
        public int? CstCareToDoID { get; set; }
        public string ContactName { get; set; }
    }
}
