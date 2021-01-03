using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IQSoft.eCommerce.Entities.Security
{
    [Table(name: "CF_User", Schema = "dbo")]
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string LanguageSelect { get; set; }
        public int RefRecordID { get; set; }
        [NotMapped]
        public string Email { get; set; }
    }

    [Table(name: "CF_Employee", Schema = "dbo")]
    public class CF_Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public int CompanyID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string EmployeeNo { get; set; }
        public string NickName { get; set; }
        public string Phone { get; set; }
        public string HandPhone { get; set; }
        public string Title { get; set; }

    }
}
