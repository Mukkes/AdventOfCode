using AdventOfCode2021.Day20.Solvers;

namespace AdventOfCode2021.Day20
{
    public class Program : TrenchMapSolver
    {
        static void Main(string[] args)
        {
            var program = new Program();
            program.PrintResultPartOne();
            program.PrintResultPartTwo();
            Console.ReadKey();
        }

        public Program() : this(null)
        {
        }

        public Program(string? input) : base(input)
        {
        }

        public override object SolvePartOne()
        {
            var trenchMap = Input;
            trenchMap = Enhance(trenchMap, 2);
            trenchMap.Print();
            Console.WriteLine();
            return trenchMap.CountLightPixels();
        }

        public override object SolvePartTwo()
        {
            var trenchMap = Input;
            trenchMap = Enhance(trenchMap, 50);
            trenchMap.Print();
            Console.WriteLine();
            return trenchMap.CountLightPixels();
        }

        private TrenchMap Enhance(TrenchMap trenchMap, int x)
        {
            for (var i = 0; i < x; i++)
            {
                trenchMap = trenchMap.Enhance();
                //trenchMap.Print();
                //Console.WriteLine();
            }
            return trenchMap;
        }
    }
}