using AdventOfCode.InputParser;
using System;
using System.Collections.Generic;

namespace AdventOfCode.Year2021
{
    public class Day15 : PuzzleSolution<int[,], long>
    {
        public Day15() : this(false) { }
        public Day15(bool useExampleInput) : base(2021, 15, useExampleInput)
        {
            InputParser = new MultiLineToMultidimensionalIntArrayParser(InputFile);
        }

        public override long ResultPartOne()
        {
            var positions = CreatePositions(Input);
            SetNeighbors(positions);
            positions[0, 0].FirstCalculateLowestTotalRisk();
            var sqrt = (int)Math.Sqrt(positions.Length) - 1;
            var result = positions[sqrt, sqrt].LowestRisk;
            return result;
        }

        public override long ResultPartTwo()
        {
            var positions = CreatePositionsPartTwo(Input);
            SetNeighbors(positions);
            positions[0, 0].FirstCalculateLowestTotalRisk();
            var sqrt = (int)Math.Sqrt(positions.Length) - 1;
            var result = positions[sqrt, sqrt].LowestRisk;
            return result;
        }

        private Position[,] CreatePositionsPartTwo(int[,] input)
        {
            var oldPostions = CreatePositions(Input);
            var sqrt = (int)Math.Sqrt(input.Length);
            var size = sqrt * 5;
            var positions = new Position[size, size];
            for (int x = 0; x < oldPostions.Length; x++)
            {
                positions[x / sqrt, x % sqrt] = oldPostions[x / sqrt, x % sqrt];
            }
            for (int x = 0; x < positions.Length; x++)
            {
                if (positions[x / size, x % size] == null)
                {
                    var pX = (x / size) - sqrt;
                    var pY = x % size;
                    if (pX < 0)
                    {
                        pX = x / size;
                        pY = (x % size) - sqrt;
                    }
                    positions[x / size, x % size] = new Position(positions[pX, pY].RiskLevel + 1, x / size, x % size);
                }
            }
            return positions;
        }

        private Position[,] CreatePositions(int[,] input)
        {
            var sqrt = (int)Math.Sqrt(input.Length);
            var positions = new Position[sqrt, sqrt];
            for (int x = 0; x < input.Length; x++)
            {
                positions[x / sqrt, x % sqrt] = new Position(input[x / sqrt, x % sqrt], x / sqrt, x % sqrt);
            }
            return positions;
        }

        private void SetNeighbors(Position[,] positions)
        {
            var sqrt = (int)Math.Sqrt(positions.Length);
            for (int i = 0; i < positions.Length; i++)
            {
                var x = i / sqrt;
                var y = i % sqrt;
                var position = positions[x, y];
                try
                {
                    position.Neighbors.Add(positions[x - 1, y]);
                }
                catch { }
                try
                {
                    position.Neighbors.Add(positions[x + 1, y]);
                }
                catch { }
                try
                {
                    position.Neighbors.Add(positions[x, y - 1]);
                }
                catch { }
                try
                {
                    position.Neighbors.Add(positions[x, y + 1]);
                }
                catch { }
            }
        }
    }

    class Position
    {
        public long LowestRisk = 2990;
        public readonly int RiskLevel;
        public List<Position> Neighbors = new List<Position>();
        public readonly int X;
        public readonly int Y;

        public Position(int riskLevel, int x, int y)
        {
            if (riskLevel > 18)
            {
                throw new Exception();
            }
            if (riskLevel > 9)
            {
                RiskLevel = riskLevel - 9;
            }
            else
            {
                RiskLevel = riskLevel;
            }
            X = x;
            Y = y;
        }

        public void FirstCalculateLowestTotalRisk()
        {
            foreach (var neighbor in Neighbors)
            {
                neighbor.CalculateLowestTotalRisk(0);
            }
        }

        public void CalculateLowestTotalRisk(long risk)
        {
            if (risk + RiskLevel >= LowestRisk)
            {
                return;
            }
            LowestRisk = risk + RiskLevel;
            foreach (var neighbor in Neighbors)
            {
                neighbor.CalculateLowestTotalRisk(LowestRisk);
            }
        }
    }
}
