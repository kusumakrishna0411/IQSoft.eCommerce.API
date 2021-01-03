using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IQSoft.eCommerce.Entities.Core
{
    [Table(name: "EmployeeProfile", Schema = "MobileApp")]
    public class EmployeeProfile
    {
        [Key]
        public int UserID { get; set; }
        public string LoginName { get; set; }
        public string LanguageSelect { get; set; }
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployeeNo { get; set; }
        public string PostOrRole { get; set; }
        public string Password { get; set; }
        public string PhotoUrl { get; set; }
    }
}
