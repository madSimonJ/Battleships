using System;
using System.Linq;
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

			[Fact]
			public void then_the_board_should_have_two_ships_length_4_and_1_ship_length_3()
			{
				gameBoard.Armada.Where(x => x.Squares.Count() == 4).Should().HaveCount(2);
				gameBoard.Armada.Where(x => x.Squares.Count() == 3).Should().HaveCount(1);
			}

			[Fact]
			public void then_no_two_ships_should_be_on_the_same_square()
			{
				gameBoard.Armada.SelectMany(x => x.Squares).Should().OnlyHaveUniqueItems();
			}
		}
	}
}
