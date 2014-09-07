using MarsRover.Core.Flags;
using MarsRover.Core.Parser;
using MarsRover.Ground;
using MarsRover.Rover;

namespace MarsRover.Core.Installer
{
    public class DimensionInstaller : IInstaller
    {
        public DimensionInstaller(string input)
        {
            Input = input;
        }

        private IGround Ground { get; set; }
        private string Input { get; set; }

        public void Execute()
        {
            string[] arguments = Input.Split(' ');
            int width = int.Parse(arguments[0]);
            int height = int.Parse(arguments[1]);
            Ground.SetDimension(new Dimension(width, height));
        }

        public InputTypes GetInputType()
        {
            return InputTypes.DimensionInput;
        }

        public void SetContext(IGround ground, IRover rover)
        {
            Ground = ground;
        }
    }
}