using System;
using System.Collections.Generic;
using System.Linq;
using MarsRover.Core.Exceptions;
using MarsRover.Core.Installer;

namespace MarsRover.Core.Parser
{
    public class Parser : IParser
    {
        public readonly List<IInstaller> InstallerList;

        private readonly string[] delimiter = {Environment.NewLine};

        public Parser()
        {
            InstallerList = new List<IInstaller>();
        }

        public List<IInstaller> GetInstallers()
        {
            return InstallerList;
        }

        public void Parse(string input, IList<Func<IInterpreter>> expressionTree)
        {
            if (input == null || input.Split(delimiter, StringSplitOptions.None).Count() <= 2)
            {
                throw new InputNotValidException("Please check input lines.");
            }

            if (expressionTree == null)
            {
                throw new ExpressionTreeNotValid("Please create expression tree.");
            }

            foreach (string inputLine in input.Split(delimiter, StringSplitOptions.None))
            {
                foreach (Func<IInterpreter> expression in expressionTree)
                {
                    var installer = expression().Interpret(inputLine);
                    if(!(installer is NullInstaller))
                        InstallerList.Add(installer);
                }
            }
        }
    }
}