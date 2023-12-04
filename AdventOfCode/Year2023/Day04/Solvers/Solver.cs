using AdventOfCode.Year2023.Day04.Models;
using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.ExtensionClasses;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2023.Day04.Solvers;

[Solver]
public class Solver : StringArraySolver
{
    public override int Year => 2023;

    public override int Day => 04;

    public override object SolvePartOne()
    {
        var cards = GetCards();
        var sum = 0;
        foreach (var card in cards)
        {
            sum += card.GetCardValue();
        }
        return sum;
    }

    public override object SolvePartTwo()
    {
        var cards = GetCards();
        for (var x = 0; x < cards.Count; x++)
        {
            var amount = cards[x].GetAmountWinningNumbers();
            for (var i = 1; i <= amount; i++)
            {
                var copy = cards.FirstOrDefault(c => c.Id == cards[x].Id + i);
                if (copy != null)
                {
                    cards.Add(copy);
                }
            }
        }
        return cards.Count;
    }

    private List<Card> GetCards()
    {
        var cards = new List<Card>();
        foreach (var line in Input)
        {
            var cardString = line.Split(':');
            var card = new Card(cardString[0].ExtractInteger());
            var numbersString = cardString[1].Split('|');
            var winningNumbers = numbersString[0].Split(' ');
            foreach (var winningNumber in winningNumbers)
            {
                var num = winningNumber.ExtractInteger();
                if (num > 0)
                {
                    card.WinningNumbers.Add(num);
                }
            }
            var numbers = numbersString[1].Split(' ');
            foreach (var number in numbers)
            {
                var num = number.ExtractInteger();
                if (num > 0)
                {
                    card.Numbers.Add(num);
                }
            }
            cards.Add(card);
        }
        return cards;
    }
}
