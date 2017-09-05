using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rationalNumberex
{
    class Program
    {
        static void Main(string[] args)
        {
            Rational r = new Rational(2, 6);
            Rational s = new Rational(1, 2);
            int i = 5;
            Rational t = i + r;
            Console.WriteLine(t);
            Console.ReadKey();
        }
    }
}
