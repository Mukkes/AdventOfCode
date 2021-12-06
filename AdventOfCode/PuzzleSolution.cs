using System;
using System.IO;

namespace AdventOfCode
{
    abstract class PuzzleSolution<ResultType> : IPuzzleSolution
    {
        private readonly bool _useExampleInput;
        private string _inputFolder => _useExampleInput ? "ExampleInputs" : "Inputs";
        public int Year { get; }
        public int Day { get; }

        protected PuzzleSolution(int year, int day) : this(year, day, false) { }

        protected PuzzleSolution(int year, int day, bool useExampleInput)
        {
            Year = year;
            Day = day;
            _useExampleInput = useExampleInput;
        }

        protected string InputFile => "Year" + Year + @"\" + _inputFolder + @"\Day" + Day + ".txt";

        public virtual ResultType ResultPartOne()
        {
            throw new NotImplementedException();
        }

        public virtual ResultType ResultPartTwo()
        {
            throw new NotImplementedException();
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
