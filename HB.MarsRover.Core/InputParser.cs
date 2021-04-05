using HB.MarsRover.Abstractions;
using HB.MarsRover.Common.Enums;
using HB.MarsRover.Core.Command;
using HB.MarsRover.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HB.MarsRover.Core
{
    public class InputParser : IInputParser
    {
        private const int DIRECTION_INDEX = 2;
        private const int PLATEAU_SIZE_INPUT_LENGTH = 2;
        private const int ROVER_INPUT_LENGTH = 3;
        private const string SEPARATOR = " ";
        private const int X_COORDINATE_INDEX = 0;
        private const int Y_COORDINATE_INDEX = 1;

        public bool TryParseCommandnput(string commandsInput, IRover rover)
        {
            if (!string.IsNullOrEmpty(commandsInput)) {
                char[] arrayOfCommands = commandsInput.ToCharArray();

                foreach (var command in arrayOfCommands)
                {
                    switch (char.ToUpper(command))
                    {
                        case 'M':
                            rover.Commands.Add(new MoveCommand());
                            break;
                        case 'R':
                            rover.Commands.Add(new RotateRightCommand());
                            break;
                        case 'L':
                            rover.Commands.Add(new RotateLeftCommand());
                            break;
                        default:
                            return false;
                    }
                }
            } 

            return rover.Commands.Any();
        }

        public bool TryParsePlateauInput(string plateauInput, IPlateau plateau)
        {
            if (!string.IsNullOrEmpty(plateauInput))
            {
                string[] plateauSizeArray = plateauInput.Split(SEPARATOR);

                if (plateauSizeArray.Length == PLATEAU_SIZE_INPUT_LENGTH)
                {
                    bool xCoordinateIsValid = int.TryParse(plateauSizeArray[X_COORDINATE_INDEX], out int xCoordinate);
                    bool yCoordinateIsValid = int.TryParse(plateauSizeArray[Y_COORDINATE_INDEX], out int yCoordinate);

                    if (xCoordinateIsValid && yCoordinateIsValid)
                    {
                        plateau.Position.X = xCoordinate;
                        plateau.Position.Y = yCoordinate;

                        return true;
                    }
                        
                }
            }
            return false;
        }

        public bool TryParseRoverInput(string roverInput, IRover rover)
        {
            if (!string.IsNullOrEmpty(roverInput))
            {
                string[] roverInputArray = roverInput.Split(SEPARATOR);

                if (roverInputArray.Length == ROVER_INPUT_LENGTH)
                {
                    bool xCoordinateIsValid = int.TryParse(roverInputArray[X_COORDINATE_INDEX], out int xCoordinate);
                    bool yCoordinateIsValid = int.TryParse(roverInputArray[Y_COORDINATE_INDEX], out int yCoordinate);
                    bool directionIsValid = Enum.TryParse<Directions>(roverInputArray[DIRECTION_INDEX].ToUpper(), out Directions direction);

                    if (xCoordinateIsValid && yCoordinateIsValid && directionIsValid)
                    {
                        rover.Position.X = xCoordinate;
                        rover.Position.Y = yCoordinate;
                        rover.Direction = direction;

                        return true;
                    }
                }
            }

            return false;
        }
    }
}
