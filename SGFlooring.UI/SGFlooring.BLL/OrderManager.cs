using SGFlooring.Models;
using SGFlooring.Models.Interfaces;
using SGFlooring.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGFlooring.BLL
{
    public class OrderManager
    {
        private IOrderRepository _orderRepository;
        private IProductRepository _productRepository;
        private ITaxRepository _taxRepository;

        public OrderManager (IOrderRepository orderRepository, IProductRepository productRepository, ITaxRepository taxRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _taxRepository = taxRepository;
        }

        public List<Product> ListProducts()
        {
            List<Product> allProducts = new List<Product>();
            allProducts = _productRepository.ListProducts();

            return allProducts;
        }

        public void RemoveOrder(DateTime orderDate, int orderNumber)
        {
            string prefix = "Orders_";
            string dateParse = orderDate.ToString("MMddyyyy");
            string orderID = $"{prefix}{dateParse}";

            _orderRepository.RemoveSpecificOrder(orderDate, orderNumber);
        }

        public Order GetSpecificOrder(DateTime orderDate, int orderNumber)
        {
            Order order = new Order();
            order = _orderRepository.SpecificOrder(orderDate, orderNumber);

            if (order.OrderNumber == 0)
            {
                Console.WriteLine("Order does not exist, press any key to return to main menu...");
                Console.ReadKey();
                return order;
            }

            return order;
        }

        public List<Tax> ListStates()
        {
            List<Tax> allStates = new List<Tax>();
            allStates = _taxRepository.GetList();

            return allStates;
        }

        public void GetState(Order newOrder)
        {
            _taxRepository.GetState(newOrder);
        }

        public OrderLookupResponse LookupOrders(DateTime date)
        {
            OrderLookupResponse response = new OrderLookupResponse();

            response.ListOfOrders = _orderRepository.LoadOrders(date);

            if(response.ListOfOrders == null)
            {
                response.Success = false;
                response.Message = "No orders were made on that date.";
            }
            else
            {
                response.Success = true;
            }
            return response;
        }

        public void SaveOrder(Order newOrder)
        {
            newOrder.OrderNumber = 1;
            List<Order> orders = _orderRepository.LoadOrders(newOrder.OrderDate);
            if (orders.Count == 0)
            {
                _orderRepository.Create(newOrder);
            }
            else
            {
                int order = orders.Max(o => o.OrderNumber);

                newOrder.OrderNumber = order + 1;
                _orderRepository.Create(newOrder);
            }
        }

        public void SaveEditedOrder(Order orderToEdit)
        {
            _orderRepository.Create(orderToEdit);
        }

        public void GetProduct(Order newOrder)
        {
            _productRepository.GetProduct(newOrder);
        }        
    }
}
