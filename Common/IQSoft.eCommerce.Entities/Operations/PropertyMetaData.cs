using System;
using System.Collections.Generic;
using System.Linq;

namespace IQSoft.eCommerce.Entities.Operations
{
    public class PropertyMetaData
    {
        public vw_Property Property { get; set; }
        public List<vw_Phase> Phases { get; set; }
        public List<vw_Block> Blocks { get; set; }
        public List<vw_Unit> Units { get; set; }

        public List<FloorUnit> FloorData
        {
            get
            {
                var floors = this.Units.Select(u => u.FloorName).Distinct().OrderBy(s => s);
                var result = new List<FloorUnit>();

                foreach (var floor in floors)
                {
                    result.Add(new FloorUnit { FloorName = floor, Units = this.Units.Where(f => f.FloorName.Equals(floor, StringComparison.OrdinalIgnoreCase)).ToList() });
                }

                return result;
            }            
        }
    }
}
