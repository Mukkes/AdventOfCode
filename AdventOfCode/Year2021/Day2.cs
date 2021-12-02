namespace AdventOfCode.Year2021
{
    public class Day2 : PuzzleSolution
    {
        public override int Year => 2021;

        public override int Day => 2;

        private string[] Input => GetInputAsStringArray();

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
