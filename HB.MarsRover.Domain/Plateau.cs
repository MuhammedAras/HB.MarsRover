using HB.MarsRover.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace HB.MarsRover.Domain
{
    public class Plateau : IPlateau
    {
        public IPosition Position { get; set; }
        public List<IRover> Rovers { get; set; }

        public Plateau(IPosition position)
        {
            Position = position;
            Rovers = new List<IRover>();
        }
    }
}
