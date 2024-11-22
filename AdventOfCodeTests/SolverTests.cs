using AdventOfCodeLibrary;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCodeTests;

public class SolverTests
{
    [Theory]
    [MemberData(nameof(Solvers))]
    public void SolverTest(IBaseSolver solver)
    {
        Assert.Equal(solver.AnswerPartOne, solver.SolvePartOne());
        Assert.Equal(solver.AnswerPartTwo, solver.SolvePartTwo());
    }

    public static IEnumerable<object[]> Solvers
    {
        get
        {
            var solverRegister = new SolverRegister(["AdventOfCode.dll"]);
            foreach (var solver in solverRegister.Solvers)
            {
                yield return new object[] { solver };
            }
        }
    }
}