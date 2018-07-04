using System;
using System.Collections.Generic;
using System.Linq;
using Battleships.Domain;

namespace BattleShips.ConsoleApp
{
	public class GameHandler
	{
		public GameBoard PlayersBoard { get; private set; }
		public GameBoard ComputersBoard { get; private set; }

		public GameHandler(GameBoard playersBoard, GameBoard computersBoard)
		{
			PlayersBoard = playersBoard;
			ComputersBoard = computersBoard;
		}

		public void TakeTurn(char x, char y)
		{
			var hitSquare = ComputersBoard.Armada.SelectMany(ship => ship.Squares).SingleOrDefault(sqr => sqr.X == x && sqr.Y == y);
			if (hitSquare != null)
				hitSquare.Status = SquareStatus.Hit;

			//if (!ComputersBoard.Armada.SelectMany(ship => ship.Squares).Any(sqr => sqr.X == x && sqr.Y == y)) return;

			//var shipsNotHit = ComputersBoard.Armada.Where(ship => !ship.Squares.Any(sqr => sqr.X == x && sqr.Y == y));
			//var newComputerArmada = new List<Ship>();
			//newComputerArmada.AddRange(shipsNotHit);

			//var shipHit = ComputersBoard.Armada.Single(ship => ship.Squares.Any(sqr => sqr.X == x && sqr.Y == y));
			//shipHit.Squares.Single(sqr => sqr.X == x && sqr.Y == y).Status = SquareStatus.Hit;

			//newComputerArmada.Add(shipHit);

			//ComputersBoard = new GameBoard
			//{
			//	Armada = newComputerArmada
			//};
		}
	}
}
