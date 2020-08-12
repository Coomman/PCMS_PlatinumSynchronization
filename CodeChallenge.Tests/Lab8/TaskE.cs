using Lab8;
using NUnit.Framework;
using FluentAssertions;

namespace CodeChallenge.Tests.Lab8
{
    internal class TaskE : ITestClass
    {
        private Graph _graph;

        [Test]
        public void ExampleTest()
        {
            const int vertexCount = 2;

            (int from, int to)[] edges =
            {
                (1, 0)
            };

            _graph = new Graph(vertexCount, Extensions.GetEdgeList(vertexCount, edges));

            _graph.Bfs(0);

            _graph.GetVertexesInfo().Should().BeEquivalentTo("0 1");
        }
    }
}
