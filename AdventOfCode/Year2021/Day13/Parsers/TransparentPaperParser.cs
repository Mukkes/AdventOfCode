using AdventOfCode.Year2021.Day13.Models;
using AdventOfCodeLibrary.ExtensionClasses;
using AdventOfCodeLibrary.Models;
using AdventOfCodeLibrary.Parsers;

namespace AdventOfCode.Year2021.Day13.Parsers;

internal class TransparentPaperParser : StringArrayParser, IInputParser<TransparentPaper>
{
    public new TransparentPaper Parse(string input)
    {
        var transparentPaper = new TransparentPaper();
        foreach (var line in base.Parse(input))
        {
            if (line.Contains(','))
            {
                var lineArray = line.Split(',');
                transparentPaper.Points.Add(new Point2D(int.Parse(lineArray[0]), int.Parse(lineArray[1])));
            }
            else if (line.Contains('x'))
            {
                transparentPaper.Folds.Add(new Fold('x', line.ExtractInteger()));
            }
            else if (line.Contains('y'))
            {
                transparentPaper.Folds.Add(new Fold('y', line.ExtractInteger()));
            }
        }
        return transparentPaper;
    }
}
