using MarsRover.Calculators;
using MarsRover.Models;
using Shouldly;
using Xunit;

namespace MarsRover.Tests
{
    public class RoverStateCalculator_Integration_Tests
    {
        private RoverStateCalculator CreateService()
        {
            return new RoverStateCalculator(new DirectionCalculator(), new PositionCalculator());
        }

        [Theory]
        [InlineData(0, 0, Direction.N, Action.LeftTurn, 0, 0, Direction.W)]
        [InlineData(0, 0, Direction.N, Action.Move, 0, 1, Direction.N)]
        [InlineData(0, 0, Direction.E, Action.Move, 1, 0, Direction.E)]
        [InlineData(4, 5, Direction.N, Action.Move, 4, 5, Direction.N)]
        [InlineData(4, 5, Direction.E, Action.Move, 4, 5, Direction.E)]
        public void Action_Tests(int x, int y, Direction direction, Action action, int expectedX, int expectedY, Direction expectedDirection)
        {
            // Arrange
            var service = CreateService();
            var currentState = new RoverState
            {
                Position = new Position
                {
                    X = x,
                    Y = y
                },
                Direction = direction
            };

            // Act
            var result = service.Action(currentState, new Position
            {
                X = 4,
                Y = 5
            }, action);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.Direction.ShouldBe(expectedDirection),
                () => result.Position.X.ShouldBe(expectedX),
                () => result.Position.Y.ShouldBe(expectedY)
            );
        }
    }
}
