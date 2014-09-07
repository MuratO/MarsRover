using MarsRover.Core.Flags;

namespace MarsRover.Core.Installer
{
    public interface IInstaller : IContext
    {
        void Execute();
        InputTypes GetInputType();
    }
}