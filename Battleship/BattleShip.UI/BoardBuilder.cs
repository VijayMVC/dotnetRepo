using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class BoardBuilder
    {
        public Board BuildBoard(Board boardname)
        {
            boardname = new Board();
            PlaceShipRequest request = new PlaceShipRequest();
            ConsoleOutput.DrawBlankBoard();

            for (ShipType s = ShipType.Destroyer; s <= ShipType.Carrier; s++)
            {
                request.ShipType = s;
                while (true)
                { 
                Console.WriteLine($"Place your {s}, by indicating the starting coordinate.\n Press 'm' at any time to redraw the board");
                request.Coordinate = ConsoleInput.GetCoordinateFromUser();
                request.Direction = ConsoleInput.GetShipDirection();
                var result = boardname.PlaceShip(request);

                    if (result == ShipPlacement.Overlap)
                    {
                        ConsoleOutput.OverlappingShip();
                    }
                    if (result == ShipPlacement.NotEnoughSpace)
                    {
                        ConsoleOutput.NotEnoughSpace();
                    }
                    if (result == ShipPlacement.Ok)
                    {
                        ConsoleOutput.ShipSuccessPlaced();
                        break;
                    }
                }     
            }
            return boardname;            
        }
    }
}
