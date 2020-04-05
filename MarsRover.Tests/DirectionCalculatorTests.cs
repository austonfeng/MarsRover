using MarsRover;
using NSubstitute;
using System;
using MarsRover.Calculators;
using MarsRover.Models;
using Shouldly;
using Xunit;
using Action = MarsRover.Models.Action;

namespace MarsRover.Tests
{
    public class DirectionCalculatorTests
    {
        private DirectionCalculator CreateService()
        {
            return new DirectionCalculator();
        }

        [Theory]
        [InlineData(Direction.W, Action.Move, Direction.W)]
        [InlineData(Direction.N, Action.Move, Direction.N)]
        [InlineData(Direction.S, Action.Move, Direction.S)]
        [InlineData(Direction.E, Action.Move, Direction.E)]

        [InlineData(Direction.W, Action.LeftTurn, Direction.S)]
        [InlineData(Direction.N, Action.LeftTurn, Direction.W)]
        [InlineData(Direction.S, Action.LeftTurn, Direction.E)]
        [InlineData(Direction.E, Action.LeftTurn, Direction.N)]

        [InlineData(Direction.W, Action.RightTurn, Direction.N)]
        [InlineData(Direction.N, Action.RightTurn, Direction.E)]
        [InlineData(Direction.S, Action.RightTurn, Direction.W)]
        [InlineData(Direction.E, Action.RightTurn, Direction.S)]
        public void Turn_Tests(Direction currentDirection, Action action, Direction expectedDirection)
        {
            // Arrange
            var service = CreateService();

            // Act
            var result = service.Turn(currentDirection, action);

            // Assert
            result.ShouldBe(expectedDirection);
        }
    }
}
