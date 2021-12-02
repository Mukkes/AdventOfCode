using System;
using System.IO;

namespace AdventOfCode
{
    public abstract class PuzzleSolution
    {
        public abstract int Year { get; }
        public abstract int Day { get; }
        public abstract int ResultPartOne();
        public abstract int ResultPartTwo();

        private string InputFile => "Year" + Year + @"\Inputs\Day" + Day + ".txt";

        public string GetInputAsString()
        {
            return File.ReadAllText(InputFile);
        }

        public string[] GetInputAsStringArray()
        {
            string input = GetInputAsString();
            return input.Split(Environment.NewLine);
        }

        public int[] GetInputAsIntArray()
        {
            var input = GetInputAsStringArray();
            return Array.ConvertAll(input, int.Parse);
        }
    }
}
