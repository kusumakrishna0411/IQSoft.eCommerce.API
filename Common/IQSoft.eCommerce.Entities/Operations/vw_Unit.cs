using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IQSoft.eCommerce.Entities.Operations
{
    [Table(name: "vw_Unit", Schema = "MobileApp")]
    public class vw_Unit
    {
        [Key]
        public int UnitID { get; set; }
        public int BlockID { get; set; }
        public int PhaseID { get; set; }
        public int ProjectID { get; set; }
        public string UnitNo { get; set; }
        public string RoomNo { get; set; }
        public string FloorNo { get; set; }
        public short Floor { get; set; }
        public string FloorName { get; set; }
        public string RoomCode { get; set; }
        public int TypeId { get; set; }
        public string RecordStatus { get; set; }
        public string ParsedStatus { get; set; }
        public DateTime? ReleaseDate { get; set; }
        
        public decimal? InteriorAreaPrice { get; set; }
        public decimal? BuildUpAreaPrice { get; set; }
        public decimal? BuildUpArea { get; set; }
        public long? Total { get; set; }

        public bool IsAvailable { get; set; }
        public string ImageName { get; set; }
        public string ImageDescription { get; set; }
        public string ImageUrl { get; set; }

        public string UnitType { get; set; }
        public string Direction { get; set; }
        public string IsSupplement { get; set; }
        public int? MasterUnitID { get; set; }

        public string CustomerName { get; set; }
        public string AccountNo { get; set; }
        public DateTime? ReserveDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? SaleDate { get; set; }

        public int? ReserveID { get; set; }
        public int? SaleID { get; set; }

    }

    public class FloorUnit
    {
        public string FloorName { get; set; }
        public List<vw_Unit> Units { get; set; }
    }

    public class UnitStatus
    {
        public string Title { get; set; }
    }

}
