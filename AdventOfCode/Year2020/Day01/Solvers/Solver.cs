using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2020.Day01.Solvers;

[Solver]
public class Solver : IntArraySolver
{
    public override int Year => 2020;

    public override int Day => 01;

    public override object SolvePartOne()
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

    public override object SolvePartTwo()
    {
        for (int i = 0; i < Input.Length; i++)
        {
            for (int j = i + 1; j < Input.Length; j++)
            {
                for (int k = j + 1; k < Input.Length; k++)
                {
                    if (Input[i] + Input[j] + Input[k] == 2020)
                    {
                        return Input[i] * Input[j] * Input[k];
                    }
                }
            }
        }
        throw new Exception();
    }
}
