using AdventOfCodeLibrary;

var solverRegister = new SolverRegister();
var solver = solverRegister.Single(solver => solver.Year == 2023 && solver.Day == 12);

var exampleInput = @"???.### 1,1,3
.??..??...?##. 1,1,3
?#?#?#?#?#?#?#? 1,3,1,6
????.#...#... 4,1,1
????.######..#####. 1,6,5
?###???????? 3,2,1";

//solver.SetInput(exampleInput);
Console.WriteLine(solver.SolvePartOne());
Console.WriteLine(solver.SolvePartTwo());
Console.ReadKey();