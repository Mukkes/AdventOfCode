using AdventOfCodeLibrary;

var solverRegister = new SolverRegister();
var solver = solverRegister.Single(solver => solver.Year == 2021 && solver.Day == 1);

var exampleInput = @"O....#....
O.OO#....#
.....##...
OO.#O....O
.O.....O#.
O.#..O.#.#
..O..#O..O
.......O..
#....###..
#OO..#....";
//solver.SetInput(exampleInput);
Console.WriteLine(solver.SolvePartOne());
Console.WriteLine(solver.SolvePartTwo());
Console.ReadKey();