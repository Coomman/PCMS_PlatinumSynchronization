using System;
using System.Collections.Generic;

namespace Lab9
{
    public class BipartiteGraph : Graph
    {
        public BipartiteGraph(int vertexCount, IReadOnlyList<HashSet<int>> edges) 
            : base(vertexCount, edges) { }

        public void Dfs(int v, PartColor partColor)
        {
            _vertexes[v].Color = Color.Black;
            _vertexes[v].PartColor = partColor;

            foreach (var edgeDist in _vertexes[v])
            {
                if (_vertexes[edgeDist].NotVisited)
                {
                    Dfs(edgeDist, partColor == PartColor.Blue ? PartColor.Red : PartColor.Blue);
                }

                if (_vertexes[edgeDist].PartColor == partColor)
                {
                    Console.WriteLine("NO");
                    
                    Environment.Exit(0);
                }
            }
        }
    }

    public class Bipartite : GraphTask
    {
        public override void Execute()
        {
            var numbers = ReadIntArray();
            
            var graph = ReadGraph<BipartiteGraph>(numbers[0], numbers[1], true);

            for (int i = 0; i < graph.VertexesCount; i++)
            {
                if (graph[i].NotVisited)
                {
                    graph.Dfs(i, PartColor.Blue);   
                }
            }
            
            Console.WriteLine("YES");
        }
    }
}