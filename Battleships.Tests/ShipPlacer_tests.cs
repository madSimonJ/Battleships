using System;
using System.Linq;
using Battleships.Domain;
using Battleships.Tests;
using BattleShips.BusinessLogic;
using FluentAssertions;
using Xunit;

namespace ShipPlacer_Tests__
{
    namespace given_a_game_board_with_no_ships_already_placed_on_it
    {
        public class when_placing_a_ship_of_length_four_horizontally
        {
            private readonly GameBoard board;
            public when_placing_a_ship_of_length_four_horizontally()
            {
	            var mockCoordsPlacer = new MockCoordGenerator(new[] {'a'}, new[] {'1'});
                var shipPlacer = new ShipPlacer(mockCoordsPlacer.GenerateCoords);

                board = shipPlacer.PlaceHorizontalShipOfLength(new GameBoard(), 4);
            }

            [Fact]
            public void then_a_ship_of_length_four_is_added_to_the_board()
            {
                board.Armada.First().Squares.Should().HaveCount(4);
            }

            [Fact]
            public void then_the_ship_should_be_placed_with_all_squares_on_the_same_row()
            {
                var firstY = board.Armada.First().Squares.First().Y;
                board.Armada.First().Squares.Select(x => x.Y).All(x => x == firstY).Should().BeTrue();
            }

            [Fact]
            public void then_the_ship_should_be_placed_on_four_consecutive_squares()
            {
                var squares = board.Armada.First().Squares.ToArray();
                squares[1].X.Should().Be((char)(squares[0].X + 1));
                squares[2].X.Should().Be((char)(squares[0].X + 2));
                squares[3].X.Should().Be((char)(squares[0].X + 3));
            }

            [Fact]
            public void then_the_x_cooedinate_should_be_between_a_and_j()
            {
                var squares = board.Armada.First().Squares;
                squares.Select(x => x.X).All(x => x >= 'a' && x <= 'j').Should().BeTrue();
            }

            [Fact]
            public void then_the_y_coordinate_should_be_between_0_and_9()
            {
                var squares = board.Armada.First().Squares;
                squares.Select(x => x.Y).All(x => x >= '0' && x <= '9').Should().BeTrue();
            }
        }

        public class when_placing_a_ship_of_length_four_vertically
        {
            private readonly GameBoard board;
            public when_placing_a_ship_of_length_four_vertically()
            {
	            var mockCoordsPlacer = new MockCoordGenerator(new[] { 'a' }, new[] { '1' });
	            var shipPlacer = new ShipPlacer(mockCoordsPlacer.GenerateCoords);

				board = shipPlacer.PlaceVerticalShipOfLength(new GameBoard(), 4);
            }

            [Fact]
            public void then_a_ship_of_length_four_is_added_to_the_board()
            {
                board.Armada.First().Squares.Should().HaveCount(4);
            }

            [Fact]
            public void then_the_ship_should_be_placed_with_all_squares_on_the_same_column()
            {
                var firstX = board.Armada.First().Squares.First().X;
                board.Armada.First().Squares.Select(x => x.X).All(x => x == firstX).Should().BeTrue();
            }

            [Fact]
            public void then_the_ship_should_be_placed_on_four_consecutive_squares_going_down()
            {
                var squares = board.Armada.First().Squares.ToArray();
                squares[1].Y.Should().Be((char)(squares[0].Y + 1));
                squares[2].Y.Should().Be((char)(squares[0].Y + 2));
                squares[3].Y.Should().Be((char)(squares[0].Y + 3));
            }

            [Fact]
            public void then_the_x_coordinate_should_be_between_a_and_j()
            {
                var squares = board.Armada.First().Squares;
                squares.Select(x => x.X).All(x => x >= 'a' && x <= 'j').Should().BeTrue();
            }

            [Fact]
            public void then_the_y_coordinate_should_be_between_0_and_9()
            {
                var squares = board.Armada.First().Squares;
                squares.Select(x => x.Y).All(x => x >= '0' && x <= '9').Should().BeTrue();
            }
        }

        public class when_placing_a_ship_of_length_four_diagonally_down_and_right
        {
            private readonly GameBoard board;
	        private readonly MockCoordGenerator mockCoordsPlacer;
			public when_placing_a_ship_of_length_four_diagonally_down_and_right()
            {
	            mockCoordsPlacer = new MockCoordGenerator(new[] { 'a' }, new[] { '1' });
	            var shipPlacer = new ShipPlacer(mockCoordsPlacer.GenerateCoords);

				board = shipPlacer.PlaceDiagonallyDownAndRightShipOfLength(new GameBoard(), 4);
            }

            [Fact]
            public void then_a_ship_of_length_four_is_added_to_the_board()
            {
                board.Armada.First().Squares.Should().HaveCount(4);
            }

            [Fact]
            public void then_the_x_coords_of_the_ship_should_increase_by_one_each_time()
            {
                var squares = board.Armada.First().Squares.ToArray();
                squares[1].X.Should().Be((char)(squares[0].X + 1));
                squares[2].X.Should().Be((char)(squares[0].X + 2));
                squares[3].X.Should().Be((char)(squares[0].X + 3));
            }

            [Fact]
            public void then_the_y_coords_of_the_ship_should_increase_by_one_each_time()
            {
                var squares = board.Armada.First().Squares.ToArray();
                squares[1].Y.Should().Be((char)(squares[0].Y + 1));
                squares[2].Y.Should().Be((char)(squares[0].Y + 2));
                squares[3].Y.Should().Be((char)(squares[0].Y + 3));
            }

	        [Fact]
	        public void then_the_last_three_columns_should_not_be_selected()
	        {
		        mockCoordsPlacer.MinMaxParams.Single(Helper.IsXCoord).max.Should().Be('g');
	        }

	        [Fact]
	        public void then_the_last_three_Rows_should_not_be_selected()
	        {
		        mockCoordsPlacer.MinMaxParams.Single(Helper.IsYCoord).max.Should().Be('6');
	        }


        }

		public class when_placing_a_ship_of_length_four_diagonally_down_and_left
		{
			private readonly GameBoard board;
			private char minXCoord;
			private char maxYCoord;
			private MockCoordGenerator mockCoordsPlacer;
			public when_placing_a_ship_of_length_four_diagonally_down_and_left()
			{
				mockCoordsPlacer = new MockCoordGenerator(new[] { 'j' }, new[] { '1' });
				var shipPlacer = new ShipPlacer(mockCoordsPlacer.GenerateCoords);

				board = shipPlacer.PlaceDiagonallyDownAndLeftShipOfLength(new GameBoard(), 4);
			}

			[Fact]
			public void then_a_ship_of_length_four_is_added_to_the_board()
			{
				board.Armada.First().Squares.Should().HaveCount(4);
			}

			[Fact]
			public void then_the_x_coords_of_the_ship_should_increase_by_one_each_time()
			{
				var squares = board.Armada.First().Squares.ToArray();
				squares[1].X.Should().Be((char)(squares[0].X - 1));
				squares[2].X.Should().Be((char)(squares[0].X - 2));
				squares[3].X.Should().Be((char)(squares[0].X - 3));
			}

			[Fact]
			public void then_the_y_coords_of_the_ship_should_increase_by_one_each_time()
			{
				var squares = board.Armada.First().Squares.ToArray();
				squares[1].Y.Should().Be((char)(squares[0].Y + 1));
				squares[2].Y.Should().Be((char)(squares[0].Y + 2));
				squares[3].Y.Should().Be((char)(squares[0].Y + 3));
			}

			[Fact]
			public void then_the_first_three_columns_should_not_be_selected()
			{
				mockCoordsPlacer.MinMaxParams.Single(Helper.IsXCoord).min.Should().Be('d');
			}

			[Fact]
			public void then_the_last_three_Rows_should_not_be_selected()
			{
				mockCoordsPlacer.MinMaxParams.Single(Helper.IsYCoord).max.Should().Be('6');
			}


		}

		namespace and_a_ship_is_to_be_placed_at_the_end_of_a_row
        {
            public class when_placing_a_ship_horizontally
			{
                private readonly GameBoard board;
                public when_placing_a_ship_horizontally()
                {
	                var mockCoordsPlacer = new MockCoordGenerator(new[] { 'g' }, new[] { '1' });
	                var shipPlacer = new ShipPlacer(mockCoordsPlacer.GenerateCoords);

					board = shipPlacer.PlaceHorizontalShipOfLength(new GameBoard(), 4);
                }

                [Fact]
                public void then_a_ship_of_length_four_is_added_to_the_board()
                {
                    board.Armada.First().Squares.Last().X.Should().Be('j');
                }
            }
        }

        namespace and_a_ship_is_to_be_placed_at_the_end_of_a_column
        {
            public class when_placing_a_ship_vertically
			{
                private readonly GameBoard board;
                public when_placing_a_ship_vertically()
                {
	                var mockCoordsPlacer = new MockCoordGenerator(new[] { 'g' }, new[] { '6' });
	                var shipPlacer = new ShipPlacer(mockCoordsPlacer.GenerateCoords);

					board = shipPlacer.PlaceVerticalShipOfLength(new GameBoard(), 4);
                }

                [Fact]
                public void then_a_ship_of_length_four_is_added_to_the_board()
                {
                    board.Armada.First().Squares.Last().Y.Should().Be('9');
                }
            }
        }
	}

	namespace given_a_game_board_with_a_ship_already_placed_on_it
	{
		public class when_attempting_to_place_a_ship_on_the_same_location
		{
			private readonly GameBoard board;
			private readonly MockCoordGenerator mockCoordGenerator;
			public when_attempting_to_place_a_ship_on_the_same_location()
			{
				mockCoordGenerator = new MockCoordGenerator(new[] { 'b', 'd', 'g' }, new[] { '2', '1', '0' });
				var shipPlacer = new ShipPlacer(mockCoordGenerator.GenerateCoords);

				board = shipPlacer.PlaceHorizontalShipOfLength(new GameBoard(), 4);
				board = shipPlacer.PlaceVerticalShipOfLength(board, 4);
			}

			[Fact]
			public void then_a_new_location_for_the_second_ship_should_be_requested()
			{
				mockCoordGenerator.XCoordCount.Should().Be(3);
				mockCoordGenerator.YCoordCount.Should().Be(3);
			}
		}
	}
}

