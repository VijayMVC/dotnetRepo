using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoblinsBattle
{
    class Goblin
    {
        //we only need one rng for all goblin instances, so static
        //private static Random _rng = new Random();

        public double DodgeChance { get; set; }
        public Armor GoblinArmor { get; set; }
        public Weapon GoblinWeapon { get; set; }
        public double CritHitChance { get; set; }

        private int _hitPoints;

        public string Name { get; set; }
        public bool IsDead { get; private set; }

        public int HitPoints
        {
            get { return _hitPoints; }
            set
            {
                //check incoming value
                if (value < 0)
                    return;
                else //otherwise save it to the field
                    _hitPoints = value;
            }
        }

        public void Attack(Goblin target)
        {
            int damage = GoblinWeapon.GenerateDamage(target);
            //int damage = (int)(_rng.Next(5) * (1.0 - target.GoblinArmor.PercentReduction));
            Console.WriteLine($"{Name} attacks {target.Name} for {damage} damage!");

            target.Hit(damage);
        }

        // for when this instance gets hit
        public void Hit(int damage)
        {
            if (RNG.NextDouble() < DodgeChance)
            {
                //dodged
                Console.WriteLine($"{ Name} dodged!");
            }
            else if (RNG.NextDouble() < CritHitChance)
            {
                damage = GoblinWeapon.CritDamage();
                _hitPoints -= damage;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Hit is critical, {Name} receives {damage} damage. They have {_hitPoints} health.");
                Console.ForegroundColor = ConsoleColor.White;
                if (_hitPoints <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{Name} has died!");
                    IsDead = true;
                }
            }
            else
            {
                // damage = GoblinArmor.AdjustDamage(damage);
                // deduct damage
                _hitPoints -= damage;
                Console.WriteLine($"{Name} receives {damage} damage. They have {_hitPoints} health.");

                // should we die?
                if (_hitPoints <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{Name} has died!");
                    IsDead = true;
                }
            }
        }
    }
}
