using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Solvers;
using System.Reflection;

namespace AdventOfCodeLibrary;

public class SolverRegister
{
    private readonly IReadOnlyList<string> _assemblyFileNames;

    public SolverRegister(List<string> assemblyFileNames)
    {
        _assemblyFileNames = assemblyFileNames.AsReadOnly();
        Solvers = GetSolvers().AsReadOnly();
    }

    public IReadOnlyList<IBaseSolver> Solvers { get; }

    private IEnumerable<Assembly> Assemblies
    {
        get
        {
            foreach (var assemblyFileName in _assemblyFileNames)
            {
                yield return Assembly.LoadFrom(assemblyFileName);
            }
        }
    }

    private IEnumerable<Type> Types
    {
        get
        {
            var types = new List<Type>();
            foreach (var assembly in Assemblies)
            {
                types.AddRange(assembly.GetTypes());
            }
            return types;
        }
    }

    private List<IBaseSolver> GetSolvers()
    {
        var solvers = new List<IBaseSolver>();
        foreach (Type type in Types)
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
}
