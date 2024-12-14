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
    public override object? AnswerPartOne => 5248;

    public override object? AnswerPartTwo => 4507;

    protected override IInputParser<Manual> InputParser => new ManualParser();

    private List<List<int>> _correctUpdates = new List<List<int>>();
    private List<List<int>> _incorrectUpdates = new List<List<int>>();

    public override object SolvePartOne()
    {
        if (_correctUpdates.Count <= 0)
        {
            ProcessUpdates();
        }
        return
            _correctUpdates
            .Select(update => update[update.Count / 2])
            .Sum();
    }

    public override object SolvePartTwo()
    {
        if (_incorrectUpdates.Count <= 0)
        {
            ProcessUpdates();
        }
        return
            _incorrectUpdates
            .Select(update => update[update.Count / 2])
            .Sum();
    }

    private void ProcessUpdates()
    {
        foreach (var update in ParsedInput.Updates)
        {
            var rightOrder = true;
            for (var updateIndex = 0; updateIndex < update.Count; updateIndex++)
            {
                for (var beforeIndex = updateIndex - 1; beforeIndex >= 0; beforeIndex--)
                {
                    if (ParsedInput.Rules.Contains((update[updateIndex], update[beforeIndex])))
                    {
                        var temp = update[updateIndex];
                        update[updateIndex] = update[beforeIndex];
                        update[beforeIndex] = temp;
                        rightOrder = false;
                        updateIndex = 0;
                        break;
                    }
                }
                if (!rightOrder)
                {
                    continue;
                }
                for (var afterIndex = updateIndex + 1; afterIndex < update.Count; afterIndex++)
                {
                    if (ParsedInput.Rules.Contains((update[afterIndex], update[updateIndex])))
                    {
                        var temp = update[updateIndex];
                        update[updateIndex] = update[afterIndex];
                        update[afterIndex] = temp;
                        rightOrder = false;
                        updateIndex = 0;
                        break;
                    }
                }
            }
            if (rightOrder)
            {
                _correctUpdates.Add(update);
            }
            else
            {
                _incorrectUpdates.Add(update);
            }
        }
    }
}
