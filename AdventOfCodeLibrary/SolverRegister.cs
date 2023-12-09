using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Solvers;
using System.Collections;

namespace AdventOfCodeLibrary;

public class SolverRegister : IEnumerable<IBaseSolver>
{
    private readonly IReadOnlyList<IBaseSolver> _solvers;

    public SolverRegister()
    {
        _solvers = GetSolvers() ?? new List<IBaseSolver>();
    }

    public IEnumerator<IBaseSolver> GetEnumerator()
    {
        return _solvers.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private List<IBaseSolver> GetSolvers()
    {
        var solvers = new List<IBaseSolver>();
        foreach (Type type in GetTypesFromAssemblies())
        {
            if (type.GetCustomAttributes(typeof(SolverAttribute), true).Length > 0)
            {
                var solver = Activator.CreateInstance(type) as IBaseSolver;
                if (solver != null)
                {
                    solvers.Add(solver);
                }
            }
        }
        return solvers
            .OrderBy(solver => solver.Year)
            .ThenBy(solver => solver.Day)
            .ToList();
    }

    private IEnumerable<Type> GetTypesFromAssemblies()
    {
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            foreach (Type type in assembly.GetTypes())
            {
                yield return type;
            }
        }
    }
}
