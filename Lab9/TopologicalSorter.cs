using System;
using System.Collections.Generic;
using System.Linq;
using CodeChallenge.Core;

namespace Lab9
{
    public class TopologicalGraph : Graph
    {
        private readonly Stack<int> _route = new Stack<int>();

        public TopologicalGraph(int vertexCount, IReadOnlyList<HashSet<int>> edges)
            : base(vertexCount, edges) { }

        public void Dfs(int v)
        {
            _vertexes[v].Color = Color.Gray;

            foreach (var edgeDist in _vertexes[v])
            {
                if (_vertexes[edgeDist].NotVisited)
                {
                    Dfs(edgeDist);
                }
                else if (_vertexes[edgeDist].Color == Color.Gray)
                {
                    Console.WriteLine(-1);
                    Environment.Exit(0);
                }
            }

            _vertexes[v].Color = Color.Black;
            _route.Push(v + 1);
        }

        public string GetRoute()
            => string.Join(" ", _route.ToArray());
    }

    public class TopologicalSorter : ConsoleTask
    {
        public override void Execute()
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
            }

            var graph = new TopologicalGraph(vertexesCount, edges);

            for (int i = 0; i < vertexesCount; i++)
            {
                if (graph[i].NotVisited)
                    graph.Dfs(i);
            }

            WriteLine(graph.GetRoute());
        }
    }
}
