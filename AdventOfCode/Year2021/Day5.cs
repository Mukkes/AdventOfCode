using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AdventOfCode.Year2021
{
    public class Day5 : PuzzleSolution
    {
        public Day5() : base(year: 2021, day: 5) { }

        private string[] Input => GetInputAsStringArray();
        private Dictionary<Point, int> diagram;

        public override int ResultPartOne()
        {
            diagram = new Dictionary<Point, int>();
            foreach (var line in Input)
            {
                var coordinates = line.Split(new string[] { ",", " -> " }, StringSplitOptions.None).Select(int.Parse).ToArray();
                IncrementLine(coordinates);
            }
            var result = 0;
            foreach (var point in diagram)
            {
                if (point.Value > 1)
                {
                    result++;
                }
            }
            return result;
        }

        public override int ResultPartTwo()
        {
            diagram = new Dictionary<Point, int>();
            foreach (var line in Input)
            {
                var coordinates = line.Split(new string[] { ",", " -> " }, StringSplitOptions.None).Select(int.Parse).ToArray();
                IncrementLine(coordinates);
                IncrementDiagonalLine(coordinates);
            }
            var result = 0;
            foreach (var point in diagram)
            {
                if (point.Value > 1)
                {
                    result++;
                }
            }
            return result;
        }

        private void IncrementLine(int[] coordinates)
        {
            if (coordinates[0] == coordinates[2])
            {
                if (coordinates[1] > coordinates[3])
                {
                    IncrementVerticalLine(coordinates[0], coordinates[3], coordinates[1]);
                }
                else
                {
                    IncrementVerticalLine(coordinates[0], coordinates[1], coordinates[3]);
                }
            }
            else if (coordinates[1] == coordinates[3])
            {
                if (coordinates[0] > coordinates[2])
                {
                    IncrementHorizontalLine(coordinates[1], coordinates[2], coordinates[0]);
                }
                else
                {
                    IncrementHorizontalLine(coordinates[1], coordinates[0], coordinates[2]);
                }
            }
        }

        private void IncrementDiagonalLine(int[] coordinates)
        {
            if (coordinates[0] != coordinates[2] && coordinates[1] != coordinates[3])
            {
                IncrementDiagonalLine(coordinates[0], coordinates[1], coordinates[2], coordinates[3]);
            }
        }

        private void IncrementVerticalLine(int x, int y1, int y2)
        {
            for (var y = y1; y <= y2; y++)
            {
                IncrementPointInDiagram(new Point(x, y));
            }
        }

        private void IncrementHorizontalLine(int y, int x1, int x2)
        {
            for (var x = x1; x <= x2; x++)
            {
                IncrementPointInDiagram(new Point(x, y));
            }
        }

        private void IncrementDiagonalLine(int x1, int y1, int x2, int y2)
        {
            var incrementX = x1 > x2 ? -1 : 1;
            var incrementY = y1 > y2 ? -1 : 1;
            var x = x1;
            var y = y1;
            while (x != (x2 + incrementX))
            {
                IncrementPointInDiagram(new Point(x, y));
                x += incrementX;
                y += incrementY;
            }
        }

        private void IncrementPointInDiagram(Point point)
        {
            if (diagram.TryGetValue(point, out int value))
            {
                diagram.Remove(point);
                diagram.Add(point, ++value);
            }
            else
            {
                diagram.Add(point, 1);
            }
        }
    }
}
