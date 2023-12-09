using AdventOfCodeLibrary;
using AdventOfCodeLibrary.Models;

var solverRegister = new SolverRegister(typeof(Program).Assembly);
var yearDay = new YearDay(2023, 9);
var solver = solverRegister.Solvers.GetValueOrDefault(yearDay);

var exampleInput = @"0 3 6 9 12 15
1 3 6 10 15 21
10 13 16 21 30 45";

//solver.SetInput(exampleInput);
Console.WriteLine(solver.SolvePartOne());
Console.WriteLine(solver.SolvePartTwo());
Console.ReadKey();