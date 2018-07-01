using Battleships.Domain;

namespace BattleShips.BusinessLogic
{
    public static class GameFactory
    {
	    public static GameBoard NewBoard() => new GameBoard();

    }
}
