using MarsRover.Models;

namespace MarsRover.Calculators
{
    public interface IRoverStateCalculator
    {
        RoverState Action(RoverState currentState, Position maxPosition, Action action);
    }
}