using MarsRover.Models;

namespace MarsRover.Calculators
{
    public class RoverStateCalculator : IRoverStateCalculator
    {
        private readonly IDirectionCalculator _directionCalculator;
        private readonly IPositionCalculator _positionCalculator;

        public RoverStateCalculator(IDirectionCalculator directionCalculator, IPositionCalculator positionCalculator)
        {
            _directionCalculator = directionCalculator;
            _positionCalculator = positionCalculator;
        }

        public RoverState Action(RoverState currentState, Position maxPosition, Action action)
        {
            var newState = new RoverState
            {
                Direction = _directionCalculator.Turn(currentState.Direction, action),
                Position = currentState.Position
            };

            if (action == Models.Action.Move)
            {
                newState.Position = _positionCalculator.Move(currentState, maxPosition);
            }

            return newState;
        }
    }
}