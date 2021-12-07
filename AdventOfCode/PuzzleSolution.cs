using AdventOfCode.InputParser;
using System;
using System.IO;

namespace AdventOfCode
{
    abstract class PuzzleSolution<InputType, ResultType> : IPuzzleSolution
    {
        private readonly bool _useExampleInput;

        protected PuzzleSolution(int year, int day) : this(year, day, false) { }

        protected PuzzleSolution(int year, int day, bool useExampleInput)
        {
            Year = year;
            Day = day;
            _useExampleInput = useExampleInput;
        }

        public int Year { get; }
        public int Day { get; }
        private string _inputFolder => _useExampleInput ? "ExampleInputs" : "Inputs";
        protected string InputFile => "Year" + Year + @"\" + _inputFolder + @"\Day" + Day + ".txt";
        protected IInputParser<InputType> InputParser { get; set; }
        protected InputType Input => InputParser.Input;

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
