namespace AdventOfCode.InputParser
{
    interface IInputParser<ResultType>
    {
        ResultType Input { get; }
    }
}
