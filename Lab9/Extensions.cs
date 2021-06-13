using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Lab9
{
    public enum Color : byte {White, Gray, Black};

    public class Vertex : IEnumerable<int>
    {
        public Color Color { get; set; } = Color.White;
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
    }
}
