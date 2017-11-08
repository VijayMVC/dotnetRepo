using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Tables
{
    public class Special
    {
        public int SpecialID { get; set; }
        public string SpecialName { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public int value { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }

        public Special()
        {
            Vehicles = new HashSet<Vehicle>();
        }
    }
}
