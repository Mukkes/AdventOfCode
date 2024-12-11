using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2024.Day11.Solvers;

[Solver]
public class Solver : BaseSolver<List<long>>
{
    public override int Year => 2024;

    public override int Day => 11;

    public override object? AnswerPartOne => 222461;

    public override object? AnswerPartTwo => 264350935776416;

    protected override IInputParser<List<long>> InputParser => new LongListParser(" ");

    private Dictionary<(long stone, int blinks), long> _stonesDictionary = new Dictionary<(long stone, int blinks), long> ();

    public override object SolvePartOne()
    {
        return 
            ParsedInput
            .Select(stone => GetSumStone(stone, 25))
            .Sum();
    }

    public override object SolvePartTwo()
    {
        return
            ParsedInput
            .Select(stone => GetSumStone(stone, 75))
            .Sum();
    }

    private long GetSumStone(long stone, int blinks)
    {
        if (blinks == 0)
        {
            return 1;
        }
        if (_stonesDictionary.TryGetValue((stone, blinks), out long value))
        {
            return value;
        }
        var result = 0L;
        var stoneString = stone.ToString();
        if (stone == 0)
        {
            result = GetSumStone(1, blinks - 1);
        }
        else if (stoneString.Count() % 2 == 0)
        {
            result = 
                GetSumStone(long.Parse(stoneString[0..(stoneString.Count() / 2)]), blinks - 1) +
                GetSumStone(long.Parse(stoneString[(stoneString.Count() / 2)..]), blinks - 1);
        }
        else
        {
            result = GetSumStone(stone * 2024, blinks - 1);
        }
        _stonesDictionary.TryAdd((stone, blinks), result);
        return result;
    }
}
