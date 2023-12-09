using AdventOfCodeLibrary;
using AdventOfCodeLibrary.Models;

var solverRegister = new SolverRegister(typeof(Program).Assembly);
var yearDay = new YearDay(2023, 8);
var solver = solverRegister.Solvers.GetValueOrDefault(yearDay);

var exampleInput = @"LR

11A = (11B, XXX)
11B = (XXX, 11Z)
11Z = (11B, XXX)
22A = (22B, XXX)
22B = (22C, 22C)
22C = (22Z, 22Z)
22Z = (22B, 22B)
XXX = (XXX, XXX)";

//solver.SetInput(exampleInput);
Console.WriteLine(solver.SolvePartOne());
Console.WriteLine(solver.SolvePartTwo());
Console.ReadKey();