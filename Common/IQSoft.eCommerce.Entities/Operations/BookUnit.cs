using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IQSoft.eCommerce.Entities.Operations
{
    [Table(name: "BookUnit", Schema = "dbo")]
    public class BookUnit
    {
        [Key]
        public int Id { get; set; }

        public int UnitDetailId { get; set; }
        public int OpportunityId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public int BookedBy { get; set; }
        public int Amount { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZIP { get; set; }

    }
}
