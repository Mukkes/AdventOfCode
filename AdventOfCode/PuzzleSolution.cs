using System;
using System.IO;

namespace AdventOfCode
{
    public abstract class PuzzleSolution
    {
        public abstract int Day { get;  }
        public abstract int ResultPartOne();
        public abstract int ResultPartTwo();

        public string[] GetInputAsStringArray(string file)
        {
            string input = File.ReadAllText(file);
            return input.Split(Environment.NewLine);
        }

        public int[] GetInputAsIntArray(string file)
        {
            var input = GetInputAsStringArray(file);
            return Array.ConvertAll(input, int.Parse);
        }
    }
}
