namespace AdventOfCodeLibrary.Models;
public readonly struct Point3D
{
    public int X { get; init; }
    public int Y { get; init; }
    public int Z { get; init; }

    public Point3D() : this(0, 0, 0) { }

    public Point3D(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public static bool operator ==(Point3D pointA, Point3D pointB)
    {
        return
            pointA.X == pointB.X &&
            pointA.Y == pointB.Y &&
            pointA.Z == pointB.Z;
    }

    public static bool operator !=(Point3D pointA, Point3D pointB)
    {
        return
            pointA.X != pointB.X ||
            pointA.Y != pointB.Y ||
            pointA.Z != pointB.Z;
    }

    public static Point3D operator +(Point3D point, Vector3D vector)
    {
        return new Point3D(point.X + vector.X, point.Y + vector.Y, point.Z + vector.Z);
    }

    public static Point3D operator +(Vector3D vector, Point3D point)
    {
        return point + vector;
    }

    public static Point3D operator -(Point3D point, Vector3D vector)
    {
        return new Point3D(point.X - vector.X, point.Y - vector.Y, point.Z - vector.Z);
    }

    public static Vector3D operator -(Point3D pointA, Point3D pointB)
    {
        return new Vector3D(pointA.X - pointB.X, pointA.Y - pointB.Y, pointA.Z - pointB.Z);
    }

    public override int GetHashCode()
    {
        return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        return 
            (obj is Point3D point) &&
            X == point.X &&
            Y == point.Y &&
            Z == point.Z;
    }

    public override string ToString()
    {
        return X + "," + Y + "," + Z;
    }
}
