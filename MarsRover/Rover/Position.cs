using MarsRover.Core.Flags;
using MarsRover.Ground;

namespace MarsRover.Rover
{
    public struct Position
    {
        public DirectionFlags CurrentDirection;
        public Point Point;

        public Position(Point point, DirectionFlags direction)
        {
            Point = point;
            CurrentDirection = direction;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", this.Point.X, this.Point.Y, this.CurrentDirection );
        }
    }
}