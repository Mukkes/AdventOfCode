namespace AdventOfCode2021.Day16
{
    public interface IInputParser<TResult>
    {
        TResult Parse(string inputFileName);
    }
}
