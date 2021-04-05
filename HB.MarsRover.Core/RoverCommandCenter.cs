using HB.MarsRover.Abstractions;
using System.Collections.Generic;

namespace HB.MarsRover.Core
{
    public class RoverCommandCenter : IRoverCommandCenter
    {
        public IRover Rover { get; set; }
        private Queue<ICommand> Commands;

        public RoverCommandCenter()
        {
            Commands = new Queue<ICommand>();
        }

        public void HandleCommands()
        {
            Rover.Commands.ForEach(command => Commands.Enqueue(command));
        }

        public void ExecuteCommands()
        {
            while (Commands.Count > 0)
            {
                ICommand command = Commands.Dequeue();

                command.Execute(Rover);
            }
        }
    }
}
