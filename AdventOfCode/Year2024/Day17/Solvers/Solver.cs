using AdventOfCode.Year2024.Day17.Models;
using AdventOfCode.Year2024.Day17.Parsers;
using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2024.Day17.Solvers;

[Solver]
public class Solver : BaseSolver<ChronospatialComputer>
{
    public override object? AnswerPartOne => "1,2,3,1,3,2,5,3,1";

    //public override object? AnswerPartTwo => ;

    protected override IInputParser<ChronospatialComputer> InputParser => new ChronospatialComputerParser();

    public override object SolvePartOne()
    {
        var computer = ParsedInput;
        computer.Run();
        return computer.GetOutputAsString();
    }

    public override object SolvePartTwo()
    {
        var computer = default(ChronospatialComputer);
        var a = -1;
        var program = string.Join(",", ParsedInput.ProgramArray);
        do
        {
            a++;
            computer = new ChronospatialComputer(ParsedInput);
            computer.RegisterA = a;
            computer.RunPartTwo();
            if (a % 1000000 == 0)
            {
                Console.WriteLine(a);
            }
            if (a == int.MaxValue)
            {
                return -1;
            }
        } while (computer.GetOutputAsString() != program);
        return a;
    }
}
