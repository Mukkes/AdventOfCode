using System.Collections.Generic;

namespace AdventOfCode
{
    class PuzzleSolutionRegister
    {
        public static List<IPuzzleSolution> Year2021 => new List<IPuzzleSolution>()
        {
            new Year2021.Day14(),
            new Year2021.Day13(),
            new Year2021.Day12(),
            new Year2021.Day11(),
            new Year2021.Day10(),
            new Year2021.Day9(),
            new Year2021.Day8(),
            new Year2021.Day7(),
            new Year2021.Day6(),
            new Year2021.Day5(),
            new Year2021.Day4(),
            new Year2021.Day3(),
            new Year2021.Day2(),
            new Year2021.Day1()
        };

        public static List<IPuzzleSolution> Year2020 => new List<IPuzzleSolution>()
        {
            new Year2020.Day1()
        };
    }
}
