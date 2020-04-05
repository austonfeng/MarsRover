using MarsRover.Models;

namespace MarsRover.Calculators
{
    public interface IDirectionCalculator
    {
        Direction Turn(Direction currentDirection, Action action);
    }
}