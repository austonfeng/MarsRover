using MarsRover;
using MarsRover.Calculators;
using MarsRover.InstructionParsers;
using NSubstitute;
using System;
using MarsRover.Models;
using Shouldly;
using Xunit;
using Action = MarsRover.Models.Action;

namespace MarsRover.Tests
{
    public class RoverControllerTests
    {
        private readonly IInstructionParser _subInstructionParser;
        private readonly IRoverStateCalculator _subRoverStateCalculator;

        public RoverControllerTests()
        {
            _subInstructionParser = Substitute.For<IInstructionParser>();
            _subRoverStateCalculator = Substitute.For<IRoverStateCalculator>();
        }

        private RoverController CreateRoverController()
        {
            return new RoverController(
                _subInstructionParser,
                _subRoverStateCalculator);
        }

        [Fact]
        public void Run_Tests()
        {
            // Arrange
            var roverController = CreateRoverController();
            _subRoverStateCalculator.Action(Arg.Any<RoverState>(),
                Arg.Any<Position>(),
                Arg.Any<Action>()).Returns(new RoverState()
            {
                Direction = Direction.E,
                Position = new Position
                {
                    X = 32,
                    Y = 54
                }
            });

            _subInstructionParser.Parse("").Returns(new Instructions
            {
                Rovers = new IRoverInstructions[]
                {
                    new RoverInstructions
                    {
                        Actions = new []
                        {
                            new Action(),
                            new Action(),
                            new Action(),
                        }
                    },
                    
                    new RoverInstructions
                    {
                        Actions = new []
                        {
                            new Action(),
                            new Action(),
                        }
                    }
                },
                PlateauMaxPosition = new Position
                {
                    X = 4,
                    Y = 6
                }
            });

            // Act
            var result = roverController.Run("");

            // Assert
            result.ShouldBe(@"32 54 E
32 54 E");
        }
    }
}
