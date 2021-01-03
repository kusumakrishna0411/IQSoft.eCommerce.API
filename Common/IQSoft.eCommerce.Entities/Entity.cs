using System;

namespace IQSoft.eCommerce.Entities
{
    public abstract class Entity
    {
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
