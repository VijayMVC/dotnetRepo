﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGFlooring.Models.Interfaces
{
    public interface IProductRepository
    {
        List<Product> ListProducts();
        Order GetProduct(Order order);
    }
}