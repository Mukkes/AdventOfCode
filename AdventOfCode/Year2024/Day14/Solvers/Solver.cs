using AdventOfCode.Year2024.Day14.Models;
using AdventOfCode.Year2024.Day14.Parsers;
using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Models;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2024.Day14.Solvers;

[Solver]
public class Solver : BaseSolver<List<Robot>>
{
    //public override object? AnswerPartOne => ;

    //public override object? AnswerPartTwo => ;

    protected override IInputParser<List<Robot>> InputParser => new RobotParser();

    public int Width = 101;
    public int Height = 103;

    public override object SolvePartOne()
    {
        for (int i = 0; i < 100; i++)
        {
            foreach (var robot in ParsedInput)
            {
                MoveRobot(robot);
            }
        }
        return CalcutationSafestArea();
    }

    public override object SolvePartTwo()
    {
        var steps = 0;
        while (true)
        {
            foreach (var robot in ParsedInput)
            {
                MoveRobot(robot);
                steps++;
                if (IsTree())
                {
                    PrintGrid();
                    Console.WriteLine(steps);
                    //return steps;
                }
                if (steps % 1000000 == 0)
                {
                    //PrintGrid();
                    Console.WriteLine(steps);
                }
                if (steps > 100000000)
                {
                    return steps;
                }
            }
        }
        return steps;
    }

    private void MoveRobot(Robot robot)
    {
        var newPosition = robot.Position + robot.Velocity;
        if (newPosition.X >= Width)
        {
            newPosition = new Point2D(newPosition.X - Width, newPosition.Y);
        }
        else if (newPosition.X < 0)
        {
            newPosition = new Point2D(newPosition.X + Width, newPosition.Y);
        }
        if (newPosition.Y >= Height)
        {
            newPosition = new Point2D(newPosition.X , newPosition.Y - Height);
        }
        if (newPosition.Y < 0)
        {
            newPosition = new Point2D(newPosition.X, newPosition.Y + Height);
        }
        robot.Position = newPosition;
    }

    private int CalcutationSafestArea()
    {
        var quadrant1 = 0;
        var quadrant2 = 0;
        var quadrant3 = 0;
        var quadrant4 = 0;
        var middleX = Width / 2;
        var middleY = Height / 2;
        foreach (var robot in ParsedInput)
        {
            if (robot.Position.X < middleX && robot.Position.Y < middleY)
            {
                quadrant1++;
            }
            else if (robot.Position.X > middleX && robot.Position.Y < middleY)
            {
                quadrant2++;
            }
            else if (robot.Position.X < middleX && robot.Position.Y > middleY)
            {
                quadrant3++;
            }
            else if (robot.Position.X > middleX && robot.Position.Y > middleY)
            {
                quadrant4++;
            }
        }
        return quadrant1 * quadrant2 * quadrant3 * quadrant4;
    }

    private bool IsTree()
    {
        var minX = Width / 3;
        var maxX = Width - (Width / 3);
        var minY = Height / 3;
        var maxY = Height - (Height / 3);
        var tree = 0;
        foreach (var robot in ParsedInput)
        {
            if (robot.Position.X > minX && robot.Position.X < maxX &&
                robot.Position.Y > minY && robot.Position.Y < maxY)
            {
                tree++;
            }
        }
        return tree > 160;
    }

    private void PrintGrid()
    {
        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                var robots = ParsedInput.Where(robot => robot.Position == new Point2D(x, y)).Count();
                if (robots > 0)
                {
                    Console.Write(robots);
                }
                else
                {
                    Console.Write('.');
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
