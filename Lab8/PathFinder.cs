using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;

using CodeChallenge.Core;

namespace Lab8
{
    public class Vertex : IEnumerable<int>
    {
        public int Value = -1;
        private readonly HashSet<int> _edges;

        public Vertex(HashSet<int> edges)
        {
            _edges = edges;
        }

        public bool NotVisited => Value == -1;

        public IEnumerator<int> GetEnumerator()
        {
            return _edges.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class Graph
    {
        private readonly Vertex[] _vertexes;

        private ConcurrentBag<int> _currentLayer = new ConcurrentBag<int>();
        private ConcurrentBag<int> _nextLayer = new ConcurrentBag<int>();

        private int _depth;

        public Graph(int vertexCount, IReadOnlyList<HashSet<int>> edges)
        {
            _vertexes = new Vertex[vertexCount];

            for (int i = 0; i < vertexCount; i++)
                _vertexes[i] = new Vertex(edges[i]);
        }

        private void BfsRoutine(Vertex cur)
        {
            cur
                .AsParallel()
                .Where(edgeDest => _vertexes[edgeDest].NotVisited)
                .ForAll(v =>
                {
                    lock (_vertexes[v])
                        if (_vertexes[v].NotVisited)
                        {
                            _vertexes[v].Value = _depth + 1;
                            _nextLayer.Add(v);
                        }
                });
        }
        public void Bfs(int start)
        {
            _vertexes[start].Value = 0;
            _currentLayer.Add(start);

            _depth = 0;
            while (_currentLayer.Any())
            {
                _currentLayer
                    .AsParallel()
                    .ForAll(v => BfsRoutine(_vertexes[v]));

                _currentLayer = _nextLayer;
                _nextLayer = new ConcurrentBag<int>();

                _depth++;
            }
        }

        public string GetVertexesInfo()
            => string.Join(" ", _vertexes.Select(v => v.Value));
    }

    public class PathFinder : ConsoleTask
    {
        public override void Execute()
        {
            var numbers = ReadIntArray();

            var vertexCount = numbers[0];
            var edgesCount = numbers[1];

            var edges = Enumerable.Repeat(0, vertexCount)
                .Select(edge => new HashSet<int>()).ToArray();

            for (int i = 0; i < edgesCount; i++)
            {
                var edge = ReadLine().TrimEnd().Split()
                    .Select(v => int.Parse(v) - 1).ToArray();

                if (edge[0] == edge[1])
                    continue;

                edges[edge[0]].Add(edge[1]);
                edges[edge[1]].Add(edge[0]);
            }

            var graph = new Graph(vertexCount, edges);

            graph.Bfs(0);
            WriteLine(graph.GetVertexesInfo());
        }
    }
}
