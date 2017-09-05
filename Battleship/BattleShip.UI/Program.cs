using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL;

namespace BattleShip.UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            //initiate start game 
            while(true)
            {
                
                GameSetup game = new GameSetup();
                game.setupGame();
                bool Again = GameFlow.PlayAgain();
                if (true && (Again))
                {
                    GameSetup newGame = new GameSetup();
                    newGame.setupGame();
                }
                else break;
            }
        }
        
    }
}
