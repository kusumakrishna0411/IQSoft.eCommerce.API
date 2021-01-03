using System;
using System.Collections.Generic;
using System.Text;

namespace IQSoft.eCommerce.Entities.Core
{
    public class DashboardData
    {
        public string Category { get; set; }
        public long UnitsSold { get; set; }
        public long UnitsUnSold { get; set; }
        //public string UnitType { get; set; }
        public long Sales { get; set; }
        public long Collected { get; set; }
    }
}
