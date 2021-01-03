using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IQSoft.eCommerce.Entities.Operations
{
    [Table(name: "vw_Block", Schema = "MobileApp")]
    public class vw_Block
    {
        [Key]
        public int BlockID { get; set; }
        public string BlockNo { get; set; }
        public string BlockName { get; set; }
        public int? PhaseID { get; set; }
        public string ImageName { get; set; }
        public string ImageDescription { get; set; }
        public string ImageUrl { get; set; }
        public int ProjectID { get; set; }
        public string RecordStatus { get; set; }

    }
}
