using HB.MarsRover.Abstractions;
using HB.MarsRover.Common.Enums;
using System;

namespace HB.MarsRover.Core.Command
{
    public class RotateRightCommand : ICommand
    {
        public void Execute(IRover rover)
        {
            RotateRight(rover);
        }

        private void RotateRight(IRover rover)
        {
            rover.Direction = rover.Direction switch
            {
                Directions.N => Directions.E,
                Directions.W => Directions.N,
                Directions.S => Directions.W,
                Directions.E => Directions.S,
                _ => throw new InvalidOperationException(),
            };
        }
    }
}
