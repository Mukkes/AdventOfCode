namespace AdventOfCode2021.Day19
{
    public class Beacon : Position
    {
        public Beacon(int x, int y, int z) : base(x, y, z) { }

        public Beacon(Position position) : this(position.X, position.Y, position.Z) { }

        public override string ToString()
        {
            return "Beacon: " + base.ToString();
        }
    }
}
