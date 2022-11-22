namespace AdventOfCode2021.Day20
{
    public class Point
    {
        public readonly int X;
        public readonly int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj is Point point)
            {
                if (X == point.X && Y == point.Y)
                {
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            return X.ToString() + ',' + Y.ToString();
        }
    }
}
