using MarsRover.Models;

namespace MarsRover.InstructionParsers
{
    public class PositionParser : IPositionParser
    {
        public Position ParsePlateauMaxPosition(string line)
        {
            var plateauMaxPosition = line.Split(" ");
            return new Position
            {
                X = int.Parse(plateauMaxPosition[0]),
                Y = int.Parse(plateauMaxPosition[1])
            };
        }
    }
}