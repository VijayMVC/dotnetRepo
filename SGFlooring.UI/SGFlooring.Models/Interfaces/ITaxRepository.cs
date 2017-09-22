using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGFlooring.Models.Interfaces
{
    interface ITaxRepository
    {
        Tax GetTax(Tax tax);
        List<Tax> GetList();
    }
}
