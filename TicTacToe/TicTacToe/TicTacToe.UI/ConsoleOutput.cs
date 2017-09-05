using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.BLL;

namespace TicTacToe.UI
{
	static class ConsoleOutput
	{
		internal static void DisplayGameResults( Board gameBoard )
		{
			throw new NotImplementedException();
		}

		internal static void PromptUserForCoordinate()
		{
			Console.Write( "Please enter a coordinate for your move: " );
		}

		internal static void DrawBoard( Board gameBoard )
		{
			for( int y = 0; y < 3; y++ )
			{
				for( int x = 0; x < 3; x++ )
				{
					SquareState currentState = gameBoard.GetSquare( x, y );
					switch( currentState )
					{
						case SquareState.Unmarked:
							Console.Write( " " );
							break;
						case SquareState.O:
							Console.Write( "O" );
							break;
						case SquareState.X:
							Console.Write( "X" );
							break;
					}
					Console.Write( "|" );
				}
				Console.WriteLine();
				Console.WriteLine( "------" );
			}
		}
	}
}
