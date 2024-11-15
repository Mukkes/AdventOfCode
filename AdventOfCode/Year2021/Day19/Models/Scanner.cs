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
            var x = X + beacon.X;
            var y = Y + beacon.Y;
            var z = Z + beacon.Z;
            beacons.Add(new Beacon(x, y, z));
        }
        return beacons;
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
