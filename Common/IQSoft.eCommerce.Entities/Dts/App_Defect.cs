using System;

namespace IQSoft.eCommerce.Entities.Dts
{
    public class App_Defect
    {
        public int UnitId { get; set; }        
        public DateTime ReportDate { get; set; }
        public DateTime? TargetDate { get; set; }
        public int ReportedBy { get; set; }
        
        //4165
        public int ReasonID { get; set; }
        //4224
        public int Appointment { get; set; }
        //606
        public int ReportVia { get; set; }

        public string Summary { get; set; }
        public string Description { get; set; }

        public int DefectTypeID { get; set; }
        public string Type { get; set; }
        public int LocationID { get; set; }
        public int Contractor1ID { get; set; }
    }
}
