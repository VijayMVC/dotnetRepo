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
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Goblin g1 = new Goblin();
                Goblin g2 = new Goblin();

                g1.Name = "Bob";
                g1.HitPoints = 25;
                g1.DodgeChance = 0.10;
                g1.GoblinArmor = new Armor();
                g1.GoblinArmor.PercentReduction = 0.5;
                g1.GoblinWeapon = new Weapon();
                g1.GoblinWeapon.MinDamage = 2;
                g1.GoblinWeapon.MaxDamage = 9;
                g1.CritHitChance = 0.20;
                g1.GoblinWeapon.Critical = 1.9;

                g2.Name = "Tom";
                g2.HitPoints = 25;
                g2.DodgeChance = 0.10;
                g2.GoblinArmor = new Armor();
                g2.GoblinArmor.PercentReduction = 0.5;
                g2.GoblinWeapon = new Weapon();
                g2.GoblinWeapon.MinDamage = 4;
                g2.GoblinWeapon.MaxDamage = 8;
                g2.CritHitChance = 0.20;
                g2.GoblinWeapon.Critical = 1.5;

                // they should take turns attacking, goblin 1 will go first
                int whoseTurn = 1;

                while (!g1.IsDead && !g2.IsDead)
                {
                    if (whoseTurn == 1)
                    {
                        g1.Attack(g2);
                        whoseTurn = 2;
                    }
                    else
                    {
                        g2.Attack(g1);
                        whoseTurn = 1;
                    }
                }

                Console.WriteLine("The battle is ended!");
            } while (ConsoleKey.F5 == Console.ReadKey().Key);
        }
    }
}
