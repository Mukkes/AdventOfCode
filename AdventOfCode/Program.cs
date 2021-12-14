using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Program
    {
        private static void Main(string[] args)
        {
            //PrintSolutions(2021, PuzzleSolutionRegister.Year2021);
            //PrintSolutions(2020, PuzzleSolutionRegister.Year2020);
            PrintSolution(PuzzleSolutionRegister.Year2021.First());
            Console.ReadKey();
        }

        private static void PrintSolutions(int year, List<IPuzzleSolution> solutions)
        {
            Console.WriteLine("Year " + year);
            foreach (var solution in solutions)
            {
                PrintSolution(solution);
            }
        }

        private static void PrintSolution(IPuzzleSolution solution)
        {
            Console.Write("Day ");
            Console.WriteLine(solution.Day);
            Console.Write("Part 1: ");
            solution.PrintResultPartOne();
            Console.Write("Part 2: ");
            solution.PrintResultPartTwo();
            Console.WriteLine();
        }
    }
}
