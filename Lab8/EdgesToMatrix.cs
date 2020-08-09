using System.IO;
using CodeChallenge.Core;

namespace Lab8
{
    public class EdgesToMatrix : IFileTask
    {
        private AdjMatrix _adjMatrix;

        public void ExecuteFile(StreamReader sr, StreamWriter sw)
        {
            var query = sr.ReadLine().Split();

            var vertexCount = int.Parse(query[0]);
            var edgesCount = int.Parse(query[1]);

            var edges = new (int from, int to)[edgesCount];
            for (int i = 0; i < edgesCount; i++)
            {
                query = sr.ReadLine().Split();
                edges[i] = (int.Parse(query[0]) - 1, int.Parse(query[1]) - 1);
            }

            _adjMatrix = new AdjMatrix(vertexCount);
            _adjMatrix.FillDirect(edges);

            for (int i = 0; i < vertexCount; i++)
            {
                for(int j = 0; j < vertexCount; j++)
                    sw.Write($"{(_adjMatrix[i, j] ? 1 : 0)} ");
                
                sw.WriteLine();
            }
        }
    }
}
