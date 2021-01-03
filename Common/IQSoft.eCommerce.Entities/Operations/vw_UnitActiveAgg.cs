using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IQSoft.eCommerce.Entities.Operations
{
    [Table(name: "vw_UnitActiveAgg", Schema = "MobileApp")]
    public class vw_UnitActiveAgg
    {
        [Key]
        public int RNo { get; set; }
        public int ProjectID { get; set; }
        public int PhaseID { get; set; }
        public int BlockID { get; set; }
        public string FloorName { get; set; }
        public int TypeId { get; set; }
        public string UnitType { get; set; }
        public int AvailableCount { get; set; }
    }
}
