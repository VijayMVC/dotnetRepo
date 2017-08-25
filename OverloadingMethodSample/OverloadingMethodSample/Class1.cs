using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverloadingMethodSample
{
    class Dog
    {
        public void Bark ()
        {
            Console.WriteLine("Bark Bark Bark");
        }
        public void Bark (string name)
        {
            Console.WriteLine("Hello my name is " + name);
        }
    }
}
