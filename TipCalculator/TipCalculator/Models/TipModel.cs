using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TipCalculator.Models
{
    public class TipModel
    {
        public decimal? Bill { get; set;}
        public decimal? Tip { get; set; }
        public decimal? Total { get; set; }
    }
}