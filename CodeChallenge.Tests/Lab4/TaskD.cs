using Lab4;
using NUnit.Framework;
using FluentAssertions;

namespace CodeChallenge.Tests.Lab4
{
    internal class TaskD : ITestClass
    {
        private PolishNotationController _task;

        [SetUp]
        public void SetUp()
        {
            _task = new PolishNotationController();
        }

        [Test]
        public void ExampleTest()
        {
            _task.PushNum(8);
            _task.PushNum(9);
            _task.Add();
            _task.PushNum(1);
            _task.PushNum(7);
            _task.Subtract();
            _task.Multiply();

            _task.GetAnswer().Should().Be(-102);
        }
    }
}
