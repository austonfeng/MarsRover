using System.Collections.Generic;

namespace MarsRover.Models
{
    public interface IRoverInstructions
    {
        RoverState InitialState { get; set; }
        IEnumerable<Action> Actions { get; set; }
    }
}