using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class CarModel
    {
        public int CarModelID { get; set; }
        public string ModelName { get; set; }
        public DateTime AddedDate { get; set; }
        public virtual Make AMake { get; set; }
        public virtual Employee AnEmployee { get; set; }        
    }
}
