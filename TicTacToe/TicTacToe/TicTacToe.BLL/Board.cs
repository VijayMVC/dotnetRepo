using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.BLL
{
	public class Board
	{
		public bool GameOver { get; set; }
		public bool IsXTurn { get; private set; } = true;

		SquareState [,] _squares = new SquareState[3,3];




		public Board()
		{
			for( int y = 0; y < 3; y++ )
			{
				for( int x = 0; x < 3; x++ )
				{
					_squares[ x, y ] = SquareState.Unmarked;
				}
			}
		}

		public void PlaceMark( Coord loc )
		{
			_squares[ loc.X, loc.Y ] = IsXTurn ? SquareState.X : SquareState.O;

			//CheckIfGameOver();

			bool boardFilled = true;

			for( int x = 0; boardFilled && x < 3; x++ )
			{
				for( int y = 0; boardFilled && y < 3; y++ )
				{
					if( _squares[ x, y ] == SquareState.Unmarked )
					{
						boardFilled = false;
					}
				}
			}

			if( boardFilled )
			{
				GameOver = true;
			}

			bool rowSame = true;
			bool colSame = true;

			if( !boardFilled )
			{
				for( int y = 0; y < 3; y++ )
				{
					bool rowAllSame = true;
					for( int x = 0; x < 3; x++ )
					{
						if( _squares[ x, y ] != _squares[ loc.X, loc.Y ] )
						{
							rowAllSame = false;
							break;
						}
					}

					if( rowAllSame )
					{
						GameOver = true;
						break;
					}
				}


				for( int x = 0; x < 3; x++ )
				{
					bool colAllSame = true;
					for( int y = 0; y < 3; y++ )
					{
						if( _squares[ x, y ] != _squares[ loc.X, loc.Y ] )
						{
							colAllSame = false;
							break;
						}
					}

					if( colAllSame )
					{
						GameOver = true;
						break;
					}
				}

				bool diagonalSame = true;
				bool otherDiagonalSame = true;
				for( int i = 0; i < 3; i++ )
				{
					if( _squares[ i, 2-i ] != _squares[ loc.X, loc.Y ] )
					{
						diagonalSame = false;
					}
					if( _squares[ i, i ] != _squares[ loc.X, loc.Y ] )
					{
						otherDiagonalSame = false;
					}
				}
				if( diagonalSame || otherDiagonalSame )
				{
					GameOver = true;
				}


			}


			IsXTurn = !IsXTurn;
		}

		public bool IsEmptySqaure( Coord toReturn )
		{
			return _squares[ toReturn.X, toReturn.Y ] == SquareState.Unmarked;
		}

		public SquareState GetSquare( int x, int y )
		{
			return _squares[ x, y ];
		}
	}
}
