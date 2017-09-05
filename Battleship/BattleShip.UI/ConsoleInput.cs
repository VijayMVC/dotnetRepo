using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    class ConsoleInput
    {
        internal static string P1EnterName()
        {
            ConsoleOutput.PromptP1Name();
            string p1Name = Console.ReadLine();
            return p1Name;
        }

        internal static string P2EnterName()
        {
            ConsoleOutput.PromptP2Name();
            string p2Name = Console.ReadLine();
            return p2Name;
        }

        public static Coordinate GetCoordinateFromUser()
        {
            Coordinate toReturn = null;
            while (true)
            {
                ConsoleOutput.PromptforCoordinate();
                string input = Console.ReadLine(), strX, strY; int x, y;
                if (input == "m")
                {
                    ConsoleOutput.DrawBlankBoard();
                    ConsoleOutput.PromptforCoordinate();
                    input = Console.ReadLine();
                }


                if (input.Length == 2 || input.Length == 3)
                {
                    strX = input.Substring(0, 1);
                    x = GetNumberFromLetter(strX);
                    strY = input.Substring(1);
                    int.TryParse(strY, out y);

                    toReturn = new Coordinate(x, y);
                    break;
                }
                if (toReturn == null)
                {
                }
            }
            return toReturn;
        }


        public static ShipDirection GetShipDirection()
        {
            string letter;
            ConsoleOutput.PromptForDirection();
            letter = Console.ReadLine();
            if (letter == "m")
            {
                ConsoleOutput.DrawBlankBoard();
                ConsoleOutput.PromptForDirection();
                letter = Console.ReadLine();
            }
            switch (letter.ToLower())
            {
                case "l":
                    return ShipDirection.Left;
                case "r":
                    return ShipDirection.Right;
                case "u":
                    return ShipDirection.Up;
                case "d":
                    return ShipDirection.Down;
                default:
                    return ShipDirection.Down;
            }
        }
        
        static int GetNumberFromLetter(string letter)
        {
            int result = -1;
            switch (letter.ToLower())
            {
                case "a":
                    result = 1;
                    break;
                case "b":
                    result = 2;
                    break;
                case "c":
                    result = 3;
                    break;
                case "d":
                    result = 4;
                    break;
                case "e":
                    result = 5;
                    break;
                case "f":
                    result = 6;
                    break;
                case "g":
                    result = 7;
                    break;
                case "h":
                    result = 8;
                    break;
                case "i":
                    result = 9;
                    break;
                case "j":
                    result = 10;
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
