using AdventOfCodeLibrary;
using AdventOfCode.Year2024.Day06.Solvers;

namespace AdventOfCodeTests.Year2024.Day06.Fixtures;
public class SolverFixture : IDisposable
{
    public Solver Solver { get; init; }
    public Solver SolverWhitExampleInput { get; init; }

    public SolverFixture()
    {
        var solverRegister = new SolverRegister(["AdventOfCode.dll"]);
        Solver = (Solver)solverRegister.Solvers.Single(solver => solver.Year == 2024 && solver.Day == 6);
        Solver.SolvePartOne();
        Solver.SolvePartTwo();

        solverRegister = new SolverRegister(["AdventOfCode.dll"]);
        SolverWhitExampleInput = (Solver)solverRegister.Solvers.Single(solver => solver.Year == 2024 && solver.Day == 6);
        SolverWhitExampleInput.Input = 
@"....#.....
.........#
..........
..#.......
.......#..
..........
.#..^.....
........#.
#.........
......#...";
        SolverWhitExampleInput.SolvePartOne();
        SolverWhitExampleInput.SolvePartTwo();
    }

    public void Dispose()
    {
    }
}
