using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Tables
{
    public class Purchase
    {
        public int PurchaseID { get; set; }
        public decimal PurchasePrice { get; set; }
        public string VinNumber { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int PurchaseTypeID { get; set; }
    }
}
