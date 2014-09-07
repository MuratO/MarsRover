using System;
using MarsRover.Core.Flags;
using MarsRover.Ground;
using MarsRover.Rover;

namespace MarsRover.Core.Installer
{
    public class PositionInstaller : IInstaller
    {
        private String Input { get; set; }
        private IRover Rover { get; set; }

        public PositionInstaller(string input)
        {
            Input = input;
        }
         
        public void Execute()
        {
            var args = Input.Split(' ');
            var x = int.Parse(args[0]);
            var y = int.Parse(args[1]);

            var direction = args[2][0];

            var position = new Position(new Point(x, y), FlagsConverter.GetDirectionKey(direction.ToString()));
            Rover.SetPosition(position);
        }

        public InputTypes GetInputType()
        {
            return InputTypes.PositionInput;
        }
        
        public void SetContext(IGround ground, IRover rover)
        {
            Rover = rover;
        }
    }
}