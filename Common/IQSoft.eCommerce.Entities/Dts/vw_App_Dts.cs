using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IQSoft.eCommerce.Entities.Dts
{
    [Table(name: "vw_App_Dts", Schema = "MobileApp")]
    public class vw_App_Dts
    {
        [Key]
        public int DefectHeaderID { get; set; }
        public string ReportNo { get; set; }
        public DateTime? ReportDate { get; set; }

        public int? UnitId { get; set; }
        public int ReportedBy { get; set; }
        public int ReportVia { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public string Remark { get; set; }
        public DateTime? CompletionDate { get; set; }
        public int Acceptance { get; set; }
        public string RecordStatus { get; set; }

        public int CreateUserID { get; set; }
        public DateTime? CreateDate { get; set; }
        public int ModifyUserID { get; set; }
        public DateTime? ModifyDate { get; set; }

        public int? ReasonID { get; set; }
        public int? Appointment { get; set; }
        public int? Keys { get; set; }

        public DateTime? KeyDate { get; set; }
        public int? CstCareToDoID { get; set; }
        public string ContactName { get; set; }

        public int ProjectID { get; set; }
        public int PhaseID { get; set; }
        
        public string ProjectName { get; set; }
        public string PhaseDesc { get; set; }

        public string RoomNo { get; set; }
        public string FloorNo { get; set; }
        public string Floor { get; set; }
        public string FloorName { get; set; }
        public string RoomCode { get; set; }
        public string PropertyStatus { get; set; }
        public DateTime? ReleaseDate { get; set; }

        public decimal? InteriorAreaPrice { get; set; }
        public decimal? BuildUpAreaPrice { get; set; }
        public decimal? Total { get; set; }

        public string UnitNo { get; set; }
        public int ItemsCount { get; set; }

    }

    public class DtsConsolidated
    {
        public List<vw_App_Dts> Headers { get; set; }
        public List<PS_DefectItem> Items { get; set; }
    }

    public class DefectItemDocument
    {
        public string DocumentName { get; set; }
        public int? RefRecordID { get; set; }
        public string Keyword { get; set; }
        public string Description { get; set; }
    }
}
