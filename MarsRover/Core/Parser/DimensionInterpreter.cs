using System.Text.RegularExpressions;
using MarsRover.Core.Flags;
using MarsRover.Core.Installer;

namespace MarsRover.Core.Parser
{
    public class DimensionInterpreter : IInterpreter
    {
        public IInstaller Interpret(string inputLine)
        {
            if (new Regex(@"^\d+ \d+$").IsMatch(inputLine))
            {
                return new DimensionInstaller(inputLine);
            }
            return new NullInstaller();
        }
    }

}