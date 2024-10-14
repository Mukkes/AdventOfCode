using AdventOfCode.Year2021.Day14.Models;
using AdventOfCodeLibrary.Parsers;

namespace AdventOfCode.Year2021.Day14.Parsers;
internal class PolymerFormulaParser : StringArrayParser, IInputParser<PolymerFormula>
{
    public new PolymerFormula Parse(string input)
    {
        var polymerFormula = new PolymerFormula();
        var stringArray = base.Parse(input);
        polymerFormula.Template = stringArray[0].ToList();
        foreach (var line in stringArray[2..])
        {
            var pair = line.Split(" -> ");
            polymerFormula.Rules.Add(pair[0], pair[1]);
        }
        return polymerFormula;
    }
}
