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
                var shipPlacer = new ShipPlacer(x => 'a', x => '1');

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
                var shipPlacer = new ShipPlacer(x => 'a', x => '1');

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


    }
}

