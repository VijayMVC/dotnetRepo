﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Computer_Players
{
    class TotallyRandom : Player
    {
        public TotallyRandom(string name) : base(name)
        {
        }

        public override Choices GetChoice()
        {
            int a = 0;
            Random _rng = new Random();
            a = _rng.Next(1, 3);
            
            switch (a)
            {
                case 1:
                    return Choices.Paper;
                case 2:
                    return Choices.Rock;
                default:
                    return Choices.Scissors;       
            }
        }
    }
}
