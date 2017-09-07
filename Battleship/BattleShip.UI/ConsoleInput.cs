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
    public class ConsoleInput
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
                string input = Console.ReadLine(); 
                if (input == "m")
                {
                    ConsoleOutput.DrawBlankBoard();
                    ConsoleOutput.PromptforCoordinate();
                    input = Console.ReadLine();
                }
                bool isValidCoordinate = TryParseCoordinate(input, out toReturn);
                if(isValidCoordinate)
                {
                    break;
                }
                
            }
            return toReturn;
        }

        public static bool TryParseCoordinate(string input, out Coordinate toReturn)
        {
            input = input.Replace(",","");
            if (input == "")
            {
                toReturn = null;
                return false;
            }

            String strX, strY; int x, y;
            strY = input.Substring(1);
            strX = input.Substring(0, 1);
            x = GetNumberFromLetter(strX);
            
            if (int.TryParse(strY, out y) == true && x > 0 && x < 11)
            {
                if (y > 0 && y < 11)
                {
                    toReturn = new Coordinate(x, y);
                    return true;
                }
            }
            toReturn = null;
            return false;
        }

        public static ShipDirection GetShipDirection()
        {
            string toReturn;
            while (true)
            {
                ConsoleOutput.PromptForDirection();
                string letter = Console.ReadLine();

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
                        break;
                }
                bool ValidateDirection = isValidDirection(letter, out toReturn);
                if (ValidateDirection)
                {
                    break;
                }
            }
            return ShipDirection.Down;
        }

        public static bool isValidDirection(string direction, out String toReturn)
        {
            string letter = direction;
            if (letter == "l" || letter == "L" || letter == "r" || letter == "R" || letter == "u" || letter == "U" || letter == "d" || letter == "D" || letter == "m")
            {
                toReturn = letter;
                return true;
            }
            toReturn = null;
            return false;
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
