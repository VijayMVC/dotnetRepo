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

        //will need to set up an ordermanager to handle live data package
        //public OrderManager (IProductRepository productRepository)
        //{
        //    _productRepository = productRepository;
        //}

        public List<Product> ListProducts()
        {
            List<Product> allProducts = new List<Product>();
            allProducts = _productRepository.ListProducts();

            return allProducts;
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

        public OrderLookupResponse LookupOrders(string ordersID)
        {
            OrderLookupResponse response = new OrderLookupResponse();

            response.ListOfOrders = _orderRepository.LoadOrders(ordersID);

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
            string orderId = DateToOrderId(newOrder.OrderDate);
            List<Order> orders = _orderRepository.LoadOrders(orderId);
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

        public void GetProduct(Order newOrder)
        {
            _productRepository.GetProduct(newOrder);
        }

        public static string DateToOrderId(DateTime date)
        {
            string prefix = "Orders_";
            string dateParse = date.ToString("MMddyyyy");
            string orderID = $"{prefix}{dateParse}";

            return orderID;
        }

        
    }
}
