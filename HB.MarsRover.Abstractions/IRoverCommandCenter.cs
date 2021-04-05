using System;
using System.Collections.Generic;
using System.Text;

namespace HB.MarsRover.Abstractions
{
    public interface IRoverCommandCenter
    {
        IRover Rover { get; set; }
        void HandleCommands();
        void ExecuteCommands();
    }
}
