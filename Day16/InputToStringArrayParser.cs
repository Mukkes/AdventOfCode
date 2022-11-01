namespace AdventOfCode2021.Day16
{
    public class InputToStringArrayParser : IInputParser<string[]>
    {
        public string[] Parse(string inputFileName)
        {
            return File.ReadAllLines(inputFileName);
        }
    }
}
