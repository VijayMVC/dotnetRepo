using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Ships;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;

namespace BattleShip.UI
{
    public class GameSetup
    {
        //start game
        private string p1Name;
        private string p2Name;

        BoardBuilder BoardSetup = new BoardBuilder();
        public void setupGame()
        {
            //display splashscreen
            ConsoleOutput.DisplayTitle();

            //collect player names and store them
            p1Name = ConsoleInput.P1EnterName();
            p2Name = ConsoleInput.P2EnterName();

                //player 1 setup your board
                ConsoleOutput.PlaceYourShips(p1Name);
                Board p1Board = new Board();
                p1Board = BoardSetup.BuildBoard(p1Board);
                //player 2 setup your board
                ConsoleOutput.PlaceYourShips(p2Name);
                Board p2Board = new Board();
                p2Board = BoardSetup.BuildBoard(p2Board);

                Player PlayerOne = new Player(p1Name, p1Board);
                Player PlayerTwo = new Player(p2Name, p2Board);

                //determine who goes first randomly
                bool IsPlayer1sTurn = DecideWhoGoesFirst();

                bool DecideWhoGoesFirst()
                {
                    return RNG.CoinFlip();
                }

                //set the game state and call gameflow method
                GameState Current = new GameState(PlayerOne, PlayerTwo, IsPlayer1sTurn);
                //loop back until victory
                while (!GameFlow.GameOver)
                {
                    if (IsPlayer1sTurn)
                    {
                        ConsoleOutput.DrawActiveBoard(p2Board);
                        GameFlow p1 = new GameFlow(PlayerOne, PlayerTwo);
                        IsPlayer1sTurn = false;
                    }
                    else
                    {
                        ConsoleOutput.DrawActiveBoard(p1Board);
                        GameFlow p2 = new GameFlow(PlayerTwo, PlayerOne);
                        IsPlayer1sTurn = true;
                    }
                }
        }
    }
}
