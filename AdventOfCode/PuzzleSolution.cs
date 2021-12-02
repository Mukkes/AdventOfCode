using System;
using System.IO;

namespace AdventOfCode
{
    public abstract class PuzzleSolution
    {
        public readonly int Year;
        public readonly int Day;

        protected PuzzleSolution(int year, int day)
        {
            Year = year;
            Day = day;
        }

        private string InputFile => "Year" + Year + @"\Inputs\Day" + Day + ".txt";

        public virtual int ResultPartOne()
        {
            throw new NotImplementedException();
        }

        public virtual int ResultPartTwo()
        {
            throw new NotImplementedException();
        }

        protected string[] GetInputAsStringArray()
        {
            return File.ReadAllLines(InputFile);
        }

        protected int[] GetInputAsIntArray()
        {
            var input = GetInputAsStringArray();
            return Array.ConvertAll(input, int.Parse);
        }
    }
}
