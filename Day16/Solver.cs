namespace AdventOfCode2021.Day16
{
    internal class Solver : StringSolver
    {
        public Solver()
        {
            UseExampleInput = false;
        }

        protected override object SolvePartOne()
        {
            var packets = PacketParser.Parse(Input);
            var sum = 0L;
            foreach (var packet in packets)
            {
                sum += packet.Version;
            }
            return sum;
        }

        protected override object SolvePartTwo()
        {
            return 0;
        }
    }
}
