namespace AdventOfCode2021.Day16.Parsers
{
    public class InputToStringArrayParser : IInputParser<string[]>
    {
        public string[] Parse(string inputFileName)
        {
            return File.ReadAllLines(inputFileName);
        }
    }
}
