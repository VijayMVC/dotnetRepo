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
        //Order manager will be able to lookup, create, update, and delete an order
        private IOrderRepository _orderRepository;

        public OrderManager (IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public OrderLookupResponse LookupOrder(int OrderNumber)
        {
            OrderLookupResponse response = new OrderLookupResponse();

            response.Order = _orderRepository.LoadOrder(OrderNumber);

            if (response.Order == null)
            {
                response.Success = false;
                response.Message = $"{OrderNumber} is not a valid order";
            }
            else
            {
                response.Success = true;
            }
            return response;
        }        
    }
}
