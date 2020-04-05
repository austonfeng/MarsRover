using System.Collections.Generic;
using MarsRover.Models;

namespace MarsRover.InstructionParsers
{
    public interface IRoverActionParser
    {
        IEnumerable<Action> Parse( string actions);
    }
}