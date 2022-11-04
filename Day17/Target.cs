using System.Drawing;

namespace AdventOfCode2021.Day17
{
    internal class Target
    {
        internal readonly Point TopLeft;
        internal readonly Point BottomRight;

        internal Target(int x1, int x2, int y1, int y2)
        {
            TopLeft = new Point();
            BottomRight = new Point();
            if (x1 < x2)
            {
                TopLeft.X = x1;
                BottomRight.X = x2;
            }
            else
            {
                TopLeft.X = x2;
                BottomRight.X = x1;
            }
            if (y1 > y2)
            {
                TopLeft.Y = y1;
                BottomRight.Y = y2;
            }
            else
            {
                TopLeft.Y = y2;
                BottomRight.Y = y1;
            }
        }

        internal bool IsInside(Point point)
        {
            return 
                point.X >= TopLeft.X && 
                point.X <= BottomRight.X && 
                point.Y <= TopLeft.Y && 
                point.Y >= BottomRight.Y;
        }
    }
}
