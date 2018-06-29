using System;

namespace Battleships.Domain
{
    public static class GameFactory
    {
	    public static GameBoard NewBoard() => new GameBoard();
    }
}
