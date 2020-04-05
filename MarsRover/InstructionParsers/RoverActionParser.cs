using System;
using System.Collections.Generic;
using System.Linq;
using Action = MarsRover.Models.Action;

namespace MarsRover.InstructionParsers
{
    public class RoverActionParser : IRoverActionParser
    {
        public IEnumerable<Action> Parse(string actions)
        {
            return actions.Select(Parse);
        }

        private Action Parse(char action)
        {
            switch (action)
            {
                case 'M': return Action.Move;
                case 'L': return Action.LeftTurn;
                case 'R': return Action.RightTurn;
                default:throw new ArgumentException("Action not supported: "+action);
            }
        }
    }
}