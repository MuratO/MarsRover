using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsRover.Core.Flags;
using MarsRover.Ground;
using MarsRover.Rover;

namespace MarsRover.Output
{
    internal class ConsoleOutput : IOutput
    {
        public void SendGroundInfo(IGround ground)
        {
            var dim = ground.GetDimension();
            Console.WriteLine(" Ground info -->  Width : {0} Height : {1}", dim.Width, dim.Height);
        }

        public void SendRoversInfo(IList<IRover> rovers)
        {
            if (rovers != null && rovers.Count > 0)
            {
                Console.WriteLine(" Rover count --> {0}", rovers.Count);
                foreach (var rover in rovers)
                {
                    var position = rover.GetCurrentPosition();
                    Console.WriteLine(" Rover position info --> {0} {1} {2}",
                        position.Point.X,
                        position.Point.Y,
                        FlagsConverter.GetDirectionValue(position.CurrentDirection));

                    foreach (var p in rover.GetPositionList() )
                    {
                        Console.WriteLine("      Rover position detail --> {0}",p.ToString());
                    }
                }
            }
            else
            {
                Console.WriteLine("Rovers not found.");
            }
        }
    }
}
