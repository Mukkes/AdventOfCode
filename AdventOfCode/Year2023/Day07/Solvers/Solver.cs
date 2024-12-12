using AdventOfCode.Year2023.Day07.Models;
using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2023.Day07.Solvers;

[Solver]
public class Solver : BaseSolver<string[]>
{
    public override object? AnswerPartOne => 246795406L;

    public override object? AnswerPartTwo => 249356515L;

    protected override IInputParser<string[]> InputParser => new StringArrayParser();

    public override object SolvePartOne()
    {
        var hands = GetHands();
        var orderdHands = hands.OrderBy(x => x.Score).ToList();
        var sum = 0L;
        for (var i = 1; i <= orderdHands.Count; i++)
        {
            sum += orderdHands[i - 1].Bid * i;
        }
        return sum;
    }

    public override object SolvePartTwo()
    {
        var hands = GetHands();
        var orderdHands = hands.OrderBy(x => x.JokerScore).ToList();
        var sum = 0L;
        for (var i = 1; i <= orderdHands.Count; i++)
        {
            sum += orderdHands[i - 1].Bid * i;
        }
        return sum;
    }

    private List<Hand> GetHands()
    {
        var hands = new List<Hand>();
        foreach (var line in ParsedInput)
        {
            var s = line.Split(' ');
            hands.Add(new Hand(s[0], long.Parse(s[1])));
        }
        return hands;
    }
}
