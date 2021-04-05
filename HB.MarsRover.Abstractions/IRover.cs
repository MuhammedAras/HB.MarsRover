using HB.MarsRover.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HB.MarsRover.Abstractions
{
    public interface IRover
    {
        Directions Direction { get; set; }
        IPlateau Plateau { get; set; }
        IPosition Position { get; set; }
        List<ICommand> Commands { get; set; }

        void SetLocation(IPosition position, Directions direction = Directions.N);
        void Init();
    }
}
