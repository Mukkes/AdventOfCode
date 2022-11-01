namespace AdventOfCode2021.Day16
{
    public class InputToStringParser : InputToStringArrayParser, IInputParser<string>
    {
        public new string Parse(string inputFileName)
        {
            return base.Parse(inputFileName)[0];
        }
    }
}
