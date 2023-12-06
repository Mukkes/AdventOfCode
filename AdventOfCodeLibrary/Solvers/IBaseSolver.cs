namespace AdventOfCodeLibrary.Solvers;

public  interface IBaseSolver
{
    int Year { get; }
    int Day { get; }
    object SolvePartOne();
    object SolvePartTwo();
    void SetInput(string input);
}
