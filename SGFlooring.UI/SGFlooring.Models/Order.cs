using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGFlooring.Models
{
    public class Order
    {
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public string State { get; set; }
        public string ProductType { get; set; }
        public decimal Area { get; set; }
        public decimal CostPerSquareFoot { get; set; }
        public decimal LaborCostPerSquareFoot { get; set; }
        public decimal TaxRate { get; set; }

        public decimal MaterialCost => Area * CostPerSquareFoot;
        public decimal Tax => (MaterialCost + LaborCost) * (TaxRate / 100.00M);
        public decimal Total => MaterialCost + LaborCost + Tax;
        public decimal LaborCost => LaborCostPerSquareFoot * Area;
    }
}
