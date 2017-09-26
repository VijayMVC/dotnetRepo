using SGFlooring.BLL;
using SGFlooring.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
            bool isValid = false;

            Console.Clear();
            Console.WriteLine("Edit an order");
            Console.WriteLine("*********************************");

            while (!isValid)
            {
                Console.Clear();
                Console.Write("Enter the date (mm/dd/yyyy) of the order to be edited: ");
                //confirm valid date
                if (DateTime.TryParse(Console.ReadLine(), out orderDate))
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Error: Invalid date entered\nPress any key to re enter date");
                    Console.ReadKey();
                    isValid = false;
                }
            }
            isValid = false;

            Console.Write("Enter the order number of the order to be edited: ");
            int.TryParse(Console.ReadLine(), out orderNumber);

            orderToEdit = manager.GetSpecificOrder(orderDate, orderNumber);

            Console.Write($"Enter customer name (currently: {orderToEdit.CustomerName.Replace("^",",")}): ");
            string name = Console.ReadLine();
            if (!(string.IsNullOrWhiteSpace(name)))
            {
                orderToEdit.CustomerName = name;
            }

            while (!isValid)
            {
                List<Tax> stateList = manager.ListStates();
                ConsoleIO.DisplayStateDetails(stateList);
                Console.Write($"Enter the customer state (currently: {orderToEdit.State}):  ");
                string state = Console.ReadLine();
                if (!(string.IsNullOrWhiteSpace(state)))
                {
                    orderToEdit.State = state;
                    manager.AddStateToOrder(orderToEdit);
                    if (manager.ListStates().Any(o => o.StateAbbreviation == orderToEdit.State || o.StateName == orderToEdit.State))
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Error: State entered is not a valid state.\nPress any key to re enter state");
                        Console.ReadKey();
                        isValid = false;
                    }
                }
                else
                {
                    isValid = true;
                }
            }
            isValid = false;

            while (!isValid)
            {
                List<Product> prodList = manager.ListProducts();
                ConsoleIO.DisplayProductDetails(prodList);
                Console.Write($"Enter the product type (currently: {orderToEdit.ProductType}):  ");
                string productType = Console.ReadLine();
                if (!(string.IsNullOrWhiteSpace(productType)))
                {
                    orderToEdit.ProductType = productType;
                    manager.AddProductToOrder(orderToEdit);
                    if (manager.ListProducts().Any(p => p.ProductType == orderToEdit.ProductType))
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Error: Product type entered is not valid.\nPress any key to re enter product type");
                        Console.ReadKey();
                        isValid = false;
                    }
                }
                else
                {
                    isValid = true;
                }
            }
            isValid = false;

            while (!isValid)
            {
                Console.Write($"Enter the area (currently: {orderToEdit.Area}):  ");
                int area = 0;
                int.TryParse(Console.ReadLine(), out area);
                if (area != 0)
                {
                    orderToEdit.Area = area;
                    if (orderToEdit.Area >= 100)
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Error: Area entered is not valid.\nPress any key to re enter area");
                        Console.ReadKey();
                        isValid = false;
                    }
                }
                else
                {
                    isValid = true;
                }
            }
            isValid = false;

            while (!isValid)
            {
                ConsoleIO.DisplaySpecificOrder(orderToEdit);
                Console.WriteLine("Would you like to save this order? Y/N");
                string answer = Console.ReadLine().ToString();

                switch (answer.ToLower())
                {
                    case "y":
                        manager.SaveEditedOrder(orderToEdit);
                        isValid = true;
                        break;
                    case "yes":
                        manager.SaveEditedOrder(orderToEdit);
                        isValid = true;
                        break;
                    case "n":
                        isValid = true;
                        break;
                    case "no":
                        isValid = true;
                        break;
                    default:
                        isValid = false;
                        break;
                }
            }
        }
    }
}
