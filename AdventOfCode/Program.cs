using AdventOfCodeLibrary;
using AdventOfCodeLibrary.Models;

var solverRegister = new SolverRegister(typeof(Program).Assembly);
var yearDay = new YearDay(2023, 6);
var solver = solverRegister.Solvers.GetValueOrDefault(yearDay);

var exampleInput = @"";

//solver.SetInput(exampleInput);
Console.WriteLine(solver.SolvePartOne());
Console.WriteLine(solver.SolvePartTwo());
Console.ReadKey();