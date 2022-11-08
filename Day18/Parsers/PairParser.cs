using AdventOfCode2021.Day16.Parsers;

namespace AdventOfCode2021.Day18.Parsers
{
    public class PairParser : InputToStringArrayParser, IInputParser<List<Pair>>
    {
        public new List<Pair> Parse(string input)
        {
            var pairs = new List<Pair>();
            foreach (var s in base.Parse(input))
            {
                pairs.Add(ExtractPair(null, s));
            }
            return pairs;
        }

        private Pair ExtractPair(Pair? parent, string input)
        {
            var pair = new Pair(parent);
            var s = input.Substring(1, input.Length - 2);
            if (char.IsNumber(s[0]))
            {
                pair.LeftRegularNumber = s[0] - '0';
            }
            else
            {
                var count = 0;
                var pairString = string.Empty;
                foreach (var c in s)
                {
                    if (c == '[')
                    {
                        count++;
                    }
                    if (c == ']')
                    {
                        count--;
                    }
                    pairString += c;
                    if (count == 0)
                    {
                        pair.LeftPair = ExtractPair(pair, pairString);
                        break;
                    }
                }
            }
            if (char.IsNumber(s[s.Length - 1]))
            {
                pair.RightRegularNumber = s[s.Length - 1] - '0';
            }
            else
            {
                var count = 0;
                var pairString = string.Empty;
                foreach (var c in s.Reverse())
                {
                    if (c == '[')
                    {
                        count++;
                    }
                    if (c == ']')
                    {
                        count--;
                    }
                    pairString = c + pairString;
                    if (count == 0)
                    {
                        pair.RightPair = ExtractPair(pair, pairString);
                        break;
                    }
                }
            }
            return pair;
        }
    }
}
