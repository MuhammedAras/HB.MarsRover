using HB.MarsRover.Common.Enums;
using HB.MarsRover.Abstractions;
using System;
using System.Collections.Generic;

namespace HB.MarsRover.Domain
{
    public class Rover : IRover
    {
        public Directions Direction { get; set; }
        public IPlateau Plateau { get; set; }
        public IPosition Position { get; set; }
        public List<ICommand> Commands { get; set; }

        public Rover(IPosition position, Directions direction = Directions.N)
        {
            Position = position;
            Direction = direction;
            Commands = new List<ICommand>();
        }
    }
}
