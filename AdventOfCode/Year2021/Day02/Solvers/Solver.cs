using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2021.Day02.Solvers;

[Solver]
public class Solver : BaseSolver<string[]>
{
    public override object? AnswerPartOne => 1924923;

    public override object? AnswerPartTwo => 1982495697;

    protected override IInputParser<string[]> InputParser => new StringArrayParser();

    public override object SolvePartOne()
    {
        var horizontal = 0;
        var depth = 0;
        foreach (var line in ParsedInput)
        {
            var command = GetCommand(line);
            if (command.Direction == "forward")
            {
                horizontal += command.X;
            }
            else if (command.Direction == "down")
            {
                depth += command.X;
            }
            else if (command.Direction == "up")
            {
                depth -= command.X;
            }
        }
        return horizontal * depth;
    }

    public override object SolvePartTwo()
    {
        var horizontal = 0;
        var depth = 0;
        var aim = 0;
        foreach (var line in ParsedInput)
        {
            var command = GetCommand(line);
            if (command.Direction == "forward")
            {
                horizontal += command.X;
                depth += aim * command.X;
            }
            else if (command.Direction == "down")
            {
                aim += command.X;
            }
            else if (command.Direction == "up")
            {
                aim -= command.X;
            }
        }
        return horizontal * depth;
    }

    private (string Direction, int X) GetCommand(string command)
    {
        var commandArray = command.Split(" ");
        return (commandArray[0], int.Parse(commandArray[1]));
    }
}
