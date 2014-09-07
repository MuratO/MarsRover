using MarsRover.Core.Flags;
using MarsRover.Ground;
using MarsRover.Rover;

namespace MarsRover.Core.Rules
{
    public class SouthPositionRule : IPositionRules
    {
        public bool IsApplicableRule(Position position)
        {
            return (position.CurrentDirection.Equals(DirectionFlags.South));
        }

        public Position Move(Position position, InstructionFlags instruction)
        {
            if (instruction.Equals(InstructionFlags.Left))
            {
                position.CurrentDirection = DirectionFlags.East;
            }
            else if (instruction.Equals(InstructionFlags.Right))
            {
                position.CurrentDirection = DirectionFlags.West;
            }
            else if (instruction.Equals(InstructionFlags.Move))
            {
                position.Point = new Point(position.Point.X, position.Point.Y - 1);
            }
            return position;
        }
    }
}