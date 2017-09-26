using System.Collections.Generic;

namespace SGFlooring.Models.Interfaces
{
    public interface ITaxRepository
    {
        List<Tax> GetList();
        Order AddStateToOrder(Order newOrder);
    }
}
