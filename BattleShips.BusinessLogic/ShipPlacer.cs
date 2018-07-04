using System;
using System.Collections.Generic;
using System.Linq;
using Battleships.Domain;

namespace BattleShips.BusinessLogic
{
    public class ShipPlacer
    {
        private readonly Func<char, char, char> _randomCoordSelector;

        public ShipPlacer(Func<char, char, char> randomCoordSelector)
        {
            _randomCoordSelector = randomCoordSelector;
        }

        public GameBoard PlaceHorizontalShipOfLength(GameBoard oldGameBoard, int shipLength)
        {
            return NewGameBoardFromOld(
                oldGameBoard, 
                shipLength, 
                () => (
                    _randomCoordSelector('a', (char)('j' - (shipLength - 1))),
                    _randomCoordSelector('0', '9')
                    )
                ,
                (newX, newY, x) => new Square
            {
                X = (char) (newX + x),
                Y = newY
            });
        }

        public GameBoard PlaceVerticalShipOfLength(GameBoard oldGameBoard, int shipLength)
        {
            return NewGameBoardFromOld(
                oldGameBoard, 
                shipLength, 
                () => (
                    _randomCoordSelector('a', 'j'),
                    _randomCoordSelector('0', (char)('9' - (shipLength - 1)))
                    ),
                (newX, newY, x) => new Square
            {
                X = newX,
                Y = (char) (newY+ x)
            });
        }

        public GameBoard PlaceDiagonallyDownAndRightShipOfLength(GameBoard oldGameBoard, int shipLength)
        {
	        var maxXcoord = (char)('j' - (shipLength - 1));
            var maxYCoord = (char)('9' - (shipLength - 1));

			return NewGameBoardFromOld(
			    oldGameBoard, 
			    shipLength,
			    () =>
                    (
                        _randomCoordSelector('a', maxXcoord),
                        _randomCoordSelector('0', maxYCoord)
                        ),
			    (newX, newY, x) => new Square
            {
                X =(char)(newX + x),
                Y = (char)(newY + x)
            });
        }

	    public GameBoard PlaceDiagonallyDownAndLeftShipOfLength(GameBoard oldGameBoard, int shipLength)
	    {
		    var minXCoord = (char)('a' + (shipLength - 1));
		    var maxYCoord = (char)('9' - (shipLength - 1));

		    return NewGameBoardFromOld(
		        oldGameBoard, 
		        shipLength, 
		        () => (
		            _randomCoordSelector(minXCoord, 'j'),
		            _randomCoordSelector('0', maxYCoord)
                    ),
		        (newX, newY, x) => new Square
		    {
			    X = (char)(newX- x),
			    Y = (char)(newY+ x)
		    });
		}

        private static GameBoard NewGameBoardFromOld(GameBoard oldGameBoard, int shipLength, Func<(char, char)> newCoordGenerator, Func<char, char, int, Square> newSquareGenerator)
        {
            Square[] newSquares()
            {
                (char, char) newCoords = newCoordGenerator();
                return Enumerable.Range(0, shipLength).Select(x => newSquareGenerator(newCoords.Item1, newCoords.Item2, x)).ToArray();
            }

            var allSquares = oldGameBoard.Armada?.Any() ?? false
                ? oldGameBoard.Armada.SelectMany(x => x.Squares).ToArray()
                : new Square[0];

            var newSq = newSquares();

            while (allSquares.Any(x=> newSq.Any(y => x.X == y.X && x.Y == y.Y)))
            {
                newSq = newSquares();
            }

            return new GameBoard
            {
                Armada = new List<Ship>(oldGameBoard?.Armada ?? Enumerable.Empty<Ship>())
                {
                    new Ship
                    {
                        Squares = newSq
                    }
                }
            };
        }
    }
}
