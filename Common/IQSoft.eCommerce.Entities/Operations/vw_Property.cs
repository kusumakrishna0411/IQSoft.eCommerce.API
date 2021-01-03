using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IQSoft.eCommerce.Entities.Operations
{
    [Table(name: "vw_Property", Schema = "MobileApp")]
    public class vw_Property
    {
        [Key]
        public int ProjectID { get; set; }        
        public string ProjectNo { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDesc { get; set; }

        public string ProjectImageLink { get; set; }
        public string ProjectHtmlContent { get; set; }

        public string ImageName { get; set; }
        public string ImageDescription { get; set; }
        public string ImageUrl { get; set; }
        
        [NotMapped]
        public string BrandingImages { get; set; }
    }
}
