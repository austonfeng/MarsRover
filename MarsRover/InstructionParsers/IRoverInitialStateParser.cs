using MarsRover.Models;

namespace MarsRover.InstructionParsers
{
    public interface IRoverInitialStateParser
    {
        RoverState Parse(string initialState);
    }
}