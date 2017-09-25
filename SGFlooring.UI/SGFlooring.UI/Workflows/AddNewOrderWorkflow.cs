﻿using SGFlooring.BLL;
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
            
            ConsoleIO.DisplayStateDetails(manager.ListStates());
            Console.WriteLine("From the list above, please enter the state the customer is located in: ");
            newOrder.State = Console.ReadLine();
            manager.GetState(newOrder);

            ConsoleIO.DisplayProductDetails(manager.ListProducts());
            Console.WriteLine("From the list above, please enter the name of the product type you would like: ");
            newOrder.ProductType = Console.ReadLine();
            manager.GetProduct(newOrder);

            Console.Write("please enter the area of your project space in sq feet: ");
            int input = 0;
            int.TryParse(Console.ReadLine(),out input);
            newOrder.Area = input;

            ConsoleIO.DisplaySpecificOrder(newOrder);
            Console.WriteLine("Would you like to place this order? (Y/N)");
            string answer = Console.ReadLine().ToString();

            switch(answer.ToLower())
            {
                case "y":
                    manager.SaveOrder(newOrder);
                    break;
                case "n":
                    break;
                default:
                    break;
            }
        }
    }
}