using Lab4;
using NUnit.Framework;
using FluentAssertions;

namespace CodeChallenge.Tests.Lab4
{
    internal class TaskA : ITestClass
    {
        private Stack<int> _stack;

        [SetUp]
        public void SetUp()
        {
            _stack = new Stack<int>();
        }

        [Test]
        public void ExampleTest()
        {
            _stack.Push(1);
            _stack.Push(10);

            _stack.Pop().Should().Be(10);

            _stack.Push(2);
            _stack.Push(1234);

            _stack.Pop().Should().Be(1234);
        }
    }
}
