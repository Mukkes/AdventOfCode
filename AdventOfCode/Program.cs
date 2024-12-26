using AdventOfCodeLibrary;
using System.Diagnostics;

var solverRegister = new SolverRegister(["AdventOfCode.dll"]);
var solver = solverRegister.Solvers.Single(solver => solver.Year == 2024 && solver.Day == 13);

var exampleInput = @"Button A: X+94, Y+34
Button B: X+22, Y+67
Prize: X=8400, Y=5400

Button A: X+26, Y+66
Button B: X+67, Y+21
Prize: X=12748, Y=12176

Button A: X+17, Y+86
Button B: X+84, Y+37
Prize: X=7870, Y=6450

Button A: X+69, Y+23
Button B: X+27, Y+71
Prize: X=18641, Y=10279";
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