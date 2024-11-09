namespace AdventOfCode.Year2021.Day21.Models;
public class DeterministicDice
{
    private const int _max = 100;
    private int _side;

    public DeterministicDice()
    {
        _side = _max;
        Count = 0;
    }

    public int Count { get; private set; }

    public int Roll()
    {
        Count++;
        _side++;
        if (_side > _max)
        {
            _side = 1;
        }
        return _side;
    }

    public override string ToString()
    {
        return "Side: " + _side + " count: " + Count;
    }
}
