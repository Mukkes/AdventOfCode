using AdventOfCodeLibrary;
using System.Diagnostics;

var solverRegister = new SolverRegister(["AdventOfCode.dll"]);
var solver = (AdventOfCode.Year2024.Day14.Solvers.Solver)solverRegister.Solvers.Single(solver => solver.Year == 2024 && solver.Day == 14);

var exampleInput = @"p=0,4 v=3,-3
p=6,3 v=-1,-3
p=10,3 v=-1,2
p=2,0 v=2,-1
p=0,0 v=1,3
p=3,0 v=-2,-2
p=7,6 v=-1,-3
p=3,0 v=-1,-2
p=9,3 v=2,3
p=7,3 v=-1,2
p=2,4 v=2,-3
p=9,5 v=-3,-3";
//var exampleInput = @"p=2,4 v=2,-3";
//solver.Input = exampleInput;
//solver.Width = 11;
//solver.Height = 7;

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