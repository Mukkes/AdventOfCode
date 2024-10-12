using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2021.Day06.Solvers;

[Solver]
public class Solver : StringSolver
{
    public override int Year => 2021;

    public override int Day => 6;

    public override object? AnswerPartOne => 389726;

    public override object? AnswerPartTwo => 1743335992042;

    public override object SolvePartOne()
    {
        var lanternfish = ParsedInput.Split(',').Select(int.Parse).ToList();
        var days = 80;
        for (var day = 0; day < days; day++)
        {
            lanternfish = lanternfish.Select(x => --x).ToList();
            lanternfish.Where(x => x == -1).ToList().ForEach(x => lanternfish.Add(8));
            lanternfish = lanternfish.Select(x => x == -1 ? 6 : x).ToList();
        }
        return lanternfish.Count;
    }

    public override object SolvePartTwo()
    {
        var lanternfish = new long[9];
        ParsedInput.Split(',').Select(long.Parse).ToList().ForEach(x => ++lanternfish[x]);
        var days = 256;
        for (var day = 0; day < days; day++)
        {
            var x = lanternfish[0];
            for (var i = 0; i < 8; i++)
            {
                lanternfish[i] = lanternfish[i + 1];
            }
            lanternfish[8] = x;
            lanternfish[6] += x;
        }
        return lanternfish.Sum();
    }
}
