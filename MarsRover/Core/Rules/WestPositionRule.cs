using MarsRover.Core.Flags;
using MarsRover.Ground;
using MarsRover.Rover;

namespace MarsRover.Core.Rules
{
    public class WestPositionRule : IPositionRules
    {
        public bool IsApplicableRule(Position position)
        {
            return (position.CurrentDirection.Equals(DirectionFlags.West));
        }

        public Position Move(Position position, InstructionFlags instruction)
        {
            if (instruction.Equals(InstructionFlags.Left))
            {
                position.CurrentDirection = DirectionFlags.South;
            }
            else if (instruction.Equals(InstructionFlags.Right))
            {
                position.CurrentDirection = DirectionFlags.North;
            }
            else if (instruction.Equals(InstructionFlags.Move))
            {
                position.Point = new Point(position.Point.X - 1, position.Point.Y);
            }
            return position;
        }
    }
}