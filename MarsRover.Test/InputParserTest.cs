using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using MarsRover.Core.Exceptions;
using MarsRover.Core.Parser;
using MarsRover.Test;
using NUnit.Framework;

namespace MarsRover.UnitTest
{
    [TestFixture]
    public class InputParserTest
    {
        private readonly StringBuilder inputBuilder = new StringBuilder();
        private readonly IList<Func<IInterpreter>> expressionList;

        public InputParserTest()
        {
            ContainerBuilder container = ContainerTest.CreateContainer();
            expressionList = container.Build().Resolve<IEnumerable<Func<IInterpreter>>>().ToList();
        }

        [TestCase(5)]
        public void InputParser_Init_Parse_Valid_Test(int expressionCount)
        {
            inputBuilder.Clear();
            inputBuilder.AppendLine("5 5");
            inputBuilder.AppendLine("1 2 N");
            inputBuilder.AppendLine("LMLMLMLMM");
            inputBuilder.AppendLine("3 3 E");
            inputBuilder.Append("MMRMMRMRRM");

            var parser = new Parser();
            parser.Parse(inputBuilder.ToString(), expressionList);
            Assert.AreEqual(parser.InstallerList.Count, expressionCount);
        }

        [Test]
        public void InputParser_Init_ExpressionTree_Not_Valid_Test()
        {
            inputBuilder.Clear();
            inputBuilder.AppendLine("5 5");
            inputBuilder.AppendLine("1 2 N");
            inputBuilder.AppendLine("LMLMLMLMM");
            inputBuilder.AppendLine("3 3 E");
            inputBuilder.Append("MMRMMRMRRM");
            Assert.Throws<ExpressionTreeNotValid>(() => new Parser().Parse(inputBuilder.ToString(), null));
        }

        [Test]
        public void InputParser_Init_Input_Not_Valid_Test()
        {
            inputBuilder.Clear();
            inputBuilder.AppendLine("5 5");
            Assert.Throws<InputNotValidException>(() => new Parser().Parse(inputBuilder.ToString(), expressionList));
        }
    }
}