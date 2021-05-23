using CodeChallenge.Core;

namespace Lab8
{
    public class IndirectCheck : FileTask
    {
        private AdjMatrix _adjMatrix;

        public override void Execute()
        {
            int vertexCount = ReadInt();

            _adjMatrix = new AdjMatrix(vertexCount);

            for (int i = 0; i < vertexCount; i++)
            {
                var numbers = ReadIntArray();

                for (int j = 0; j < vertexCount; j++)
                    _adjMatrix[i, j] = numbers[j] == 1;
            }

            WriteLine(_adjMatrix.IsIndirect() ? "YES" : "NO");
        }
    }
}
