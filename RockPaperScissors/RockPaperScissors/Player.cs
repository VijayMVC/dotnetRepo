using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    abstract class Player : IRPSPlayer
    {
        public Player(string name)
        {
            Name = name;
        }
        public string Name { get; }

        public abstract Choices GetChoice();
    }
}

