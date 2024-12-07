using AdventOfCode.Year2024.Day07.Models;
using AdventOfCodeLibrary.Parsers;

namespace AdventOfCode.Year2024.Day07.Parsers;
public class EquationParser : StringArrayParser, IInputParser<List<Equation>>
{
    public new List<Equation> Parse(string input)
    {
        var equations = new List<Equation>();
        foreach (var line in base.Parse(input))
        {
            var equation = new Equation();
            var split = line.Split(": ");
            equation.TestValue = long.Parse(split[0]);
            foreach (var number in split[1].Split(' '))
            {
                equation.Numbers.Add(long.Parse(number));
            }
            equations.Add(equation);
        }
        return equations;
    }
}
