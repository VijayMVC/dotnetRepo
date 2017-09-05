using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor.UI
{
    class UserInput
    {
        public static int GetUserInput()
        {
            Console.Clear();
            int output;
            string input;

            while(true)
            {
                Console.Write("Enter a number greater than 0");
                input = Console.ReadLine();

                if(int.TryParse(input, out output))
                {
                    return output;
                }
                else
                {
                    Console.WriteLine("That is not a valid number");
                    Console.ReadKey();
                }
            }
        }
    }
}
