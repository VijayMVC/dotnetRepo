using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGFlooring.Models.Interfaces
{
    public class Tax
    {
        string StateAbbreviation { get; set; }
        string StateName { get; set; }
        decimal TaxRate { get; set; }
    }
}
