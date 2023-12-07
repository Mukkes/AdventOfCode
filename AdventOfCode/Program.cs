using AdventOfCodeLibrary;
using AdventOfCodeLibrary.Models;

var solverRegister = new SolverRegister(typeof(Program).Assembly);
var yearDay = new YearDay(2023, 7);
var solver = solverRegister.Solvers.GetValueOrDefault(yearDay);

var exampleInput = @"32T3K 765
T55J5 684
KK677 28
KTJJT 220
QQQJA 483";

//solver.SetInput(exampleInput);
Console.WriteLine(solver.SolvePartOne());
Console.WriteLine(solver.SolvePartTwo());
Console.ReadKey();