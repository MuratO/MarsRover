namespace MarsRover.Ground
{
    public class Plateau : IGround
    {
        private Dimension Dimension { get; set; }

        public void SetDimension(Dimension dimension)
        {
            Dimension = dimension;
        }

        public Dimension GetDimension()
        {
            return Dimension;
        }

        public bool IsValidPositon(Point currentPoint)
        {
            bool isValidXPosition = currentPoint.X >= 0 && currentPoint.X <= Dimension.Width;
            bool isValidYPosition = currentPoint.Y >= 0 && currentPoint.Y <= Dimension.Height;

            return isValidXPosition && isValidYPosition;
        }
    }
}