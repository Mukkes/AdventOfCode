using AdventOfCode.InputParser;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AdventOfCode.Year2021
{
    public class Day9 : PuzzleSolution<string[], int>
    {
        public Day9() : this(false) { }
        public Day9(bool useExampleInput) : base(2021, 9, useExampleInput)
        {
            InputParser = new MultiLineToStringArrayParser(InputFile);
        }

        public override int ResultPartOne()
        {
            var result = 0;
            for (int x = 0; x < Input.Length; x++)
            {
                for (int y = 0; y < Input[0].Length; y++)
                {
                    if (IsLowest(x, y))
                    {
                        result += int.Parse(Input[x][y].ToString()) + 1;
                    }
                }
            }
            return result;
        }

        public override int ResultPartTwo()
        {
            var basinSizes = new List<int>();
            for (int x = 0; x < Input.Length; x++)
            {
                for (int y = 0; y < Input[0].Length; y++)
                {
                    if (IsLowest(x, y))
                    {
                        basinSizes.Add(BasinSize(new List<Point>(), x, y));
                    }
                }
            }
            var s1 = basinSizes.Max();
            basinSizes.Remove(s1);
            var s2 = basinSizes.Max();
            basinSizes.Remove(s2);
            var s3 = basinSizes.Max();
            return s1 * s2 * s3;
        }

        private bool IsLowest(int x, int y)
        {
            var value = Input[x][y];
            // Up
            if (x - 1 >= 0 && value >= Input[x - 1][y])
            {
                return false;
            }
            // Down
            if (x + 1 < Input.Length && value >= Input[x + 1][y])
            {
                return false;
            }
            // Left
            if (y - 1 >= 0 && value >= Input[x][y - 1])
            {
                return false;
            }
            // Right
            if (y + 1 < Input[0].Length && value >= Input[x][y + 1])
            {
                return false;
            }
            return true;
        }

        private int BasinSize(List<Point> points, int x, int y)
        {
            if (points.Contains(new Point(x, y)))
            {
                return 0;
            }
            points.Add(new Point(x, y));
            int size = 1;
            // Up
            if (x - 1 >= 0 && int.Parse(Input[x - 1][y].ToString()) < 9)
            {
                size += BasinSize(points, x - 1, y);
            }
            // Down
            if (x + 1 < Input.Length && int.Parse(Input[x + 1][y].ToString()) < 9)
            {
                size += BasinSize(points, x + 1, y);
            }
            // Left
            if (y - 1 >= 0 && int.Parse(Input[x][y - 1].ToString()) < 9)
            {
                size += BasinSize(points, x, y - 1);
            }
            // Right
            if (y + 1 < Input[0].Length && int.Parse(Input[x][y + 1].ToString()) < 9)
            {
                size += BasinSize(points, x, y + 1);
            }
            return size;
        }
    }
}
