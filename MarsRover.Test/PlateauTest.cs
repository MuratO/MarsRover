using MarsRover.Ground;
using NUnit.Framework;

namespace MarsRover.UnitTest
{
    [TestFixture]
    public class Plateau_Size_Test
    {
        [TestCase(2, 2)]
        [TestCase(3, 4)]
        [TestCase(6, 5)]
        public void PlateauTest_CheckSize(int specifiedWidth, int specifiedHeight)
        {
            var plateau = new Plateau();
            var specifiedDim = new Dimension(specifiedWidth, specifiedHeight);
            plateau.SetDimension(specifiedDim);

            Dimension createdDim = plateau.GetDimension();

            Assert.AreEqual(specifiedDim, createdDim);
        }
    }

    [TestFixture]
    public class Plateau_ValidPoint_Test
    {
        [TestCase(2, 2, 1, 0)]
        [TestCase(3, 3, 2, 2)]
        [TestCase(6, 2, 3, 2)]
        [TestCase(5, 5, 1, 2)]
        [TestCase(5, 5, 3, 3)]
        public void point_in_plateau_dimension_return_true(int specifiedWidth, int specifiedHeight, int pointX,
            int pointY)
        {
            var plateau = new Plateau();
            var specifiedDim = new Dimension(specifiedWidth, specifiedHeight);
            plateau.SetDimension(specifiedDim);

            var currentPoint = new Point(pointX, pointY);
            bool isValidPosition = plateau.IsValidPositon(currentPoint);

            Assert.That(isValidPosition);
        }

        [TestCase(2, 2, 3, 1)]
        [TestCase(1, 1, 2, 1)]
        [TestCase(3, 2, -1, -2)]
        [TestCase(4, 2, 5, 2)]
        [TestCase(5, 3, 3, 5)]
        public void point_in_plateau_dimension_return_false(int specifiedWidth, int specifiedHeight, int pointX,
            int pointY)
        {
            var plateau = new Plateau();
            var specifiedDim = new Dimension(specifiedWidth, specifiedHeight);
            plateau.SetDimension(specifiedDim);

            var currentPoint = new Point(pointX, pointY);
            bool isValidPosition = plateau.IsValidPositon(currentPoint);

            Assert.That(!isValidPosition);
        }
    }
}