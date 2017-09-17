using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Computer_Players
{
    class AlwaysRock : Player
    {
        public AlwaysRock(string name) : base(name)
        {
        }

        public override Choices GetChoice()
        {
            return Choices.Rock;
        }
    }
}
