using Lab1;
using NUnit.Framework;
using FluentAssertions;

namespace CodeChallenge.Tests.Lab1
{
    internal class TaskA : ITestClass
    {
        private readonly AplusB _task = new AplusB();

        [Test]
        public void ExampleTest()
        {
            _task.Add(23, 11).Should().Be(34);
            _task.Add(-100, 1).Should().Be(-99);
        }
    }
}
