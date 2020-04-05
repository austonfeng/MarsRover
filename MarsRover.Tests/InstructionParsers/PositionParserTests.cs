using MarsRover.InstructionParsers;
using NSubstitute;
using System;
using Shouldly;
using Xunit;

namespace MarsRover.Tests.InstructionParsers
{
    public class PositionParserTests
    {
        private PositionParser CreatePositionParser()
        {
            return new PositionParser();
        }

        [Theory]
        [InlineData("3 5", 3, 5)]
        [InlineData("6 8", 6, 8)]
        public void ParsePlateauMaxPosition_Tests(string position, int expectedX, int expectedY)
        {
            // Arrange
            var positionParser = CreatePositionParser();

            // Act
            var result = positionParser.ParsePlateauMaxPosition(position);

            // Assert
            result.X.ShouldBe(expectedX);
            result.Y.ShouldBe(expectedY);
        }
    }
}
