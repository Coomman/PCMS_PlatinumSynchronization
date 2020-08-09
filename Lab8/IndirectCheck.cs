using System.IO;
using System.Linq;
using CodeChallenge.Core;

namespace Lab8
{
    public class IndirectCheck : IFileTask
    {
        private AdjMatrix _adjMatrix;

        public void ExecuteFile(StreamReader sr, StreamWriter sw)
        {
            int vertexCount = int.Parse(sr.ReadLine());

            _adjMatrix = new AdjMatrix(vertexCount);

            for (int i = 0; i < vertexCount; i++)
            {
                var query = sr.ReadLine().TrimEnd().Split().Select(int.Parse).ToList();

                for (int j = 0; j < vertexCount; j++)
                    _adjMatrix[i, j] = query[j] == 1;
            }

            sw.WriteLine(_adjMatrix.IsIndirect() ? "YES" : "NO");
        }
    }
}
