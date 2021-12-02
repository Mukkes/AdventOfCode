using System;
using System.IO;

namespace AdventOfCode
{
    public abstract class PuzzleSolution
    {
        public abstract int Year { get; }
        public abstract int Day { get; }

        private string InputFile => "Year" + Year + @"\Inputs\Day" + Day + ".txt";

        public virtual int ResultPartOne()
        {
            throw new NotImplementedException();
        }

        public virtual int ResultPartTwo()
        {
            throw new NotImplementedException();
        }

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
