using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2021
{
    public class Day4 : PuzzleSolution<int>
    {
        public Day4() : base(year: 2021, day: 4) { }

        private string[] Input => GetInputAsStringArray();

        public override int ResultPartOne()
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

        public override int ResultPartTwo()
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

    class BingoBoard
    {
        private int[,] _rows = new int[5,5];
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
}
