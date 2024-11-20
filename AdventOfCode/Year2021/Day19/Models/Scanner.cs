using AdventOfCodeLibrary.Models;

namespace AdventOfCode.Year2021.Day19.Models;
public class Scanner
{
    public Scanner(int id)
    {
        Id = id;
        Beacons = new List<Beacon>();
    }

    public int Id { get; }

    public Point3D Position { get; set; }

    public int Rotation { get; set; }

    public List<Vector3D> BeaconVectors { get; set; }

    public List<Beacon> Beacons { get; }

    public void AddBeacons(List<Beacon> beacons)
    {
        foreach (var beacon in beacons)
        {
            AddBeacon(beacon);
        }
    }

    public void AddBeacon(Beacon beacon)
    {
        if (!ContainsBeacon(beacon))
        {
            Beacons.Add(beacon);
        }
    }

    public bool ContainsBeacon(Beacon beacon)
    {
        foreach (var scannerBeacon in Beacons)
        {
            if (scannerBeacon.Position.Equals(beacon.Position))
            {
                return true;
            }
        }
        return false;
    }

    public List<Beacon> GetRelativeBeacons()
    {
        var beacons = new List<Beacon>();
        foreach (var beacon in Beacons)
        {
            var b = Rotate(beacon.Position, Rotation);
            var x = Position.X + b.X;
            var y = Position.Y + b.Y;
            var z = Position.Z + b.Z;
            beacons.Add(new Beacon((int)x, (int)y, (int)z));
        }
        return beacons;
    }

    public Point3D Rotate(Point3D point, int rotation)
    {
        switch (rotation)
        {
            case 0:
                return new Point3D(point.X, point.Y, point.Z);
            case 1:
                return new Point3D(point.X, -point.Y, -point.Z);
            case 2:
                return new Point3D(point.X, point.Z, -point.Y);
            case 3:
                return new Point3D(point.X, -point.Z, point.Y);

            case 4:
                return new Point3D(-point.X, point.Z, point.Y);
            case 5:
                return new Point3D(-point.X, -point.Z, -point.Y);
            case 6:
                return new Point3D(-point.X, point.Y, -point.Z);
            case 7:
                return new Point3D(-point.X, -point.Y, point.Z);

            case 8:
                return new Point3D(point.Y, point.Z, point.X);
            case 9:
                return new Point3D(point.Y, -point.Z, -point.X);
            case 10:
                return new Point3D(point.Y, point.X, -point.Z);
            case 11:
                return new Point3D(point.Y, -point.X, point.Z);

            case 12:
                return new Point3D(-point.Y, point.X, point.Z);
            case 13:
                return new Point3D(-point.Y, -point.X, -point.Z);
            case 14:
                return new Point3D(-point.Y, point.Z, -point.X);
            case 15:
                return new Point3D(-point.Y, -point.Z, point.X);

            case 16:
                return new Point3D(point.Z, point.X, point.Y);
            case 17:
                return new Point3D(point.Z, -point.X, -point.Y);
            case 18:
                return new Point3D(point.Z, point.Y, -point.X);
            case 19:
                return new Point3D(point.Z, -point.Y, point.X);

            case 20:
                return new Point3D(-point.Z, point.Y, point.X);
            case 21:
                return new Point3D(-point.Z, -point.Y, -point.X);
            case 22:
                return new Point3D(-point.Z, point.X, -point.Y);
            case 23:
                return new Point3D(-point.Z, -point.X, point.Y);
        }
        throw new NotImplementedException();
    }

    // Kan weg?
    public Scanner Clone()
    {
        var scanner = new Scanner(Id);
        scanner.Position = Position;
        scanner.Rotation = Rotation;
        foreach (var beacon in Beacons)
        {
            scanner.Beacons.Add(new Beacon(beacon.Position));
        }
        return scanner;
    }

    public override string ToString()
    {
        return "Scanner " + Id + ": " + base.ToString();
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode() ^ base.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        if (obj is Scanner scanner)
        {
            if (scanner.Id == Id)
            {
                return base.Equals(obj);
            }
        }
        return false;
    }
}
