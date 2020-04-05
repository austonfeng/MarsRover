using System.Linq;
using MarsRover.InstructionParsers;
using MarsRover.Models;
using Shouldly;
using Xunit;

namespace MarsRover.Tests
{
    public class InstructionParserTests
    {

        private InstructionParser CreateInstructionParser()
        {
            return new InstructionParser(new PositionParser(), new RoverInitialStateParser(), new RoverActionParser());
        }

        [Theory]
        [InlineData("5 5", 5, 5, 0)]
        [InlineData("5 7", 5, 7, 0)]
        [InlineData(@"5 5
1 2 N
LMLMLMLMM
3 3 E
MMRMMRMRRM", 5, 5, 2)]
        public void Parse_Tests(string instructions, int plateauMaxX, int plateauMaxY, int roverCount)
        {
            // Arrange
            var instructionParser = CreateInstructionParser();

            // Act
            var result = instructionParser.Parse(instructions);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.PlateauMaxPosition.X.ShouldBe(plateauMaxX),
                () => result.PlateauMaxPosition.Y.ShouldBe(plateauMaxY),
                () => result.Rovers.Count().ShouldBe(roverCount)
            );
        }

        [Fact]
        public void Parse_example_return_correct_result()
        {
            // Arrange
            var instructionParser = CreateInstructionParser();

            // Act
            string instructions= @"5 5
1 2 N
LMLMLMLMM
3 3 E
MMRMMRMRRM";
            var result = instructionParser.Parse(instructions);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.PlateauMaxPosition.X.ShouldBe(5),
                () => result.PlateauMaxPosition.Y.ShouldBe(5),
                () => result.Rovers.Count().ShouldBe(2),
                () => result.Rovers.ElementAt(0).Actions.ElementAt(0).ShouldBe(Action.LeftTurn)
            );
        }
    }
}
