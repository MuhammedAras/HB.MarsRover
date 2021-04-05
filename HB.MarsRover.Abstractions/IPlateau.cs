using System;
using System.Collections.Generic;

namespace HB.MarsRover.Abstractions
{
    public interface IPlateau
    {
        IPosition Position { get; set; }
        List<IRover> Rovers { get; set; }
    }
}
