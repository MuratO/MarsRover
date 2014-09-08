using System.Collections.Generic;
using MarsRover.Ground;
using MarsRover.Rover;

namespace MarsRover.Output
{
    public interface IOutput
    {
        string GetGroundInfo(IGround ground);
        string GetRoversInfo(IList<IRover> rovers);
        string GetReport(IList<IRover> rovers);
        void WriteReport(string report);
    }
}