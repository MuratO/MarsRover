using MarsRover.Core.Flags;
using MarsRover.Ground;
using MarsRover.Headquarter;
using MarsRover.Rover;
using NUnit.Framework;

namespace MarsRover.Test
{
    [TestFixture]
    public class PathFinderTest
    {
        [Test]
        public void path_find_not_valid_test()
        {
            Assert.AreNotEqual(
                PathFinder.FindPosition(new Position(new Point(1, 2), DirectionFlags.North), InstructionFlags.Move),
                new Position(new Point(1, 2), DirectionFlags.North));
            Assert.AreNotEqual(
                PathFinder.FindPosition(new Position(new Point(1, 2), DirectionFlags.East), InstructionFlags.Left),
                new Position(new Point(0, 2), DirectionFlags.South));
            Assert.AreNotEqual(
                PathFinder.FindPosition(new Position(new Point(0, 2), DirectionFlags.West), InstructionFlags.Right),
                new Position(new Point(0, 2), DirectionFlags.South));
            Assert.AreNotEqual(
                PathFinder.FindPosition(new Position(new Point(0, 2), DirectionFlags.West), InstructionFlags.Move),
                new Position(new Point(0, 1), DirectionFlags.South));
        }

        [Test]
        public void path_find_valid_test()
        {
            Assert.AreEqual(
                PathFinder.FindPosition(new Position(new Point(1, 2), DirectionFlags.North), InstructionFlags.Left),
                new Position(new Point(1, 2), DirectionFlags.West));
            Assert.AreEqual(
                PathFinder.FindPosition(new Position(new Point(1, 2), DirectionFlags.West), InstructionFlags.Move),
                new Position(new Point(0, 2), DirectionFlags.West));
            Assert.AreEqual(
                PathFinder.FindPosition(new Position(new Point(0, 2), DirectionFlags.West), InstructionFlags.Left),
                new Position(new Point(0, 2), DirectionFlags.South));
            Assert.AreEqual(
                PathFinder.FindPosition(new Position(new Point(0, 2), DirectionFlags.South), InstructionFlags.Move),
                new Position(new Point(0, 1), DirectionFlags.South));
        }
    }
}