using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IQSoft.eCommerce.Entities.Security
{
    //[Table(name: "Users", Schema = "dbo")]
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        //public Byte[] Password { get; set; }
        public string Password { get; set; }
        //public Byte[] Status { get; set; }
    }
}
