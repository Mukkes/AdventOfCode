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
    public override object? AnswerPartOne => 408;

    public override object? AnswerPartTwo => 13348L;

    protected override IInputParser<List<Scanner>> InputParser => new BeaconScannerParser();

    private HashSet<Point3D> ScannerPositions = new HashSet<Point3D>();
    private HashSet<Point3D> BeaconPositions = new HashSet<Point3D>();

    public override object SolvePartOne()
    {
        if (BeaconPositions.Count <= 0)
        {
            FindAllPositionsScannersAndBeacons();
        }
        return BeaconPositions.Count;
    }

    private void FindAllPositionsScannersAndBeacons()
    { 
        var startingScanner = 0;
        var scanners = ParsedInput;
        var foundScanners = new List<Scanner>
        {
            scanners[startingScanner]
        };
        AddPositions(scanners[startingScanner]);
        scanners.Remove(scanners[startingScanner]);
        for (var f = 0; f < foundScanners.Count; f++)
        {
            for (var n = 0; n < scanners.Count; n++)
            {
                for (var r = 0; r < 24; r++)
                {
                    var count = 0;
                    foreach (var beaconN in scanners[n].BeaconVectors)
                    {
                        count = 0;
                        foreach (var beaconF in foundScanners[f].BeaconPositions)
                        {
                            count = 0;
                            var difference = beaconF - Rotate(beaconN, r);
                            var checkedBeacons = 0;
                            foreach (var beaconND in scanners[n].BeaconVectors)
                            {
                                var rotatedBeaconND = Rotate(beaconND, r);
                                var p = rotatedBeaconND + difference;
                                if (foundScanners[f].BeaconPositions.Contains(p))
                                {
                                    count++;
                                }
                                checkedBeacons++;
                                if (scanners[n].BeaconVectors.Count - (checkedBeacons - count) < 12)
                                {
                                    break;
                                }
                            }
                            if (count >= 12)
                            {
                                var scanner = scanners[n];
                                scanner.Position = difference;
                                scanner.Rotation = r;
                                foundScanners.Add(scanner);
                                scanners.Remove(scanner);
                                AddPositions(scanner);
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
    }

    private void AddPositions(Scanner scanner)
    {
        ScannerPositions.Add(scanner.Position);
        //Console.WriteLine("Scanner" + scanner.Id + ": " + scanner.Position);
        foreach (var beacon in scanner.BeaconPositions)
        {
            BeaconPositions.Add(beacon);
            //Console.WriteLine("Beacon: " + beacon);
        }
    }

    public static Vector3D Rotate(Vector3D vector, int rotation)
    {
        switch (rotation)
        {
            case 0:
                return new Vector3D(vector.X, vector.Y, vector.Z);
            case 1:
                return new Vector3D(vector.X, -vector.Y, -vector.Z);
            case 2:
                return new Vector3D(vector.X, vector.Z, -vector.Y);
            case 3:
                return new Vector3D(vector.X, -vector.Z, vector.Y);

            case 4:
                return new Vector3D(-vector.X, vector.Z, vector.Y);
            case 5:
                return new Vector3D(-vector.X, -vector.Z, -vector.Y);
            case 6:
                return new Vector3D(-vector.X, vector.Y, -vector.Z);
            case 7:
                return new Vector3D(-vector.X, -vector.Y, vector.Z);

            case 8:
                return new Vector3D(vector.Y, vector.Z, vector.X);
            case 9:
                return new Vector3D(vector.Y, -vector.Z, -vector.X);
            case 10:
                return new Vector3D(vector.Y, vector.X, -vector.Z);
            case 11:
                return new Vector3D(vector.Y, -vector.X, vector.Z);

            case 12:
                return new Vector3D(-vector.Y, vector.X, vector.Z);
            case 13:
                return new Vector3D(-vector.Y, -vector.X, -vector.Z);
            case 14:
                return new Vector3D(-vector.Y, vector.Z, -vector.X);
            case 15:
                return new Vector3D(-vector.Y, -vector.Z, vector.X);

            case 16:
                return new Vector3D(vector.Z, vector.X, vector.Y);
            case 17:
                return new Vector3D(vector.Z, -vector.X, -vector.Y);
            case 18:
                return new Vector3D(vector.Z, vector.Y, -vector.X);
            case 19:
                return new Vector3D(vector.Z, -vector.Y, vector.X);

            case 20:
                return new Vector3D(-vector.Z, vector.Y, vector.X);
            case 21:
                return new Vector3D(-vector.Z, -vector.Y, -vector.X);
            case 22:
                return new Vector3D(-vector.Z, vector.X, -vector.Y);
            case 23:
                return new Vector3D(-vector.Z, -vector.X, vector.Y);
        }
        throw new NotImplementedException();
    }

    public override object SolvePartTwo()
    {
        if (ScannerPositions.Count <= 0)
        {
            FindAllPositionsScannersAndBeacons();
        }
        var maxDistance = long.MinValue;
        foreach (var scanner1 in ScannerPositions)
        {
            foreach (var scanner2 in ScannerPositions)
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

    private long ScannerDistance(Point3D pointA, Point3D pointB)
    {
        var difference = pointA - pointB;
        return long.Abs(difference.X) + long.Abs(difference.Y) + long.Abs(difference.Z);
    }
}
