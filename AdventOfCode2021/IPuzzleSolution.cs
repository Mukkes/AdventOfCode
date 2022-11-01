namespace AdventOfCode
{
    interface IPuzzleSolution
    {
        int Day { get; }
        int Year { get; }
        void PrintResultPartOne();
        void PrintResultPartTwo();
    }
}
