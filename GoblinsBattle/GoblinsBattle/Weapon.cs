using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoblinsBattle
{
    class Weapon
    {
        public int MaxDamage{get; set;}
        public int MinDamage { get; set; }
        public double Critical { get; set; }
        internal int GenerateDamage(Goblin target)
        {
            int damage = (int)(RNG.Next(MinDamage, MaxDamage + 1) * (1.0 - target.GoblinArmor.PercentReduction));
            return damage;
        }

        internal int CritDamage()
        {
            int damage = (int)(RNG.Next(MinDamage, MaxDamage + 1) * (Critical));
            return damage;
        }
    }
}
