using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.BLL;

namespace TicTacToe.UI
{
	static class ConsoleInput
	{
		internal static Coord GetMarkLocation( Board currentState )
		{

			ConsoleOutput.PromptUserForCoordinate();

			string userInput = Console.ReadLine();
			Coord toReturn = null;

			//loop until we have valid user input
			while( !(Coord.TryParse( userInput, out toReturn ) && currentState.IsEmptySqaure( toReturn )))
			{
				ConsoleOutput.PromptUserForCoordinate();
				userInput = Console.ReadLine();
			}

			return toReturn;
		}
	}
}
