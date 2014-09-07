using System;
using System.Collections.Generic;
using MarsRover.Core.Exceptions;
using MarsRover.Core.Flags;
using MarsRover.Ground;
using MarsRover.Headquarter;

namespace MarsRover.Rover
{
    public class Rover : IRover
    {
        private StatusFlags Status;
        private Position CurrentPosition { get; set; }
        private List<Position> PositionList { get; set; }
        private List<InstructionFlags> Instructions { get; set; }

        public Rover()
        {
            Status = StatusFlags.Prepared;
            PositionList = new List<Position>();
        }

        public void SetPosition(Position currentPosition)
        {
            CurrentPosition = currentPosition;
        }

        public void SetInstructions(List<InstructionFlags> instructions)
        {
            Instructions = instructions;
        }

        public Position GetCurrentPosition()
        {
            return CurrentPosition;
        }

        public IList<Position> GetPositionList()
        {
            return PositionList;
        }

        public void Move(IGround ground)
        {
            try
            {
                Status = StatusFlags.Moving;

                foreach (InstructionFlags instruction in Instructions)
                {
                    if (ground.IsValidPositon(CurrentPosition.Point))
                    {
                        Position position = PathFinder.FindPosition(CurrentPosition, instruction);
                        SetPosition(position);
                        PositionList.Add(position);
                    }
                    else
                    {
                        throw new RoverNotValidPointException("The Rover not moving this point.");
                    }
                }

                Status = StatusFlags.Moved;
            }
            catch (Exception ex)
            {
                //
            }
            finally
            {
                StopRover();
            }
        }

        private void StopRover()
        {
            Status = StatusFlags.Stopped;
        }
    }
}