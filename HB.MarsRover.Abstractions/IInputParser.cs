namespace HB.MarsRover.Abstractions
{
    public interface IInputParser
    {
        bool TryParseCommandnput(string commandsInput, IRover rover);
        bool TryParsePlateauInput(string plateauInput, IPlateau plateau);
        bool TryParseRoverInput(string roverInput, IRover rover);
    }
}
