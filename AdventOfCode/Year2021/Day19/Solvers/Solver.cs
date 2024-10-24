using AdventOfCode.Year2021.Day19.Models;
using AdventOfCode.Year2021.Day19.Parsers;
using AdventOfCodeLibrary.Attributes;
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

    public Solver()
    {
        _scanners = ParsedInput;
        _fullMap = _scanners[1].Clone();
        _foundScanners = new List<Scanner>
        {
            _scanners[1]
        };
        _scanners.Remove(_scanners[1]);
    }

    private List<Scanner> _scanners;
    private List<Scanner> _foundScanners;
    private Scanner _fullMap;

    public override object SolvePartOne()
    {
        for (var i = 0; i < _scanners.Count; i++)
        {
            if (DoScannersOverlap(_fullMap, _scanners[i]))
            {
                i = -1;
            }
        }
        foreach (var beacon in _fullMap.Beacons)
        {
            Console.WriteLine(beacon);
        }
        return _fullMap.Beacons.Count;
    }

    private bool DoScannersOverlap(Scanner scanner1, Scanner scanner2)
    {
        foreach (var beacon1 in scanner1.Beacons)
        {
            for (int i = 0; i < 24; i++)
            {
                var clone = scanner2.Clone();
                clone.Rotate(i);
                for (var j = 0; j < 15; j++)
                {
                    var difference = GetDifference(beacon1, clone.Beacons[j]);
                    clone.SetPosition(difference);
                    if (_fullMap.DoesScannerOverlap(clone))
                    {
                        var count = _fullMap.Beacons.Count;
                        _fullMap.AddBeacons(clone.GetRelativeBeacons());
                        Console.WriteLine(clone);
                        if (_fullMap.Beacons.Count > count)
                        {
                            scanner2.SetPosition(difference);
                            _foundScanners.Add(scanner2);
                            _scanners.Remove(scanner2);
                            return true;
                        }
                        return false;
                    }
                }
            }
        }
        return false;
    }

    public override object SolvePartTwo()
    {
        for (var i = 0; i < _scanners.Count; i++)
        {
            if (DoScannersOverlap(_fullMap, _scanners[i]))
            {
                i = -1;
            }
        }
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

    private Position GetDifference(Position position1, Position position2)
    {
        var position = new Position();
        position.X = position1.X - position2.X;
        position.Y = position1.Y - position2.Y;
        position.Z = position1.Z - position2.Z;
        return position;
    }

    private int ScannerDistance(Scanner scanner1, Scanner scanner2)
    {
        var difference = GetDifference(scanner1, scanner2);
        return int.Abs(difference.X) + int.Abs(difference.Y) + int.Abs(difference.Z);
    }
}
