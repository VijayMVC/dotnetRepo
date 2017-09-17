using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Computer_Players
{
    class AlwaysPaper : Player
    {
        public AlwaysPaper(string name) : base(name)
        {
        }

        public override Choices GetChoice()
        {
            return Choices.Paper;
        }
    }
}
