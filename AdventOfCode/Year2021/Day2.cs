using AdventOfCode.InputParser;

namespace AdventOfCode.Year2021
{
    class Day2 : PuzzleSolution<int>
    {
        private readonly MultiLineToStringArrayParser _inputParser;

        public Day2() : base(year: 2021, day: 2)
        {
            _inputParser = new MultiLineToStringArrayParser(InputFile);
        }

        private string[] Input => _inputParser.Input;

        public override int ResultPartOne()
        {
            int horizontal = 0;
            int depth = 0;
            foreach (var line in Input)
            {
                var command = GetCommand(line);
                if (command.Direction == "forward")
                {
                    horizontal += command.X;
                }
                else if (command.Direction == "down")
                {
                    depth += command.X;
                }
                else if (command.Direction == "up")
                {
                    depth -= command.X;
                }
            }
            return horizontal * depth;
        }

        public override int ResultPartTwo()
        {
            int horizontal = 0;
            int depth = 0;
            int aim = 0;
            foreach (var line in Input)
            {
                var command = GetCommand(line);
                if (command.Direction == "forward")
                {
                    horizontal += command.X;
                    depth += aim * command.X;
                }
                else if (command.Direction == "down")
                {
                    aim += command.X;
                }
                else if (command.Direction == "up")
                {
                    aim -= command.X;
                }
            }
            return horizontal * depth;
        }

        private (string Direction, int X) GetCommand(string command)
        {
            var commandArray = command.Split(" ");
            return (commandArray[0], int.Parse(commandArray[1]));
        }
    }
}
