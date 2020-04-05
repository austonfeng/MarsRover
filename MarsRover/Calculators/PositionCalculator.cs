using System;
using MarsRover.Models;

namespace MarsRover.Calculators
{
    public class PositionCalculator : IPositionCalculator
    {
        public Position Move(RoverState currentState, Position maxPosition)
        {
            var newPosition = new Position
            {
                X = currentState.Position.X,
                Y = currentState.Position.Y
            };

            switch (currentState.Direction)
            {
                case Direction.E:
                    newPosition.X = Math.Min(maxPosition.X, currentState.Position.X + 1);
                    break;

                case Direction.W:
                    newPosition.X = Math.Max(0, currentState.Position.X - 1);
                    break;

                case Direction.N:
                    newPosition.Y = Math.Min(maxPosition.Y, currentState.Position.Y + 1);
                    break;

                case Direction.S:
                    newPosition.Y = Math.Max(0, currentState.Position.Y - 1);
                    break;
            }

            return newPosition;
        }
    }
}