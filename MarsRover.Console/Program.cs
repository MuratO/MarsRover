using System;
using System.Text;

namespace MarsRover.ConsoleUI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var commandBuilder = new StringBuilder();
            /*
            Console.WriteLine("Please input command lines for landing NASA Mars Rovers.");
            Console.WriteLine("After the completed input operation, press the Escape button.");
            Console.WriteLine("");
            while (!Console.ReadKey().Key.ToString().Equals("Escape"))
            {
                commandBuilder.Append(Console.ReadLine());
                commandBuilder.Append(Environment.NewLine);
            }

            Console.WriteLine(commandBuilder.ToString());
            */

            commandBuilder.AppendLine("5 5");
            commandBuilder.AppendLine("1 2 N");
            commandBuilder.AppendLine("LMLMLMLMM");
            commandBuilder.AppendLine("3 3 E");
            commandBuilder.Append("MMRMMRMRRM");


            BootStrapper.Init(commandBuilder.ToString());

            Console.ReadKey();
            
        }
    }
}