using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IQSoft.eCommerce.Entities.Operations
{
    [Table(name: "vw_PS_AgentSale", Schema = "MobileApp")]
    public class AgentSale
    {
        [Key]
        public int UnitID { get; set; }
        public int BlockID { get; set; }
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string CustomerName { get; set; }
        public string Mobile { get; set; }
        public string UnitNo { get; set; }
        public string RoomNo { get; set; }
        public string FloorNo { get; set; }
        public short? Floor { get; set; }
        public string FloorName { get; set; }
        public string RoomCode { get; set; }
        public string RecordStatus { get; set; }
        public decimal TotalPriceInMillion { get; set; }

        public DateTime? ReleaseDate { get; set; }
        public int? SaleID { get; set; }
        public DateTime? SaleDate { get; set; }
        public int? SaleAgentID { get; set; }
        public int? SoldBy { get; set; }
        public string UserName { get; set; }
    }

    public class DaySale
    {
        public DateTime SaleDate { get; set; }
        public int Count { get; set; }
        public decimal Amount { get; set; }
    }

    public class YearSale
    {
        public YearSale()
        {
            //this.Sales = new List<AgentSale>();
            this.DaySales = new List<DaySale>();
            this.M1Sales = new List<DaySale>();
            this.M3Sales = new List<DaySale>();
            this.M6Sales = new List<DaySale>();
            this.M9Sales = new List<DaySale>();
        }
        public vw_Property Property { get; set; }
        //public List<AgentSale> Sales { get; set; }
        public List<DaySale> DaySales { get; set; }
        public List<DaySale> M1Sales { get; set; }
        public List<DaySale> M3Sales { get; set; }
        public List<DaySale> M6Sales { get; set; }
        public List<DaySale> M9Sales { get; set; }
    }
}
