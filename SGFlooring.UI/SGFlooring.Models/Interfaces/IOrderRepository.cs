﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGFlooring.Models.Interfaces
{
    public interface IOrderRepository
    {
        void Create(Order order);
        List<Order> LoadOrders(string ordersID);
        Order SpecificOrder(int orderNumber);//david said you will need a second paramater of date (this may become clear once I implement file repo)
        void Update(Order order);
        void Delete(int orderNumber);//david said you will need a second paramater of date, other option may be Order parameter by itself
    }
}
