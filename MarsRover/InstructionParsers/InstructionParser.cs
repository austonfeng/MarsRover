using System.Collections.Generic;
using MarsRover.Models;

namespace MarsRover.InstructionParsers
{
    public class InstructionParser : IInstructionParser
    {
        private readonly IPositionParser _positionParser;
        private readonly IRoverInitialStateParser _roverInitialStateParser;
        private readonly IRoverActionParser _roverActionParser;

        public InstructionParser(IPositionParser positionParser,
            IRoverInitialStateParser roverInitialStateParser,
            IRoverActionParser roverActionParser)
        {
            _positionParser = positionParser;
            _roverInitialStateParser = roverInitialStateParser;
            _roverActionParser = roverActionParser;
        }

        public IInstructions Parse(string instructionString)
        {
            var lines = instructionString.Split("\r\n");
            Position position = _positionParser.ParsePlateauMaxPosition(lines[0]);

            var roverCount = (lines.Length - 1) / 2;
            var rovers = new List<IRoverInstructions>();
            for (int roverIndex = 0; roverIndex < roverCount; roverIndex++)
            {
                rovers.Add(new RoverInstructions
                {
                    InitialState = _roverInitialStateParser.Parse(lines[roverIndex * 2 + 1]),
                    Actions = _roverActionParser.Parse(lines[roverIndex * 2 + 2])
                });
            }

            return new Instructions
            {
                PlateauMaxPosition = position,
                Rovers = rovers
            };
        }
    }
}