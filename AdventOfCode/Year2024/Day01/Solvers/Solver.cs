using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2024.Day01.Solvers;

[Solver]
public class Solver : BaseSolver<string[]>
{
    public override object? AnswerPartOne => 1970720;

    public override object? AnswerPartTwo => 17191599;

    protected override IInputParser<string[]> InputParser => new StringArrayParser();

    public override object SolvePartOne()
    {
        var left = new List<int>();
        var right = new List<int>();
        foreach (var s in ParsedInput)
        {
            var numbers = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            left.Add(int.Parse(numbers[0]));
            right.Add(int.Parse(numbers[1]));
        }
        left.Sort();
        right.Sort();
        var totalDistance = 0;
        for (var i = 0; i < left.Count; i++)
        {
            totalDistance += int.Abs(left[i] - right[i]);
        }
        return totalDistance;
    }

    public override object SolvePartTwo()
    {
        var left = new List<int>();
        var right = new Dictionary<int, int>();
        foreach (var s in ParsedInput)
        {
            var numbers = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            left.Add(int.Parse(numbers[0]));
            var rightNumber = int.Parse(numbers[1]);
            if (right.ContainsKey(rightNumber))
            {
                right[rightNumber]++;
            }
            else
            {
                right.Add(rightNumber, 1);
            }
        }
        var similarityScore = 0;
        foreach (var l in left)
        {
            if (right.TryGetValue(l, out int value))
            {
                similarityScore += l * value;
            }
        }
        return similarityScore;
    }
}
