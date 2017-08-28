using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoblinsBattle
{
    class Goblin
    {
        private int _hitPoints;

        public int GetHitPoints()
        {
            return _hitPoints;
        }

        public void SetHitPoints(int hp)
        {
            // if hp is negative do nothing and return
            if (hp < 0)
                return;
            else
                _hitPoints = hp;
        }


    }
}
