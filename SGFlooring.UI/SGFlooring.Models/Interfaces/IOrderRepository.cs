using System;
using System.Collections.Generic;

namespace SGFlooring.Models.Interfaces
{
    public interface IOrderRepository
    {
        void Create(Order order);
        List<Order> LoadOrders(DateTime date);
        Order SpecificOrder(DateTime date,int orderNumber);
        void RemoveSpecificOrder(DateTime date, int orderNumber);
    }
}
