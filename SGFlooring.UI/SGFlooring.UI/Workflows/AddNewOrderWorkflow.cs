using SGFlooring.BLL;
using SGFlooring.Models;
using System;
using System.Linq;

namespace SGFlooring.UI.Workflows
{
    public class AddNewOrderWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();
            Order newOrder = new Order();
            DateTime date;
            bool isValid = false;
           
            Console.Clear();
            Console.WriteLine("Add an order");
            Console.WriteLine("*********************************");

            while (!isValid)
            {
                Console.Clear();
                Console.Write("Enter the date (mm/dd/yyyy) that you would like to create the order for: ");
                //confirm date is valid and in the future.
                if (DateTime.TryParse(Console.ReadLine(), out date))
                {
                    isValid = true;
                }
                else
                {
                    isValid = false;
                }

                if (date > DateTime.Now)
                {
                    isValid = true;
                    newOrder.OrderDate = date;
                }
                else
                {
                    Console.WriteLine("Error: Must be a valid future date\nPress any key to re enter date");
                    Console.ReadKey();
                    isValid = false;
                }
            }
            isValid = false;

            
            while (!isValid)
            {
                Console.Clear();
                Console.Write("Please enter the customer name: ");
                //confirm name is not blank
                newOrder.CustomerName = Console.ReadLine().Replace(",","^");
                if (string.IsNullOrWhiteSpace(newOrder.CustomerName))
                {
                    Console.WriteLine("Error: Name entered is not valid.\nPress any key to re enter name");
                    Console.ReadKey();
                    isValid = false;
                }
                else
                {
                    isValid = true;
                }
            }
            isValid = false;

            while (!isValid)
            {
                Console.Clear();
                ConsoleIO.DisplayStateDetails(manager.ListStates());
                Console.WriteLine("From the list above, please enter the state the customer is located in: ");
                //confirm state exists within repo
                newOrder.State = Console.ReadLine();
                manager.AddStateToOrder(newOrder);
                if(manager.ListStates().Any(o => o.StateAbbreviation == newOrder.State || o.StateName == newOrder.State))
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
            isValid = false;

            while (!isValid)
            {
                Console.Clear();
                ConsoleIO.DisplayProductDetails(manager.ListProducts());
                Console.WriteLine("From the list above, please enter the name of the product type you would like: ");
                //confirm product exists within repo
                newOrder.ProductType = Console.ReadLine();
                manager.AddProductToOrder(newOrder);
                if(manager.ListProducts().Any(p => p.ProductType == newOrder.ProductType))
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
            isValid = false;

            while (!isValid)
            {
                Console.Clear();
                Console.Write("please enter the area of your project space in sq feet (must be at least 100 sq. ft.): ");
                int input = 0;
                //confirm area is at least 100 sq ft
                int.TryParse(Console.ReadLine(), out input);
                newOrder.Area = input;
                if (newOrder.Area >= 100)
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
            isValid = false;

            while (!isValid)
            {
                ConsoleIO.DisplaySpecificOrder(newOrder);
                Console.WriteLine("Would you like to place this order? (Y/N)");
                string answer = Console.ReadLine().ToString();

                switch (answer.ToLower())
                {
                    case "y":
                        manager.SaveOrder(newOrder);
                        isValid = true;
                        break;
                    case "yes":
                        manager.SaveOrder(newOrder);
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
