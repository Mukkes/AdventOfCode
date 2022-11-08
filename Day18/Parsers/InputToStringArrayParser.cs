using AdventOfCode2021.Day16.Parsers;

namespace AdventOfCode2021.Day18.Parsers
{
    public class InputToStringArrayParser : IInputParser<string[]>
    {
        public string[] Parse(string input)
        {
            return input.Split(Environment.NewLine);
        }
    }
}
