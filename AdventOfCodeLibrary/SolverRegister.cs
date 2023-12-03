using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Models;
using AdventOfCodeLibrary.Solvers;
using System.Collections.ObjectModel;
using System.Reflection;

namespace AdventOfCodeLibrary;

public class SolverRegister
{
    public readonly ReadOnlyDictionary<YearDay, IBaseSolver> Solvers;

    public SolverRegister(Assembly assembly)
    {
        var solvers = GetSolvers(assembly);
        Solvers = new ReadOnlyDictionary<YearDay, IBaseSolver>(solvers);
    }

    private Dictionary<YearDay, IBaseSolver> GetSolvers(Assembly assembly)
    {
        var solvers = new Dictionary<YearDay, IBaseSolver>();
        foreach (Type type in assembly.GetTypes())
        {
            if (type.GetCustomAttributes(typeof(SolverAttribute), true).Length > 0)
            {
                var solver = Activator.CreateInstance(type) as IBaseSolver;
                if (solver == null)
                {
                    continue;
                }
                var yearDay = new YearDay(solver.Year, solver.Day);
                solvers.Add(yearDay, solver);
            }
        }
        return solvers;
    }
}
