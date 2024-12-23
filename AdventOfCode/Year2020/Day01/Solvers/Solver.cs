﻿using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2020.Day01.Solvers;

[Solver]
public class Solver : BaseSolver<int[]>
{
    public override object? AnswerPartOne => 889779;

    public override object? AnswerPartTwo => 76110336;

    protected override IInputParser<int[]> InputParser => new IntArrayParser();

    public override object SolvePartOne()
    {
        for (int i = 0; i < ParsedInput.Length; i++)
        {
            for (int j = i + 1; j < ParsedInput.Length; j++)
            {
                if (ParsedInput[i] + ParsedInput[j] == 2020)
                {
                    return ParsedInput[i] * ParsedInput[j];
                }
            }
        }
        throw new Exception();
    }

    public override object SolvePartTwo()
    {
        for (int i = 0; i < ParsedInput.Length; i++)
        {
            for (int j = i + 1; j < ParsedInput.Length; j++)
            {
                for (int k = j + 1; k < ParsedInput.Length; k++)
                {
                    if (ParsedInput[i] + ParsedInput[j] + ParsedInput[k] == 2020)
                    {
                        return ParsedInput[i] * ParsedInput[j] * ParsedInput[k];
                    }
                }
            }
        }
        throw new Exception();
    }
}
