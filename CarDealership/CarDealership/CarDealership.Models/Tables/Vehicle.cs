using CarDealership.Models.Tables;
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
        public bool IsAutomatic { get; set; }
        public int Year { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsNew { get; set; }
        public bool IsFeatured { get; set; }
        public string Color { get; set; }
        public string Interior { get; set; }
        public virtual Make CarMake { get; set; }
        public virtual CarModel CarModel { get; set; }
        public virtual BodyType CarBody { get; set; }
        public virtual ICollection<Special> Specials { get; set; }
        public string ImageLocation { get; set; }

        public Vehicle()
        {
            Specials = new HashSet<Special>();
        }
    }
}
