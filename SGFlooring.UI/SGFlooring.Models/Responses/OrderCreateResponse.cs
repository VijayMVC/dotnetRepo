using SGFlooring.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGFlooring.Models.Responses
{
    public class OrderCreateResponse : Response
    {
        public Order NewOrder { get; set; }
        public List<Product> AllProducts { get; set; }
        public Product NewProduct { get; set; }
        public Tax NewTax { get; set; }
    }
}
