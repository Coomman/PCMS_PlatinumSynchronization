using CodeChallenge.Core;

namespace Lab8
{
    public class EdgesToMatrix : FileTask
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
            _adjMatrix.FillDirect(edges);

            for (int i = 0; i < vertexCount; i++)
            {
                for(int j = 0; j < vertexCount; j++)
                    Write($"{(_adjMatrix[i, j] ? 1 : 0)} ");
                
                WriteLine();
            }
        }
    }
}
