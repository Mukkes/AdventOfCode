using AdventOfCode.Year2023.Day08.Models;
using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2023.Day08.Solvers;

[Solver]
public class Solver : StringArraySolver
{
    public override int Year => 2023;

    public override int Day => 8;

    public override object? AnswerPartOne => 20777;

    public override object? AnswerPartTwo => 13289612809129L;

    public override object SolvePartOne()
    {
        var nodes = GetNodes(ParsedInput[2..]);
        var steps = 0;
        var node = nodes.Single(node => node.Name == "AAA");
        while (node.Name != "ZZZ")
        {
            foreach (var c in ParsedInput[0])
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
        var nodes = GetNodes(ParsedInput[2..]);
        var startNodes = GetStartNodes(nodes);
        var steps = new List<long>();
        for (var i = 0; i < startNodes.Count; i++)
        {
            steps.Add(StepsUntilEndWithZ(startNodes[i], ParsedInput[0]));
        }
        var highestSteps = steps.Max();
        var totalSteps = 0L;
        while (true)
        {
            totalSteps += highestSteps;
            var b = true;
            foreach (var step in steps)
            {
                if (totalSteps % step != 0)
                {
                    b = false;
                    break;
                }
            }
            if (b)
            {
                break;
            }
        }
        return totalSteps;
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

    private long StepsUntilEndWithZ(Node node, string navigation)
    {
        var steps = 0L;
        do
        {
            foreach (var c in navigation)
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
        } while (node.Name[2] != 'Z');
        return steps;
    }
}
