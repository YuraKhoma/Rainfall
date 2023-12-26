using System.ComponentModel.DataAnnotations;

namespace Rainfall.Models
{
    public class Items
    {
        public string Id { get; set; }

        [Display(Name = "EA region")]
        public string EaRegionName { get; set; }

        public int Easting { get; set; }


        [Display(Name = "Grid Reference")]
        public string GridReference { get; set; }

        public string Label { get; set; }

        public double Lat { get; set; }

        public double Long { get; set; }

        public Measures Measures { get; set; }

        public int Northing { get; set; }

        public string Notation { get; set; }


        [Display(Name = "Station ID")]
        public string StationReference { get; set; }

        public string Type { get; set; }
    }
}
