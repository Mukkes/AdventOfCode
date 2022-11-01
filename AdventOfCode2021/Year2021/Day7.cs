using AdventOfCode.InputParser;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2021
{
    class Day7 : PuzzleSolution<List<int>, int>
    {
        public Day7() : base(year: 2021, day: 7)
        {
            InputParser = new SingleLineToIntListParser(InputFile);
        }

        public override int ResultPartOne()
        {
            var leastFuel = int.MaxValue;
            var lowestPosition = Input.Min();
            var highestPosition = Input.Max();
            for (int position = lowestPosition; position <= highestPosition; position++)
            {
                var fuel = 0;
                foreach (var number in Input)
                {
                    fuel += Math.Abs(number - position);
                }
                if (fuel < leastFuel)
                {
                    leastFuel = fuel;
                }
            }
            return leastFuel;
        }

        public override int ResultPartTwo()
        {
            var leastFuel = int.MaxValue;
            var lowestPosition = Input.Min();
            var highestPosition = Input.Max();
            for (int position = lowestPosition; position <= highestPosition; position++)
            {
                var fuel = 0;
                foreach (var number in Input)
                {
                    var n = Math.Abs(number - position);
                    fuel += TriangularNumber(n);
                }
                if (fuel < leastFuel)
                {
                    leastFuel = fuel;
                }
            }
            return leastFuel;
        }

        private int TriangularNumber(int n)
        {
            return n * (n + 1) / 2;
        }
    }
}
