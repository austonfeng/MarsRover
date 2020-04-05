using MarsRover.Models;
using Action = MarsRover.Models.Action;

namespace MarsRover.Calculators
{
    public class DirectionCalculator : IDirectionCalculator
    {
        public Direction Turn(Direction currentDirection, Action action)
        {
            return (currentDirection, action) switch
            {
                (_, Action.Move) => currentDirection,
                (Direction.W, Action.LeftTurn) => Direction.S,
                (Direction.S, Action.LeftTurn) => Direction.E,
                (Direction.E, Action.LeftTurn) => Direction.N,
                (Direction.N, Action.LeftTurn) => Direction.W,
                (Direction.W, Action.RightTurn) => Direction.N,
                (Direction.S, Action.RightTurn) => Direction.W,
                (Direction.E, Action.RightTurn) => Direction.S,
                (Direction.N, Action.RightTurn) => Direction.E,
            };
        }
    }
}