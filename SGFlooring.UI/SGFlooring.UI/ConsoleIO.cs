using SGFlooring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGFlooring.UI
{
    public class ConsoleIO
    {
        public static void DisplayOrderDetails(List<Order> allOrders)
        {
            List<Order> AllOrders = new List<Order>();
            AllOrders = allOrders;

            foreach (Order order in allOrders)
            {
                Console.WriteLine("****************************");
                Console.WriteLine($"{order.OrderNumber} | {order.OrderDate:MM/dd/yyyy}");
                Console.WriteLine($"{order.CustomerName}");
                Console.WriteLine($"{order.State}");
                Console.WriteLine($"Product: {order.ProductType}");
                Console.WriteLine($"Materials: {order.MaterialCost:c}");
                Console.WriteLine($"Labor: {order.LaborCost:c}");
                Console.WriteLine($"Tax: {order.Tax:c}");
                Console.WriteLine($"Total: {order.Total:c}");
            }
        }

        public static void DisplayProductDetails(List<Product> allProducts)
        {
            Console.WriteLine("{0, -15}{1,-10}{2,-10}","Product Type","Cost Per Sq Foot","Labor Cost Per Sq Foot");
            foreach (Product product in allProducts)
            {
                Console.WriteLine("****************************");
                Console.WriteLine("{0,-15}{1,-5}{2,-5}", product.ProductType, product.CostPerSquareFoot,product.LaborCostPerSquareFoot);
            }
        }
    }
}
