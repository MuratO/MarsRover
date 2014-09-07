using System.Collections.Generic;
using MarsRover.Core.Flags;
using MarsRover.Core.Rules;
using MarsRover.Rover;

namespace MarsRover.Headquarter
{
    public static class PathFinder
    {
        private static readonly List<IPositionRules> Rules = new List<IPositionRules>();

        static PathFinder()
        {
            Rules.Add(new EastPositionRule());
            Rules.Add(new NorthPositionRule());
            Rules.Add(new SouthPositionRule());
            Rules.Add(new WestPositionRule());
        }

        public static Position FindPosition(Position currentPosition, InstructionFlags instruction)
        {
            var position = new Position();
            foreach (IPositionRules rule in Rules)
            {
                if (rule.IsApplicableRule(currentPosition))
                {
                    position = rule.Move(currentPosition, instruction);
                }
            }
            return position;
        }
    }
}