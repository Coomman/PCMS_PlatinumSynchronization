using System;
using System.Collections.Generic;

namespace Lab9
{
    public class CycleGraph : Graph
    {
        private readonly Stack<int> _route = new Stack<int>();

        public CycleGraph(int vertexCount, IReadOnlyList<HashSet<int>> edges) 
            : base(vertexCount, edges) { }

        public void Dfs(int v)
        {
            _vertexes[v].Color = Color.Gray;
            _route.Push(v + 1);

            foreach (var edgeDist in _vertexes[v])
            {
                if (_vertexes[edgeDist].NotVisited)
                {
                    Dfs(edgeDist);
                }
                else if (_vertexes[edgeDist].Color == Color.Gray)
                {
                    ShowCycle(edgeDist + 1);

                    Environment.Exit(0);
                }
            }

            _vertexes[v].Color = Color.Black;
            _route.Pop();
        }

        private void ShowCycle(int cycleStart)
        {
            var cycle = new Stack<int>();

            while (_route.Peek() != cycleStart)
            {
                cycle.Push(_route.Pop());
            }
            
            cycle.Push(cycleStart);

            Console.WriteLine("YES");
            Console.WriteLine(string.Join(" ", cycle));
        }
    }

    class CycleResearcher : GraphTask
    {
        public override void Execute()
        {
            var graph = ReadGraph<CycleGraph>();

            for (int i = 0; i < graph.VertexesCount; i++)
            {
                if (graph[i].NotVisited)
                {
                    graph.Dfs(i);   
                }
            }

            WriteLine("NO");
        }
    }
}
