using System;
using MarsRover.Core.Flags;
using MarsRover.Ground;
using MarsRover.Rover;

namespace MarsRover.Core.Installer
{
    public class NullInstaller : IInstaller
    {
        public void Execute()
        {
            throw new NotImplementedException();
        }

        public InputTypes GetInputType()
        {
            throw new NotImplementedException();
        }

        public void ParseInput()
        {
            throw new NotImplementedException();
        }

        public void SetContext(IGround ground, IRover rover)
        {
         
        }
    }
}