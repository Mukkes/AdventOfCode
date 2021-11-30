using System;

namespace AdventOfCode.Year2020
{
    public class Day1
    {
        public static int Solve()
        {
            var input = Program.ReadInputFromFile(@"Year2020\Inputs\Day1.txt");
            for (int i = 0;i < input.Length; i++)
            {
                for (int j = i + 1; j < input.Length; j++)
                {
                    if (input[i] + input[j] == 2020)
                    {
                        return input[i] * input[j];
                    }
                }
            }
            throw new Exception();
        }
    }
}
