using System.Collections.Generic;
using MarsRover.Ground;
using MarsRover.Rover;

namespace MarsRover.Output
{
    public interface IOutput
    {
        void SendGroundInfo(IGround ground);
        void SendRoversInfo(IList<IRover> rovers);
    }
}