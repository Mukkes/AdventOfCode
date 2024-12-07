using AdventOfCodeLibrary;
using System.Diagnostics;

var solverRegister = new SolverRegister(["AdventOfCode.dll"]);
var solver = solverRegister.Solvers.Single(solver => solver.Year == 2024 && solver.Day == 7);

var exampleInput = @"190: 10 19
3267: 81 40 27
83: 17 5
156: 15 6
7290: 6 8 6 15
161011: 16 10 13
192: 17 8 14
21037: 9 7 18 13
292: 11 6 16 20";
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