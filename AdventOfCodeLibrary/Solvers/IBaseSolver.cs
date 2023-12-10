namespace AdventOfCodeLibrary.Solvers;

public  interface IBaseSolver
{
    int Year { get; }
    int Day { get; }
    object? AnswerPartOne { get; }
    object? AnswerPartTwo { get; }
    object SolvePartOne();
    object SolvePartTwo();
    void SetInput(string input);
}
