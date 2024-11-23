using AdventOfCodeLibrary.Models;

namespace AdventOfCode.Year2023.Day10.Models;
public class Pipe : Point2DOld
{
    public char Symbol { get; }
    public Pipe? Previous { get; set; }

    public Pipe(Point2DOld point2D, char symbol) : this(point2D.X, point2D.Y, symbol)
    {
    }

    public Pipe(long x, long y, char symbol) : this(x, y, symbol, null)
    {
    }

    public Pipe(Point2DOld point2D, char symbol, Pipe? previous) : this(point2D.X, point2D.Y, symbol, previous)
    {
    }

    public Pipe(long x, long y, char symbol, Pipe? previous) : base(x, y)
    {
        Symbol = symbol;
        Previous = previous;
    }

    private Point2DOld[] GetNeighbors()
    {
        var neighbors = new Point2DOld[2];
        if (Symbol == '|')
        {
            neighbors[0] = new Point2DOld(X - 1, Y);
            neighbors[1] = new Point2DOld(X + 1, Y);
        }
        else if (Symbol == '-')
        {
            neighbors[0] = new Point2DOld(X, Y - 1);
            neighbors[1] = new Point2DOld(X, Y + 1);
        }
        else if (Symbol == 'L')
        {
            neighbors[0] = new Point2DOld(X - 1, Y);
            neighbors[1] = new Point2DOld(X, Y + 1);
        }
        else if (Symbol == 'J')
        {
            neighbors[0] = new Point2DOld(X - 1, Y);
            neighbors[1] = new Point2DOld(X, Y - 1);
        }
        else if (Symbol == '7')
        {
            neighbors[0] = new Point2DOld(X + 1, Y);
            neighbors[1] = new Point2DOld(X, Y - 1);
        }
        else if (Symbol == 'F')
        {
            neighbors[0] = new Point2DOld(X + 1, Y);
            neighbors[1] = new Point2DOld(X, Y + 1);
        }
        return neighbors;
    }

    public Point2DOld GetNext()
    {
        var neighbors = GetNeighbors();
        if (!neighbors[0].Equals(Previous))
        {
            return neighbors[0];
        }
        return neighbors[1];
    }

    public int Length()
    {
        var length = 1;
        var previous = Previous;
        do
        {
            length++;
            previous = previous.Previous;
        } while (!Equals(previous));
        return length;
    }

    public override string ToString()
    {
        return Symbol + ": " + base.ToString();
    }
}
