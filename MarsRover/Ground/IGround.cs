using MarsRover.Rover;

namespace MarsRover.Ground
{
    public interface IGround
    {
        void SetDimension(Dimension dimension);
        Dimension GetDimension();
        bool IsValidPositon(Point currentPoint);

    }
}