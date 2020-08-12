using Lab8;
using NUnit.Framework;
using FluentAssertions;

namespace CodeChallenge.Tests.Lab8
{
    internal class TaskA : ITestClass
    {
        private AdjMatrix _adjMatrix;

        [Test]
        public void ExampleTest()
        {
            _adjMatrix = new AdjMatrix(3);

            (int from, int to)[] edges =
            {
                (0, 1),
                (1, 2),
                (2, 0),
                (2, 1)
            };

            _adjMatrix.FillDirect(edges);

            _adjMatrix[0, 0].Should().Be(false);
            _adjMatrix[0, 1].Should().Be(true);
            _adjMatrix[0, 2].Should().Be(false);
            _adjMatrix[1, 0].Should().Be(false);
            _adjMatrix[1, 1].Should().Be(false);
            _adjMatrix[1, 2].Should().Be(true);
            _adjMatrix[2, 0].Should().Be(true);
            _adjMatrix[2, 1].Should().Be(true);
            _adjMatrix[2, 2].Should().Be(false);
        }
    }
}
