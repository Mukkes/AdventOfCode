namespace AdventOfCode2021.Day16
{
    public abstract class StringArraySolver : BaseSolver<string[]>
    {
        public StringArraySolver() : base(new InputToStringArrayParser()) { }
    }
}
