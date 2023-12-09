using AdventOfCode.Year2023.Day08.Models;
using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2023.Day08.Solvers;

[Solver]
public class Solver : StringArraySolver
{
    public override int Year => 2023;

    public override int Day => 08;

    public override object SolvePartOne()
    {
        var nodes = GetNodes(Input[2..]);
        var steps = 0;
        var node = nodes.Single(node => node.Name == "AAA");
        while (node.Name != "ZZZ")
        {
            foreach (var c in Input[0])
            {
                if (c == 'L')
                {
                    node = node.Left;
                }
                else
                {
                    node = node.Right;
                }
                steps++;
            }
        }
        return steps;
    }

    public override object SolvePartTwo()
    {
        var nodes = GetNodes(Input[2..]);
        var startNodes = GetStartNodes(nodes);
        return 0;
    }

    private List<Node> GetNodes(string[] input)
    {
        var nodes = new List<Node>();
        foreach (var line in input)
        {
            nodes.Add(new Node(line[0..3]));
        }
        for (var i = 0; i < input.Length; i++)
        {
            nodes[i].Left = nodes.Single(node => node.Name == input[i][7..10]);
            nodes[i].Right = nodes.Single(node => node.Name == input[i][12..15]);
        }
        return nodes;
    }

    private List<Node> GetStartNodes(List<Node> nodes)
    {
        return nodes.Where(node => node.Name[2] == 'A').ToList();
    }

    private void HandleSteps(Dictionary<string, Node> nodes, string steps)
    {

    }
}
