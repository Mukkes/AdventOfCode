using AdventOfCode.Year2023.Day03.Solvers;
using AdventOfCodeLibrary;
using AdventOfCodeLibrary.Models;
using System.Reflection;

var solverRegister = new SolverRegister(typeof(Program).Assembly);
var yearDay1 = new YearDay(2023, 2);
var yearDay2 = new YearDay(2023, 1);
var b1 = yearDay1 == yearDay2;
var b2 = yearDay1.Equals(yearDay2);
var s = solverRegister.Solvers.GetValueOrDefault(yearDay1);

var exampleInput = @"";

var solver = new Solver();
//solver.SetInput(exampleInput);
Console.WriteLine(solver.SolvePartOne());
Console.WriteLine(solver.SolvePartTwo());
Console.ReadKey();