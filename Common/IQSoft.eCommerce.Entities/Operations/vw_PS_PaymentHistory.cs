using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IQSoft.eCommerce.Entities.Operations
{
    [Table(name: "vw_PS_PaymentHistory", Schema = "MobileApp")]
    public class vw_PS_PaymentHistory
    {
        [Key]
        public int BillID { get; set; }
        public int UnitID { get; set; }
        public string UnitNo { get; set; }
        public string ProjectName { get; set; }
        public string PhaseDesc { get; set; }
        public string BlockName { get; set; }
        public long? SellingPrice { get; set; }
        public long? Debit { get; set; }
        public long? ReceiptAmt { get; set; }
        public long? AdjustmentAmt { get; set; }
        public string DebtorName { get; set; }
        public int? DebtorID { get; set; }
        public string BILLTYPENAME { get; set; }
        public string Description { get; set; }
        public string SaleStatus { get; set; }
        public DateTime? DocDate { get; set; }
        public string DocNo { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? TransactionDate { get; set; }
        public long? BillingAmt { get; set; }
        public long? ReceiptAmount { get; set; }
        public long? OutstandingwithTaxAmt { get; set; }
    }
}
