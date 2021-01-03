using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IQSoft.eCommerce.Entities.Dts
{
    [Table(name: "CF_Document", Schema = "dbo")]
    public class CF_Document
    {
        [Key]
        public int DocumentID { get; set; }
        public string RefTable { get; set; }
        public int RefRecordID { get; set; }

        public string DocumentName { get; set; }
        public string DocumentPath { get; set; }
        public string Keyword { get; set; }
        public string Description { get; set; }

        public DateTime? DocumentDate { get; set; }
        public decimal? FileSize { get; set; }
        public string MIMEType { get; set; }

        public int? DocumentTypeID { get; set; }
        public int? CheckOutUserID { get; set; }
        public string RecordStatus { get; set; }

        public int CreateUserID { get; set; }
        public DateTime CreateDate { get; set; }
        public int ModifyUserID { get; set; }
        public DateTime ModifyDate { get; set; }

        public int? DirectoryID { get; set; }
    }
}
