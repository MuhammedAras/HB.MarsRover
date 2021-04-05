using HB.MarsRover.Abstractions;
using HB.MarsRover.Common.Enums;
using HB.MarsRover.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HB.MarsRover.Core.Command
{
    public class MoveCommand : ICommand
    {
        public void Execute(IRover rover)
        {
            Move(rover);
        }

        private void Move(IRover rover)
        {
            IPosition currentPosition = rover.Position;

            rover.Position = rover.Direction switch
            {
                Directions.N => new Position(currentPosition.X, currentPosition.Y + 1),
                Directions.W => new Position(currentPosition.X - 1, currentPosition.Y),
                Directions.S => new Position(currentPosition.X, currentPosition.Y - 1),
                Directions.E => new Position(currentPosition.X + 1, currentPosition.Y),
                _ => throw new InvalidOperationException(),
            };

            CheckRoverPosition(rover);
        }

        private void CheckRoverPosition(IRover rover)
        {
            IPosition plateauPosition = rover.Plateau.Position;
            IPosition roverPosition = rover.Position;

            if(rover.Position.X > plateauPosition.X || rover.Position.X < 0 || rover.Position.Y > plateauPosition.Y || rover.Position.Y < 0)
            {
                throw new Exception(string.Format(@"Out of boundary on plateau. Plateau Boundary: X: {0}, Y: {1} - Rover Position: X: {2}, Y: {3}", plateauPosition.X, plateauPosition.Y, roverPosition.X, roverPosition.Y));
            }
        }
    }
}
