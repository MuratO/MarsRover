using MarsRover.Ground;
using MarsRover.Rover;

namespace MarsRover.Core.Installer
{
    public interface IContext
    {
        void SetContext(IGround ground, IRover roverList);
    }
}