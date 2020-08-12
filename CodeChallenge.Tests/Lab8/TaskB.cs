using Lab8;
using NUnit.Framework;
using FluentAssertions;

namespace CodeChallenge.Tests.Lab8
{
    internal class TaskB : ITestClass
    {
        private AdjMatrix _adjMatrix;

        [Test]
        public void ExampleTest()
        {
            _adjMatrix = new AdjMatrix(3);

            int[,] matrix =
            {
                {0, 1, 1},
                {1, 0, 1},
                {1, 1, 0}
            };

            _adjMatrix.Fill(matrix);

            _adjMatrix.IsIndirect().Should().BeTrue();
        }

        [Test]
        public void ExampleTest2()
        {
            _adjMatrix = new AdjMatrix(3);

            int[,] matrix =
            {
                {0, 1, 0},
                {1, 0, 1},
                {1, 1, 0}
            };

            _adjMatrix.Fill(matrix);

            _adjMatrix.IsIndirect().Should().BeFalse();
        }

        [Test]
        public void ExampleTest3()
        {
            _adjMatrix = new AdjMatrix(3);

            int[,] matrix =
            {
                {0, 1, 0},
                {1, 1, 1},
                {0, 1, 0}
            };

            _adjMatrix.Fill(matrix);

            _adjMatrix.IsIndirect().Should().BeFalse();
        }
    }
}
