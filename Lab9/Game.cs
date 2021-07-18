using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab9
{
    public class GameGraph : Graph
    {
        public GameGraph(int vertexCount, IReadOnlyList<HashSet<int>> edges)
            : base(vertexCount, edges) { }

        public int StartVertex;
        
        private int _stepsToFinish = int.MaxValue;
        private bool _firstPlayerWins;

        public void Dfs(int v, int steps)
        {
            if (_vertexes[v].Any())
            {
                if (steps < _stepsToFinish)
                {
                    foreach (var edgeDest in _vertexes[v])
                    {
                        Dfs(edgeDest, steps + 1);
                        
                        if (_firstPlayerWins)
                        {
                            if (v == StartVertex)
                            {
                                Console.WriteLine("First player wins");
                                
                                Environment.Exit(0);
                            }

                            if (steps % 2 == 0)
                                return;
                        }
                    }
                }
            }
            else
            {
                if (steps < _stepsToFinish)
                {
                    _stepsToFinish = steps;
                }

                _firstPlayerWins = steps % 2 == 1;
            }
        }
    }

    public class Game : GraphTask
    {
        public override void Execute()
        {
            var numbers = ReadIntArray();

            var graph = ReadGraph<GameGraph>(numbers[0], numbers[1]);
            graph.StartVertex = numbers[2] - 1;
            
            graph.Dfs(graph.StartVertex, 0);

            WriteLine("Second player wins");
        }
    }
}