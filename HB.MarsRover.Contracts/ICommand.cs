namespace HB.MarsRover.Abstractions
{
    public interface ICommand
    {
        void Execute(IRover rover);
    }
}
