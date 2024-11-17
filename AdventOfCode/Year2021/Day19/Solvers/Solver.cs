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

    private List<Scanner> _scanners;
    private List<Scanner> _foundScanners;
    private Scanner _fullMap;

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
                            var difference = GetDifference(beaconF, Rotate(beaconN, r));
                            foreach (var beaconND in _scanners[n].Beacons)
                            {
                                var rotatedBeaconND = Rotate(beaconND, r);
                                var p = AddPosition(rotatedBeaconND, difference);
                                foreach (var beaconFD in _foundScanners[f].GetRelativeBeacons())
                                {
                                    if (beaconFD.X == p.X && beaconFD.Y == p.Y && beaconFD.Z == p.Z)
                                    {
                                        count++;
                                        break;
                                    }
                                }
                            }
                            if (count >= 12)
                            {
                                var scanner = _scanners[n];
                                scanner.SetPosition(difference);
                                scanner.Rotation = r;
                                _foundScanners.Add(scanner);
                                _scanners.Remove(scanner);
                                _fullMap.AddBeacons(scanner.GetRelativeBeacons());
                                n--;
                                Console.WriteLine(scanner);
                                //foreach (var b in scanner.GetRelativeBeacons())
                                //{
                                //    Console.WriteLine(b);
                                //}
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

    //public override object SolvePartOne()
    //{
    //    var startingScanner = 0;
    //    _scanners = ParsedInput;
    //    _fullMap = _scanners[startingScanner].Clone();
    //    _foundScanners = new List<Scanner>
    //    {
    //        _scanners[startingScanner]
    //    };
    //    _scanners.Remove(_scanners[startingScanner]);
    //    for (var i = 0; i < _foundScanners.Count; i++)
    //    {
    //        for (var j = 0; j < _scanners.Count; j++)
    //        {
    //            //Console.WriteLine("Does " + _foundScanners[i] + " overlap with " + _scanners[j]);
    //            //if (DoScannersOverlap(_foundScanners[i], _scanners[j]))
    //            if (DoScannersOverlap(_fullMap, _scanners[j]))
    //            {
    //                j = -1;
    //            }
    //        }
    //    }
    //    foreach (var beacon in _fullMap.Beacons)
    //    {
    //        Console.WriteLine(beacon);
    //    }
    //    return _fullMap.Beacons.Count;
    //}

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
                        //var count = _fullMap.Beacons.Count;
                        _fullMap.AddBeacons(clone.GetRelativeBeacons());
                        Console.WriteLine(clone);
                        //if (_fullMap.Beacons.Count > count)
                        //{
                            scanner2.SetPosition(difference);
                            _foundScanners.Add(scanner2);
                            _scanners.Remove(scanner2);
                            return true;
                        //}
                        //return false;
                    }
                }
            }
        }
        return false;
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

    private Position GetDifference(Position position1, Position position2)
    {
        var position = new Position();
        position.X = position1.X - position2.X;
        position.Y = position1.Y - position2.Y;
        position.Z = position1.Z - position2.Z;
        return position;
    }

    private Position AddPosition(Position position1, Position position2)
    {
        var position = new Position();
        position.X = position1.X + position2.X;
        position.Y = position1.Y + position2.Y;
        position.Z = position1.Z + position2.Z;
        return position;
    }

    private int ScannerDistance(Scanner scanner1, Scanner scanner2)
    {
        var difference = GetDifference(scanner1, scanner2);
        return int.Abs(difference.X) + int.Abs(difference.Y) + int.Abs(difference.Z);
    }
}
