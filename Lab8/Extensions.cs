using System;
using System.Collections.Generic;

namespace Lab8
{
    public class AdjMatrix
    {
        private readonly bool[,] _matrix;
        private readonly int _vertexCount;

        public AdjMatrix(int vertexCount)
        {
            _matrix = new bool[vertexCount, vertexCount];
            _vertexCount = vertexCount;
        }

        public bool this[int h, int w]
        {
            get => _matrix[h, w];
            set => _matrix[h, w] = value;
        }

        public void FillDirect(IList<(int from, int to)> edges)
        {
            foreach (var (from, to) in edges)
                _matrix[from, to] = true;
        }
        public bool FillIndirect(IList<(int from, int to)> edges)
        {
            foreach (var (from, to) in edges)
            {
                if (_matrix[from, to])
                    return true;

                _matrix[from, to] = true;
                _matrix[to, from] = true;
            }

            return false;
        }

        public bool IsIndirect()
        {
            for (int i = 0; i < _vertexCount; i++)
            for (int j = 0; j <= i; j++)
                if (i == j && _matrix[i, j] || _matrix[i, j] != _matrix[j, i])
                    return false;

            return true;
        }
    }

    internal static class Extensions
    {
        public static IEnumerable<int> IndexesWhere<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            int index = 0;

            foreach (var element in source)
            {
                if (predicate(element))
                    yield return index;

                index++;
            }
        }
    }
}
