using HB.MarsRover.Common.Enums;
using System.Collections.Generic;

namespace HB.MarsRover.Abstractions
{
    public interface IRover
    {
        Directions Direction { get; set; }
        IPlateau Plateau { get; set; }
        IPosition Position { get; set; }
        List<ICommand> Commands { get; set; }
    }
}
