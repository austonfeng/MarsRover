using MarsRover;
using NSubstitute;
using System;
using System.Linq;
using MarsRover.InstructionParsers;
using Shouldly;
using Xunit;

namespace MarsRover.Tests
{
    public class RoverActionParserTests
    {

        private RoverActionParser CreateRoverActionParser()
        {
            return new RoverActionParser();
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("LMLMLMLMM", "LeftTurn,Move,LeftTurn,Move,LeftTurn,Move,LeftTurn,Move,Move")]
        [InlineData("MMRMMRMRRM", "Move,Move,RightTurn,Move,Move,RightTurn,Move,RightTurn,RightTurn,Move")]
        public void Parse_Tests(string actions, string expectedActions)
        {
            // Arrange
            var roverActionParser = CreateRoverActionParser();

            // Act
            var result = roverActionParser.Parse(actions);

            // Assert
            string.Join(",", result).ShouldBe(expectedActions);
        }
        [Theory]
        [InlineData("KLM")]
        [InlineData("MRLS")]
        public void Parse__When_invlid_input___Throw_Exceptio(string actions)
        {
            // Arrange
            var roverActionParser = CreateRoverActionParser();

            // Act
              Should.Throw<ArgumentException>(()=>roverActionParser.Parse(actions).ToArray());
        }
    }
}
