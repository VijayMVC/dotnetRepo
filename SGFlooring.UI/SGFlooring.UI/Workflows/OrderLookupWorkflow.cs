using SGFlooring.BLL;
using SGFlooring.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGFlooring.UI.Workflows
{
    public class OrderLookupWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();

            Console.Clear();
            Console.WriteLine("Lookup Orders");
            Console.WriteLine("*********************************");
            Console.Write("Enter the date (mm/dd/yyyy) that you would like to view orders for: ");

            DateTime date;
            DateTime.TryParse(Console.ReadLine(), out date);
            string orderID = OrderManager.DateToOrderId(date);
            
            OrderLookupResponse response = manager.LookupOrders(orderID);

            if(response.Success)
            {
                ConsoleIO.DisplayOrderDetails(response.ListOfOrders);
            }
            else
            {
                Console.WriteLine("An error occured: ");
                Console.WriteLine(response.Message);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
