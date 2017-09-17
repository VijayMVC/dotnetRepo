using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    public class GameFlow
    {
        private IRPSPlayer _player;

        public GameFlow(IRPSPlayer player)
        {
            _player = player;
        }

        public void PlayGame(IRPSPlayer p1, IRPSPlayer p2)
        {
            Choices p1Choice = p1.GetChoice();
            Choices p2Choice = p2.GetChoice();

            if (p1Choice == p2Choice)
            {
                Console.WriteLine($"{p1.Name} and {p2.Name} have tied");
            }
            else if (p1Choice == Choices.Rock && p2Choice == Choices.Scissors
                || p1Choice == Choices.Scissors && p2Choice == Choices.Paper
                || p1Choice == Choices.Paper && p2Choice == Choices.Rock)
            {
                Console.WriteLine($"{p1.Name} has defeated {p2.Name}!");
            }
            else
            {
                Console.WriteLine($"{p2.Name} has defeated {p1.Name}!");
            }
        }

        public void PlayAgainstComputer()
        {
            Player humanPlayer = new HumanPlayer("Player1");

            PlayGame(humanPlayer, _player);
        }
    }
}
