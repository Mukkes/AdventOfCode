using System;
using System.IO;

namespace AdventOfCode
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Year 2021");
            Console.WriteLine("Day  1: " + Year2021.Day1.PartOne() + ", " + Year2021.Day1.PartTwo());
            Console.WriteLine();
            Console.WriteLine("Year 2020");
            Console.WriteLine("Day  1: " + Year2020.Day1.Solve());
            Console.ReadKey();
        }

        public static int[] ReadInputFromFile(string file)
        {
            var streamReader = new StreamReader(file);
            string input = streamReader.ReadToEnd();
            var inputStringArray = input.Split(Environment.NewLine);
            return Array.ConvertAll(inputStringArray, int.Parse);
        }
    }
}
