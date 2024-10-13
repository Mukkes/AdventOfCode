﻿using AdventOfCodeLibrary;

var solverRegister = new SolverRegister();
var solver = solverRegister.Single(solver => solver.Year == 2021 && solver.Day == 13);

var exampleInput = @"";
//solver.SetInput(exampleInput);
Console.WriteLine(solver.SolvePartOne());
Console.WriteLine(solver.SolvePartTwo());
Console.ReadKey();