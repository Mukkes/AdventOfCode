using AdventOfCodeLibrary;

var solverRegister = new SolverRegister();
var solver = solverRegister.Single(solver => solver.Year == 2023 && solver.Day == 10);

var exampleInput = @"7-F7-
.FJ|7
SJLL7
|F--J
LJ.LJ";

//solver.SetInput(exampleInput);
Console.WriteLine(solver.SolvePartOne());
Console.WriteLine(solver.SolvePartTwo());
Console.ReadKey();