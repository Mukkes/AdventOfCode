using AdventOfCode.Year2021.Day20.Models;
using AdventOfCode.Year2021.Day20.Parsers;
using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2021.Day20.Solvers;

[Solver]
public class Solver : BaseSolver<TrenchMap>
{
    public override object? AnswerPartOne => 5097;

    public override object? AnswerPartTwo => 17987;

    protected override IInputParser<TrenchMap> InputParser => new TrenchMapParser();

    public override object SolvePartOne()
    {
        var trenchMap = ParsedInput;
        trenchMap = Enhance(trenchMap, 2);
        trenchMap.Print();
        Console.WriteLine();
        return trenchMap.CountLightPixels();
    }

    public override object SolvePartTwo()
    {
        var trenchMap = ParsedInput;
        trenchMap = Enhance(trenchMap, 50);
        trenchMap.Print();
        Console.WriteLine();
        return trenchMap.CountLightPixels();
    }

    private TrenchMap Enhance(TrenchMap trenchMap, int x)
    {
        for (var i = 0; i < x; i++)
        {
            trenchMap = trenchMap.Enhance();
            //trenchMap.Print();
            //Console.WriteLine();
        }
        return trenchMap;
    }
}
