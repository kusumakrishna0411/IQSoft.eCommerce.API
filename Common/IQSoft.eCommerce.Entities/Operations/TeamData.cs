using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IQSoft.eCommerce.Entities.Operations
{
    public class TeamData
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public long TotalSales { get; set; }
        public long UnitsSold { get; set; }

    }
}
