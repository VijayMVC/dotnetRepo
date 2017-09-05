using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            int theAnswer;
            int playerGuess;
            string playerInput;
            int count = 0;
            string difficulty;
            int difLevel;
            int topRange;

            Random r = new Random();
            theAnswer = r.Next(1, 21);
            // get player input
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nWelcome to the Guessing Game! You win if you can guess the number I am thinking of!\nPlease enter your name to begin: ");
            name = Console.ReadLine();
            Console.Write($"\n Hi {name}, press 'Q' at any time to quit" +
                    $"\n Please select your difficulty level then press enter" +
                    $"\n Easy: Press 1" +//range 1-5
                    $"\n Medium: Press 2" +//range 1-20
                    $"\n Hard: Press 3 \n");//range 1-50
                difficulty = Console.ReadLine();
            do
            {
                if (int.TryParse(difficulty, out difLevel))
                {
                    if ((difLevel < 1) || (difLevel > 3)) 
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{name}, you did not select a valid difficulty level." +
                        $"\n Easy: Press 1" +//range 1-5
                        $"\n Medium: Press 2" +//range 1-20
                        $"\n Hard: Press 3 \n");//range 1-50
                        difficulty = Console.ReadLine();
                    }
                    else if (difLevel == 1)
                    {
                        topRange = 5;
                        theAnswer = r.Next(1, 6);
                        break;
                    }
                    else if (difLevel == 2)
                    {
                        topRange = 20;
                        theAnswer = r.Next(1, 21);
                        break;
                    }
                    else if (difLevel == 3)
                    {
                        topRange = 50;
                        theAnswer = r.Next(1, 51);
                        break;
                    }
                }
                else
                    Console.WriteLine("that is not a valid difficulty level");
            } while (true);
       


            do
            {
                // get player input
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"\n Total guess attempts:{count}\n enter your guess (1-{topRange}): ");
                playerInput = Console.ReadLine();
                count++;

                //attempt to convert the string to a number
                if (int.TryParse(playerInput, out playerGuess))
                {
                    if (playerGuess < 1 || playerGuess > topRange)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Please enter a number between 1 and {topRange}! ");
                    }
                    else if (playerGuess == theAnswer && count == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{name}, you ACED it on your first guess! You are the official Guessing Game master!");
                        break;
                    }
                    else if (playerGuess == theAnswer)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{theAnswer} was the number. {name}, you Win!");
                        break;
                    }
                    else
                    {

                        if (playerGuess > theAnswer)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Your guess was too High!");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Your guess was too low!");
                        }
                    }
                }
                else if (playerInput == "Q" || playerInput == "q")
                {
                    return;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"That wasn't a number {name}!");
                }

            } while (true);

            Console.WriteLine("Press any key to quit.");
            Console.ReadKey();
        }
    }
}
