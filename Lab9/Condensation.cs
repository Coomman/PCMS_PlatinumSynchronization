using System.Collections.Generic;
using System.Linq;

namespace Lab9
{
    public class CondensedGraph : Graph
    {
        private List<int>[] _invertedEdges;
        
        public readonly List<int> Order = new List<int>();

        public CondensedGraph(int vertexCount, IReadOnlyList<HashSet<int>> edges) 
            : base(vertexCount, edges) { }
        
        public void FillInvertedEdges()
        {
            _invertedEdges = Enumerable.Repeat(0, VertexesCount)
                .Select(_ => new List<int>())
                .ToArray();
            
            for (int v = 0; v < VertexesCount; v++)
            {
                foreach (var edgeDest in _vertexes[v])
                {
                    _invertedEdges[edgeDest].Add(v);
                }
            }
        }

        public void DfsStraight(int v)
        {
            _vertexes[v].Color = Color.Gray;

            foreach (var edgeDest in _vertexes[v])
            {
                if (_vertexes[edgeDest].NotVisited)
                {
                    DfsStraight(edgeDest);
                }
            }
            
            Order.Add(v);
            _vertexes[v].Color = Color.Black;
        }

        public void DfsInverted(int v, int compNum)
        {
            _vertexes[v].LocalIndex = compNum;

            foreach (var edgeDest in _invertedEdges[v])
            {
                if (_vertexes[edgeDest].LocalIndex == 0)
                {
                    DfsInverted(edgeDest, compNum);
                }
            }
        }
    }

    public class Condensation : GraphTask
    {
        public override void Execute()
        {
            var graph = ReadGraph<CondensedGraph>();
            graph.FillInvertedEdges();

            for (int i = 0; i < graph.VertexesCount; i++)
            {
                if (graph[i].NotVisited)
                {
                    graph.DfsStraight(i);
                }
            }
            
            graph.Order.Reverse();

            int compNum = 0;
            foreach (var v in graph.Order)
            {
                if (graph[v].LocalIndex == 0)
                {
                    graph.DfsInverted(v, ++compNum);
                }
            }
            
            WriteLine(compNum);
            WriteLine(string.Join(" ", graph.Select(v => v.LocalIndex)));
        }
    }
}