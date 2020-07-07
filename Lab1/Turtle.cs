using System.IO;
using CodeChallenge.Core;

namespace Lab1
{
    public class Turtle : IFileTask
    {
        private int[,] _field;

        private int _height;
        private int _width;

        public int MaxValue { get; private set; }

        public Turtle() { }
        public Turtle(int[,] field, int height, int width)
        {
            _field = field;
            _height = height;
            _width = width;
        }

        public void FindBestPath(int i, int j, int value = 0)
        {
            _field[i, j] += value;

            if (i == _height - 1 && j == 0 && MaxValue < _field[i, j])
                MaxValue = _field[i, j];

            if (i + 1 < _height)
                FindBestPath(i + 1, j, _field[i, j]);

            if (j > 0)
                FindBestPath(i, j - 1, _field[i, j]);

            _field[i, j] -= value;
        }

        public void ExecuteFile(StreamReader sr, StreamWriter sw)
        {
            var query = sr.ReadLine().Split();

            _height = int.Parse(query[0]);
            _width = int.Parse(query[1]);

            _field = new int[_height, _width];

            for (int i = 0; i < _height; i++)
            {
                query = sr.ReadLine().Split();

                for (int j = 0; j < _width; j++)
                    _field[i, j] = int.Parse(query[j]);
            }

            FindBestPath(0, _width - 1);

            sw.WriteLine(MaxValue);
        }
    }
}
