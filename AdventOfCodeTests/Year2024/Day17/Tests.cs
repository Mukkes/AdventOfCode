using AdventOfCode.Year2024.Day17.Models;

namespace AdventOfCodeTests.Year2024.Day17;
public class Tests
{
    [Fact]
    public void Example1()
    {
        var computer = new ChronospatialComputer(default, default, 9, [2,6]);
        computer.Run();
        computer.RegisterB.Should().Be(1);
    }

    [Fact]
    public void Example2()
    {
        var computer = new ChronospatialComputer(10, default, default, [5, 0, 5, 1, 5, 4]);
        computer.Run();
        computer.GetOutputAsString().Should().Be("0,1,2");
    }

    [Fact]
    public void Example3()
    {
        var computer = new ChronospatialComputer(2024, default, default, [0, 1, 5, 4, 3, 0]);
        computer.Run();
        string.Join(",", computer.Output).Should().Be("4,2,5,6,7,7,7,7,3,1,0");
        computer.RegisterA.Should().Be(0);
    }

    [Fact]
    public void Example4()
    {
        var computer = new ChronospatialComputer(default, 29, default, [1, 7]);
        computer.Run();
        computer.RegisterB.Should().Be(26);
    }

    [Fact]
    public void Example5()
    {
        var computer = new ChronospatialComputer(default, 2024, 43690, [4, 0]);
        computer.Run();
        computer.RegisterB.Should().Be(44354);
    }
}
