using AdventOfCode.Year2021.Day13.Models;
using AdventOfCode.Year2021.Day13.Parsers;
using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Models;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2021.Day13.Solvers;

[Solver]
public class Solver : BaseSolver<TransparentPaper>
{
    public override int Year => 2021;

    public override int Day => 13;

    public override object? AnswerPartOne => 684;

    //public override object? AnswerPartTwo => "JRZBLGKH";
    public override object? AnswerPartTwo =>
@"..##.###..####.###..#.....##..#..#.#..#
...#.#..#....#.#..#.#....#..#.#.#..#..#
...#.#..#...#..###..#....#....##...####
...#.###...#...#..#.#....#.##.#.#..#..#
#..#.#.#..#....#..#.#....#..#.#.#..#..#
.##..#..#.####.###..####..###.#..#.#..#";

    protected override IInputParser<TransparentPaper> InputParser => new TransparentPaperParser();

    public override object SolvePartOne()
    {
        var transparentPaper = ParsedInput;
        var coordinates = transparentPaper.Points;
        var fold = transparentPaper.Folds.First();
        Fold(coordinates, fold.Direction, fold.Position);
        var result = coordinates.Distinct().Count();
        return result;
    }

    public override object SolvePartTwo()
    {
        var transparentPaper = ParsedInput;
        var coordinates = transparentPaper.Points;
        foreach (var fold in transparentPaper.Folds)
        {
            Fold(coordinates, fold.Direction, fold.Position);
        }
        var paper = coordinates.Distinct().OrderBy(c => c.Y).ThenBy(c => c.X);
        var result = "";
        //Console.WriteLine();
        for (int y = 0; y < 6; y++)
        {
            for (int x = 0; x < 39; x++)
            {
                if (coordinates.Contains(new Point2DOld(x, y)))
                {
                    result += "#";
                    //Console.Write('#');
                }
                else
                {
                    result += ".";
                    //Console.Write('.');
                }
            }
            if (y < 5)
            {
                result += Environment.NewLine;
            }
            //Console.WriteLine();
        }
        return result;
        //return "JRZBLGKH";
    }

    private void Fold(List<Point2DOld> coordinates, char direction, int position)
    {
        if (direction == 'x')
        {
            FoldX(coordinates, position);
        }
        else if (direction == 'y')
        {
            FoldY(coordinates, position);
        }
    }

    private void FoldX(List<Point2DOld> coordinates, int position)
    {
        for (int i = 0; i < coordinates.Count; i++)
        {
            if (coordinates[i].X > position)
            {
                var j = coordinates[i].X - position;
                coordinates[i] = new Point2DOld(position - j, coordinates[i].Y);
            }
            if (coordinates[i].X == position)
            {
                throw new Exception();
            }
        }
    }

    private void FoldY(List<Point2DOld> coordinates, int position)
    {
        for (int i = 0; i < coordinates.Count; i++)
        {
            if (coordinates[i].Y > position)
            {
                var j = coordinates[i].Y - position;
                coordinates[i] = new Point2DOld(coordinates[i].X, position - j);
            }
            if (coordinates[i].Y == position)
            {
                throw new Exception();
            }
        }
    }
}
