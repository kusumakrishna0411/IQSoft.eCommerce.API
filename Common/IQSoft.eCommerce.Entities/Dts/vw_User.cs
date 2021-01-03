using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IQSoft.eCommerce.Entities.Dts
{
    [Table(name: "vw_Users", Schema = "MobileApp")]
    public class vw_User
    {
        [Key]
        public int UserID { get; set; }
        public string LoginName { get; set; }
        public string UserName { get; set; }
    }
}
