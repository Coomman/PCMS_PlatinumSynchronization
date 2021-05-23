using CodeChallenge.Core;

namespace Lab8
{
    public class ParallelEdgesCheck : FileTask
    {
        private AdjMatrix _adjMatrix;

        public override void Execute()
        {
            var numbers = ReadIntArray();

            var vertexCount = numbers[0];
            var edgesCount = numbers[1];

            var edges = new (int from, int to)[edgesCount];
            for (int i = 0; i < edgesCount; i++)
            {
                numbers = ReadIntArray();
                edges[i] = (numbers[0] - 1, numbers[1] - 1);
            }

            _adjMatrix = new AdjMatrix(vertexCount);

            WriteLine(_adjMatrix.FillIndirect(edges) ? "YES" : "NO");
        }
    }
}
