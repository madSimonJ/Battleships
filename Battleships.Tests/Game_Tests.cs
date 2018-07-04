using System;
using Battleships.Domain;
using BattleShips.BusinessLogic;
using FluentAssertions;
using Xunit;

namespace GameTests__
{
	namespace given_a_request_for_a_new_game
	{
		public class when_setting_up_the_board
		{
			private readonly GameBoard gameBoard;
			public when_setting_up_the_board()
			{
				gameBoard = GameFactory.NewBoard(new ShipPlacer((min, max) => (char)new Random().Next(min, max)));
			}

			[Fact]
			public void then_the_board_should_have_an_armada()
			{
				gameBoard.Armada.Should().HaveCount(3);
			}
		}
	}
}
