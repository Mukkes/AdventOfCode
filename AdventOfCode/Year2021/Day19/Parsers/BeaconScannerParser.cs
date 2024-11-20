using AdventOfCode.Year2021.Day19.Models;
using AdventOfCodeLibrary.Models;
using AdventOfCodeLibrary.Parsers;

namespace AdventOfCode.Year2021.Day19.Parsers;
internal class BeaconScannerParser : StringArrayParser, IInputParser<List<Scanner>>
{
    public new List<Scanner> Parse(string input)
    {
        var scanners = new List<Scanner>();
        foreach (var s in base.Parse(input))
        {
            if (s == string.Empty)
            {
                continue;
            }
            if (s[0..2] == "--")
            {
                var scannerInfo = s.Split(' ');
                scanners.Add(new Scanner(int.Parse(scannerInfo[2])));
            }
            else
            {
                var beaconInfo = s.Split(',');
                var beaconVector = new Vector3D(int.Parse(beaconInfo[0]), int.Parse(beaconInfo[1]), int.Parse(beaconInfo[2]));
                scanners.Last().BeaconVectors.Add(beaconVector);
            }
        }
        return scanners;
    }
}
