using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class HumanPlayer : Player
    {
        public HumanPlayer(string name) : base(name)
        {
        }

        public override Choices GetChoice()
        {
                Console.WriteLine("Select rock, paper, or scissors");
                string input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "rock":
                        return Choices.Rock;
                    case "paper":
                        return Choices.Paper;
                    default:
                        return Choices.Scissors;
                }
        }
    }
}
