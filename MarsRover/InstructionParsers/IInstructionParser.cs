using MarsRover.Models;

namespace MarsRover.InstructionParsers
{
    public interface IInstructionParser
    {
        IInstructions Parse(string instructionString);
    }
}