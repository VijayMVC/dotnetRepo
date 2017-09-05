using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rationalNumberex
{
    public class Rational
    {
        
        public int numerator { get; set; }
        public int denominator { get; set; }
        public Rational(int n, int d)
        {
            int gcd = GCD(n, d);
            n /= gcd;
            d /= gcd;
            numerator = n;
            denominator = d;
        }

        public override string ToString()
        {
            return numerator + "/" + denominator;
        }

        static int GCD(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }
            else
                return GCD(b, a % b);
        }

        public static Rational operator + (Rational r, Rational s)
        {
            int addN = s.denominator * r.numerator + s.numerator * r.denominator;
            int addD = s.denominator * r.denominator;

            return new Rational(addN, addD);
        }
        public static Rational operator + (Rational r, int n)
        {
            Rational s = new Rational(n, 1);
                return r + s;
        }
        public static Rational operator +(int n, Rational r)
        { 
            return r + n;
        }




    }
}
