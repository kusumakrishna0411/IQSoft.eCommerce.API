using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IQSoft.eCommerce.Entities.Dts
{
    [Table(name: "App_DtsType", Schema = "MobileApp")]
    public class App_DtsType
    {
        [Key]
        public int RNo { get; set; }
        public int PopupLstElementID { get; set; }
        public int PopupLstID { get; set; }
        public string StringEN { get; set; }
        public int? ParentPopupLstElementID { get; set; }

        public override string ToString()
        {
            return StringEN;
        }

        public override bool Equals(object obj)
        {
            var item = obj as App_DtsType;

            if (item == null)
            {
                return false;
            }

            return this.PopupLstElementID.Equals(item.PopupLstElementID) && this.PopupLstID.Equals(item.PopupLstID) && this.ParentPopupLstElementID.Equals(item.ParentPopupLstElementID);
        }

        public override int GetHashCode()
        {
            return this.PopupLstElementID.GetHashCode();
        }

        public List<App_DtsType> GetHeaderItems(List<App_DtsType> source)
        {
            var headerTypes = new int[] { 797, 809, 132 };
            return source.Where(s => headerTypes.Contains(s.PopupLstID)).ToList();
        }

        public List<App_DtsType> GetDetailedItems(List<App_DtsType> source)
        {
            var detailedTypes = new int[] { 206, 176, 52 };
            return source.Where(s => detailedTypes.Contains(s.PopupLstID) || s.ParentPopupLstElementID.HasValue == false).ToList();
        }
    }
}
