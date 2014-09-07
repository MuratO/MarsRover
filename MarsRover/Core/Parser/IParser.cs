using System;
using System.Collections.Generic;
using MarsRover.Core.Installer;

namespace MarsRover.Core.Parser
{
    public interface IParser
    {
        void Parse(string input, IList<Func<IInterpreter>> expressionTree);
        List<IInstaller> GetInstallers();
    }
}