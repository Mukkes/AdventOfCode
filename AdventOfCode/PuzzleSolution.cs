using System;
using System.IO;

namespace AdventOfCode
{
    public abstract class PuzzleSolution<ResultType> : IPuzzleSolution
    {
        //private const string InputFolder = "ExampleInputs";
        private const string InputFolder = "Inputs";

        public int Year { get; }
        public int Day { get; }

        protected PuzzleSolution(int year, int day)
        {
            Year = year;
            Day = day;
        }

        private string InputFile => "Year" + Year + @"\" + InputFolder + @"\Day" + Day + ".txt";

        public virtual ResultType ResultPartOne()
        {
            throw new NotImplementedException();
        }

        public virtual ResultType ResultPartTwo()
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

        protected string GetSingleLineInputAsString()
        {
            return GetInputAsStringArray()[0];
        }

        public void PrintResultPartOne()
        {
            PrintResult(ResultPartOne);
        }

        public void PrintResultPartTwo()
        {
            PrintResult(ResultPartTwo);
        }

        private void PrintResult(Func<ResultType> resultFunc)
        {
            try
            {
                Console.WriteLine(resultFunc());
            }
            catch (NotImplementedException)
            {
                Console.WriteLine("Not solved yet.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Input file not found!");
            }
        }
    }
}
