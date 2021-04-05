using System.Collections.Generic;

namespace HB.MarsRover.Abstractions
{
    public interface ICommandParser
    {
        List<ICommand> Parse(string commands);
    }
}
