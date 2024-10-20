using AdventOfCode.Year2021.Day18.Models;
using AdventOfCode.Year2021.Day18.Parsers;
using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2021.Day18.Solvers;

[Solver]
public class Solver : BaseSolver<List<Pair>>
{
    public override int Year => 2021;

    public override int Day => 18;

    public override object? AnswerPartOne => 4480;

    public override object? AnswerPartTwo => 4676;

    protected override IInputParser<List<Pair>> InputParser => new PairParser();

    public override object SolvePartOne()
    {
        var pair = AddPairs(ParsedInput);
        return pair.Magnitude();
    }

    public override object SolvePartTwo()
    {
        var largestMagnitude = 0L;
        foreach (var pair1 in ParsedInput)
        {
            foreach (var pair2 in ParsedInput)
            {
                if (pair1 == pair2)
                {
                    continue;
                }
                var pair = Addition(pair1.Clone(), pair2.Clone());
                //Console.WriteLine("-------------");
                //Console.WriteLine("after addition: " + pair.ToString());
                Explode(pair);
                var magnitude = pair.Magnitude();
                //Console.WriteLine("magnitude: " + magnitude);
                if (magnitude > largestMagnitude)
                {
                    largestMagnitude = magnitude;
                }
                pair = Addition(pair2.Clone(), pair1.Clone());
                //Console.WriteLine("-------------");
                //Console.WriteLine("after addition: " + pair.ToString());
                Explode(pair);
                magnitude = pair.Magnitude();
                //Console.WriteLine("magnitude: " + magnitude);
                if (magnitude > largestMagnitude)
                {
                    largestMagnitude = magnitude;
                }
            }
        }
        return largestMagnitude;
    }

    public Pair AddPairs(List<Pair> pairs)
    {
        var pair = pairs[0].Clone();
        for (int i = 1; i < ParsedInput.Count; i++)
        {
            pair = Addition(pair, ParsedInput[i].Clone());
            //Console.WriteLine("-------------");
            //Console.WriteLine("after addition: " + pair.ToString());
            Explode(pair);
        }
        return pair;
    }

    private Pair Addition(Pair pair1, Pair pair2)
    {
        var pair = new Pair(null);
        pair1.Parent = pair;
        pair2.Parent = pair;
        pair.LeftPair = pair1;
        pair.RightPair = pair2;
        return pair;
    }

    private void Explode(Pair pair)
    {
        while (pair.Explode())
        {
            //Console.WriteLine("after explode:  " + pair.ToString());
        }
        Split(pair);
    }

    private void Split(Pair pair)
    {
        if (pair.Split())
        {
            //Console.WriteLine("after split:    " + pair.ToString());
            Explode(pair);
        }
    }
}
