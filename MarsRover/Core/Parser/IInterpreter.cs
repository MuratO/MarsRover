using MarsRover.Core.Installer;

namespace MarsRover.Core.Parser
{
    public interface IInterpreter
    {
        IInstaller Interpret(string inputLine);
    }
}