using AdventOfCode.Year2021.Day19.Solvers;
using AdventOfCodeLibrary.Models;

namespace AdventOfCode.Year2021.Day19.Models;
public class Scanner
{
    public Scanner(int id)
    {
        Id = id;
        Position = new Point3D();
        Rotation = 0;
    }

    public int Id { get; }

    private Point3D _position;
    public Point3D Position
    {
        get => _position;
        set
        {
            _position = value;
            _beaconPositions.Clear();
        }
    }

    private int _rotation;
    public int Rotation
    {
        get => _rotation;
        set
        {
            _rotation = value;
            _beaconPositions.Clear();
        }
    }

    public HashSet<Vector3D> BeaconVectors { get; } = new HashSet<Vector3D>();

    private HashSet<Point3D> _beaconPositions = new HashSet<Point3D>();
    public HashSet<Point3D> BeaconPositions
    {
        get
        {
            if (_beaconPositions.Count == 0)
            {
                foreach (var beaconVector in BeaconVectors)
                {
                    var vector = Solver.Rotate(beaconVector, Rotation);
                    _beaconPositions.Add(Position + vector);
                }
            }
            return _beaconPositions;
        }
    }
}
