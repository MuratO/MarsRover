using System.Text;
using Autofac;
using MarsRover.Headquarter;
using NUnit.Framework;

namespace MarsRover.Test
{
    [TestFixture]
    public class AcceptanceTest
    {
        private string RoverCommand()
        {
            var sb = new StringBuilder();
            sb.AppendLine("5 5");
            sb.AppendLine("1 2 N");
            sb.AppendLine("LMLMLMLMM");
            sb.AppendLine("3 3 E");
            sb.Append("MMRMMRMRRM");
            return sb.ToString();
        }

        private string ExpectedRoverPosition()
        {
            var sb = new StringBuilder();
            sb.AppendLine("1 3 N");
            sb.AppendLine("5 1 E");
            return sb.ToString();
        }

        [Test]
        public void check_navigation_for_expectd_output()
        {
            string getRoversInfo = "";
            using (IContainer container = ContainerTest.CreateContainer().Build())
            {
                var baseOffice = container.Resolve<IBaseOffice>();
                getRoversInfo = baseOffice
                    .Setup(RoverCommand())
                    .StartNavigate()
                    .GetRoversInfo();
            }


            Assert.AreEqual(getRoversInfo, ExpectedRoverPosition());
        }
    }
}