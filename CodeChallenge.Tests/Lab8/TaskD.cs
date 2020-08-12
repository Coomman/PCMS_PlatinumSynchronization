using Lab8;
using NUnit.Framework;
using FluentAssertions;

namespace CodeChallenge.Tests.Lab8
{
    internal class TaskD : ITestClass
    {
        private ComponentGraph _graph;

        [Test]
        public void ExampleTest()
        {
            const int vertexCount = 3;

            (int from, int to)[] edges =
            {
                (0, 1)
            };

            _graph = new ComponentGraph(vertexCount, Extensions.GetEdgeList(vertexCount, edges));

            for (int i = 0; i < vertexCount; i++)
                if (_graph[i] == 0)
                    _graph.Bfs(i);

            _graph.ComponentCount.Should().Be(2);
            _graph.GetVertexesInfo().Should().BeEquivalentTo("1 1 2");
        }

        [Test]
        public void ExampleTest2()
        {
            const int vertexCount = 4;

            (int from, int to)[] edges =
            {
                (0, 2),
                (1, 3)
            };

            _graph = new ComponentGraph(vertexCount, Extensions.GetEdgeList(vertexCount, edges));

            for (int i = 0; i < vertexCount; i++)
                if (_graph[i] == 0)
                    _graph.Bfs(i);

            _graph.ComponentCount.Should().Be(2);
            _graph.GetVertexesInfo().Should().BeEquivalentTo("1 2 1 2");
        }
    }
}
