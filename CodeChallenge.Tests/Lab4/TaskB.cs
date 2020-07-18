using Lab4;
using NUnit.Framework;
using FluentAssertions;

namespace CodeChallenge.Tests.Lab4
{
    internal class TaskB : ITestClass
    {
        private Queue<int> _queue;

        [SetUp]
        public void SetUp()
        {
            _queue = new Queue<int>();
        }

        [Test]
        public void ExampleTest()
        {
            _queue.Push(1);
            _queue.Push(10);

            _queue.Pop().Should().Be(1);
            _queue.Pop().Should().Be(10);
        }
    }
}
