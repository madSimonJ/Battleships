using Battleships.Domain;

namespace BattleShips.BusinessLogic
{
    public static class GameFactory
    {
	    public static GameBoard NewBoard(ShipPlacer placer)
	    {
	        var emptyBoard = placer.PlaceVerticalShipOfLength(new GameBoard(), 4);
	        var boardWithOne = placer.PlaceVerticalShipOfLength(emptyBoard, 4);
	        return placer.PlaceVerticalShipOfLength(boardWithOne, 3);
	    }
    }
}
