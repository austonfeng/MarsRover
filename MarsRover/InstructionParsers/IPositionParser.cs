using MarsRover.Models;

namespace MarsRover.InstructionParsers
{
    public interface IPositionParser
    {
        Position ParsePlateauMaxPosition(string line);
    }
}