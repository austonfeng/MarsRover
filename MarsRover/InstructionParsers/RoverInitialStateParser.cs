using System;
using MarsRover.Models;

namespace MarsRover.InstructionParsers
{
    public class RoverInitialStateParser : IRoverInitialStateParser
    {
        public RoverState Parse(string initialState)
        {
            var states = initialState.Split(" ");
            return new RoverState
            {
                Direction = (Direction)Enum.Parse(typeof(Direction), states[2]),
                Position = new Position
                {
                    X = int.Parse(states[0]),
                    Y = int.Parse(states[1])
                }
            };
        }
    }
}