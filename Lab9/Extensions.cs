using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using CodeChallenge.Core;

namespace Lab9
{
    public enum Color : byte {White, Gray, Black};
    public enum PartColor : byte {Red, Blue};

    public class Vertex : IEnumerable<int>
    {
        public Color Color { get; set; } = Color.White;
        public PartColor PartColor { get; set; }
        
        private readonly HashSet<int> _edges;

        public Vertex(HashSet<int> edges)
        {
            _edges = edges;
        }

        public bool NotVisited => Color == Color.White;

        public IEnumerator<int> GetEnumerator()
        {
            return _edges.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public abstract class Graph
    {
        protected readonly Vertex[] _vertexes;

        public Vertex this[int index] => _vertexes[index];
        
        protected Graph(int vertexCount, IReadOnlyList<HashSet<int>> edges)
        {
            _vertexes = new Vertex[vertexCount];

            for (int i = 0; i < vertexCount; i++)
                _vertexes[i] = new Vertex(edges[i]);
        }

        public string GetVertexesInfo()
            => string.Join(" ", _vertexes.Select(v => v.Color));

        public int VertexesCount => _vertexes.Length;
    }

    public abstract class GraphTask : ConsoleTask
    {
        protected T ReadGraph<T>(bool isNotOriented = false) where T : Graph
        {
            var numbers = ReadIntArray();

            int vertexesCount = numbers[0];
            int edgesCount = numbers[1];

            var edges = Enumerable.Repeat(0, vertexesCount)
                .Select(edge => new HashSet<int>()).ToArray();

            for (int i = 0; i < edgesCount; i++)
            {
                numbers = ReadIntArray();
                edges[numbers[0] - 1].Add(numbers[1] - 1);

                if (isNotOriented)
                    edges[numbers[1] - 1].Add(numbers[0] - 1);
            }

            return (T) Activator.CreateInstance(typeof(T), vertexesCount, edges);
        }

        public abstract override void Execute();
    }
}
