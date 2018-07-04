﻿using System.Linq;
using Battleships.Domain;
using Battleships.Tests;
using BattleShips.BusinessLogic;
using BattleShips.ConsoleApp;
using FluentAssertions;
using Xunit;

namespace GameHandler_Tests__
{
	namespace given_a_new_board_for_the_player_and_the_computer_at_the_beginning_of_a_game
	{
		public class when_the_player_takes_a_turn_that_will_hit
		{
			private readonly GameHandler gameHandler;

			public when_the_player_takes_a_turn_that_will_hit()
			{
				var placer = new ShipPlacer(
						new MockCoordGenerator(
								new [] { 'a', 'b', 'c', 'a', 'b', 'c' },
								new [] {'0', '0', '0', '0', '0', '0' }
							).GenerateCoords
					);

				gameHandler = new GameHandler(
						GameFactory.NewBoard(placer, (min, max) => 1),
						GameFactory.NewBoard(placer, (min, max) => 1)
					);

				gameHandler.TakeTurn('a', '1');
			}

			[Fact]
			public void then_the_ship_that_has_been_hit_should_show_the_damage()
			{
				var hitShip = gameHandler.ComputersBoard.Armada.Single(x => x.Squares.Any(y => y.X == 'a' && y.Y == '1'));
				hitShip.Squares.Single(x => x.X == 'a' && x.Y == '1').Status.Should().Be(SquareStatus.Hit);
			}

			[Fact]
			public void then_no_other_ship_should_be_hit()
			{
				gameHandler.ComputersBoard.Armada
					.SelectMany(x => x.Squares)
					.Where(x => x.X != 'a' && x.Y != '1')
					.All(x => x.Status == SquareStatus.NotHit)
					.Should().BeTrue();
			}
		}
	}
}
