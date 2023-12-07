using AdventOfCode.Year2023.Day04.Models;

namespace AdventOfCode.Year2023.Day07.Models;
public class Hand
{
    public string Cards { get; set; }
    public long Bid { get; set; }
    public long Score { get; }
    public long JokerScore { get; }

    public Hand(string cards, long bid)
    {
        Cards = cards;
        Bid = bid;
        Score = GetScore();
        JokerScore = GetJokerScore();
    }

    private long GetScore()
    {
        var score = 0L;
        var cards = new Dictionary<char, long>();
        foreach (var card in Cards)
        {
            if (cards.TryGetValue(card, out long value))
            {
                cards[card] = value + 1;
            }
            else
            {
                cards.Add(card, 1);
            }
        }
        score += CardValues[Cards[0]] * 100000000;
        score += CardValues[Cards[1]] * 1000000;
        score += CardValues[Cards[2]] * 10000;
        score += CardValues[Cards[3]] * 100;
        score += CardValues[Cards[4]];
        if (cards.ContainsValue(5))
        {
            score += 90000000000;
        }
        else if (cards.ContainsValue(4))
        {
            score += 80000000000;
        }
        else if (cards.ContainsValue(3) && cards.ContainsValue(2))
        {
            score += 70000000000;
        }
        else if (cards.ContainsValue(3))
        {
            score += 60000000000;
        }
        else if (cards.ContainsValue(2) && cards.Count == 3)
        {
            score += 50000000000;
        }
        else if (cards.ContainsValue(2))
        {
            score += 40000000000;
        }
        else
        {
            score += 30000000000;
        }

        return score;
    }

    public Dictionary<char, long> CardValues => new Dictionary<char, long>()
    {
        { 'A', 50 },
        { 'K', 40 },
        { 'Q', 30 },
        { 'J', 20 },
        { 'T', 10 },
        { '9', 9 },
        { '8', 8 },
        { '7', 7 },
        { '6', 6 },
        { '5', 5 },
        { '4', 4 },
        { '3', 3 },
        { '2', 2 }
    };

    private long GetJokerScore()
    {
        var score = 0L;
        var cards = new Dictionary<char, long>();
        var j = 0;
        foreach (var card in Cards)
        {
            if (card == 'J')
            {
                j++;
            }
            else if (cards.TryGetValue(card, out long value))
            {
                cards[card] = value + 1;
            }
            else
            {
                cards.Add(card, 1);
            }
        }
        score += JokerCardValues[Cards[0]] * 100000000;
        score += JokerCardValues[Cards[1]] * 1000000;
        score += JokerCardValues[Cards[2]] * 10000;
        score += JokerCardValues[Cards[3]] * 100;
        score += JokerCardValues[Cards[4]];
        if (cards.Any())
        {
            var keyOfMaxValue = cards.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
            cards[keyOfMaxValue] += j;
        }
        else
        {
            score += 90000000000;
            return score;
        }
        if (cards.ContainsValue(5))
        {
            score += 90000000000;
        }
        else if (cards.ContainsValue(4))
        {
            score += 80000000000;
        }
        else if (cards.ContainsValue(3) && cards.ContainsValue(2))
        {
            score += 70000000000;
        }
        else if (cards.ContainsValue(3))
        {
            score += 60000000000;
        }
        else if (cards.ContainsValue(2) && cards.Count == 3)
        {
            score += 50000000000;
        }
        else if (cards.ContainsValue(2))
        {
            score += 40000000000;
        }
        else
        {
            score += 30000000000;
        }

        return score;
    }

    public Dictionary<char, long> JokerCardValues => new Dictionary<char, long>()
    {
        { 'A', 50 },
        { 'K', 40 },
        { 'Q', 30 },
        { 'T', 10 },
        { '9', 9 },
        { '8', 8 },
        { '7', 7 },
        { '6', 6 },
        { '5', 5 },
        { '4', 4 },
        { '3', 3 },
        { '2', 2 },
        { 'J', 1 },
    };

    public override string ToString()
    {
        return Cards + ", " + Bid + ", " + Score + ", " + JokerScore;
    }
}
