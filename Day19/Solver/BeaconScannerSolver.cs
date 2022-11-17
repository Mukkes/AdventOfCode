using AdventOfCode2021.Day16.Solvers;
using AdventOfCode2021.Day19.Parsers;

namespace AdventOfCode2021.Day19.Solver
{
    public abstract class BeaconScannerSolver : BaseSolver<List<Scanner>>
    {
        public BeaconScannerSolver(string? input) : base(new BeaconScannerParser(), input) { }
    }
}
