using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IQSoft.eCommerce.Entities.Operations
{
    [Table(name: "App_Sale", Schema = "dbo")]
    public class App_Sale
    {
        [Key]
        public int RowID { get; set; }        

        public int? ProspectID { get; set; }
        public int? AccountID { get; set; }

        public string AppProspectID { get; set; }
        public string AccountNo { get; set; }
        public string AppSaleID { get; set; }

        public int? CompanyID { get; set; }
        public int? ProjectID { get; set; }
        public int PhaseID { get; set; }
        public int BlockID { get; set; }
        public int UnitID { get; set; }
        public string UnitNo { get; set; }
        public string CustomerName { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public DateTime ReserveDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string Remark { get; set; }
        public string SaleStatus { get; set; }

        public int? ApproveByID { get; set; }
        public DateTime? ApproveDate { get; set; }
        public int SaleAgentID { get; set; }
        public int? CreateUserID { get; set; }
        public DateTime? CreateDate { get; set; }

        public int? ModifyUserID { get; set; }
        public DateTime? ModifyDate { get; set; }

        public string RecordStatus { get; set; }
        /// <summary>
        /// Reserve / Book
        /// </summary>
        public string SaleType { get; set; }
        public int? BookAmt { get; set; }

        public string ReferenceNo { get; set; }
        public int? PayMethod { get; set; }

        public int? CurrencyID { get; set; }
        public int? BankAccountID { get; set; }


        [NotMapped]
        public int? ReserveID { get; set; }
        [NotMapped]
        public int? SaleID { get; set; }
        [NotMapped]
        public int? CancelReasonId { get; set; }
        [NotMapped]
        public DateTime? SaleDate { get; set; }

    }

}
