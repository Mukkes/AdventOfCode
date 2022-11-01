namespace AdventOfCode2021.Day16
{
    public abstract class StringSolver : BaseSolver<string>
    {
        public StringSolver() : base(new InputToStringParser()) { }
    }
}
