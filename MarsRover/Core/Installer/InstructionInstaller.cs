using System;
using System.Linq;
using MarsRover.Core.Flags;
using MarsRover.Ground;
using MarsRover.Rover;

namespace MarsRover.Core.Installer
{
    public class InstructionInstaller : IInstaller
    {
        private String Input { get; set; }
        private IRover Rover { get; set; }

        public InstructionInstaller(string input)
        {
            Input = input;
        }

        public void Execute()
        {
            var args = Input.ToCharArray();
            var instructionList = args.Select(argument => FlagsConverter.GetInstructionKey(argument.ToString())).ToList();
            Rover.SetInstructions(instructionList);
        }

        public InputTypes GetInputType()
        {
            return InputTypes.InstructionInput;
        }

        public void SetContext(IGround ground, IRover rover)
        {
            Rover = rover;
        }
    }
}