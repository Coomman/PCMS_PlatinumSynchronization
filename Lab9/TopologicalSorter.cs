﻿using System;
using System.Collections.Generic;

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
            => string.Join(" ", _route);
    }

    public class TopologicalSorter : GraphTask
    {
        public override void Execute()
        {
            var numbers = ReadIntArray();
            
            var graph = ReadGraph<TopologicalGraph>(numbers[0], numbers[1]);

            for (int i = 0; i < graph.VertexesCount; i++)
            {
                if (graph[i].NotVisited)
                    graph.Dfs(i);
            }

            WriteLine(graph.GetRoute());
        }
    }
}
