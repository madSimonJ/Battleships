using System;
using Battleships.Domain;

namespace BattleShips.BusinessLogic
{
    public static class GameFactory
    {
	    public static GameBoard NewBoard(ShipPlacer placer, Func<int, int, int> randomNumberGenerator)
	    {
		    var boardWithOne = placer.PlaceShipOfLength(new GameBoard(), 4, () => IntToShipDirection(randomNumberGenerator(0, 4)));
			var boardWithTwo = placer.PlaceShipOfLength(boardWithOne, 4, () => IntToShipDirection(randomNumberGenerator(0, 4)));
			return placer.PlaceShipOfLength(boardWithTwo, 3, () => IntToShipDirection(randomNumberGenerator(0, 4)));
		}

	    private static ShipDirection IntToShipDirection(int randomNum)
	    {
		    switch (randomNum)
		    {
				case 0:
					return ShipDirection.Horizontal;
				case 1:
					return ShipDirection.Vertical;
				case 2:
					return ShipDirection.DiagonallyDownAndLeft;
				case 3:
					return ShipDirection.DiagonallyDownAndRight;
				default:
					throw new ArgumentOutOfRangeException();
		    }
	    }
    }
}
