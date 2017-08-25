using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverloadingMethodSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog Stella = new Dog();

            Stella.Bark();
            Stella.Bark("Stella");

            Console.ReadLine();
            
        }
    }
}
