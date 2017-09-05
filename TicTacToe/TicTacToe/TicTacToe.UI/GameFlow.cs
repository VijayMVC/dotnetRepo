using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.BLL;

namespace TicTacToe.UI
{
	class GameFlow
	{
		//1. create board
		//2. decide who goes first
		//3. place marks until game is over
		internal void Start()
		{
			Board gameBoard = CreateBoard();
			bool isPlayerAsTurn = DecideWhoGoesFirst();

			while( !gameBoard.GameOver )
			{
				PlaceMark( isPlayerAsTurn, gameBoard );
				isPlayerAsTurn = !isPlayerAsTurn;
			}

			ConsoleOutput.DisplayGameResults( gameBoard );
		}

		private void PlaceMark( bool isPlayerAsTurn, Board gameBoard )
		{
			//1. Draw the board
			ConsoleOutput.DrawBoard( gameBoard );

			//2. Prompt user for mark location
			Coord markLocation = ConsoleInput.GetMarkLocation(gameBoard);

			//3. Update the state of the board
			gameBoard.PlaceMark( markLocation );

			//4. redraw board
			ConsoleOutput.DrawBoard( gameBoard );

			Console.ReadLine();
		}

		private bool DecideWhoGoesFirst()
		{
			return RNG.CoinFlip();
		}

		private Board CreateBoard()
		{
			Board toReturn = new Board();
			toReturn.GameOver = false;
			return toReturn;
		}
	}
}
