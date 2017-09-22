using SGFlooring.BLL;
using SGFlooring.Models;
using SGFlooring.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGFlooring.UI.Workflows
{
    public class AddNewOrderWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();
            Order newOrder = new Order();
            DateTime orderDate = new DateTime();
           
            Console.Clear();
            Console.WriteLine("Add an order");
            Console.WriteLine("*********************************");
            Console.Write("Enter the date (mm/dd/yyyy) that you would like to create the order for: ");
            DateTime.TryParse(Console.ReadLine(), out orderDate);
            newOrder.OrderDate = orderDate;
            Console.Write("Please enter the customer name: ");
            newOrder.CustomerName = Console.ReadLine();
            Console.Write("Please enter the state the customer is located in: ");
            newOrder.State = Console.ReadLine();
            Console.WriteLine("Please enter the name of the product type you would like: ");
            OrderCreateResponse response = manager.ListProducts();
            ConsoleIO.DisplayProductDetails(response.AllProducts);
            Console.ReadKey();
        }
    }
}
