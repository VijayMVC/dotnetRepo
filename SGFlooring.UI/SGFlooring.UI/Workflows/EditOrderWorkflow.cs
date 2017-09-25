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
    public class EditOrderWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();
            DateTime orderDate = new DateTime();
            Order orderToEdit = new Order();
            int orderNumber = 0;

            Console.Clear();
            Console.WriteLine("Edit an order");
            Console.WriteLine("*********************************");

            Console.Write("Enter the date (mm/dd/yyyy) of the order to be edited: ");
            DateTime.TryParse(Console.ReadLine(), out orderDate);

            Console.Write("Enter the order number of the order to be edited: ");
            int.TryParse(Console.ReadLine(), out orderNumber);

            orderToEdit = manager.GetSpecificOrder(orderDate, orderNumber);

            Console.Write($"Enter customer name (currently: {orderToEdit.CustomerName}): ");
            string name = Console.ReadLine();
            if (name != "")
            {
                orderToEdit.CustomerName = name;
            }

            List<Tax> stateList = manager.ListStates();
            ConsoleIO.DisplayStateDetails(stateList);
            Console.Write($"Enter the customer state (currently: {orderToEdit.State}):  ");
            string state = Console.ReadLine();
            if (state != "")
            {
                orderToEdit.State = state;
                manager.GetState(orderToEdit);
            }

            List<Product> prodList = manager.ListProducts();
            ConsoleIO.DisplayProductDetails(prodList);
            Console.Write($"Enter the product type (currently: {orderToEdit.ProductType}):  ");
            string productType = Console.ReadLine();
            if (productType != "")
            {
                orderToEdit.ProductType = productType;
                manager.GetProduct(orderToEdit);
            }

            Console.Write($"Enter the area (currently: {orderToEdit.Area}):  ");
            int area = 0;
            int.TryParse(Console.ReadLine(), out area);
            if (area != 0)
            {
                orderToEdit.Area = area;
            }

            ConsoleIO.DisplaySpecificOrder(orderToEdit);
            Console.WriteLine("Would you like to save this order? Y/N");
            string answer = Console.ReadLine().ToString();

            switch (answer.ToLower())
            {
                case "y":
                    manager.SaveEditedOrder(orderToEdit);
                    break;
                case "n":
                    break;
                default:
                    break;
            }
        }
    }
}
