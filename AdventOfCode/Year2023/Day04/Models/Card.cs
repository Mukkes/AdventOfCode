namespace AdventOfCode.Year2023.Day04.Models;
public class Card
{
    public int Id { get; }
    public List<int> WinningNumbers { get; } = new List<int>();
    public List<int> Numbers { get; } = new List<int>();

    public Card(int id)
    {
        Id = id;
    }

    public List<int> GetWinningNumbers()
    {
        var winningNumbers = new List<int>();
        foreach (var  number in Numbers)
        {
            if (WinningNumbers.Contains(number))
            {
                winningNumbers.Add(number);
            }
        }
        return winningNumbers;
    }

    public int GetAmountWinningNumbers()
    {
        return GetWinningNumbers().Count();
    }

    public int GetCardValue()
    {
        var amount = GetAmountWinningNumbers();
        if (amount == 0)
        {
            return 0;
        }
        var sum = 1;
        for (var i = 1; i < amount; i++)
        {
            sum *= 2;
        }
        return sum;
    }
}
