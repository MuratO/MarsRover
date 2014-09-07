using System.Reflection;
using Autofac;
using MarsRover.Headquarter;
using NUnit.Framework;

namespace MarsRover.Test
{
    [TestFixture]
    public class ContainerTest
    {
        public static void Init()
        {
            using (IContainer container = CreateContainer().Build())
            {
                var baseOffice = container.Resolve<IBaseOffice>();
            }
        }

        public static ContainerBuilder CreateContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(Assembly.Load("MarsRover"))
                .AsImplementedInterfaces();

            return builder;
        }

        [Test]
        public void Container_Init_Test()
        {
            Assert.DoesNotThrow(Init);
        }
    }
}