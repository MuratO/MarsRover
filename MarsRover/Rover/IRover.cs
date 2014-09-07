using System.Collections;
using System.Collections.Generic;
using MarsRover.Core.Flags;
using MarsRover.Ground;

namespace MarsRover.Rover
{
    public interface IRover
    {
        void Move(IGround ground);
        void SetPosition(Position currentPosition);
        void SetInstructions(List<InstructionFlags> instructions);
        Position GetCurrentPosition();
        IList<Position> GetPositionList();
    }
}