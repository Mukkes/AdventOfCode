namespace AdventOfCode.Year2021.Day19.Models;
public class Scanner : Position
{
    public Scanner(int id) : base(0, 0, 0)
    {
        Id = id;
        Beacons = new List<Beacon>();
    }

    public int Id { get; }

    public List<Beacon> Beacons { get; }

    public int Rotation { get; set; }

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

    public bool DoesScannerOverlap(Scanner scanner)
    {
        var count = 0;
        var otherCount = scanner.Beacons.Count;
        foreach (var beacon in scanner.GetRelativeBeacons())
        {
            if (ContainsBeacon(beacon))
            {
                count++;
                if (count >= 12)
                {
                    return true;
                }
            }
            else
            {
                otherCount--;
                if ((otherCount + count) < 12)
                {
                    return false;
                }
            }
        }
        return false;
    }

    public bool ContainsBeacon(Beacon beacon)
    {
        foreach (var scannerBeacon in Beacons)
        {
            if (scannerBeacon.Equals(beacon))
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
            var b = Rotate(beacon, Rotation);
            var x = X + b.X;
            var y = Y + b.Y;
            var z = Z + b.Z;
            beacons.Add(new Beacon(x, y, z));
        }
        return beacons;
    }
    public Position Rotate(Position position, int rotation)
    {
        switch (rotation)
        {
            case 0:
                return new Position(position.X, position.Y, position.Z);
            case 1:
                return new Position(position.X, -position.Y, -position.Z);
            case 2:
                return new Position(position.X, position.Z, -position.Y);
            case 3:
                return new Position(position.X, -position.Z, position.Y);

            case 4:
                return new Position(-position.X, position.Z, position.Y);
            case 5:
                return new Position(-position.X, -position.Z, -position.Y);
            case 6:
                return new Position(-position.X, position.Y, -position.Z);
            case 7:
                return new Position(-position.X, -position.Y, position.Z);

            case 8:
                return new Position(position.Y, position.Z, position.X);
            case 9:
                return new Position(position.Y, -position.Z, -position.X);
            case 10:
                return new Position(position.Y, position.X, -position.Z);
            case 11:
                return new Position(position.Y, -position.X, position.Z);

            case 12:
                return new Position(-position.Y, position.X, position.Z);
            case 13:
                return new Position(-position.Y, -position.X, -position.Z);
            case 14:
                return new Position(-position.Y, position.Z, -position.X);
            case 15:
                return new Position(-position.Y, -position.Z, position.X);

            case 16:
                return new Position(position.Z, position.X, position.Y);
            case 17:
                return new Position(position.Z, -position.X, -position.Y);
            case 18:
                return new Position(position.Z, position.Y, -position.X);
            case 19:
                return new Position(position.Z, -position.Y, position.X);

            case 20:
                return new Position(-position.Z, position.Y, position.X);
            case 21:
                return new Position(-position.Z, -position.Y, -position.X);
            case 22:
                return new Position(-position.Z, position.X, -position.Y);
            case 23:
                return new Position(-position.Z, -position.X, position.Y);
        }
        throw new NotImplementedException();
    }

    public new Scanner Clone()
    {
        var scanner = new Scanner(Id);
        scanner.SetPosition(this);
        foreach (var beacon in Beacons)
        {
            scanner.Beacons.Add(new Beacon(beacon));
        }
        return scanner;
    }

    public override void Rotate(int i)
    {
        foreach (var beacon in Beacons)
        {
            beacon.Rotate(i);
        }
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
