using System;
using System.Collections.Generic;
using System.Linq;
using Battleships.Domain;

namespace BattleShips.BusinessLogic
{
    public class ShipPlacer
    {
        private readonly Func<char, char, char> _randomXCoordSelector;
        private readonly Func<char, char, char> _randomYCoordSelector;

        public ShipPlacer(Func<char, char, char> randomXCoordSelector, Func<char, char, char> randomYCoordSelector)
        {
            _randomXCoordSelector = randomXCoordSelector;
            _randomYCoordSelector = randomYCoordSelector;
        }

        public GameBoard PlaceHorizontalShipOfLength(GameBoard oldGameBoard, int shipLength)
        {
            var randomXCoord = _randomXCoordSelector('a', (char)('j' - (shipLength - 1)));
            var randomYCoord = _randomYCoordSelector('0', '9');

            return NewGameBoardFromOld(oldGameBoard, shipLength, x => new Square
            {
                X = (char) (randomXCoord + x),
                Y = randomYCoord
            });
        }

        public GameBoard PlaceVerticalShipOfLength(GameBoard oldGameBoard, int shipLength)
        {
            var randomXCoord = _randomXCoordSelector('a', 'j');
            var randomYCoord = _randomYCoordSelector('0', (char)('9' - (shipLength - 1)));

            return NewGameBoardFromOld(oldGameBoard, shipLength, x => new Square
            {
                X = randomXCoord,
                Y = (char) (randomYCoord + x)
            });
        }

        public GameBoard PlaceDiagonallyDownAndRightShipOfLength(GameBoard oldGameBoard, int shipLength)
        {
	        var maxXcoord = (char)('j' - (shipLength - 1));
            var randomXCoord = _randomXCoordSelector('a', maxXcoord);
            var maxYCoord = (char)('9' - (shipLength - 1));
	        var randomYCoord = _randomYCoordSelector('0', maxYCoord);

			return NewGameBoardFromOld(oldGameBoard, shipLength, x => new Square
            {
                X =(char)(randomXCoord + x),
                Y = (char)(randomYCoord + x)
            });
        }

	    public GameBoard PlaceDiagonallyDownAndLeftShipOfLength(GameBoard oldGameBoard, int shipLength)
	    {
		    var minXCoord = (char)('a' + (shipLength - 1));
		    var randomXCoord = _randomXCoordSelector(minXCoord, 'j');
		    var maxYCoord = (char)('9' - (shipLength - 1));
		    var randomYCoord = _randomYCoordSelector('0', maxYCoord);

		    return NewGameBoardFromOld(oldGameBoard, shipLength, x => new Square
		    {
			    X = (char)(randomXCoord - x),
			    Y = (char)(randomYCoord + x)
		    });
		}

		private static GameBoard NewGameBoardFromOld(GameBoard oldGameBoard, int shipLength, Func<int, Square> newSquareGenerator) => 
            new GameBoard
            {
                Armada = new List<Ship>(oldGameBoard?.Armada ?? Enumerable.Empty<Ship>())
                {
                    new Ship
                    {
                        Squares =
                            Enumerable.Range(0, shipLength).Select(newSquareGenerator)
                    }
                }
            };
    }
}
