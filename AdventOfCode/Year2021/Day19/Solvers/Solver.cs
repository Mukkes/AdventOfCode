using AdventOfCode.Year2021.Day19.Models;
using AdventOfCode.Year2021.Day19.Parsers;
using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Models;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2021.Day19.Solvers;

[Solver]
public class Solver : BaseSolver<List<Scanner>>
{
    public override int Year => 2021;

    public override int Day => 19;

    public override object? AnswerPartOne => 408;

    public override object? AnswerPartTwo => 13348;

    protected override IInputParser<List<Scanner>> InputParser => new BeaconScannerParser();

    private List<Point3D> Scanners;
    private List<Point3D> Beacons;
    private List<Scanner> _scanners;
    private List<Scanner> _foundScanners;
    private Scanner _fullMap;

    private void ScannerFound(Scanner scanner)
    {
        _foundScanners.Add(scanner);
        _scanners.Remove(scanner);
    }

    public override object SolvePartOne()
    {
        var startingScanner = 0;
        _scanners = ParsedInput;
        _fullMap = _scanners[startingScanner].Clone();
        _foundScanners = new List<Scanner>
        {
            _scanners[startingScanner]
        };
        _scanners.Remove(_scanners[startingScanner]);
        for (var f = 0; f < _foundScanners.Count; f++)
        {
            for (var n = 0; n < _scanners.Count; n++)
            {
                for (var r = 0; r < 24; r++)
                {
                    var count = 0;
                    foreach (var beaconN in _scanners[n].Beacons)
                    {
                        count = 0;
                        foreach (var beaconF in _foundScanners[f].GetRelativeBeacons())
                        {
                            count = 0;
                            var difference = GetDifference(beaconF.Position, Rotate(beaconN.Position, r));
                            foreach (var beaconND in _scanners[n].Beacons)
                            {
                                var rotatedBeaconND = Rotate(beaconND.Position, r);
                                var p = AddPosition(rotatedBeaconND, difference);
                                foreach (var beaconFD in _foundScanners[f].GetRelativeBeacons())
                                {
                                    if (beaconFD.Position.X == p.X && beaconFD.Position.Y == p.Y && beaconFD.Position.Z == p.Z)
                                    {
                                        count++;
                                        break;
                                    }
                                }
                            }
                            if (count >= 12)
                            {
                                var scanner = _scanners[n];
                                scanner.Position = difference;
                                scanner.Rotation = r;
                                _foundScanners.Add(scanner);
                                _scanners.Remove(scanner);
                                _fullMap.AddBeacons(scanner.GetRelativeBeacons());
                                n--;
                                break;
                            }
                        }
                        if (count >= 12)
                        {
                            break;
                        }
                    }
                    if (count >= 12)
                    {
                        break;
                    }
                }
            }
        }
        return _fullMap.Beacons.Count;
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

    public override object SolvePartTwo()
    {
        var maxDistance = int.MinValue;
        foreach (var scanner1 in _foundScanners)
        {
            foreach (var scanner2 in _foundScanners)
            {
                if (scanner1 != scanner2)
                {
                    var distance = ScannerDistance(scanner1, scanner2);
                    if (distance > maxDistance)
                    {
                        maxDistance = distance;
                    }
                }
            }
        }
        return maxDistance;
    }

    private Point3D GetDifference(Point3D point1, Point3D point2)
    {
        var x = point1.X - point2.X;
        var y = point1.Y - point2.Y;
        var z = point1.Z - point2.Z;
        return new Point3D(x, y, z);
    }

    private Point3D AddPosition(Point3D point1, Point3D point2)
    {
        var x = point1.X + point2.X;
        var y = point1.Y + point2.Y;
        var z = point1.Z + point2.Z;
        return new Point3D(x, y, z);
    }

    private int ScannerDistance(Scanner scanner1, Scanner scanner2)
    {
        var difference = GetDifference(scanner1.Position, scanner2.Position);
        return int.Abs(difference.X) + int.Abs(difference.Y) + int.Abs(difference.Z);
    }
}
