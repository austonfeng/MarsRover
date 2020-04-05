using System.Collections.Generic;
using System.Linq;
using MarsRover.Calculators;
using MarsRover.InstructionParsers;
using MarsRover.Models;

namespace MarsRover
{
    public class RoverController : IRoverController
    {
        private readonly IInstructionParser _instructionParser;
        private readonly IRoverStateCalculator _roverStateCalculator;

        public RoverController(IInstructionParser instructionParser, 
            IRoverStateCalculator roverStateCalculator)
        {
            _instructionParser = instructionParser;
            _roverStateCalculator = roverStateCalculator;
        }

        public string Run(string instructionString)
        {
            var instructions = _instructionParser.Parse(instructionString);
            var finalStates = new List<RoverState>();
            foreach (var rover in instructions.Rovers)
            {
                var state = rover.InitialState;
                foreach (var action in rover.Actions)
                {
                    state = _roverStateCalculator.Action(state, instructions.PlateauMaxPosition, action);
                }
                finalStates.Add(state);
            }

            return string.Join("\r\n", finalStates.Select(s => s.Position.X + " " + s.Position.Y + " " + s.Direction));
        }
    }
}