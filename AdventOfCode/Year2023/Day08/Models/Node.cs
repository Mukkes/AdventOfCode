namespace AdventOfCode.Year2023.Day08.Models;
public class Node
{
    public string Name { get; }
    public Node Left { get; set; }
    public Node Right { get; set; }

    public Node(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return Name + " = (" + Left.Name + ", " + Right.Name + ")";
    }
}
