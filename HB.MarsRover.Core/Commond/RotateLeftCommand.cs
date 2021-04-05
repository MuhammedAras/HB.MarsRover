using HB.MarsRover.Abstractions;
using HB.MarsRover.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HB.MarsRover.Core.Command
{
    public class RotateLeftCommand : ICommand
    {
        public void Execute(IRover rover)
        {
            RotateLeft(rover);
        }

        private void RotateLeft(IRover rover)
        {
            rover.Direction = rover.Direction switch
            {
                Directions.N => Directions.W,
                Directions.W => Directions.S,
                Directions.S => Directions.E,
                Directions.E => Directions.N,
                _ => throw new InvalidOperationException(),
            };
        }
    }
}
