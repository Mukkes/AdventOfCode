using System;
using System.IO;

namespace AdventOfCode.Year2020
{
    public class Day1
    {
        public static int Solve()
        {
            var input = GetInput(@"Year2020\Inputs\Day1.txt");
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

        private static int[] GetInput(string file)
        {
            string input = File.ReadAllText(file);
            var inputStringArray = input.Split(Environment.NewLine);
            return Array.ConvertAll(inputStringArray, int.Parse);
        }
    }
}
