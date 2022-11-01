namespace AdventOfCode2021.Day16.Parsers
{
    public interface IInputParser<TResult>
    {
        TResult Parse(string inputFileName);
    }
}
