﻿using AdventOfCode.InputParser;
using System;

namespace AdventOfCode.Year2020
{
    class Day1 : PuzzleSolution<int[], int>
    {
        public Day1() : base(year: 2020, day: 1)
        {
            InputParser = new MultiLineToIntArrayParser(InputFile);
        }

        public override int ResultPartOne()
        {
            for (int i = 0; i < Input.Length; i++)
            {
                for (int j = i + 1; j < Input.Length; j++)
                {
                    if (Input[i] + Input[j] == 2020)
                    {
                        return Input[i] * Input[j];
                    }
                }
            }
            throw new Exception();
        }
    }
}
