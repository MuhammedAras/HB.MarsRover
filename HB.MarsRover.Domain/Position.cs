using HB.MarsRover.Abstractions;
using HB.MarsRover.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HB.MarsRover.Domain
{
    public class Position : IPosition
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position() { }
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
