using System.IO;
using System.Linq;
using System.Collections.Generic;

using CodeChallenge.Core;

namespace Lab8
{
    public class ComponentGraph
    {
        private readonly int[] _vertexes;
        private readonly HashSet<int>[] _edges;

        public int ComponentCount { get; private set; }

        public ComponentGraph(int vertexCount, HashSet<int>[] edges)
        {
            _vertexes = new int[vertexCount];
            _edges = edges;
        }

        public int this[int vertexNum] => _vertexes[vertexNum];

        public void Bfs(int start)
        {
            var queue = new Queue<int>();
            queue.Enqueue(start);

            ComponentCount++;

            while (queue.Any())
            {
                var v = queue.Dequeue();
                _vertexes[v] = ComponentCount;

                foreach (var vertex in _edges[v].Where(edgeDest => _vertexes[edgeDest] == 0))
                    queue.Enqueue(vertex);
            }
        }

        public string GetVertexesInfo()
            => string.Join(" ", _vertexes);
    }

    public class Components : IFileTask
    {
        public void ExecuteFile(StreamReader sr, StreamWriter sw)
        {
            var query = sr.ReadLine().Split();

            var vertexCount = int.Parse(query[0]);
            var edgesCount = int.Parse(query[1]);

            var edges = Enumerable.Repeat(0, vertexCount)
                .Select(edge => new HashSet<int>()).ToArray();

            for (int i = 0; i < edgesCount; i++)
            {
                var edge = sr.ReadLine().TrimEnd().Split()
                    .Select(v => int.Parse(v) - 1).ToArray();

                if(edge[0] == edge[1])
                    continue;

                edges[edge[0]].Add(edge[1]);
                edges[edge[1]].Add(edge[0]);
            }

            var graph = new ComponentGraph(vertexCount, edges);

            for(int i = 0; i < vertexCount; i++)
                if(graph[i] == 0)
                    graph.Bfs(i);

            sw.WriteLine(graph.ComponentCount);
            sw.WriteLine(graph.GetVertexesInfo());
        }
    }
}
