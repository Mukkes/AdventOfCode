using AdventOfCode.Year2021.Day04.Models;
using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2021.Day04.Solvers;

[Solver]
public class Solver : StringArraySolver
{
    public override int Year => 2021;

    public override int Day => 4;

    public override object? AnswerPartOne => 35670;

    public override object? AnswerPartTwo => 22704;

    public override object SolvePartOne()
    {
        var bingoNumbers = GetBingoNumbers();
        var bingoBoards = GetBingoBoards();
        foreach (var number in bingoNumbers)
        {
            foreach (var board in bingoBoards)
            {
                if (board.Mark(number))
                {
                    return board.GetSumUnmarktNumbers() * number;
                }
            }
        }
        return 0;
    }

    private List<int> GetBingoNumbers()
    {
        var line = Input[0];
        var bingoNumbers = line.Split(',');
        return bingoNumbers.Select(int.Parse).ToList();
    }

    private List<BingoBoard> GetBingoBoards()
    {
        var boards = new List<BingoBoard>();
        var board = default(BingoBoard);
        for (var i = 1; i < Input.Length; i++)
        {
            if (string.IsNullOrEmpty(Input[i]))
            {
                board = new BingoBoard();
                boards.Add(board);
            }
            else
            {
                var numbersAsString = Input[i].Split(" ");
                var numbers = RemoveEmptyItems(numbersAsString.ToList());
                board.AddRow(numbers.Select(int.Parse).ToArray());
            }
        }
        return boards;
    }

    private List<string> RemoveEmptyItems(List<string> list)
    {
        var newList = new List<string>();
        foreach (var item in list)
        {
            if (!string.IsNullOrEmpty(item))
            {
                newList.Add(item);
            }
        }
        return newList;
    }

    public override object SolvePartTwo()
    {
        var result = 0;
        var bingoNumbers = GetBingoNumbers();
        var bingoBoards = GetBingoBoards();
        foreach (var number in bingoNumbers)
        {
            foreach (var board in bingoBoards)
            {
                if (!board.Bingo && board.Mark(number))
                {
                    result = board.GetSumUnmarktNumbers() * number;
                }
            }
        }
        return result;
    }
}
