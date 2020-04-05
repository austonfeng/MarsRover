using MarsRover.Models;

namespace MarsRover.Calculators
{
    public interface IPositionCalculator
    {
        Position Move(RoverState currentState, Position maxPosition);
    }
}