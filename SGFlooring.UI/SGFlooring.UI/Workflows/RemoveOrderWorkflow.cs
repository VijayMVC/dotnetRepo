using SGFlooring.BLL;
using SGFlooring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGFlooring.UI.Workflows
{
    public class RemoveOrderWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();
            DateTime orderDate = new DateTime();
            int orderNumber = 0;

            Console.Clear();
            Console.WriteLine("Remove an order");
            Console.WriteLine("*********************************");

            Console.Write("Enter the date (mm/dd/yyyy) of the order to be removed: ");
            DateTime.TryParse(Console.ReadLine(), out orderDate);

            Console.Write("Enter the order number of the order to be removed: ");
            int.TryParse(Console.ReadLine(), out orderNumber);

            ConsoleIO.DisplaySpecificOrder(manager.GetSpecificOrder(orderDate, orderNumber));
            Console.WriteLine("Remove this order? Y/N");
            string answer = Console.ReadLine().ToString();

            switch (answer.ToLower())
            {
                case "y":
                    manager.RemoveOrder(orderDate, orderNumber);
                    break;
                case "n":
                    break;
                default:
                    break;
            }
        }
    }
}
