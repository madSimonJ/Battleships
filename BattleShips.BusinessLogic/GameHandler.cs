using System;
using System.Collections.Generic;
using System.Linq;
using Battleships.Domain;

namespace BattleShips.ConsoleApp
{
	public class GameHandler
	{
	    private readonly Func<char, char, char> _coordGenerator;
	    public GameBoard PlayersBoard { get; private set; }
		public GameBoard ComputersBoard { get; private set; }

		public GameHandler(GameBoard playersBoard, GameBoard computersBoard, Func<char, char, char> coordGenerator)
		{
		    _coordGenerator = coordGenerator;
		    PlayersBoard = playersBoard;
			ComputersBoard = computersBoard;
		}

		public GameTurnStatus TakeTurn(char x, char y)
		{
			var hitSquare = ComputersBoard.Armada.SelectMany(ship => ship.Squares).SingleOrDefault(sqr => sqr.X == x && sqr.Y == y);
			if (hitSquare != null)
				hitSquare.Status = SquareStatus.Hit;

		    var computerHit = (
		            _coordGenerator('a', 'j'),
                    _coordGenerator('0', '9')
		        );
            return new GameTurnStatus
            {
                PlayerHit = hitSquare != null,
                ComputerPlayerShot = computerHit
            };
		}
	}
}
