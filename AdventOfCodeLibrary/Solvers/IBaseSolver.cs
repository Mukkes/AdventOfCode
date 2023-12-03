namespace AdventOfCodeLibrary.Solvers;

public  interface IBaseSolver
{
    abstract int Year { get; }
    abstract int Day { get; }
    abstract object SolvePartOne();
    abstract object SolvePartTwo();
}
