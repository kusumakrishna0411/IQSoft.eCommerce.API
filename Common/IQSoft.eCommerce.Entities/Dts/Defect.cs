using System.Collections.Generic;

namespace IQSoft.eCommerce.Entities.Dts
{
    public class Defect
    {
        public PS_DefectHeader Header { get; set; }
        public List<PS_DefectItem> Items { get; set; }
        public List<CF_Document> Documents { get; set; }
        public List<PS_DefectItemFollowUp> FollowUps { get; set; }
    }
}
