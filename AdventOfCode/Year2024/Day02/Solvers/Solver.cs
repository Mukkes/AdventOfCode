using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2024.Day02.Solvers;

[Solver]
public class Solver : BaseSolver<string[]>
{
    public override object? AnswerPartOne => 390;

    public override object? AnswerPartTwo => 439;

    protected override IInputParser<string[]> InputParser => new StringArrayParser();

    public override object SolvePartOne()
    {
        var safeReports = 0;
        foreach (var report in ParsedInput)
        {
            var levels = Array.ConvertAll(report.Split(' '), int.Parse).ToList();
            if (IsReportSafe(levels))
            {
                safeReports++;
            }
        }
        return safeReports;
    }

    public override object SolvePartTwo()
    {
        var safeReports = 0;
        foreach (var report in ParsedInput)
        {
            var levels = Array.ConvertAll(report.Split(' '), int.Parse).ToList();
            if (IsReportSafe(levels))
            {
                safeReports++;
            }
            else
            {
                for (var i = 0; i < levels.Count; i++)
                {
                    var clone = new List<int>(levels);
                    clone.RemoveAt(i);
                    if (IsReportSafe(clone))
                    {
                        safeReports++;
                        break;
                    }
                }
            }
        }
        return safeReports;
    }

    private bool IsReportSafe(List<int> report)
    {
        for (var i = 1; i < report.Count; i++)
        {
            var difference = int.Abs(report[i - 1] - report[i]);
            if (difference <= 0 || difference > 3)
            {
                return false;
            }
        }
        if (AllIncreasing(report) || AllDecreasing(report))
        {
            return true;
        }
        return false;
    }

    private bool AllIncreasing(List<int> report)
    {
        for (var i = 1; i < report.Count; i++)
        {
            if (report[i - 1] <= report[i])
            {
                return false;
            }
        }
        return true;
    }

    private bool AllDecreasing(List<int> report)
    {
        for (var i = 1; i < report.Count; i++)
        {
            if (report[i - 1] >= report[i])
            {
                return false;
            }
        }
        return true;
    }
}
