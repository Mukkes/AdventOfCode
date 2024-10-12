namespace AdventOfCodeLibrary.Solvers;

public  interface IBaseSolver
{
    int Year { get; }
    int Day { get; }
    object? AnswerPartOne { get; }
    object? AnswerPartTwo { get; }
    string Input { set; }
    object SolvePartOne();
    object SolvePartTwo();
}
