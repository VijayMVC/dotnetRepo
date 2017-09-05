using BattleShip.BLL;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class GameFlow
    {
        public static bool GameOver { get; internal set; }

        public GameFlow (Player Attacker, Player Receiver)
        {
            FireShotResponse ShotResponse;
            while (true)
            {
                ConsoleOutput.PromptPlayerTurn(Attacker);
                var shot = ConsoleInput.GetCoordinateFromUser();
                ShotResponse = Receiver.PlayerBoard.FireShot(shot);
                ShotStatus result = ShotResponse.ShotStatus;
                string ShipHit = ShotResponse.ShipImpacted;

                if (result == ShotStatus.Miss)
                {
                    ConsoleOutput.Miss(Attacker.Name);
                    break;
                }
                else if (result == ShotStatus.Hit)
                {
                    ConsoleOutput.Hit(Attacker.Name);
                    break;
                }
                else if (result == ShotStatus.HitAndSunk)
                {
                    ConsoleOutput.HitAndSunk(Attacker.Name, Receiver.Name, ShipHit);
                    break;
                }
                else if (result == ShotStatus.Victory)
                {
                    ConsoleOutput.DeclareVictory(Attacker.Name, Receiver.Name);
                    GameOver = true;
                    break;
                }
                else if (result == ShotStatus.Duplicate)
                {
                    ConsoleOutput.Duplicate(Attacker.Name);
                }
                else
                {
                    ConsoleOutput.InvalidShot(Attacker.Name);
                }
            }
        }


        public static bool PlayAgain()
        {
            GameOver = false;
            bool WantToPlayAgain = false;
            while (true)
            {
                ConsoleOutput.PlayAgain();
                string decision = Console.ReadLine();
                if (decision.ToLower() == "y")
                {
                    WantToPlayAgain = true;
                    break;
                }
                else if (decision.ToLower() == "n")
                {
                    WantToPlayAgain = false;
                    break;
                }
                else
                {

                }
            }
            return WantToPlayAgain;
        }
    }
}
