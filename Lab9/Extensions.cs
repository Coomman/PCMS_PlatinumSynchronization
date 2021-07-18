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
        private readonly HashSet<int> _edges;
        
        public Color Color { get; set; } = Color.White;
        public PartColor PartColor { get; set; }
        public int LocalIndex { get; set; }

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

    public abstract class Graph : IEnumerable<Vertex>
    {
        protected readonly List<Vertex> _vertexes;

        public Vertex this[int index] => _vertexes[index];
        
        protected Graph(int vertexCount, IReadOnlyList<HashSet<int>> edges)
        {
            _vertexes = new List<Vertex>(vertexCount);

            foreach (var e in edges)
            {
                _vertexes.Add(new Vertex(e));
            }
        }

        public int VertexesCount => _vertexes.Count;
        
        public IEnumerator<Vertex> GetEnumerator()
        {
            return _vertexes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public abstract class GraphTask : ConsoleTask
    {
        protected T ReadGraph<T>(int vertexesCount, int edgesCount, bool nonOriented = false) where T : Graph
        {
            var edges = Enumerable.Repeat(0, vertexesCount)
                .Select(edge => new HashSet<int>()).ToArray();

            for (int i = 0; i < edgesCount; i++)
            {
                var numbers = ReadIntArray();
                
                edges[numbers[0] - 1].Add(numbers[1] - 1);

                if (nonOriented)
                    edges[numbers[1] - 1].Add(numbers[0] - 1);
            }

            return (T) Activator.CreateInstance(typeof(T), vertexesCount, edges);
        }

        public abstract override void Execute();
    }
}
