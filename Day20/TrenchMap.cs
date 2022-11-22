using System;

namespace AdventOfCode2021.Day20
{
    public class TrenchMap
    {
        private const char _darkPixel = '.';
        private const char _lightPixel = '#';

        private string _algorithm;
        private Dictionary<Point, char> _pixels;
        private int _minX;
        private int _minY;
        private int _maxX;
        private int _maxY;
        private char _fillPixel;

        public TrenchMap(string algorithm) : this(algorithm, _darkPixel) { }

        public TrenchMap(string algorithm, char fillPixel)
        {
            _algorithm = algorithm;
            _pixels = new Dictionary<Point, char>();
            _minX = int.MaxValue;
            _minY = int.MaxValue;
            _maxX = int.MinValue;
            _maxY = int.MinValue;
            _fillPixel = fillPixel;
        }

        public TrenchMap Enhance()
        {
            var trenchMap = new TrenchMap(_algorithm, GetFillPixel(_fillPixel));
            for (var x = _minX - 1; x <= _maxX + 1; x++)
            {
                for (var y = _minY - 1; y <= _maxY + 1; y++)
                {
                    var pixels = string.Empty;
                    pixels += GetPixel(new Point(x - 1, y - 1));
                    pixels += GetPixel(new Point(x - 1, y));
                    pixels += GetPixel(new Point(x - 1, y + 1));

                    pixels += GetPixel(new Point(x, y - 1));
                    pixels += GetPixel(new Point(x, y));
                    pixels += GetPixel(new Point(x, y + 1));

                    pixels += GetPixel(new Point(x + 1, y - 1));
                    pixels += GetPixel(new Point(x + 1, y));
                    pixels += GetPixel(new Point(x + 1, y + 1));

                    var binary = ConvertPixelsToBinary(pixels);
                    var index = ConvertBinaryToInt(binary);
                    var pixel = GetPixelFromAlgorithm(index);
                    var point = new Point(x, y);
                    trenchMap.AddPixel(point, pixel);
                }
            }
            return trenchMap;
        }

        public void AddPixel(Point point, char pixel)
        {
            if (point.X < _minX)
            {
                _minX = point.X;
            }
            if (point.Y < _minY)
            {
                _minY = point.Y;
            }
            if (point.X > _maxX)
            {
                _maxX = point.X;
            }
            if (point.Y > _maxY)
            {
                _maxY = point.Y;
            }
            _pixels.Add(point, pixel);
        }

        public char GetPixel(Point point)
        {
            if (_pixels.ContainsKey(point))
            {
                return _pixels[point];
            }
            return _fillPixel;
        }

        public int CountLightPixels()
        {
            return _pixels.Where(pixel => pixel.Value == _lightPixel).Count();
        }

        private string ConvertPixelsToBinary(string pixels)
        {
            var binary = string.Empty;
            foreach (var pixel in pixels)
            {
                if (pixel == _lightPixel)
                {
                    binary += '1';
                }
                else
                {
                    binary += '0';
                }
            }
            return binary;
        }

        private char GetPixelFromAlgorithm(int index)
        {
            return _algorithm[index];
        }

        private int ConvertBinaryToInt(string binary)
        {
            return Convert.ToInt32(binary, 2);
        }

        private char GetFillPixel(char pixel)
        {
            if (pixel == _darkPixel)
            {
                return GetPixelFromAlgorithm(0);
            }
            else
            {
                return GetPixelFromAlgorithm(511);
            }
        }

        public void Print()
        {
            var row = 1;
            for (var x = _minX; x <= _maxX; x++)
            {
                Console.Write(row++);
                Console.Write(": ");
                for (var y = _minY; y <= _maxY; y++)
                {
                    Console.Write(GetPixel(new Point(x, y)));
                }
                Console.WriteLine();
            }
        }
    }
}
