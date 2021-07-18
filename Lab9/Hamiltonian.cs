using System;
using System.Collections.Generic;

namespace Lab9
{
    public class HamiltonianGraph : Graph
    {
        public HamiltonianGraph(int vertexCount, IReadOnlyList<HashSet<int>> edges) 
            : base(vertexCount, edges) { }

        public int Dfs(int v)
        {
            _vertexes[v].Color = Color.Black;

            foreach (var edgeDest in _vertexes[v])
            {
                if (_vertexes[edgeDest].NotVisited)
                {
                    _vertexes[edgeDest].LocalIndex = Dfs(edgeDest);
                }

                _vertexes[v].LocalIndex = Math.Max(_vertexes[edgeDest].LocalIndex, _vertexes[v].LocalIndex);
            }

            return ++_vertexes[v].LocalIndex;
        }
    }
    
    public class Hamiltonian : GraphTask
    {
        public override void Execute()
        {
            var numbers = ReadIntArray();
            
            var graph = ReadGraph<HamiltonianGraph>(numbers[0], numbers[1]);

            for (int i = 0; i < graph.VertexesCount; i++)
            {
                if (graph[i].NotVisited)
                {
                    graph[i].LocalIndex = graph.Dfs(i);

                    if (graph[i].LocalIndex == graph.VertexesCount)
                    {
                        WriteLine("YES");
                        
                        Environment.Exit(0);
                    }
                }
            }
            
            WriteLine("NO");
        }
    }
}