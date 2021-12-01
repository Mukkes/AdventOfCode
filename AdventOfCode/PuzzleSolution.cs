using System;
using System.IO;

namespace AdventOfCode
{
    public abstract class PuzzleSolution
    {
        public abstract int Day { get;  }
        public abstract int ResultPartOne();
        public abstract int ResultPartTwo();

        public int[] GetInput(string file)
        {
            string input = File.ReadAllText(file);
            var inputStringArray = input.Split(Environment.NewLine);
            return Array.ConvertAll(inputStringArray, int.Parse);
        }
    }
}
