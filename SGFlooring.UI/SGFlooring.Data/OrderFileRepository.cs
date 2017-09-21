using SGFlooring.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Models;

namespace SGFlooring.Data
{
    public class OrderFileRepository : IOrderRepository
    {

        public void Create(Order order)
        {
            throw new NotImplementedException();
        }

        public void Delete(int accountNumber)
        {
            throw new NotImplementedException();
        }

        public Order LoadOrder(int accountNumber)
        {
            throw new NotImplementedException();
        }

        public void Update(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
