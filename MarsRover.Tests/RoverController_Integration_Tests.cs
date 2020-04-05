using MarsRover.Calculators;
using MarsRover.InstructionParsers;
using Shouldly;
using Xunit;

namespace MarsRover.Tests
{
    public class RoverController_Integration_Tests
    {
        private RoverController CreateRoverController()
        {
            return new RoverController(
                new InstructionParser(new PositionParser(), new RoverInitialStateParser(), new RoverActionParser()), 
                new RoverStateCalculator(new DirectionCalculator(), new PositionCalculator()));
        }

        [Fact]
        public void Run_Tests()
        {
            // Arrange
            var roverController = CreateRoverController();
            string instructionString = @"5 5
1 2 N
LMLMLMLMM
3 3 E
MMRMMRMRRM";

            // Act
            var result = roverController.Run(instructionString);

            // Assert
            result.ShouldBe(@"1 3 N
5 1 E");
        }
    }
}
