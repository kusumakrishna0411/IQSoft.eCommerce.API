using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IQSoft.eCommerce.Entities.Operations
{
    [Table(name: "vw_Phase", Schema = "MobileApp")]
    public class vw_Phase
    {
        [Key]
        public int PhaseID { get; set; }
        public string PhaseNo { get; set; }
        public string PhaseDesc { get; set; }
        public string PhaseImageLink { get; set; }
        public string ImageName { get; set; }
        public string ImageDescription { get; set; }
        public string ImageUrl { get; set; }
        public int ProjectID { get; set; }
        public string RecordStatus { get; set; }

    }
      
}
