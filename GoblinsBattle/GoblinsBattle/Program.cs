using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoblinsBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            Goblin aGoblin = new Goblin();

            aGoblin.SetHitPoints(10);
            Console.WriteLine(aGoblin.GetHitPoints());

            aGoblin.SetHitPoints(-5);
            Console.WriteLine(aGoblin.GetHitPoints());
        }
    }
}
