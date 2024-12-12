using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2024.Day11.Solvers;

[Solver]
public class Solver : BaseSolver<List<long>>
{
    public override object? AnswerPartOne => 222461;

    public override object? AnswerPartTwo => 264350935776416;

    protected override IInputParser<List<long>> InputParser => new LongListParser(" ");
    private Dictionary<(long stone, int blinks), long> _stonesDictionary = new Dictionary<(long stone, int blinks), long> ();

    public override object SolvePartOne()
    {
        var stones = new List<long>(ParsedInput);
        for (var i = 0; i < 25; i++)
        {
            var newStones = new List<long>();
            foreach (var stone in stones)
            {
                newStones.AddRange(ApplyRules(stone));
            }
            stones = newStones;
        }
        return stones.Count();
    }

    public override object SolvePartTwo()
    {
        var sum = 0L;
        foreach (var stone in new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9})
        {
            StoreBasicStones(stone, 39);
        }
        foreach (var stone in ParsedInput)
        {
            sum += ApplyRules(stone, 75);
        }
        return sum;
    }

    private long StoreBasicStones(long beginStone, int blinks)
    {
        var stones = new List<long>() { beginStone };
        for (var i = 0; i < blinks; i++)
        {
            var newStones = new List<long>();
            foreach (var stone in stones)
            {
                newStones.AddRange(ApplyRules(stone));
            }
            stones = newStones;
            _stonesDictionary.Add((beginStone, i + 1), stones.Count());
        }
        return stones.Count();
    }

    private long ApplyRules(long beginStone, int blinks)
    {
        var sum = 0L;
        var stones = new List<long>() { beginStone };
        for (var i = 0; i < blinks; i++)
        {
            var newStones = new List<long>();
            foreach (var stone in stones)
            {
                if (_stonesDictionary.TryGetValue((stone, blinks - i), out long value))
                {
                    sum += value;
                }
                else
                {
                    newStones.AddRange(ApplyRules(stone));
                }
            }
            stones = newStones;
        }
        return stones.Count() + sum;
    }

    private List<long> ApplyRules(long stone)
    {
        var stones = new List<long>();
        if (stone == 0)
        {
            return [1];
        }
        var stoneString = stone.ToString();
        if (stoneString.Count() % 2 == 0)
        {
            return
                [(long.Parse(stoneString[0..(stoneString.Count() / 2)])), 
                (long.Parse(stoneString[(stoneString.Count() / 2)..]))];
        }
        return [stone * 2024];
    }
}
