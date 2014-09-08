using System;
using System.Collections.Generic;
using System.Linq;
using MarsRover.Core.Flags;
using MarsRover.Core.Installer;
using MarsRover.Core.Parser;
using MarsRover.Ground;
using MarsRover.Output;
using MarsRover.Rover;

namespace MarsRover.Headquarter
{
    internal class BaseOffice : IBaseOffice
    {
        private IParser Parser { get; set; }
        private IGround Ground { get; set; }
        private IOutput Output { get; set; }
        private readonly Func<IRover> Rover;
        private IList<IRover> roverSquadList { get; set; }
        private readonly IList<Func<IInterpreter>> InterpreterList;

        public BaseOffice(IGround ground, Func<IRover> rover, IParser parser, IOutput output,
            IEnumerable<Func<IInterpreter>> interpreterList)
        {
            Rover  = rover;
            Output = output;
            Parser = parser;
            Ground = ground;
            FlagsConverter.Init();
            roverSquadList = new List<IRover>();
            InterpreterList = interpreterList.ToList();
        }

        public IBaseOffice Setup(string inputLines)
        { 
            Parser.Parse(inputLines, InterpreterList);

            if (Parser.GetInstallers() != null)
            {
                foreach (IInstaller installer in Parser.GetInstallers())
                {
                    if (installer.GetInputType().Equals(InputTypes.PositionInput))
                    {
                        AddRover();
                    }

                    installer.SetContext(Ground, GetCurrentRover());
                    installer.Execute();
                }
            }

            return this;
        }

        private void AddRover()
        {
            roverSquadList.Add(Rover());
        }

        private IRover GetCurrentRover()
        {
            IRover rover = null;
            if (roverSquadList != null && roverSquadList.Count > 0)
            {
                return roverSquadList[roverSquadList.Count - 1];
            }
            else
            {
                rover = Rover();
            }
            return rover;
        }

        public IBaseOffice StartNavigate()
        {
            foreach (IRover rover in roverSquadList)
            {
                rover.Move(Ground);
            }
            return this;
        }

        public IBaseOffice SendReportEarth()
        {
         //   Output.GetGroundInfo(Ground);
            var report = Output.GetReport(roverSquadList);
            Output.WriteReport(report);
            return this;
        }

        public string GetRoversInfo()
        {
            return Output.GetRoversInfo(roverSquadList);
        }
    }
}