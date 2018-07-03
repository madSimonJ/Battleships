using System;
using System.Linq;
using Battleships.Domain;
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
                var shipPlacer = new ShipPlacer((x, y) => 'a', (x, y) => '1');

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
                var shipPlacer = new ShipPlacer((x, y) => 'a', (x, y) => '1');

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
	        private char maxXCoord;
	        private char maxYCoord;
            public when_placing_a_ship_of_length_four_diagonally_down_and_right()
            {
                var shipPlacer = new ShipPlacer((min, max) =>
                {
	                maxXCoord = max;
	                return 'a';
                }, (min, max) =>
                {
	                maxYCoord = max;
	                return '1';
                });

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
		        maxXCoord.Should().Be('g');
	        }

	        [Fact]
	        public void then_the_last_three_Rows_should_not_be_selected()
	        {
		        maxYCoord.Should().Be('6');
	        }


        }

		public class when_placing_a_ship_of_length_four_diagonally_down_and_left
		{
			private readonly GameBoard board;
			private char minXCoord;
			private char maxYCoord;
			public when_placing_a_ship_of_length_four_diagonally_down_and_left()
			{
				var shipPlacer = new ShipPlacer((min, max) =>
				{
					minXCoord = min;
					return 'j';
				}, (min, max) =>
				{
					maxYCoord = max;
					return '1';
				});

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
				minXCoord.Should().Be('d');
			}

			[Fact]
			public void then_the_last_three_Rows_should_not_be_selected()
			{
				maxYCoord.Should().Be('6');
			}


		}

		namespace and_a_ship_is_to_be_placed_at_the_end_of_a_row
        {
            public class when_placing_a_ship_horizontally
			{
                private readonly GameBoard board;
                public when_placing_a_ship_horizontally()
                {
                    var shipPlacer = new ShipPlacer((x, y) => 'g', (x, y) => '1');

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
                    var shipPlacer = new ShipPlacer((x, y) => '1', (x, y) => '6');

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
			int _xCallCount = 0;
			int _yCallCount = 0;

			public when_attempting_to_place_a_ship_on_the_same_location()
			{
				var shipPlacer = new ShipPlacer((x, y) =>
				{
					_xCallCount++;
					switch (_xCallCount)
					{
						case 1:
							return 'b';
						case 2:
							return 'd';
						case 3:
							return 'g';
						default:
							throw new Exception();
					}
				}, (x, y) =>
				{
					_yCallCount++;
					switch (_yCallCount)
					{
						case 1:
							return '2';
						case 2:
							return '1';
						case 3:
							return '0';
						default:
							throw new Exception();
					}
				});

				board = shipPlacer.PlaceHorizontalShipOfLength(new GameBoard(), 4);
				board = shipPlacer.PlaceVerticalShipOfLength(board, 4);
			}

			[Fact]
			public void then_a_new_location_for_the_second_ship_should_be_requested()
			{
				_xCallCount.Should().Be(3);
				_yCallCount.Should().Be(3);
			}
		}
	}
}

