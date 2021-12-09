namespace AdventOfCode.InputParser
{
    public interface IInputParser<ResultType>
    {
        ResultType Input { get; }
    }
}
