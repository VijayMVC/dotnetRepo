using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGFlooring.Models.Interfaces
{
    public interface IOrderRepository
    {
        void Create(Order order);
        Order LoadOrder(int accountNumber);
        void Update(Order order);
        void Delete(int accountNumber);
    }
}
