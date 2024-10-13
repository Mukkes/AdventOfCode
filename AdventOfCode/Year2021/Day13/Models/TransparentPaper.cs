using AdventOfCodeLibrary.Models;

namespace AdventOfCode.Year2021.Day13.Models;
public class TransparentPaper
{
    internal List<Fold> Folds { get; } = new List<Fold>();
    internal List<Point2D> Points { get; } = new List<Point2D>();
}
