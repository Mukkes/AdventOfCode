using AdventOfCodeLibrary.Models;
using AdventOfCodeTests.Year2024.Day06.Fixtures;

namespace AdventOfCodeTests.Year2024.Day06;
public class Tests : IClassFixture<SolverFixture>
{
    private readonly SolverFixture _solverFixture;

    public Tests(SolverFixture solverFixture)
    {
        _solverFixture = solverFixture;
    }

    [Fact]
    public void ExpectedObstructionsExampleInput()
    {
        var solver = _solverFixture.SolverWhitExampleInput;

        var expectedObstructions = new List<Point2D>()
        {
            new Point2D(3, 6),
            new Point2D(6, 7),
            new Point2D(7, 7),
            new Point2D(1, 8),
            new Point2D(3, 8),
            new Point2D(7, 9)
        };

        solver.NewObstructions.Should().Contain(expectedObstructions);
    }

    [Fact]
    public void ObstructionCantBeOnGuardPosition()
    {
        var solver = _solverFixture.Solver;
        var startPoint = solver.ParsedInput.First(x => x.Value.Equals('^')).Key;
        solver.NewObstructions.Should().NotContain(startPoint);
    }

    [Fact]
    public void NewObstructionsShouldNotContainOldObstructions()
    {
        var solver = _solverFixture.Solver;
        solver.NewObstructions.Should().NotContain(solver.OldObstructions);
    }

    [Fact]
    public void NewObstructionsShouldNotContainObstructionsOutsideGrid()
    {
        var solver = _solverFixture.Solver;
        var xLeftBound = -1;
        var xRightBound = 130;
        var yUpBound = -1;
        var yDownBound = 130;
        var obstructionsOutsideGrid = solver.NewObstructions.Where(x => x.X <= xLeftBound || x.X >= xRightBound || x.Y <= yUpBound || x.Y >= yDownBound);
        obstructionsOutsideGrid.Should().BeEmpty();
    }
}
