using AdventOfCode.Year2023.Day04.Models;
using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.ExtensionClasses;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2023.Day04.Solvers;

[Solver]
public class Solver : BaseSolver<string[]>
{
    public override object? AnswerPartOne => 20117;

    public override object? AnswerPartTwo => 13768818;

    protected override IInputParser<string[]> InputParser => new StringArrayParser();

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
            for (var y = 0; y < cards[x].Copys; y++)
            {
                for (var i = 1; i <= amount; i++)
                {
                    cards[x + i].Copys++;
                }
            }
        }
        return cards.Sum(c => c.Copys);
    }

    private List<Card> GetCards()
    {
        var cards = new List<Card>();
        foreach (var line in ParsedInput)
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
