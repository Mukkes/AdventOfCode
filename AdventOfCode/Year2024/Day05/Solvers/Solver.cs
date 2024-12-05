using AdventOfCode.Year2024.Day05.Models;
using AdventOfCode.Year2024.Day05.Parsers;
using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;
using System.Linq;

namespace AdventOfCode.Year2024.Day05.Solvers;

[Solver]
public class Solver : BaseSolver<Manual>
{
    public override int Year => 2024;

    public override int Day => 5;

    //public override object? AnswerPartOne => ;

    //public override object? AnswerPartTwo => ;

    protected override IInputParser<Manual> InputParser => new ManualParser();

    public override object SolvePartOne()
    {
        var sum = 0;
        foreach (var update in ParsedInput.Updates)
        {
            var rightOrder = true;
            for (var updateIndex = 0; updateIndex < update.Count; updateIndex++)
            {
                for (var beforeIndex = updateIndex - 1; beforeIndex >= 0; beforeIndex--)
                {
                    if (ParsedInput.Rules.Contains((update[updateIndex], update[beforeIndex])))
                    {
                        rightOrder = false;
                        break;
                    }
                }
                for (var afterIndex = updateIndex + 1; afterIndex < update.Count; afterIndex++)
                {
                    if (ParsedInput.Rules.Contains((update[afterIndex], update[updateIndex])))
                    {
                        rightOrder = false;
                        break;
                    }
                }
                if (!rightOrder)
                {
                    break;
                }
            }
            if (rightOrder)
            {
                sum += update[update.Count / 2];
            }
        }
        return sum;
    }

    public override object SolvePartTwo()
    {
        return 0;
    }
}
