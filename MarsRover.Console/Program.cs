using System;
using System.Text;

namespace MarsRover.ConsoleUI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var sb = new StringBuilder();

            sb.AppendLine("5 5");
            sb.AppendLine("1 2 N");
            sb.AppendLine("LMLMLMLMM");
            sb.AppendLine("3 3 E");
            sb.Append("MMRMMRMRRM");

            BootStrapper.Init(sb.ToString());

            Console.ReadKey();
            
        }
    }
}