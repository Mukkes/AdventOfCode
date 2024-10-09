namespace AdventOfCode.Year2021.Day04.Models;

public class BingoBoard
{
    private int[,] _rows = new int[5, 5];
    private int _rowCount = 0;
    public bool Bingo { private set; get; } = false;

    public void AddRow(int[] numbers)
    {
        for (var i = 0; i < numbers.Length; i++)
        {
            _rows[_rowCount, i] = numbers[i];
        }
        _rowCount++;
    }

    public bool Mark(int number)
    {
        for (var i = 0; i < 5; i++)
        {
            for (var j = 0; j < 5; j++)
            {
                if (_rows[i, j] == number)
                {
                    _rows[i, j] = -1;
                    if (HasBingo(i, j))
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private bool HasBingo(int row, int column)
    {
        var rowSum = 0;
        for (var i = 0; i < 5; i++)
        {
            rowSum += _rows[row, i];
        }
        if (rowSum == -5)
        {
            Bingo = true;
            return true;
        }
        var columnSum = 0;
        for (var i = 0; i < 5; i++)
        {
            columnSum += _rows[i, column];
        }
        if (columnSum == -5)
        {
            Bingo = true;
            return true;
        }
        return false;
    }

    public int GetSumUnmarktNumbers()
    {
        var sum = 0;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (_rows[i, j] != -1)
                {
                    sum += _rows[i, j];
                }
            }
        }
        return sum;
    }
}
