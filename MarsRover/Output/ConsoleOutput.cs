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
        public string GetGroundInfo(IGround ground)
        {
            var dim = ground.GetDimension();
            return string.Format(" Ground info -->  Width : {0} Height : {1}", dim.Width, dim.Height);
        }

        public string GetRoversInfo(IList<IRover> rovers)
        {
            var report = new StringBuilder();
            if (rovers != null && rovers.Count > 0)
            {
                foreach (var rover in rovers)
                {
                    var position = rover.GetCurrentPosition();
                    report.AppendLine(string.Format("{0} {1} {2}",
                        position.Point.X,
                        position.Point.Y,
                        FlagsConverter.GetDirectionValue(position.CurrentDirection)));
                }
            }
            else
            {
                report.AppendLine("Rovers not found.");
            }

            return report.ToString();
        }

        public string GetReport(IList<IRover> rovers)
        {
            var report = new StringBuilder();
            if (rovers != null && rovers.Count > 0)
            {
                report.AppendLine(string.Format(" Rover count --> {0}", rovers.Count));
                foreach (var rover in rovers)
                {
                    var position = rover.GetCurrentPosition();
                    report.AppendLine(string.Format(" Rover position info --> {0} {1} {2}",
                        position.Point.X,
                        position.Point.Y,
                        FlagsConverter.GetDirectionValue(position.CurrentDirection)));

                    foreach (var p in rover.GetPositionList())
                    {
                        report.AppendLine(string.Format("      Rover position detail --> {0}", p.ToString()));
                    }
                }
            }
            else
            {
                report.AppendLine("Rovers not found.");
            }

            return report.ToString();
        }

        public void WriteReport(string report)
        {
            Console.WriteLine(report.Trim(Environment.NewLine.ToCharArray()));
        }
    }
}
