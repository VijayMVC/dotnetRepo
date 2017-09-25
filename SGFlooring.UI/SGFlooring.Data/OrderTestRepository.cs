using SGFlooring.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Models;

namespace SGFlooring.Data
{
    public class OrderTestRepository : IOrderRepository
    {
        private static Order _order1 = new Order
        {
            OrderNumber = 1,
            OrderDate = new DateTime(2013, 6, 1),
            CustomerName = "Wise",
            State = "OH",
            TaxRate = 6.25M,
            ProductType = "Wood",
            Area = 100.00M,
            CostPerSquareFoot = 5.15M,
            LaborCostPerSquareFoot = 4.75M,
        };

        private static Order _order2 = new Order
        {
            OrderNumber = 2,
            OrderDate = new DateTime(2013, 6, 1),
            CustomerName = "Wilson",
            State = "MN",
            TaxRate = 7.25M,
            ProductType = "Laminate",
            Area = 100.00M,
            CostPerSquareFoot = 1.75M,
            LaborCostPerSquareFoot = 2.10M,
        };

        private static Order _order3 = new Order
        {
            OrderNumber = 3,
            OrderDate = new DateTime(2013, 6, 1),
            CustomerName = "Ganser",
            State = "CO",
            TaxRate = 4.25M,
            ProductType = "Tile",
            Area = 250.00M,
            CostPerSquareFoot = 3.50M,
            LaborCostPerSquareFoot = 4.15M,
        };

        private static List<Order> _allOrders = new List<Order>()
        {
            _order1,_order2,_order3
        };

        public void Create(Order order)
        {
            bool newOrder = true;
            foreach(Order o in _allOrders)
            {
                if (o.OrderNumber == order.OrderNumber)
                {
                    _allOrders.Remove(o);
                    _allOrders.Add(order);
                    newOrder = false;
                    break;
                }
            }
            if (newOrder == true)
            {
                _allOrders.Add(order);
            }
        }

        public List<Order> LoadOrders(DateTime date)
        {
            return _allOrders;
        }

        public void RemoveSpecificOrder(DateTime date, int orderNumber)
        {
            foreach (Order o in _allOrders)
            {
                if (o.OrderNumber == orderNumber)
                {
                    _allOrders.Remove(o);
                    break;
                }
            }
        }

        public Order SpecificOrder(DateTime date, int orderNumber)
        {
            Order toReturn = new Order();
            foreach (Order order in _allOrders)
            {
                if (order.OrderNumber == orderNumber)
                {
                    toReturn = order;
                    return toReturn;
                }
            }
            return toReturn;
        }
    }
}
