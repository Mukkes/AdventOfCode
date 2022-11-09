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
            var largestMagnitude = 0L;
            foreach (var pair1 in Input)
            {
                foreach (var pair2 in Input)
                {
                    if (pair1 == pair2)
                    {
                        continue;
                    }
                    var pair = Addition(pair1.Clone(), pair2.Clone());
                    Console.WriteLine("-------------");
                    Console.WriteLine("after addition: " + pair.ToString());
                    Explode(pair);
                    var magnitude = pair.Magnitude();
                    Console.WriteLine("magnitude: " + magnitude);
                    if (magnitude > largestMagnitude)
                    {
                        largestMagnitude = magnitude;
                    }
                    pair = Addition(pair2.Clone(), pair1.Clone());
                    Console.WriteLine("-------------");
                    Console.WriteLine("after addition: " + pair.ToString());
                    Explode(pair);
                    magnitude = pair.Magnitude();
                    Console.WriteLine("magnitude: " + magnitude);
                    if (magnitude > largestMagnitude)
                    {
                        largestMagnitude = magnitude;
                    }
                }
            }
            return largestMagnitude;
        }

        public Pair AddPairs(List<Pair> pairs)
        {
            var pair = pairs[0].Clone();
            for (int i = 1; i < Input.Count; i++)
            {
                pair = Addition(pair, Input[i].Clone());
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
