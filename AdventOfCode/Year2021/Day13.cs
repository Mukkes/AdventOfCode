using AdventOfCode.InputParser;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2021
{
    public class Day13 : PuzzleSolution<List<(int x, int y)>, int>
    {
        private List<(char direction, int position)> Folds
        {
            get
            {
                if (_useExampleInput)
                {
                    return new List<(char direction, int position)>()
                    {
                        ('y', 7),
                        ('x', 5)
                    };
                }
                else
                {
                    return new List<(char direction, int position)>()
                    {
                        ('x', 655),
                        ('y', 447),
                        ('x', 327),
                        ('y', 223),
                        ('x', 163),
                        ('y', 111),
                        ('x', 81),
                        ('y', 55),
                        ('x', 40),
                        ('y', 27),
                        ('y', 13),
                        ('y', 6),
                    };
                }
            }
        }

        public Day13() : this(false) { }
        public Day13(bool useExampleInput) : base(2021, 13, useExampleInput)
        {
            InputParser = new MultiLineToCoordinatesParser(InputFile);
        }

        public override int ResultPartOne()
        {
            var coordinates = new List<(int x, int y)>(Input);
            var fold = Folds.First();
            Fold(coordinates, fold.direction, fold.position);
            var result = coordinates.Distinct().Count();
            return result;
        }

        public override int ResultPartTwo()
        {
            var coordinates = new List<(int x, int y)>(Input);
            foreach (var fold in Folds)
            {
                Fold(coordinates, fold.direction, fold.position);
            }
            var paper = coordinates.Distinct().OrderBy(c => c.y).ThenBy(c => c.x);
            Console.WriteLine();
            for (int y = 0; y < 6; y++)
            {
                for (int x = 0; x < 39; x++)
                {
                    if (coordinates.Contains((x, y)))
                    {
                        Console.Write('#');
                    }
                    else
                    {
                        Console.Write('.');
                    }
                }
                Console.WriteLine();
            }
            return 0;
        }

        private void Fold(List<(int x, int y)> coordinates, char direction, int position)
        {
            if (direction == 'x')
            {
                FoldX(coordinates, position);
            }
            else if (direction == 'y')
            {
                FoldY(coordinates, position);
            }
        }

        private void FoldX(List<(int x, int y)> coordinates, int position)
        {
            for (int i = 0; i < coordinates.Count; i++)
            {
                if (coordinates[i].x > position)
                {
                    var j = coordinates[i].x - position;
                    coordinates[i] = (position - j, coordinates[i].y);
                }
                if (coordinates[i].x == position)
                {
                    throw new Exception();
                }
            }
        }

        private void FoldY(List<(int x, int y)> coordinates, int position)
        {
            for (int i = 0; i < coordinates.Count; i++)
            {
                if (coordinates[i].y > position)
                {
                    var j = coordinates[i].y - position;
                    coordinates[i] = (coordinates[i].x, position - j);
                }
                if (coordinates[i].y == position)
                {
                    throw new Exception();
                }
            }
        }
    }
}
