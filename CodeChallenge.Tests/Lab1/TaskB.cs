using Lab1;
using NUnit.Framework;
using FluentAssertions;

namespace CodeChallenge.Tests.Lab1
{
    internal class TaskB : ITestClass
    {
        private readonly AplusBB _task = new AplusBB();

        [Test]
        public void ExampleTest()
        {
            _task.Compute(23, 11).Should().Be(144);
            _task.Compute(-100, 1).Should().Be(-99);
        }
    }
}
