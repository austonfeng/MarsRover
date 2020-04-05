using System.Collections.Generic;

namespace MarsRover.Models
{
    public interface IInstructions
    {
        Position PlateauMaxPosition { get; set; }
        IEnumerable<IRoverInstructions> Rovers { get; set; }
    }
}