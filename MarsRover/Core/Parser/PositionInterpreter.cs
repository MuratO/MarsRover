using System.Text.RegularExpressions;
using MarsRover.Core.Installer;

namespace MarsRover.Core.Parser
{
    public class PositionInterpreter : IInterpreter
    {
        public IInstaller Interpret(string inputLine)
        {
            if (new Regex(@"^\d+ \d+ [NSEW]$").IsMatch(inputLine))
            {
                return new PositionInstaller(inputLine);
            }
            return new NullInstaller();
        }
    }
}