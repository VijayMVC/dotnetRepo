using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = GetNumberFromUser();

            Calculator.PrintFactors(number);
            Calculator.IsPerfectNumber(number);
            Calculator.IsPrimeNumber(number);

            Console.WriteLine("\nPress any key to quit...");
            Console.ReadKey();
        }

        /// <summary>
        /// Prompt the user for an integer.  Make sure they enter a valid integer!
        /// 
        /// See the String Input lesson for TryParse() examples
        /// </summary>
        /// <returns>the user input as an integer</returns>
        static int GetNumberFromUser()
        {
            bool success = false;
            int toReturn = int.MinValue;
            while (!success)
            {
                Console.WriteLine("What number would you like to factor?");
                success = int.TryParse(Console.ReadLine(), out toReturn);
                             
            }
            return toReturn;     
        
        }
    }
    
    class Calculator
    {
        /// <summary>
        /// Given a number, print the factors per the specification
        /// </summary>
        /// 
        public static void PrintFactors(int number)
        {
            Console.WriteLine($"\nThe factors of {number} are:");
            for (int i = 1; i <= number; i++) 
            {
                if (number % i == 0)
                    Console.Write($" {i}");
            }
            Console.WriteLine("\n");
        }

        /// <summary>
        /// Given a number, print if it is perfect or not
        /// </summary>
        public static void IsPerfectNumber(int number)
        {
            int calc = 0;
            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                    calc += i;
            }
            if (calc - number == number)
                Console.WriteLine($"{number} is a perfect number");
            else
                Console.WriteLine($"{number} is not a perfect number");
        }

        /// <summary>
        /// Given a number, print if it is prime or not
        /// </summary>
        public static void IsPrimeNumber(int number)
        {
            int count = 0;
            for (int x = 1; x <= number; x++)
            {
                if (number % x == 0)
                {
                    count++;
                }
            }
            if (count == 2)
                Console.WriteLine($"{number} is a prime number");
            else
                Console.WriteLine($"{number} is not a prime a number");
            return;
        }
       
    }
}
