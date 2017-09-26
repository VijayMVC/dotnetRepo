using System.Collections.Generic;

namespace SGFlooring.Models.Interfaces
{
    public interface IProductRepository
    {
        List<Product> ListProducts();
        Order AddProductToOrder(Order order);
    }
}
