using AdventOfCodeLibrary;
using System.Diagnostics;

var solverRegister = new SolverRegister(["AdventOfCode.dll"]);
var solver = solverRegister.Solvers.Single(solver => solver.Year == 2024 && solver.Day == 3);

var exampleInput = @"xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";
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