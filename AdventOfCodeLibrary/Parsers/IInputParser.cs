namespace AdventOfCodeLibrary.Parsers;

public interface IInputParser<TResult>
{
    TResult Parse(string input);
}
