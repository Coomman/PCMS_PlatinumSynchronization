using Lab1;
using NUnit.Framework;
using FluentAssertions;

namespace CodeChallenge.Tests.Lab1
{
    internal class TaskC : ITestClass
    {
        private Turtle _task;

        [Test]
        public void ExampleTest()
        {
            var field = new[,]
            {
                {0, 1, 2},
                {3, 6, 4},
                {2, 5, 1}
            };

            _task = new Turtle(field, 3, 3);
            _task.FindBestPath(0, 2);

            _task.MaxValue.Should().Be(19);
        }

        [Test]
        public void ExampleTest2()
        {
            var field = new[,]
            {
                {1, 0, 1},
                {1, 1, 1}
            };

            _task = new Turtle(field, 2, 3);
            _task.FindBestPath(0, 2);

            _task.MaxValue.Should().Be(4);
        }
    }
}
