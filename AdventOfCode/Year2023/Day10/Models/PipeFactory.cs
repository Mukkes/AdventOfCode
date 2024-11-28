using AdventOfCodeLibrary.Models;

namespace AdventOfCode.Year2023.Day10.Models;
public static class PipeFactory
{
    public static Pipe GetPipe(char c, Point2D point, CardinalDirection cardinalDirection)
    {
        switch (c)
        {
            case '-':
                return new DashPipe(point, cardinalDirection);
            case 'F':
                return new FPipe(point, cardinalDirection);
            case 'J':
                return new JPipe(point, cardinalDirection);
            case 'L':
                return new LPipe(point, cardinalDirection);
            case '|':
                return new PipePipe(point, cardinalDirection);
            case '7':
                return new SevenPipe(point, cardinalDirection);
            case 'S':
                return new SPipe(point, cardinalDirection);
        }
        throw new Exception();
    }
}
