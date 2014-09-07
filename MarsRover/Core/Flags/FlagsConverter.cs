using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Core.Flags
{
    public static class FlagsConverter
    {
        private static Dictionary<DirectionFlags, string> DirectionTable { get; set; }
        private static Dictionary<InstructionFlags, string> InstructionTable { get; set; }

        static FlagsConverter()
        {
            DirectionTable = new Dictionary<DirectionFlags, string>();
            InstructionTable = new Dictionary<InstructionFlags, string>();
        }

        public static void Init()
        {
            InitDirectionTable();
            InitInstructionTable();
        }

        private static void InitInstructionTable()
        { 
            InstructionTable.Add(InstructionFlags.Left  , "L");
            InstructionTable.Add(InstructionFlags.Right , "R");
            InstructionTable.Add(InstructionFlags.Move  , "M");
        }

        private static void InitDirectionTable()
        {
            DirectionTable.Add(DirectionFlags.East, "E");
            DirectionTable.Add(DirectionFlags.North, "N");
            DirectionTable.Add(DirectionFlags.South, "S");
            DirectionTable.Add(DirectionFlags.West, "W");
        }

        public static string GetDirectionValue(DirectionFlags key)
        {
            return DirectionTable[key];
        }

        public static DirectionFlags GetDirectionKey(string value)
        {
            return DirectionTable.Where(p => p.Value == value).Select(p => p.Key).FirstOrDefault();
        }

        public static InstructionFlags GetInstructionKey(string value)
        {
            return InstructionTable.Where(p => p.Value == value).Select(p => p.Key).FirstOrDefault();
        }

        public static string GetInstructionValue(InstructionFlags key)
        {
            return InstructionTable[key];
        }
    }
}
