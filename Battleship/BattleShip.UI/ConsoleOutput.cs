using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    public class ConsoleOutput
    {
        internal static void DisplayTitle()
        {
            Console.Clear();
            string str = ("**************************************");
            Console.WriteLine("\n\n\n");
            Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("**************************************");
            Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("**************BATTLESHIP**************");
            Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("**************************************\n\n");
            Console.ResetColor();
            Console.WriteLine("Welcome to Battleship! Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        internal static void PromptPlayerTurn(Player name)
        {
            var Name = name.Name;
            Console.WriteLine($"{Name}, It is your turn, enter coordinates you would like to fire your shot at: ");
        }

        internal static void Miss(string player)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{player}, you missed!");
            Console.ResetColor();
            Console.WriteLine("press any key to continue...");
            Console.ReadKey();            
        }

        internal static void Hit(string player)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Nice shot {player}, that's a hit!");
            Console.ResetColor();
            Console.WriteLine("press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        internal static void PromptP2Name()
        {
            Console.Clear();
            Console.WriteLine("Player Two please enter your name:  ");
        }

        internal static void HitAndSunk(string attacker, string receiver, string ship)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{attacker}, you sunk {receiver}'s {ship}!");
            Console.ResetColor();
            Console.WriteLine("press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        internal static void PlayAgain()
        {
            Console.WriteLine("Would you like to play again? y or n");
        }

        internal static void PromptforCoordinate()
        {
        
            Console.WriteLine("Please enter a coordinate (example: a1 is the top left corner of the board):  ");
        }

        internal static void Duplicate(string player)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{player}, you already shot there, try again");
            Console.ResetColor();
        }

        internal static void InvalidShot(string player)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{player}, that shot was off the grid, try again!");
            Console.ResetColor();
        }

        internal static void OverlappingShip()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("The ship you have attempted to place is overlapping another ship");
            Console.ResetColor();
        }

        internal static void PromptP1Name()
        {
            Console.Clear();
            Console.WriteLine("Player One please enter your name:  ");
        }

        internal static void PlaceYourShips(string Name)
        {
            string input = Name;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Name}, It's time to place your battle ships!");
            Console.ResetColor();
        }

        internal static void NotEnoughSpace()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("The ship you have attempted to place is off the board");
            Console.ResetColor();
        }

        internal static void ShipSuccessPlaced()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ship placed successfully");
            Console.ResetColor();
        }

        internal static void DrawBlankBoard()
        {
            string Letters = "ABCDEFGHIJ";
            Console.WriteLine("Key: Destroyer = 2 slots __ Submarine = 3 slots __ Cruiser = 3 slots " +
                                "\n   Battleship = 4 slots __ Carrier = 5 slots");
            Console.Write("    ");
            for (int x = 1; x < 11; x++)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("  " + x.ToString() + " ");
                Console.ResetColor();
            }

            Console.WriteLine("");

            for (int y = 0; y < 10; y++)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("  " + Letters.Substring(y, 1) + " ");
                Console.ResetColor();

                for (int x = 0; x < 11; x++)
                {
                    Console.Write("|   ");
                    
                }

                Console.WriteLine();
                Console.WriteLine("----------------------------------------------");
            }

        }

        internal static void DrawActiveBoard(Board Active)
        {
            Console.Clear();
            int yOffset;
            string Letters = "xABCDEFGHIJ";
            Console.Write("     ");
            for (int i = 0; i < 10; i++)
            {
                yOffset = i + 1;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("   " + yOffset.ToString());
                Console.ResetColor();
            }

            Console.WriteLine("");

            for (int x = 1; x < 11; x++)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("  " + Letters.Substring(x, 1));
                Console.ResetColor();

                for (int y = 0; y < 11; y++)
                {
                    ShotHistory currentState;
                    Coordinate input = new Coordinate(x,y);
                    currentState = Active.CheckCoordinate(input); 
                    switch (currentState)
                    {
                        case ShotHistory.Hit:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" H ");
                            Console.ResetColor();
                            break;
                        case ShotHistory.Miss:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(" M ");
                            Console.ResetColor();
                            break;
                        case ShotHistory.Unknown:
                            Console.Write("   ");
                            break;
                    }
                    Console.Write("|");
                }

                Console.WriteLine();
                Console.WriteLine("----------------------------------------------");
            }

        }

        internal static void PromptForDirection()
        {
            Console.WriteLine("Please enter the direction you would like to place your ship (u, d, l, r):  ");
        }

        internal static void DeclareVictory(string name1, string name2)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n\n\n                  Congratulations {name1}!!!\n" +
                              $"        You have destroyed all of {name2}'s battle ships\n" +
                              $"                     You are victorious!\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("                       $$$$$$$$$$$$$$$$\n" +
                              "                       $$$$$$$$$$$$$$$$\n" +
                              "                        $$$$$$$$$$$$$$\n" +
                              "                           $$$$$$$$\n" +
                              "                             $$$$\n" +
                              "                              $$\n" +
                              "                              $$\n" +
                              "                            $$$$$$\n");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
