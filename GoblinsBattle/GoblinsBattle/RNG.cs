using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoblinsBattle
{
    public static class RNG
    {
        static Random _generator = new Random();

        internal static int Next(int exclusiveMax)
        {
            return _generator.Next(exclusiveMax);
        }

        internal static int Next(int inclusiveMin, int exclusiveMax)
        {
            return _generator.Next(inclusiveMin, exclusiveMax);
        }

        internal static double NextDouble()
        {
            return _generator.NextDouble();
        }
    }
}
