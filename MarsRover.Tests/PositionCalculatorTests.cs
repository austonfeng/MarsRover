using MarsRover;
using NSubstitute;
using System;
using MarsRover.Calculators;
using MarsRover.Models;
using Shouldly;
using Xunit;

namespace MarsRover.Tests
{
    public class PositionCalculatorTests
    {
        private PositionCalculator CreatePositionCalculator()
        {
            return new PositionCalculator();
        }

        [Theory]
        [InlineData(0, 0, Direction.N, 0, 1)]
        [InlineData(0, 2, Direction.N, 0, 3)]
        [InlineData(0, 9, Direction.N, 0, 9)]

        [InlineData(0, 0, Direction.S, 0, 0)]
        [InlineData(0, 2, Direction.S, 0, 1)]
        [InlineData(0, 9, Direction.S, 0, 8)]

        [InlineData(0, 0, Direction.W, 0, 0)]
        [InlineData(2, 0, Direction.W, 1, 0)]
        [InlineData(4, 0, Direction.W, 3, 0)]

        [InlineData(0, 0, Direction.E, 1, 0)]
        [InlineData(2, 0, Direction.E, 3, 0)]
        [InlineData(4, 0, Direction.E, 4, 0)]
        public void Move_Tests(int x, int y, Direction direction, int expectedX, int expectedY)
        {
            // Arrange
            var positionCalculator = CreatePositionCalculator();
            RoverState currentState = new RoverState
            {
                Direction = direction,
                Position = new Position
                {
                    X = x,
                    Y = y,
                }
            };
            Position maxPosition = new Position
            {
                X = 4,
                Y = 9
            };

            // Act
            var result = positionCalculator.Move(currentState, maxPosition);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.X.ShouldBe(expectedX),
                () => result.Y.ShouldBe(expectedY)
                );
        }
    }
}
