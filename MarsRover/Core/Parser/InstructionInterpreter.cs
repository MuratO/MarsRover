using System.Text.RegularExpressions;
using MarsRover.Core.Installer;

namespace MarsRover.Core.Parser
{
    public class InstructionInterpreter : IInterpreter
    {
        public IInstaller Interpret(string inputLine)
        {
            if (new Regex(@"^[LRM]+$").IsMatch(inputLine))
            {
                 return new InstructionInstaller(inputLine);
            }
            return new NullInstaller();
        }
    }
}