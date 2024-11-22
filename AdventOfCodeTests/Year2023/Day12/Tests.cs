using AdventOfCodeLibrary;

namespace AdventOfCodeTests.Year2023.Day12;
public class SolverTests
{
    [Fact]
    public void SolverTest()
    {
        var solverRegister = new SolverRegister(["AdventOfCode.dll"]);
        var solver = solverRegister.Solvers.Single(solver => solver.Year == 2023 && solver.Day == 12);
        solver.Input = @"??#??##????#?.??#. 7,1,2,2";
        Assert.Equal(4, solver.SolvePartOne());
    }
}
