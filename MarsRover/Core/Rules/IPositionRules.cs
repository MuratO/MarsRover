using MarsRover.Core.Flags;
using MarsRover.Rover;

namespace MarsRover.Core.Rules
{
    internal interface IPositionRules
    {
        bool IsApplicableRule(Position position);
        Position Move(Position position, InstructionFlags instruction);
    }
}