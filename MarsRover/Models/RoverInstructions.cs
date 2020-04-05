using System.Collections.Generic;

namespace MarsRover.Models
{
    public class RoverInstructions : IRoverInstructions
    {
        public RoverState InitialState { get; set; }
        public IEnumerable<Action> Actions { get; set; }
    }
}