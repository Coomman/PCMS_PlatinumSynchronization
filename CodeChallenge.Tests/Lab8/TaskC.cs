using Lab8;
using NUnit.Framework;
using FluentAssertions;

namespace CodeChallenge.Tests.Lab8
{
    public class TaskC : ITestClass
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
                (0, 2)
            };

            _adjMatrix.FillIndirect(edges).Should().BeFalse();
        }

        [Test]
        public void ExampleTest2()
        {
            _adjMatrix = new AdjMatrix(3);

            (int from, int to)[] edges =
            {
                (0, 1),
                (1, 2),
                (1, 0)
            };

            _adjMatrix.FillIndirect(edges).Should().BeTrue();
        }
    }
}
