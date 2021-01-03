using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IQSoft.eCommerce.Entities.Operations
{
    public class PropertyData
    {
        [Key]
        public int ProjectID { get; set; }
        public string ProjectNo { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDesc { get; set; }

        public string PriceRange { get; set; }
        public string BuiltupSize { get; set; }

        public int Total { get; set; }
        public int Sold { get; set; }
        public int Available { get; set; }

        public string TitleImageUrl { get; set; }
        public string ImageUrl1 { get; set; }
        public string ImageUrl2 { get; set; }
        public string ImageUrl3 { get; set; }
        public string ImageUrl4 { get; set; }
        public string ImageUrl5 { get; set; }

        public string VideoUrl1 { get; set; }
        public string VideoUrl2 { get; set; }
        public string VideoUrl3 { get; set; }
        public string VideoUrl4 { get; set; }
        public string VideoUrl5 { get; set; }

        public int BedRooms { get; set; }
        public int Showers { get; set; }
        public int Parking { get; set; }

        public string MortageCalculatorLink { get; set; }
        public string MonthlyRepayment { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public string LandTitleType { get; set; }
        public string Tenure { get; set; }
        public string Furnishing { get; set; }
        public string LandArea { get; set; }
        public string CompletionDate { get; set; }
        public string PostedDate { get; set; }

        public string PropertyReview { get; set; }
        public string DeveloperReview { get; set; }

        public string Website { get; set; }
        public string Description { get; set; }

    }
}
