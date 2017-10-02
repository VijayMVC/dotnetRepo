using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharedLayoutTest.Models
{
    public class TipModel
    {
        public decimal Bill { get; set; }
        public decimal Tip { get; set; }
        public decimal TipPercent { get; set; }
        public decimal Total => ((TipPercent/100) * Bill) + Bill;
        public string Symbol { get; set; }
    }
}