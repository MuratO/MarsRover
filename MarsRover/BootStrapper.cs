using System.Reflection;
using Autofac;
using MarsRover.Headquarter;

namespace MarsRover
{
    public class BootStrapper
    {
        public static void Init(string inputLines)
        {
            using (IContainer container = CreateContainer().Build())
            {
                var baseOffice = container.Resolve<IBaseOffice>();

                baseOffice
                    .Setup(inputLines)
                    .StartNavigate()
                    .SendReportEarth();
            }
        }

        private static ContainerBuilder CreateContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AsImplementedInterfaces();

            return builder;
        }
    }
}