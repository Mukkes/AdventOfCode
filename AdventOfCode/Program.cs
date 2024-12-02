using AdventOfCodeLibrary;
using System.Diagnostics;

var solverRegister = new SolverRegister(["AdventOfCode.dll"]);
var solver = solverRegister.Solvers.Single(solver => solver.Year == 2024 && solver.Day == 2);

var exampleInput = @"7 6 4 2 1
1 2 7 8 9
9 7 6 2 1
1 3 2 4 5
8 6 4 4 1
1 3 6 7 9";
//solver.Input = exampleInput;

var stopwatch = new Stopwatch();
stopwatch.Start();

Console.WriteLine(solver.SolvePartOne());

stopwatch.Stop();
var timeSpanPartOne = stopwatch.Elapsed;
stopwatch.Start();

Console.WriteLine(solver.SolvePartTwo());

stopwatch.Stop();
var timeSpanPartTwo = stopwatch.Elapsed - timeSpanPartOne;
var timeSpanTotal = stopwatch.Elapsed;

Console.WriteLine();
Console.WriteLine("Part one: " + timeSpanPartOne);
Console.WriteLine("Part two: " + timeSpanPartTwo);
Console.WriteLine("Total: " + timeSpanTotal);
Console.ReadKey();