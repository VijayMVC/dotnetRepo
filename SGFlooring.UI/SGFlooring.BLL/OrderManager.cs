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

        public OrderManager (IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public OrderManager (IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public OrderCreateResponse ListProducts()
        {
            OrderCreateResponse response = new OrderCreateResponse();

            response.AllProducts = _productRepository.ListProducts();

            if(response.AllProducts == null)
            {
                response.Success = false;
                response.Message = "There was an error locating the product listing!";
            }
            else
            {
                response.Success = true;
            }
            return response;            
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

        public static string DateToOrderId(string userInput)
        {
            DateTime orderDate = new DateTime(0001, 01, 01);
            DateTime.TryParse(userInput, out orderDate);
            string prefix = "Orders_";
            string dateParse = orderDate.ToString("MMddyyyy");
            string orderID = $"{prefix}{dateParse}";

            return orderID;
        }

        
    }
}
