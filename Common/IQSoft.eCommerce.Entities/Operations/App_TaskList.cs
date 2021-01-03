using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IQSoft.eCommerce.Entities.Operations
{
    [Table(name: "App_TaskList", Schema = "dbo")]
    public class App_TaskList
    {
        [Key]
        public int RowID { get; set; }
        public int SaleId { get; set; }

        public DateTime DueDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public int DaysDelayed { get; set; }
        public string TaskName { get; set; }
        public string Remarks { get; set; }

        public int? CreateUserID { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? ModifyUserID { get; set; }
        public DateTime? ModifyDate { get; set; }

    }
}
