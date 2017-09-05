using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.BLL
{
	public class Coord
	{
		public int X { get; }
		public int Y { get; }

		public Coord( int x, int y )
		{
			X = x;
			Y = y;
		}

		public static bool TryParse( string userInput, out Coord coordinate )
		{
			bool toReturn = false;
			coordinate = null;

			string[] pieces = userInput.Split( ',' );

			if( pieces.Length == 2 )
			{
				int x = -1;
				int y = -1;

				if( int.TryParse( pieces[ 0 ], out x ) && int.TryParse( pieces[ 1 ], out y ) )
				{
					if( x >= 0 && x < 3 && y >= 0 && y < 3 )
					{
						coordinate = new Coord( x, y );
						toReturn = true;
					}
				}
			}

			return toReturn;
		}
	}
}
