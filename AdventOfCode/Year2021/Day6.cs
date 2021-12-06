using System.Linq;

namespace AdventOfCode.Year2021
{
    public class Day6 : PuzzleSolution<long>
    {
        public Day6() : base(year: 2021, day: 6) { }

        private string Input => GetSingleLineInputAsString();
        
        public override long ResultPartOne()
        {
            var lanternfish = Input.Split(',').Select(int.Parse).ToList();
            var days = 80;
            for (int day = 0; day < days; day++)
            {
                lanternfish = lanternfish.Select(x => --x).ToList();
                lanternfish.Where(x => x == -1).ToList().ForEach(x => lanternfish.Add(8));
                lanternfish = lanternfish.Select(x => x == -1 ? 6 : x).ToList();
            }
            return lanternfish.Count;
        }

        public override long ResultPartTwo()
        {
            var lanternfish = new long[9];
            Input.Split(',').Select(long.Parse).ToList().ForEach(x => ++lanternfish[x]);
            var days = 256;
            for (int day = 0; day < days; day++)
            {
                var x = lanternfish[0];
                for (int i = 0; i < 8; i++)
                {
                    lanternfish[i] = lanternfish[i + 1];
                }
                lanternfish[8] = x;
                lanternfish[6] += x;
            }
            return lanternfish.Sum();
        }
    }
}
