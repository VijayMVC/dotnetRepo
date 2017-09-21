using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGFlooring.Models.Interfaces
{
    public class Product
    {
        string ProductType { get; set; }
        decimal CostPerSquareFoot { get; set; }
        decimal LaborCostPerSquareFoot { get; set; }
    }
}
