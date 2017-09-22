using SGFlooring.UI.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGFlooring.UI
{
    public class Menu
    {
        public static void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("*********************************************");
                Console.WriteLine();
                Console.WriteLine("1. Display Orders");
                Console.WriteLine("2. Add an Order");
                Console.WriteLine("3. Edit an Order");
                Console.WriteLine("4. Remove an Order");
                Console.WriteLine("5. Quit");
                Console.WriteLine();
                Console.Write("Enter selection: ");
                string userinput = Console.ReadLine();

                switch(userinput)
                {
                    case "1":
                        OrderLookupWorkflow lookupWorkflow = new OrderLookupWorkflow();
                        lookupWorkflow.Execute();
                        break;
                    case "2":
                        AddNewOrderWorkflow AddOrderWorkflow = new AddNewOrderWorkflow();
                        AddOrderWorkflow.Execute();
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        return;
                }
            }
        }
    }
}
