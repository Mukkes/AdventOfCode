using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace AdventOfCode2021.Day18.Solvers
{
    public class Solver : PairSolver
    {
        public Solver() : this(null)
        {
        }

        public Solver(string? input) : base(input)
        {
        }

        public override object SolvePartOne()
        {
            var pair = AddPairs(Input);
            return pair.Magnitude();
        }

        public override object SolvePartTwo()
        {
            return 0;
        }

        public Pair AddPairs(List<Pair> pairs)
        {
            var pair = pairs[0];
            for (int i = 1; i < Input.Count; i++)
            {
                pair = Addition(pair, Input[i]);
                Console.WriteLine("-------------");
                Console.WriteLine("after addition: " + pair.ToString());
                Explode(pair);
            }
            return pair;
        }

        private Pair Addition(Pair pair1, Pair pair2)
        {
            var pair = new Pair(null);
            pair1.Parent = pair;
            pair2.Parent = pair;
            pair.LeftPair = pair1;
            pair.RightPair = pair2;
            return pair;
        }

        private void Explode(Pair pair)
        {
            while (pair.Explode())
            {
                Console.WriteLine("after explode:  " + pair.ToString());
            }
            Split(pair);
        }

        private void Split(Pair pair)
        {
            if (pair.Split())
            {
                Console.WriteLine("after split:    " + pair.ToString());
                Explode(pair);
            }
        }
    }
}
