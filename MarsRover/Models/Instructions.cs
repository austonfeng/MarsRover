using System.Collections.Generic;

namespace MarsRover.Models
{
    public class Instructions : IInstructions
    {
        public Position PlateauMaxPosition { get; set; }
        public IEnumerable<IRoverInstructions> Rovers { get; set; }
    }
}