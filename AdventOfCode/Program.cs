using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    public class Program
    {
        private static List<PuzzleSolution> Solutions2021 => new List<PuzzleSolution>()
        {
            new Year2021.Day5(),
            new Year2021.Day4(),
            new Year2021.Day3(),
            new Year2021.Day2(),
            new Year2021.Day1()
        };

        private static List<PuzzleSolution> Solutions2020 => new List<PuzzleSolution>()
        {
            new Year2020.Day1()
        };

        private static void Main(string[] args)
        {
            PrintSolutions(2021, Solutions2021);
            PrintSolutions(2020, Solutions2020);
            Console.ReadKey();
        }

        private static void PrintSolutions(int year, List<PuzzleSolution> solutions)
        {
            Console.WriteLine("Year " + year);
            foreach (var solution in solutions)
            {
                PrintSolution(solution);
            }
        }

        private static void PrintSolution(PuzzleSolution solution)
        {
            Console.Write("Day ");
            Console.WriteLine(solution.Day);
            Console.Write("Part 1: ");
            try
            {
                Console.WriteLine(solution.ResultPartOne());
            }
            catch (NotImplementedException)
            {
                Console.WriteLine("Not solved yet.");
            }
            Console.Write("Part 2: ");
            try
            {
                Console.WriteLine(solution.ResultPartTwo());
            }
            catch (NotImplementedException)
            {
                Console.WriteLine("Not solved yet.");
            }
            Console.WriteLine();
        }
    }
}
