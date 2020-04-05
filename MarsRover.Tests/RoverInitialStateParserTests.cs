using MarsRover;
using NSubstitute;
using System;
using MarsRover.InstructionParsers;
using MarsRover.Models;
using Shouldly;
using Xunit;

namespace MarsRover.Tests
{
    public class RoverInitialStateParserTests
    {
        private RoverInitialStateParser CreateRoverInitialStateParser()
        {
            return new RoverInitialStateParser();
        }

        [Theory]
        [InlineData("1 2 N", 1, 2, Direction.N)]
        [InlineData("3 3 E", 3, 3, Direction.E)]
        public void Parse_Tests(string initialState, int expectedX, int expectedY, Direction expectedDirection)
        {
            // Arrange
            var roverInitialStateParser = CreateRoverInitialStateParser();

            // Act
            var result = roverInitialStateParser.Parse(initialState);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.Direction.ShouldBe(expectedDirection),
                () => result.Position.X.ShouldBe(expectedX),
                () => result.Position.Y.ShouldBe(expectedY));
        }
    }
}
