using Ninject;
using RockPaperScissors.Computer_Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            bool playAgain = true;
            string input;
            Console.WriteLine("Player 1, please enter your name: ");
            string name = Console.ReadLine();
            //IRPSPlayer player1 = new HumanPlayer(name); eliminated after ninject implementation
            //IRPSPlayer player2 = new TotallyRandom("Computer");

            while (playAgain)
            {
                GameFlow newGame = DIContainer.kernel.Get<GameFlow>();
                newGame.PlayAgainstComputer();
                //newGame.PlayGame(player1, player2);
                Console.WriteLine("Play again? y or n");
                input = Console.ReadLine();
                if (input == "n")
                {
                    playAgain = false;
                }
                else
                {
                    playAgain = true;
                }
            }
        }
    }
}
