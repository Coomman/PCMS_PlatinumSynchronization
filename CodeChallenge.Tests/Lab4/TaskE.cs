using System;
using Lab4;
using NUnit.Framework;
using FluentAssertions;

namespace CodeChallenge.Tests.Lab4
{
    internal class TaskE : ITestClass
    {
        private PriorityQueue<int> _queue;

        [SetUp]
        public void SetUp()
        {
            _queue = new PriorityQueue<int>();
        }

        [Test]
        public void ExampleTest()
        {
            _queue.Push(3, 1);
            _queue.Push(4, 2);
            _queue.Push(2, 3);

            _queue.ExtractMin().Should().Be(2);

            _queue.DecreaseKey(2, 1);

            _queue.ExtractMin().Should().Be(1);
            _queue.ExtractMin().Should().Be(3);

            Assert.Throws<InvalidOperationException>(() => _queue.ExtractMin());
        }
    }
}
