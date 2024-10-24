namespace AdventOfCode.Year2021.Day19.Models;
public class Position
{
    public Position() : this(0, 0, 0) { }

    public Position(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public int X { get; set; }

    public int Y { get; set; }

    public int Z { get; set; }

    public void SetPosition(Position position)
    {
        X = position.X;
        Y = position.Y;
        Z = position.Z;
    }

    public override int GetHashCode()
    {
        return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        if (obj is Position position)
        {
            if (X == position.X && Y == position.Y && Z == position.Z)
            {
                return true;
            }
        }
        return false;
    }

    public override string ToString()
    {
        return X + "," + Y + "," + Z;
    }

    public Position Clone()
    {
        return new Position(X, Y, Z);
    }

    public virtual void Rotate(int i)
    {
        var clone = Clone();
        switch (i)
        {
            case 0:
                X = clone.X;
                Y = clone.Y;
                Z = clone.Z;
                break;
            case 1:
                X = clone.X;
                Y = -clone.Y;
                Z = -clone.Z;
                break;
            case 2:
                X = clone.X;
                Y = clone.Z;
                Z = clone.Y;
                break;
            case 3:
                X = clone.X;
                Y = -clone.Z;
                Z = -clone.Y;
                break;

            case 4:
                X = -clone.X;
                Y = -clone.Y;
                Z = clone.Z;
                break;
            case 5:
                X = -clone.X;
                Y = clone.Z;
                Z = clone.Y;
                break;
            case 6:
                X = -clone.X;
                Y = clone.Y;
                Z = -clone.Z;
                break;
            case 7:
                X = -clone.X;
                Y = -clone.Z;
                Z = -clone.Y;
                break;

            case 8:
                X = clone.Y;
                Y = -clone.X;
                Z = clone.Z;
                break;
            case 9:
                X = clone.Y;
                Y = clone.Z;
                Z = clone.X;
                break;
            case 10:
                X = clone.Y;
                Y = clone.X;
                Z = -clone.Z;
                break;
            case 11:
                X = clone.Y;
                Y = -clone.Z;
                Z = -clone.X;
                break;

            case 12:
                X = -clone.Y;
                Y = -clone.X;
                Z = clone.Z;
                break;
            case 13:
                X = -clone.Y;
                Y = clone.Z;
                Z = -clone.X;
                break;
            case 14:
                X = -clone.Y;
                Y = clone.X;
                Z = clone.Z;
                break;
            case 15:
                X = -clone.Y;
                Y = -clone.Z;
                Z = clone.X;
                break;

            case 16:
                X = clone.Z;
                Y = clone.Y;
                Z = -clone.X;
                break;
            case 17:
                X = clone.Z;
                Y = clone.X;
                Z = clone.Y;
                break;
            case 18:
                X = clone.Z;
                Y = -clone.Y;
                Z = clone.X;
                break;
            case 19:
                X = clone.Z;
                Y = -clone.X;
                Z = -clone.Y;
                break;

            case 20:
                X = -clone.Z;
                Y = clone.Y;
                Z = clone.X;
                break;
            case 21:
                X = -clone.Z;
                Y = -clone.X;
                Z = clone.Y;
                break;
            case 22:
                X = -clone.Z;
                Y = -clone.Y;
                Z = -clone.X;
                break;
            case 23:
                X = -clone.Z;
                Y = clone.X;
                Z = -clone.Y;
                break;
        }
    }

    //public virtual void Rotate(int i)
    //{
    //    var clone = Clone();
    //    switch (i)
    //    {
    //        case 0:
    //            break;
    //        case 1:
    //            X = -clone.X;
    //            Y = -clone.Y;
    //            break;
    //        case 2:
    //            X = -clone.X;
    //            Y = -clone.Y;
    //            break;
    //        case 3:
    //            X = clone.Y;
    //            Y = clone.X;
    //            break;
    //        case 4:
    //            X = -clone.X;
    //            Z = -clone.Z;
    //            break;
    //        case 5:
    //            X = -clone.X;
    //            Z = -clone.Z;
    //            break;
    //        case 6:
    //            X = clone.Z;
    //            Z = clone.X;
    //            break;
    //        case 7:
    //            Z = -clone.Z;
    //            Y = -clone.Y;
    //            break;
    //        case 8:
    //            Z = -clone.Z;
    //            Y = -clone.Y;
    //            break;
    //        case 9:
    //            Z = clone.Y;
    //            Y = clone.Z;
    //            break;
    //        case 10:
    //            X = clone.Y;
    //            Y = clone.Z;
    //            Z = clone.X;
    //            break;
    //        case 11:
    //            X = -clone.Y;
    //            Y = -clone.Z;
    //            Z = -clone.X;
    //            break;
    //        case 12:
    //            X = clone.Z;
    //            Y = clone.X;
    //            Z = clone.Y;
    //            break;
    //        case 13:
    //            X = -clone.Z;
    //            Y = -clone.X;
    //            Z = -clone.Y;
    //            break;
    //        case 14:
    //            X = -clone.X;
    //            Y = clone.Z;
    //            Z = clone.Y;
    //            break;
    //        case 15:
    //            X = -clone.X;
    //            Y = -clone.Z;
    //            Z = -clone.Y;
    //            break;
    //        case 16:
    //            Y = -clone.Y;
    //            X = clone.Z;
    //            Z = clone.X;
    //            break;
    //        case 17:
    //            Y = -clone.Y;
    //            X = -clone.Z;
    //            Z = -clone.X;
    //            break;
    //        case 18:
    //            Z = -clone.Z;
    //            X = clone.Y;
    //            Y = clone.X;
    //            break;
    //        case 19:
    //            Z = -clone.Z;
    //            X = -clone.Y;
    //            Y = -clone.X;
    //            break;
    //        case 20:
    //            X = -clone.Z;
    //            Y = clone.X;
    //            Z = -clone.Y;
    //            break;
    //        case 21:
    //            X = -clone.Y;
    //            Y = -clone.Z;
    //            Z = clone.X;
    //            break;
    //        case 22:
    //            X = -clone.Z;
    //            Y = -clone.X;
    //            Z = clone.Y;
    //            break;
    //        case 23:
    //            X = clone.Y;
    //            Y = -clone.Z;
    //            Z = -clone.X;
    //            break;
    //        case 24:
    //            X = clone.Z;
    //            Y = -clone.X;
    //            Z = -clone.Y;
    //            break;
    //        case 25:
    //            X = -clone.Y;
    //            Y = clone.Z;
    //            Z = -clone.X;
    //            break;
    //    }
    //}
}
