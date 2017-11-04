using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class Vehicle
    {
        public int VehicleID { get; set; }
        public string VinNumber { get; set; }
        public int Mileage { get; set; }
        public decimal SalePrice { get; set; }
        public decimal MSRP { get; set; }
        public string Description { get; set; }
        public string Transmission { get; set; }
        public DateTime Year { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsNew { get; set; }
        public bool IsFeatured { get; set; }
        public int ModelID { get; set; }
        public int ColorID { get; set; }
        public int InteriorID { get; set; }
        public int BodyTypeID { get; set; }
        public int SpecialsID { get; set; }
        public int ImageID { get; set; }
    }
}
