using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL;

namespace BattleShip.UI
{
    class GameState
    {
        //information from game setup and player will populate this class, this class will then be used to start game
        Player P1 { get; }
        Player P2 { get; }
        bool IsPlayerOneTurn { get; set; }

        public GameState(Player p1, Player p2, bool p1Turn)
        {
            P1 = p1;
            P2 = p2;
            IsPlayerOneTurn = p1Turn;
        }
    }
}
